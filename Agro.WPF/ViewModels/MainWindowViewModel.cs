
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views;
using Agro.WPF.Views.Windows;
using Agro.WPF.Views.Windows.Agronomy;
using Agro.WPF.Views.Windows.Contract;
using Agro.WPF.Views.Windows.Personnel;
using Agro.WPF.Views.Windows.Storage;
using Agro.WPF.Views.Windows.TMC;
using Agro.WPF.Views.Windows.Weight;

namespace Agro.WPF.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private readonly IBaseRepository<TypeDoc> _typeRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IBaseRepository<GroupDoc> _groupRepository;


    public IEnumerable<Status>? Status { get; set; }
    public IEnumerable<GroupDoc>? Groups { get; set; }

    private IEnumerable<TypeDoc>? _types = new HashSet<TypeDoc>();
    public IEnumerable<TypeDoc>? Types { get => _types; set => Set(ref _types, value); }

    public MainWindowViewModel(
        IBaseRepository<TypeDoc> typeRepository,
        IBaseRepository<Status> statusRepository,
        IBaseRepository<GroupDoc> groupRepository)
    {
        _typeRepository = typeRepository;
        _statusRepository = statusRepository;
        _groupRepository = groupRepository;
        LoadManualData();
    }

    private async void LoadManualData()
    {
        Types = await _typeRepository.GetAllAsync();
        Status = await _statusRepository.GetAllAsync();
        Groups = await _groupRepository.GetAllAsync();
    }

    private string _title = $"Агро-2022 версия: {Assembly.GetExecutingAssembly().GetName().Version!.ToString()}";
    public string Title { get => _title; set => Set(ref _title, value); }


    #region Command

    #region ShowContractors

    private ICommand? _showContractors;

    public ICommand ShowContractors => _showContractors
        ??= new RelayCommand(OnShowContractorsCommandExecuted);

    private void OnShowContractorsCommandExecuted(object obj)
    {
        CoynterpartiesView coynterpartiesView = new();
        coynterpartiesView.Show();
    }

    #endregion

    #region ShowProduct

    private ICommand? _showproduct;

    public ICommand ShowProduct => _showproduct
        ??= new RelayCommand(OnShowProductCommandExecuted);

    private void OnShowProductCommandExecuted(object obj)
    {
        ProductsView productsView = new();
        productsView.Show();
    }

    #endregion

    #region ShowAccountingPlans

    private ICommand? _showAccountingPlans;

    public ICommand ShowAccountingPlans => _showAccountingPlans
        ??= new RelayCommand(OnShowAccountingPlansCommandExecuted);

    private void OnShowAccountingPlansCommandExecuted(object obj)
    {
        AccountingPlansView view = new AccountingPlansView();
        view.Show();
    }

    #endregion

    #region ShowInvoicesOut

    private ICommand? _showInvoicesOut;

    public ICommand ShowInvoicesOut => _showInvoicesOut
        ??= new RelayCommand(OnShowInvoicesOutCommandExecuted);

    private void OnShowInvoicesOutCommandExecuted(object obj)
    {
        InvoicesView view = new();
        var model = view.DataContext as InvoicesViewModel;
        model!.TypeInvoice = Types!.FirstOrDefault(t=>t.Id==8)!;
        model.Title = $"{model.TypeInvoice.Name} счета";
        view.Show();
    }

    #endregion

    #region ShowInvoicesIn

    private ICommand? _showInvoicesIn;

    public ICommand ShowInvoicesIn => _showInvoicesIn
        ??= new RelayCommand(OnShowInvoicesInCommandExecuted);

    private void OnShowInvoicesInCommandExecuted(object obj)
    {
        InvoicesView view = new();
        var model = view.DataContext as InvoicesViewModel;
        model!.TypeInvoice = Types!.FirstOrDefault(t => t.Id == 9)!;
        model.Title = $"{model.TypeInvoice.Name} счета";
        view.Show();
    }

    #endregion

    #region ShowOrganizationSitttings

    private ICommand? _showOrganizationSittings;

    public ICommand ShowOrganizationSittings => _showOrganizationSittings
        ??= new RelayCommand(OnShowOrganizationSittingsCommandExecuted);

    private void OnShowOrganizationSittingsCommandExecuted(object obj)
    {
        OrganizationView view = new();
        view.ShowDialog();
    }

    #endregion

    #region ShowDepartment

    private ICommand? _showDepartment;

    public ICommand ShowDepartment => _showDepartment
        ??= new RelayCommand(OnShowDepartmentCommandExecuted);

    private void OnShowDepartmentCommandExecuted(object obj)
    {
        DepartmentsView view = new();
        view.Show();
    }

    #endregion

    #region ShowCulture

    private ICommand? _showCulture;

    public ICommand ShowCulture => _showCulture
        ??= new RelayCommand(OnShowCultureCommandExecuted);

    private void OnShowCultureCommandExecuted(object obj)
    {
        CulturesView view = new();
        view.Show();
    }

    #endregion

    #region ShowLandPlot

    private ICommand? _showLandPlots;

    public ICommand ShowLandPlots => _showLandPlots
        ??= new RelayCommand(OnShowLandPlotCommandExecuted);

    private void OnShowLandPlotCommandExecuted(object obj)
    {
        LandPlotsView view = new();
        view.Show();
    }

    #endregion

    #region ShowFields

    private ICommand? _showFields;

    public ICommand ShowFields => _showFields
        ??= new RelayCommand(OnShowFieldsCommandExecuted);

    private void OnShowFieldsCommandExecuted(object obj)
    {
        FieldsView view = new();
        view.Show();
    }

    #endregion

    #region ShowTransports

    private ICommand? _showTransports;

    public ICommand ShowTransports => _showTransports
        ??= new RelayCommand(OnShowTransportsCommandExecuted);

    private void OnShowTransportsCommandExecuted(object obj)
    {
        TransportsView view = new();
        view.Show();
    }

    #endregion

    #region ShowDrivers

    private ICommand? _showDrivers;

    public ICommand ShowDrivers => _showDrivers
        ??= new RelayCommand(OnShowDriversCommandExecuted);

    private void OnShowDriversCommandExecuted(object obj)
    {
        DriversView view = new();
        view.Show();
    }

    #endregion

    #region ShowPeoples

    private ICommand? _showEmployees;

    public ICommand ShowEmployees => _showEmployees
        ??= new RelayCommand(OnShowEmployeesCommandExecuted);

    private void OnShowEmployeesCommandExecuted(object obj)
    {
        EmployeesView view = new();
        view.Show();
    }

    #endregion

    #region ShowPeoples

    private ICommand? _showPeoples;

    public ICommand ShowPeoples => _showPeoples
        ??= new RelayCommand(OnShowPeoplesCommandExecuted);

    private void OnShowPeoplesCommandExecuted(object obj)
    {
        PeoplsView view = new();
        view.Show();
    }

    #endregion

    #region ShowStaffList

    private ICommand? _showStaffList;

    public ICommand ShowStaffList => _showStaffList
        ??= new RelayCommand(OnShowStaffListCommandExecuted);

    private void OnShowStaffListCommandExecuted(object obj)
    {
        StaffListsView view = new();
        view.Show();
    }

    #endregion
    
    #region ShowWeights

    private ICommand? _showWeights;

    public ICommand ShowWeights => _showWeights
        ??= new RelayCommand(OnShowWeightsCommandExecuted);

    private void OnShowWeightsCommandExecuted(object obj)
    {
        WeightsView view = new();
        view.Show();
    }

    #endregion


    #region ShowComingFields

    private ICommand? _showComingFields;

    public ICommand ShowComingFields => _showComingFields
        ??= new RelayCommand(OnShowComingFieldsCommandExecuted);

    private void OnShowComingFieldsCommandExecuted(object obj)
    {
        ComingFieldsView view = new();
        view.Show();
    }

    #endregion

    #region ShowStorageLocations

    private ICommand? _showStorageLocations;

    public ICommand ShowStorageLocations => _showStorageLocations
        ??= new RelayCommand(OnShowStorageLocationsCommandExecuted);

    private void OnShowStorageLocationsCommandExecuted(object obj)
    {
        StorageLocationsView view = new();
        view.Show();
    }

    #endregion

    #region ShowTMC

    private ICommand? _showTmc;

    public ICommand ShowTmc => _showTmc
        ??= new RelayCommand(OnShowTMCCommandExecuted);

    private void OnShowTMCCommandExecuted(object obj)
    {
        TmCsView view = new();
        view.Show();
    }

    #endregion

    #region ShowContracts

    private ICommand? _showContractsCommand;

    public ICommand ShowContractsCommand => _showContractsCommand
        ??= new RelayCommand(OnShowContractsExecuted);

    private void OnShowContractsExecuted(object obj)
    {
        var view = new ContractsView();
        view.Show();
    }

    #endregion
    #endregion

}
