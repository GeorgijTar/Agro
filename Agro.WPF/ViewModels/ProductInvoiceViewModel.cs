using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.InvoiceVM;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels;

public class ProductInvoiceViewModel : ViewModel
{
    private readonly IBaseRepository<Nds> _ndsRepository;
    private ProductInvoice _productInvoice = new();

    public ProductInvoice ProductInvoice
    {
        get => _productInvoice;
        set
        {
            Set(ref _productInvoice, value);
            ProductInvoice.PropertyChanged += Calc;
        }
    }


private IEnumerable<Nds>? _nds = new List<Nds>();
    public IEnumerable<Nds>? Nds { get => _nds; set => Set(ref _nds, value); }

    private object _senderModel = null!;
    public object SenderModel { get => _senderModel; set => Set(ref _senderModel, value); }

    private bool _isEdit;
    public bool IsEdit { get => _isEdit; set => Set(ref _isEdit, value); }

    public ProductInvoiceViewModel(IBaseRepository<Nds> ndsRepository)
    {
        _ndsRepository = ndsRepository;
        LoadNds();
        ProductInvoice.PropertyChanged += Calc;
    }

    public void Calc(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            default: break;

            case "Quantity":
                ProductInvoice.Amount = ProductInvoice.Quantity * ProductInvoice.UnitPrice;
                break;
            case "UnitPrice":
                ProductInvoice.Amount = ProductInvoice.Quantity * ProductInvoice.UnitPrice;
                break;
            case "Amount":
                ProductInvoice.AmountNds = ProductInvoice.Amount * ProductInvoice.Nds.Percent / (decimal)100.00;
                ProductInvoice.TotalAmount = ProductInvoice.Amount + ProductInvoice.AmountNds;
                break;
            case "Nds":
                ProductInvoice.AmountNds = ProductInvoice.Amount * ProductInvoice.Nds.Percent / (decimal)100.00;
                ProductInvoice.TotalAmount = ProductInvoice.Amount + ProductInvoice.AmountNds;
                break;
            case "TotalAmount":
                ProductInvoice.PropertyChanged -= Calc;
                decimal overPercent = 1;
                if (ProductInvoice.Nds.OverPercent != 0)
                { overPercent = ProductInvoice.Nds.OverPercent; }
                ProductInvoice.AmountNds = ProductInvoice.TotalAmount / overPercent *
                        ProductInvoice.Nds.Percent / (decimal)100.00;
                ProductInvoice.Amount = ProductInvoice.TotalAmount - ProductInvoice.AmountNds;
                ProductInvoice.UnitPrice = ProductInvoice.Amount / ProductInvoice.Quantity;


                ProductInvoice.PropertyChanged += Calc;
                break;

        }
    }

    private async void LoadNds()
    {
        Nds = await _ndsRepository.GetAllAsync();
    }

    #region Commands

    #region ShowProducts

    private ICommand? _showProductsCommand;

    public ICommand ShowProductsCommand => _showProductsCommand
        ??= new RelayCommand(OnShowProductsExecuted);

    private void OnShowProductsExecuted(object obj)
    {
        var view = new ProductsView();
        var model = (ProductsViewModel)view.DataContext;
        model!.SenderModel = this;
        view.ShowDialog();
    }

    #endregion

    #region CloseWindow

    private ICommand? _closeWindowCommand;

    public ICommand CloseWindowCommand => _closeWindowCommand
        ??= new RelayCommand(OnCloseWindowCommandExecuted);

    private void OnCloseWindowCommandExecuted(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    #region SaveCommand

    private ICommand? _saveCommandCommand;

    public ICommand SaveCommand => _saveCommandCommand
        ??= new RelayCommand(OnSaveCommandExecuted, SaveCommandCan);

    private bool SaveCommandCan(object arg)
    {
        return ProductInvoice.Product.Id != 0 && ProductInvoice.Quantity != 0 && ProductInvoice.UnitPrice != 0
               && ProductInvoice.Amount != 0 && ProductInvoice.TotalAmount != 0 && ProductInvoice.Nds.Id !=0;
    }

    private void OnSaveCommandExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is InvoiceViewModel invoiceViewModel)
            {
                invoiceViewModel.SelectProductInvoice = new();
                if (IsEdit == false)
                    invoiceViewModel.Invoice.ProductsInvoice!.Add(ProductInvoice);
                invoiceViewModel.SelectProductInvoice = ProductInvoice;
            }

            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }


    }

    #endregion

    #endregion

    #endregion

}