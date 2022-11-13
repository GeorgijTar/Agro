using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Contract;
using Agro.WPF.Views.Windows;
using Agro.WPF.Views.Windows.Contract;
using Microsoft.Win32;

namespace Agro.WPF.ViewModels.InvoiceVM;

public class InvoiceViewModel : ViewModel
{
    private bool _buttonActivity = true;
    public bool ButtonActivity { get => _buttonActivity; set => Set(ref _buttonActivity, value); } 


    private readonly IInvoiceRepository<Invoice> _invoiceRepository;
    private string _title = "Новый счет";

    public string Title { get => _title; set => Set(ref _title, value); }

    private Invoice _invoice = new();

    public Invoice Invoice { get => _invoice; set => Set(ref _invoice, value); }


    private ScanFile _selectedFile = null!;
    public ScanFile SelectedFile { get => _selectedFile; set => Set(ref _selectedFile, value); }


    private ICollection<BankDetails> _bankDetailsOrg = new HashSet<BankDetails>();
    public ICollection<BankDetails> BankDetailsOrg { get => _bankDetailsOrg; set => Set(ref _bankDetailsOrg, value); }


    private IEnumerable<Nds>? _nds = new HashSet<Nds>();
    public IEnumerable<Nds>? Nds { get => _nds; set => Set(ref _nds, value); }


    private Visibility _visibilityNumeric = Visibility.Hidden;
    public Visibility VisibilityNumeric { get => _visibilityNumeric; set => Set(ref _visibilityNumeric, value); }


    private Visibility _visibilityBankOrg = Visibility.Collapsed;
    public Visibility VisibilityBankOrg { get => _visibilityBankOrg; set => Set(ref _visibilityBankOrg, value); }


    private ProductInvoice _selectProductInvoice = null!;
    public ProductInvoice SelectProductInvoice { get => _selectProductInvoice; set => Set(ref _selectProductInvoice, value); }


    private decimal _totalAmount;
    public decimal TotalAmount { get => _totalAmount; set => Set(ref _totalAmount, value); }


    private decimal _amountNds;
    public decimal AmountNds { get => _amountNds; set => Set(ref _amountNds, value); }

    private bool _isEdit;
    public bool IsEdit
    {
        get => _isEdit;
        set
        {
            Set(ref _isEdit, value);
            Invoice.ProductsInvoice!.ItemPropertyChanged += CalcItem;
            Invoice.ProductsInvoice!.CollectionChanged += CalcCol;
            Invoice.PropertyChanged += ChangedPropertyInvoice;
            Calc();
        }
    }

    private object _senderModel = null!;
    public object SenderModel { get => _senderModel; set => Set(ref _senderModel, value); }
    public InvoiceViewModel(
        IInvoiceRepository<Invoice> invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
        LoadStaticData();
        Invoice.PropertyChanged += ChangedPropertyInvoice;
        Invoice.ProductsInvoice!.ItemPropertyChanged += CalcItem;
        Invoice.ProductsInvoice!.CollectionChanged += CalcCol;
    }


    private void CalcCol(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Calc();
    }

    private void CalcItem(object? sender, ItemPropertyChangedEventArgs e)
    {
        Calc();
    }

    private void Calc()
    {

        if (Invoice.ProductsInvoice != null! && Invoice.ProductsInvoice.Any())
        {
            TotalAmount = 0;
            AmountNds = 0;
            decimal invoiceAmount = 0;
            decimal invoiceAmountNds = 0;
            decimal invoiceTotalAmount = 0;
            foreach (var product in Invoice.ProductsInvoice!)
            {
                TotalAmount += product.TotalAmount;
                AmountNds += product.AmountNds;
                invoiceAmount += product.Amount;
                invoiceAmountNds += product.AmountNds;
                invoiceTotalAmount += product.TotalAmount;
                Invoice.Nds = product.Nds;
            }
            Invoice.PropertyChanged -= ChangedPropertyInvoice;
            Invoice.Amount = invoiceAmount;
            Invoice.AmountNds = invoiceAmountNds;
            Invoice.TotalAmount = invoiceTotalAmount;
            Invoice.PropertyChanged += ChangedPropertyInvoice;
        }
    }

    private void ChangedPropertyInvoice(object? sender, PropertyChangedEventArgs e)
    {

        switch (e.PropertyName)
        {
            default: return;

            case "Nds":
                Invoice.AmountNds = Invoice.Amount * Invoice.Nds.Percent / 100;
                break;
            case "Amount":
                Invoice.AmountNds = Invoice.Amount * Invoice.Nds.Percent / 100;
                Invoice.TotalAmount = Invoice.AmountNds + Invoice.Amount;
                break;
            case "AmountNds":
                Invoice.TotalAmount = Invoice.AmountNds + Invoice.Amount;
                break;
            case "TotalAmount":
                Invoice.PropertyChanged -= ChangedPropertyInvoice;
                Invoice.AmountNds = Invoice.TotalAmount / Invoice.Nds.OverPercent * Invoice.Nds.Percent / 100;
                Invoice.Amount = Invoice.TotalAmount - Invoice.AmountNds;
                Invoice.PropertyChanged += ChangedPropertyInvoice;
                break;
            case "Counterparty":
                if (Invoice.Counterparty.BankDetails!.Count == 1)
                    Invoice.BankDetails = Invoice.Counterparty.BankDetails[0];
                break;
        }

    }

    private async void LoadStaticData()
    {
        BankDetailsOrg = await _invoiceRepository.GetAllBankDetailsOrg();
    }


    #region Commands

    #region ShowCounterpartyes

    private ICommand? _showCounterpartiesCommand;

    public ICommand ShowCounterpartiesCommand => _showCounterpartiesCommand
        ??= new RelayCommand(OnShowCounterpartiesCommandExecuted);

    private void OnShowCounterpartiesCommandExecuted(object obj)
    {
        CoynterpartiesView coynterpartiesView = new();
        ContractorsViewModel model = (ContractorsViewModel)coynterpartiesView.DataContext;
        model.ModelSender = this;
        coynterpartiesView.ShowDialog();
    }

    #endregion

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveCommandExecuted, SaveCommandCan);

    private bool SaveCommandCan(object arg)
    {
        return Invoice.Number != null! && Invoice.Nds != null! && Invoice.Amount != 0 && Invoice.TotalAmount != 0 && Invoice.Counterparty != null!;
    }

    private async void OnSaveCommandExecuted(object obj)
    {
        Invoice.Status = await _invoiceRepository.GetStatusById(1);
        var inv = await _invoiceRepository.SaveAsync(Invoice);
        if (!IsEdit)
        {
            if (SenderModel != null!)
            {
                if (SenderModel is InvoicesViewModel invoicesViewModel)
                {
                    invoicesViewModel.Invoices.Add(inv);
                }
            }
        }
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();

    }

    #endregion

    #region AddFile

    private ICommand? _addFileCommand;

    public ICommand AddFileCommand => _addFileCommand
        ??= new RelayCommand(OnAddFileCommandExecuted);

    private void OnAddFileCommandExecuted(object obj)
    {

        OpenFileDialog openFileDialog = new()
        {
            InitialDirectory = "c:\\",
            Filter = "PDF (*.PDF)|*.PDF|All files (*.*)|*.*",
            FilterIndex = 2,
            RestoreDirectory = false
        };
        if (openFileDialog.ShowDialog() == true)
        {
            //Get the path of specified file
            var filePath = openFileDialog.FileName;
            FileInfo fileInfo = new FileInfo(filePath);
            double size = fileInfo.Length / 1048576.00;
            var file = new ScanFile();
            file.Name = openFileDialog.SafeFileName;
            file.BodyBytes = File.ReadAllBytes(filePath);
            file.TotalBytes = size;
            Invoice.ScanFiles!.Add(file);
        }

    }
    #endregion

    #region RemoveFile

    private ICommand? _removeFileCommand;

    public ICommand RemoveFileCommand => _removeFileCommand
        ??= new RelayCommand(OnRemoveFileCommandExecuted, RemoveFileCan);

    private bool RemoveFileCan(object arg)
    {
        return SelectedFile != null!;
    }

    private void OnRemoveFileCommandExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить файл: {SelectedFile.Name}",
            "Редактор файлов", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            if (SelectedFile.Id != 0)
                _invoiceRepository.RemoveFile(SelectedFile);
            Invoice.ScanFiles!.Remove(SelectedFile);
        }
    }

    #endregion

    #region SaveFile

    private ICommand? _saveFileCommand;

    public ICommand SaveFileCommand => _saveFileCommand
        ??= new RelayCommand(OnSaveFileCommandExecuted, SaveFileCan);

    private void OnSaveFileCommandExecuted(object obj)
    {
        SaveFileDialog saveFileDialog = new()
        {
            InitialDirectory = "c:\\",
            FileName = SelectedFile.Name,
            DefaultExt = ".pdf",
            Filter = "PDF (*.PDF)|*.PDF|All files (*.*)|*.*",
            FilterIndex = 2,
            RestoreDirectory = false
        };


        if (saveFileDialog.ShowDialog() == true)
        {
            File.WriteAllBytes(saveFileDialog.FileName, SelectedFile.BodyBytes);
        }
    }

    private bool SaveFileCan(object arg)
    {
        return SelectedFile != null!;
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

    #endregion

    #region Numeric
    private ICommand? _numericCommand;

    public ICommand NumericCommand => _numericCommand
        ??= new RelayCommand(OnNumericCommandExecuted, CanNumericComand);

    private bool CanNumericComand(object arg)
    {
        return Invoice.Number == null! || Invoice.Number.Length == 0;
    }

    private async void OnNumericCommandExecuted(object obj)
    {
        Invoice.Number = await _invoiceRepository.GetNumber(Invoice);
    }

    #endregion

    #region ShowAddProduct

    private ICommand? _showAddProductCommand;

    public ICommand ShowAddProductCommand => _showAddProductCommand
        ??= new RelayCommand(OnShowAddProductCommandExecuted);

    private void OnShowAddProductCommandExecuted(object obj)
    {
        var view = new ProductInvoiceView();
        var viewModel = (ProductInvoiceViewModel)view.DataContext;
        viewModel.SenderModel = this;
        viewModel.IsEdit = false;
        view.ShowDialog();

    }

    #endregion

    #region ShowEditProduct

    private ICommand? _showEditProductCommand;

    public ICommand ShowEditProductCommand => _showEditProductCommand
        ??= new RelayCommand(OnShowEditProductCommandExecuted, ShowEditProductCommandCan);

    private bool ShowEditProductCommandCan(object arg)
    {
        return SelectProductInvoice != null!;
    }

    private void OnShowEditProductCommandExecuted(object obj)
    {
        var view = new ProductInvoiceView();
        var viewModel = (ProductInvoiceViewModel)view.DataContext;
        viewModel.SenderModel = this;
        viewModel.ProductInvoice = SelectProductInvoice;
        viewModel.IsEdit = true;
        view.ShowDialog();
    }

    #endregion

    #region DeleteProduct

    private ICommand? _deleteProductCommand;

    public ICommand DeleteProductCommand => _deleteProductCommand
        ??= new RelayCommand(OnDeleteProductCommandExecuted, DeleteProductCommandCan);

    private bool DeleteProductCommandCan(object arg)
    {
        return SelectProductInvoice != null!;
    }

    private async void OnDeleteProductCommandExecuted(object obj)
    {
        if (SelectProductInvoice.Id != 0)
            await _invoiceRepository.RemoveProductInvoice(SelectProductInvoice);
        Invoice.ProductsInvoice!.Remove(SelectProductInvoice);
    }

    #endregion

    #region ShowContracts

    private ICommand? _showContractsCommand;

    public ICommand ShowContractsCommand => _showContractsCommand
        ??= new RelayCommand(OnShowContractsExecuted);

    private void OnShowContractsExecuted(object obj)
    {
        var view = new ContractsView();
        var model = view.DataContext as ContractsViewModel;
        model!.Title = "Выберите договор";
        model.SenderModel = this;
        view.DataContext = model;
        view.ShowDialog();
    }

    #endregion

    #region ClesrContract

    private ICommand? _clesrContractCommand;

    public ICommand ClesrContractCommand => _clesrContractCommand
        ??= new RelayCommand(OnClesrContractExecuted, CanClesrContractExecuted);

    private bool CanClesrContractExecuted(object arg)
    {
        return Invoice != null! && Invoice.Contract != null!;
    }

    private void OnClesrContractExecuted(object obj)
    {
        Invoice.Contract = null!;
        Invoice.Specification = null!;
    }

    #endregion

    #endregion
}
