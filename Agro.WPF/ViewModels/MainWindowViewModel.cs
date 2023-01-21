using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Coming;
using Agro.WPF.ViewModels.Contract;
using Agro.WPF.ViewModels.InvoiceVM;
using Agro.WPF.Views;
using Agro.WPF.Views.Pages.Bank.BaseView;
using Agro.WPF.Views.Pages.Bank.Pay;
using Agro.WPF.Views.Pages.Coming;
using Agro.WPF.Views.Pages.Contract;
using Agro.WPF.Views.Pages.Invoice;
using Agro.WPF.Views.Windows;
using Agro.WPF.Views.Windows.Agronomy;
using Agro.WPF.Views.Windows.Invoice;
using Agro.WPF.Views.Windows.Personnel;
using Agro.WPF.Views.Windows.Storage;
using Agro.WPF.Views.Windows.TMC;
using Agro.WPF.Views.Windows.Weight;

namespace Agro.WPF.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private readonly IHelperNavigation _helperNavigation;


    private User? _user;
    public User? User { get => _user; set => Set(ref _user, value); }

    public IEnumerable<Status>? Status { get; set; }
    public IEnumerable<GroupDoc>? Groups { get; set; }
    public IEnumerable<TypeDoc>? Types { get; set; }

    public MainWindowViewModel(IHelperNavigation helperNavigation)
    {
        _helperNavigation = helperNavigation;
        Title= $"Агро-2022 версия: {Assembly.GetExecutingAssembly().GetName().Version!.ToString()}";
        User = Application.Current.Properties["User"] as User;
        Groups = Application.Current.Properties["Groups"] as IEnumerable<GroupDoc>;

        
    }

  
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
        var page = new InvoicesPage();
        var model = page.DataContext as InvoicesViewModel;
        model!.TypeInvoice = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(t=>t.Id==8)!;
        _helperNavigation.OpenPage(page, $"{model.TypeInvoice.Name} счета");
    }

    #endregion

    #region ShowInvoicesIn

    private ICommand? _showInvoicesIn;

    public ICommand ShowInvoicesIn => _showInvoicesIn
        ??= new RelayCommand(OnShowInvoicesInCommandExecuted);

    private void OnShowInvoicesInCommandExecuted(object obj)
    {
        var page = new InvoicesPage();
        var model = page.DataContext as InvoicesViewModel;
        model!.TypeInvoice = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(t => t.Id == 9)!;
        _helperNavigation.OpenPage(page, $"{model.TypeInvoice.Name} счета");

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

    #region ShowContractsIn

    private ICommand? _showContractsInCommand;

    public ICommand ShowContractsInCommand => _showContractsInCommand
        ??= new RelayCommand(OnShowContractsInExecuted);

    private void OnShowContractsInExecuted(object obj)
    {
        var page = new ContractsPage();
       var model = page.DataContext as ContractsViewModel;
        model!.GroupId = 21;
        _helperNavigation.OpenPage(page,"Реестр договоров на закупку");
    }

    #endregion

    #region ShowContractsOut

    private ICommand? _showContractsOutCommand;

    public ICommand ShowContractsOutCommand => _showContractsOutCommand
        ??= new RelayCommand(OnShowContractsOutExecuted);

    private void OnShowContractsOutExecuted(object obj)
    {
        var page = new ContractsPage();
        var model = page.DataContext as ContractsViewModel;
        model!.GroupId = 22;
        _helperNavigation.OpenPage(page, "Реестр договоров на реализацию");
    }

    #endregion

    #region ShowRegistryInvoice

    private ICommand? _showRegistryInvoiceCommand;

    public ICommand ShowRegistryInvoiceCommand => _showRegistryInvoiceCommand
        ??= new RelayCommand(OnShowRegistryInvoiceExecuted);

    private void OnShowRegistryInvoiceExecuted(object obj)
    {
        var page = new RegistryInvoicesPage();
        var model = page.DataContext as RegistryInvoicesViewModel;
        model!.TabItem= _helperNavigation.OpenPage(page, "Реестр счетов на оплату");
        
    }

    #endregion

    #region ShowExpenditureItemsView

    private ICommand? _showExpenditureItemsViewCommand;

    public ICommand ShowExpenditureItemsViewCommand => _showExpenditureItemsViewCommand
        ??= new RelayCommand(OnShowExpenditureItemsViewExecuted);

    private void OnShowExpenditureItemsViewExecuted(object obj)
    {
        _helperNavigation.OpenPage(new ExpenditureItemsPage(), "Справочник статей расходов и доходов ДДС");
    }

    #endregion

    #region ShowPaymentsOrder

    private ICommand? _showPaymentsOrderCommand;

    public ICommand ShowPaymentsOrderCommand =>
        _showPaymentsOrderCommand
            ??= new RelayCommand(OnShowPaymentsOrderExecuted);

    private void OnShowPaymentsOrderExecuted(object obj)
    {
        _helperNavigation.OpenPage(new PaymentsOrdersPage(), "Реестр платежных поручений");
    }
    #endregion

    #region ShowComingTMC

    private ICommand? _showComingTmcCommand;

    public ICommand ShowComingTmcCommand => _showComingTmcCommand
        ??= new RelayCommand(OnShowComingTmcExecuted);

    private void OnShowComingTmcExecuted(object obj)
    {
        var page = new ComingsTmcPage();
        var model = page.DataContext as ComingsTmcViewModel;
        model!.TabItem = _helperNavigation.OpenPage(page, "Реестр документов поступления");
    }

    #endregion


    #endregion

}


