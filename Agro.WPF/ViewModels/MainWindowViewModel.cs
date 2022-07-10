
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private readonly IBaseRepository<TypeDoc> _typeRepository;

    private IEnumerable<TypeDoc>? _types = new HashSet<TypeDoc>();
    public IEnumerable<TypeDoc>? Types { get => _types; set => Set(ref _types, value); }

    public MainWindowViewModel(IBaseRepository<TypeDoc> typeRepository)
    {
        _typeRepository = typeRepository;
        LoadManualData();
    }

    private async void LoadManualData()
    {
        Types = await _typeRepository.GetAllAsync();
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

    #region ShowInvoices

    private ICommand? _showInvoices;

    public ICommand ShowInvoices => _showInvoices
        ??= new RelayCommand(OnShowInvoicesCommandExecuted);

    private void OnShowInvoicesCommandExecuted(object obj)
    {
        InvoicesView view = new();
        var model = view.DataContext as InvoicesViewModel;
        model!.TypeInvoice = Types!.FirstOrDefault(t=>t.Id==10);
        model.Title = $"{model.TypeInvoice!.Name} счета";
        view.Show();
    }

    #endregion

    #endregion

}
