using System;
using Agro.DAL.Sql;
using Agro.DAL.SqLite;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Agro.Services.Repositories;
using Agro.WPF.Infrastructure.AutoMapper;
using Agro.WPF.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Agro.WPF
{
    public partial class App
    {
        private static IHost? _hosting;
        public static IHost Hosting => _hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] args) => 
            Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(opt => opt.AddJsonFile(
                "appsettings.json", false, true)).ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            var configuration = host.Configuration;
            var dbType = configuration["Database"];

            switch (dbType)
            {
                default: throw new InvalidOperationException($"Тип БД {dbType} не поддерживается");

                case "Sqlite":
                    services.AddAgroDbSqlite(configuration.GetConnectionString("Sqlite"));
                    break;

                case "SqlServer":
                    services.AddAgroDbSqlServer(configuration.GetConnectionString("SqlServer"));
                    break;
                case "MySql":
                    services.AddAgroDbMySql(configuration.GetConnectionString("MySql"));
                    break;
            }

            services.AddScoped<ContractorsViewModel>();
            services.AddScoped<CounterpartyViewModel>();

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

            services.AddScoped(typeof(IGroupRepository<GroupDto>), typeof(GroupRepository));

            services.AddScoped(typeof(ITypeRepository<TypeDocDto>), typeof(TypeRepository));

            services.AddScoped(typeof(ICounterpertyRepository<CounterpartyDto>), typeof(CounterpartyRepository));
           
            services.AddAutoMapper(
                    typeof(CounterpartyProfile), 
                    typeof(GroupProfile), 
                    typeof(TypeProfile), 
                    typeof(StatusProfile),
                    typeof(BankDetailsProfile)) // маппинг-профайлы перпедавать через запятую typeof(AppMappingProfile), typeof(MappingProfile2)
                .AddScoped(typeof(IMapper<>), typeof(AutoMapperService<>))
                .AddScoped(typeof(IMapper<,>), typeof(AutoMapperService<,>));
        }
    }
}
