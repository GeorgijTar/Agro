﻿using System;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.CheckingCounterparty;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Personnel;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.Warehouse;
using Agro.DAL.Entities.Weight;
using Agro.DAL.MySql;
using Agro.DAL.Sql;
using Agro.DAL.SqLite;
using Agro.Interfaces.Base.Repositories;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.Services.Repositories;
using Agro.WPF.ViewModels;
using Agro.WPF.ViewModels.Accounting;
using Agro.WPF.ViewModels.Agronomy;
using Agro.WPF.ViewModels.Auxiliary_windows;
using Agro.WPF.ViewModels.Contract;
using Agro.WPF.ViewModels.InvoiceVM;
using Agro.WPF.ViewModels.Organization;
using Agro.WPF.ViewModels.Personnel;
using Agro.WPF.ViewModels.Storage;
using Agro.WPF.ViewModels.TMC;
using Agro.WPF.ViewModels.Weight;
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
        public User CurrentUser { get;  set; }
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
            
            //Регистрация вью-моделей
            services.AddTransient<LoginViewModel>();
            services.AddScoped<ContractorsViewModel>();
            services.AddTransient<CounterpartyViewModel>();
            services.AddTransient<BankDetailsViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddScoped<MainWindowViewModel>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<AccountingPlansViewModel>();
            services.AddTransient<AccountingPlanViewModel>();
            services.AddTransient<InvoicesViewModel>();
            services.AddTransient<InvoiceViewModel>();
            services.AddTransient<OrganizationViewModel>();
            services.AddTransient<ProductInvoiceViewModel>();
            services.AddScoped<DepartmentsViewModel>();
            services.AddTransient<DepartmentViewModel>();
            services.AddScoped<CulturesViewModel>();
            services.AddTransient<CultureViewModel>();
            services.AddScoped<LandPlotsViewModel>();
            services.AddTransient<LandPlotViewModel>();
            services.AddScoped<FieldsViewModel>();
            services.AddTransient<FieldViewModel>();
            services.AddScoped<TransportsViewModel>();
            services.AddTransient<TransportViewModel>();
            services.AddScoped<DriversViewModel>();
            services.AddTransient<DriverViewModel>();
            services.AddTransient<PeopleViewModel>();
            services.AddScoped<PeoplsViewModel>();
            services.AddTransient<DocumentViewModel>();
            services.AddTransient<EmployeeViewModel>();
            services.AddScoped<EmployeesViewModel>();
            services.AddTransient<PostViewModel>();
            services.AddScoped<PostsViewModel>();
            services.AddScoped<StaffListsViewModel>();
            services.AddTransient<StaffListViewModel>();
            services.AddTransient<StaffListPositionViewModel>();
            services.AddScoped<DivisionsViewModel>();
            services.AddTransient<DivisionViewModel>();
            services.AddTransient<StafListSprViewModel>();
            services.AddScoped<WeightsViewModel>();
            services.AddTransient<WeightViewModel>();
            services.AddScoped<ComingFieldsViewModel>();
            services.AddTransient<ComingFieldViewModel>();
            services.AddScoped<StorageLocationsViewModel>();
            services.AddTransient<StorageLocationViewModel>();
            services.AddTransient<OfficialPersonViewModel>();
            services.AddScoped<TmCsViewModel>();
            services.AddTransient<TmcViewModel>();
            services.AddTransient<RulesAccountingViewModel>();
            services.AddTransient<ContractsViewModel>();
            services.AddTransient<ContractViewModel>();
            services.AddTransient<SpecificationContractViewModel>();
            services.AddTransient<TypeViewModel>();
            services.AddTransient<GroupViewModel>();
            services.AddTransient<RegistryInvoiceViewModel>();
            services.AddTransient<RegistryInvoicesViewModel>();


            //Регистрация репозиториев
            services.AddScoped(typeof(IBaseRepository<>), typeof(DbRepository<>));
            services.AddTransient<IInvoiceRepository<Invoice>, InvoiceRepository>();
            services.AddTransient<IBaseRepository<Product>, ProductRepository>();
            services.AddTransient<IBaseRepository<Organization>, OrganizationRepository>();
            services.AddTransient<IBaseRepository<Department>, DepartmentRepository>();
            services.AddTransient<IBaseRepository<Culture>, CultureRepository>();
            services.AddTransient<IBaseRepository<Field>, FieldRepository>();
            services.AddTransient<IBaseRepository<Driver>, DriverRepository>();
            services.AddTransient<IBaseRepository<People>, PeopleRepository>();
            services.AddTransient<IBaseRepository<Employee>, EmployeeRepository>();
            services.AddTransient<IBaseRepository<StaffList>, StaffListRepository>();
            services.AddTransient<IBaseRepository<StaffListPosition>, StaffListPositionRepository>();
            services.AddTransient<IBaseRepository<StorageLocation>, StorageLocationRepository>();
            services.AddScoped(typeof(IComingFieldRepository<ComingField>), typeof(ComingFieldRepository));
            services.AddTransient<IBaseRepository<Tmc>, TmcRepository>();
            services.AddTransient<IBaseRepository<Counterparty>, CounterpartyRepository>();
            services.AddTransient<IContractRepository<Contract>, ContractRepository>();
            services.AddScoped(typeof(ICheckCounterpartyRepository<CheckCounterparty>), typeof(CheckCounterpartyRepository));
            services.AddScoped(typeof(IRegistryInvoiceRepository<RegistryInvoice>), typeof(RegistryInvoiceRepository));
            services.AddScoped(typeof(ILoginRepository<User>), typeof(LoginRepository));



            // Регистрация мапера
            //services.AddAutoMapper(
            //        typeof(CounterpartyProfile), 
            //        typeof(GroupProfile), 
            //        typeof(TypeProfile), 
            //        typeof(StatusProfile),
            //        typeof(BankDetailsProfile),
            //        typeof(ProductProfile),
            //        typeof(UnitProfile),
            //        typeof(NdsProfile),
            //        typeof(AccountingPlanProfile),
            //        typeof(InvoiceProfile)) // маппинг-профайлы передавать через запятую typeof(AppMappingProfile), typeof(MappingProfile2)
            //    .AddScoped(typeof(IMapper<>), typeof(AutoMapperService<>))
            //    .AddScoped(typeof(IMapper<,>), typeof(AutoMapperService<,>));
        }
    }
}
