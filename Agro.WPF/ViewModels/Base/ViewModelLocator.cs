using Agro.WPF.ViewModels.Accounting;
using Agro.WPF.ViewModels.Agronomy;
using Agro.WPF.ViewModels.Contract;
using Agro.WPF.ViewModels.Organization;
using Agro.WPF.ViewModels.Personnel;
using Agro.WPF.ViewModels.Storage;
using Agro.WPF.ViewModels.TMC;
using Agro.WPF.ViewModels.Weight;
using Microsoft.Extensions.DependencyInjection;

namespace Agro.WPF.ViewModels.Base;

public class ViewModelLocator
{
    public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();

    public ContractorsViewModel ContractorsModel => App.Services.GetRequiredService<ContractorsViewModel>();

    public CounterpartyViewModel CounterpartyModel => App.Services.GetRequiredService<CounterpartyViewModel>();

    public BankDetailsViewModel BankDetailsModel => App.Services.GetRequiredService<BankDetailsViewModel>();

    public ProductsViewModel ProductsModel => App.Services.GetRequiredService<ProductsViewModel>();

    public ProductViewModel ProductModel => App.Services.GetRequiredService<ProductViewModel>();

    public AccountingPlansViewModel AccountingPlansModel => App.Services.GetRequiredService<AccountingPlansViewModel>();

    public AccountingPlanViewModel AccountingPlanModel => App.Services.GetRequiredService<AccountingPlanViewModel>();

    public InvoicesViewModel InvoicesModel => App.Services.GetRequiredService<InvoicesViewModel>();

    public InvoiceViewModel InvoiceModel => App.Services.GetRequiredService<InvoiceViewModel>();

    public OrganizationViewModel OrganizationModel => App.Services.GetRequiredService<OrganizationViewModel>();

    public ProductInvoiceViewModel ProductInvoiceModel => App.Services.GetRequiredService<ProductInvoiceViewModel>();

    public ReestrInvoiceViewModel ReestrInvoiceModel => App.Services.GetRequiredService<ReestrInvoiceViewModel>();

    public ContractsViewModel ContractsModel => App.Services.GetRequiredService<ContractsViewModel>();

    public DepartmentsViewModel DepartmentsModel => App.Services.GetRequiredService<DepartmentsViewModel>();

    public DepartmentViewModel DepartmentModel => App.Services.GetRequiredService<DepartmentViewModel>();

    public CulturesViewModel CulturesModel => App.Services.GetRequiredService<CulturesViewModel>();

    public CultureViewModel CultureModel => App.Services.GetRequiredService<CultureViewModel>();

    public LandPlotsViewModel LandPlotsModel => App.Services.GetRequiredService<LandPlotsViewModel>();

    public LandPlotViewModel LandPlotModel => App.Services.GetRequiredService<LandPlotViewModel>();

    public FieldsViewModel FieldsModel => App.Services.GetRequiredService<FieldsViewModel>();

    public FieldViewModel FieldModel => App.Services.GetRequiredService<FieldViewModel>();

    public TransportsViewModel TransportsModel => App.Services.GetRequiredService<TransportsViewModel>();

    public TransportViewModel TransportModel => App.Services.GetRequiredService<TransportViewModel>();

    public DriversViewModel DriversModel => App.Services.GetRequiredService<DriversViewModel>();

    public DriverViewModel DriverModel => App.Services.GetRequiredService<DriverViewModel>();

    public PeopleViewModel PeopleModel => App.Services.GetRequiredService<PeopleViewModel>();

    public PeoplsViewModel PeoplsModel => App.Services.GetRequiredService<PeoplsViewModel>();

    public DocumentViewModel DocumentModel => App.Services.GetRequiredService<DocumentViewModel>();

    public EmployeeViewModel EmployeeModel => App.Services.GetRequiredService<EmployeeViewModel>();

    public EmployeesViewModel EmployeesModel => App.Services.GetRequiredService<EmployeesViewModel>();

    public PostViewModel PostModel => App.Services.GetRequiredService<PostViewModel>();

    public PostsViewModel PostsModel => App.Services.GetRequiredService<PostsViewModel>();

    public StaffListsViewModel StaffListsModel => App.Services.GetRequiredService<StaffListsViewModel>();

    public StaffListViewModel StaffListModel => App.Services.GetRequiredService<StaffListViewModel>();

    public StaffListPositionViewModel StaffListPositionModel => App.Services.GetRequiredService<StaffListPositionViewModel>();

    public DivisionsViewModel DivisionsModel => App.Services.GetRequiredService<DivisionsViewModel>();

    public DivisionViewModel DivisionModel => App.Services.GetRequiredService<DivisionViewModel>();

    public StafListSprViewModel StafListSprModel => App.Services.GetRequiredService<StafListSprViewModel>();

    public WeightViewModel WeightModel => App.Services.GetRequiredService<WeightViewModel>();

    public WeightsViewModel WeightsModel => App.Services.GetRequiredService<WeightsViewModel>();

    public ComingFieldsViewModel ComingFieldsModel => App.Services.GetRequiredService<ComingFieldsViewModel>();

    public ComingFieldViewModel ComingFieldModel => App.Services.GetRequiredService<ComingFieldViewModel>();

    public StorageLocationsViewModel StorageLocationsModel => App.Services.GetRequiredService<StorageLocationsViewModel>();

    public StorageLocationViewModel StorageLocationModel => App.Services.GetRequiredService<StorageLocationViewModel>();

    public OfficialPersonViewModel OfficialPersonModel => App.Services.GetRequiredService<OfficialPersonViewModel>();

    public TmCsViewModel TmCsModel => App.Services.GetRequiredService<TmCsViewModel>();

   public TmcViewModel TmcModel => App.Services.GetRequiredService<TmcViewModel>();

   public RulesAccountingViewModel RulesAccountingModel => App.Services.GetRequiredService<RulesAccountingViewModel>();

   public ContractViewModel ContractModel => App.Services.GetRequiredService<ContractViewModel>();

   public SpecificationContractViewModel SpecificationContractModel => App.Services.GetRequiredService<SpecificationContractViewModel>();

}