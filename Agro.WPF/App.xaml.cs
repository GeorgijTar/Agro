using System;
using System.Windows;
using Agro.DAL.Entities;
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
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
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

            services.AddTransient<CounterpartyViewModel>();
            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            
            services
                .AddAutoMapper(
                    typeof(CounterpartyProfile)) // маппинг-профайлы перпедавать через запятую typeof(AppMappingProfile), typeof(MappingProfile2)
                .AddTransient(typeof(IMapper<>), typeof(AutoMapperService<>))
                .AddTransient(typeof(IMapper<,>), typeof(AutoMapperService<,>));
        }
    }
}
