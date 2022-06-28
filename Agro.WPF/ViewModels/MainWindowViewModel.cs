
using System.Windows.Input;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels;

public class MainWindowViewModel : ViewModel
{
    public MainWindowViewModel()
    {

    }

    private string _title;
    public string Title { get => _title; set => Set(ref _title, value); }


    #region Command

    #region ShowContractors

    private ICommand? _showContractors;

    public ICommand ShowContractors => _showContractors
        ??= new RelayCommand(OnShowContractorsCommandExecuted);

    private void OnShowContractorsCommandExecuted(object obj)
    {
        CoynterpartiesView coynterpartiesView = new CoynterpartiesView();
        coynterpartiesView.Show();
    }

    #endregion

    #region ShowProduct

    private ICommand? _showproduct;

    public ICommand ShowProduct => _showproduct
        ??= new RelayCommand(OnShowProductCommandExecuted);

    private void OnShowProductCommandExecuted(object obj)
    {
        ProductsView productsView = new ProductsView();
        productsView.Show();
    }

    #endregion


    #endregion

}
