
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
        model!.TypeInvoice = Types!.FirstOrDefault(t=>t.Id==10)!;
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
        model!.TypeInvoice = Types!.FirstOrDefault(t => t.Id == 11)!;
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

    #endregion

}
