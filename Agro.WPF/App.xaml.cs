using System;
using System.Collections.Generic;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.Bank.Base;
using Agro.DAL.Entities.Bank.Pay;
using Agro.DAL.Entities.CheckingCounterparty;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Personnel;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.Warehouse;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.DAL.Entities.Weight;
using Agro.DAL.MySql;
using Agro.Interfaces.Base.Repositories;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.Services.Repositories;
using Agro.Services.Repositories.Bank;
using Agro.Services.Repositories.References;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels;
using Agro.WPF.ViewModels.Accounting;
using Agro.WPF.ViewModels.Agronomy;
using Agro.WPF.ViewModels.Auxiliary_windows;
using Agro.WPF.ViewModels.Bank.BaseViewModel;
using Agro.WPF.ViewModels.Bank.Pay;
using Agro.WPF.ViewModels.Coming;
using Agro.WPF.ViewModels.Contract;
using Agro.WPF.ViewModels.Decommissioning;
using Agro.WPF.ViewModels.InvoiceVM;
using Agro.WPF.ViewModels.Organization;
using Agro.WPF.ViewModels.Personnel;
using Agro.WPF.ViewModels.Storage;
using Agro.WPF.ViewModels.TMC;
using Agro.WPF.ViewModels.UserSettings;
using Agro.WPF.ViewModels.Weight;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notification.Wpf;

namespace Agro.WPF
{
    public partial class App
    {
        private static IHost? _hosting;
        public static IHost Hosting => _hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => Hosting.Services;

        /// <summary> Глобальные переменные </summary>
        public User? CurrentUser { get;  set; }

        /// <summary> Глобальные статические справочники </summary>
        public IEnumerable<TypeDoc>? Types { get; set; }
        public IEnumerable<Status>? Status { get; set; }
        public IEnumerable<GroupDoc>? Groups { get; set; }
        public IEnumerable<TypeOperationPay> ? TypeOperation { get; set; }
        public IEnumerable<BankDetails>? BankDetailsOrg { get; set; }
        public Organization? Organization { get; set; }
        public IEnumerable<TypePayment>? TypePayments { get; set; }
        public IEnumerable<Nds>? Nds { get; set; }
        public IEnumerable<BasisPayment>? BasisPayments { get; set; }
        public IEnumerable<PayerStatus>? PayerStatus { get; set; }
        public IEnumerable<OrderPayment>? OrderPayment { get; set; }
        public IEnumerable<TypeTransactions>? TypeTransactions { get; set; }
        public IEnumerable<StorageLocation>? StorageLocations { get; set; }
        public IEnumerable<AccountingPlan>? AccountingPlans { get; set; }
        public IEnumerable<Currency>? Currency { get; set; }
        public IEnumerable<AccountingMethodNds>? AccountingMethodNds { get; set; }
        public IEnumerable<TypeObject>? TypeObjects { get; set; }
        public IEnumerable<GroupObject>? GroupObjects { get; set; }



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

                case "MySql":
                    services.AddAgroDbMySql(configuration.GetConnectionString("MySql")!);
                    break;
            }
            //Регистрация сервиса уведомлений
            services.AddSingleton<INotificationManager, NotificationManager>();

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
            services.AddTransient<RegistryInvoiceSettingsViewModel>();
            services.AddTransient<ExpenditureItemsViewModel>();
            services.AddTransient<ExpenditureItemViewModel>();
            services.AddTransient<PaymentOrdersViewModel>();
            services.AddTransient<PaymentOrderViewModel>();
            services.AddTransient<ComingsTmcViewModel>();
            services.AddTransient<ComingTmcViewModel>();
            services.AddTransient<ComingTmcPositionViewModel>();
            services.AddTransient<ComingTmcCalculationsViewModel>();
            services.AddTransient<DecommissioningTmcsViewModel>();
            services.AddTransient<DecommissioningTmcViewModel>();
            services.AddTransient<PositionDecommissioningTmcViewModel>();
            services.AddTransient<TmcSprViewModel>();
            services.AddTransient<WriteOffObjectsViewModel>();
            services.AddTransient<WriteOffObjectViewModel>();
            services.AddTransient<TypeSubTypeGroupObjectViewModel>();
            services.AddTransient<PurposeExpenditureViewModel>();
            services.AddTransient<PurposeExpendituresViewModel>();
            services.AddTransient<MovementTmcViewModel>();


            //Регистрация репозиториев
            services.AddTransient(typeof(IBaseRepository<>), typeof(DbRepository<>));
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
            services.AddTransient(typeof(IComingFieldRepository<ComingField>), typeof(ComingFieldRepository));
            services.AddTransient<IBaseRepository<Tmc>, TmcRepository>();
            services.AddTransient<IBaseRepository<Counterparty>, CounterpartyRepository>();
            services.AddTransient<IContractRepository<Contract>, ContractRepository>();
            services.AddTransient(typeof(ICheckCounterpartyRepository<CheckCounterparty>), typeof(CheckCounterpartyRepository));
            services.AddTransient(typeof(IRegistryInvoiceRepository<RegistryInvoice>), typeof(RegistryInvoiceRepository));
            services.AddTransient(typeof(ILoginRepository<User>), typeof(LoginRepository));
            services.AddTransient(typeof(IExpenditureItemRepository<ExpenditureItem>), typeof(ExpenditureItemRepository));
            services.AddTransient(typeof(IPaymentOrderRepository<PaymentOrder>), typeof(PaymentOrderRepository));
            services.AddTransient<IReferencesRepository, ReferencesRepository>();
            services.AddTransient(typeof(IComingTmcRepository<ComingTmc>), typeof(ComingTmcRepository));
            services.AddTransient(typeof(IDecommissioningTmcRepository<DecommissioningTmc>),typeof(DecommissioningTmcRepository));
            services.AddTransient(typeof(ITmcSprRepository<Tmc>), typeof(TmcSprRepository));
            services.AddTransient<IBaseRepository<WriteOffObject>, WriteOffObjectRepository>();
            services.AddTransient<IBaseRepository<PurposeExpenditure>, PurposeExpenditureRepository>();

            // Регистрация навигатора
            services.AddTransient<IHelperNavigation, HelperNavigation>();
        }
    }
}
