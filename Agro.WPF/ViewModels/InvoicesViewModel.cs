
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.InvoceEntity;
using Agro.Interfaces.Base.Repositories;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using Microsoft.Win32;
using ReportExcelLib;

namespace Agro.WPF.ViewModels;

public class InvoicesViewModel : ViewModel
{
    private readonly IInvoiceRepository<Invoice> _repository;
    private readonly IBaseRepository<Status> _statusRepository;

    private string _title = "Счета";
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<Invoice> _invoices = new();

    public ObservableCollection<Invoice> Invoices { get => _invoices; set => Set(ref _invoices, value); }

    private Invoice _selectedInvoice = null!;

    public Invoice SelectedInvoice { get => _selectedInvoice; set => Set(ref _selectedInvoice, value); }

    private TypeDoc _typeInvoice = new();
    public TypeDoc TypeInvoice { get => _typeInvoice; set => Set(ref _typeInvoice, value); }

    private Visibility _visibilityButton = Visibility.Hidden;
    public Visibility VisibilityButton { get => _visibilityButton; set => Set(ref _visibilityButton, value); }

    private Visibility _visibilityReestr = Visibility.Hidden;
    public Visibility VisibilityReestr { get => _visibilityReestr; set => Set(ref _visibilityReestr, value); }

    private ContextMenu _contextMenu = new();
    public ContextMenu ContextMenu { get => _contextMenu; set => Set(ref _contextMenu, value); }

    private IEnumerable<Nds>? _nds = new HashSet<Nds>();
    public IEnumerable<Nds>? Nds { get => _nds; set => Set(ref _nds, value); }


    private string _numberFilter = null!;
    public string NumberFilter { get => _numberFilter; set => Set(ref _numberFilter, value); }


    private DateTime _dateOnFilter;
    public DateTime DateOnFilter { get => _dateOnFilter; set => Set(ref _dateOnFilter, value); }


    private DateTime _dateOffFilter;
    public DateTime DateOffFilter { get => _dateOffFilter; set => Set(ref _dateOffFilter, value); }


    private string _innFilter = null!;
    public string InnFilter { get => _innFilter; set => Set(ref _innFilter, value); }


    private string _nameFilter = null!;
    public string NameFilter { get => _nameFilter; set => Set(ref _nameFilter, value); }

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }


    public InvoicesViewModel(IInvoiceRepository<Invoice> repository, IBaseRepository<Status> statusRepository)
    {
        _repository = repository;
        _statusRepository = statusRepository;
        LoadData();
        this.PropertyChanged += TypeChanged;
        CollectionView = CollectionViewSource.GetDefaultView(Invoices);
        this.PropertyChanged += ViewChanged;
    }

    private void ViewChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            
            case "NumberFilter":
                CollectionView.Filter = FilterByNumber;
                break;
            case "DateOnFilter":
                CollectionView.Filter = FilterByDate;
                break;
            case "DateOffFilter":
                CollectionView.Filter = FilterByDate;
                break;
            case "InnFilter":
                CollectionView.Filter = FilterByInn;
                break;
            case "NameFilter":
                CollectionView.Filter = FilterByName;
                break;
        }
    }

    private bool FilterByName(object obj)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            Invoice? dto = obj as Invoice;
            return dto!.Counterparty.Name.ToUpper().Contains(NameFilter.ToUpper()) |
                   dto.Counterparty.PayName.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByInn(object obj)
    {
        if (!string.IsNullOrEmpty(InnFilter))
        {
            Invoice? dto = obj as Invoice;
            return dto!.Counterparty.Inn.ToUpper().Contains(InnFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByDate(object obj)
    {
        if (DateOnFilter <= DateOffFilter)
        {
            Invoice? dto = obj as Invoice;
            return dto!.DateInvoice >= DateOnFilter & dto.DateInvoice <= DateOffFilter;
        }

        return true;
    }

    private bool FilterByNumber(object obj)
    {
        if (!string.IsNullOrEmpty(NumberFilter))
        {
            Invoice? dto = obj as Invoice;
            return dto!.Number.ToUpper().Contains(NumberFilter.ToUpper());
        }
        return true;
    }



    private void TypeChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "TypeInvoice")
        {
            if (TypeInvoice.Id == 8)
            {
                VisibilityButton = Visibility.Visible;
                VisibilityReestr = Visibility.Hidden;
            }
            else
            {
                VisibilityButton = Visibility.Collapsed;
                VisibilityReestr = Visibility.Visible;
            }
            GetContextMenu();
        }
    }

    private void GetContextMenu()
    {
        ContextMenu.Items.Clear();

        var mi = new MenuItem();
        mi.Header = "File";
        var mia = new MenuItem();
        mia.Header = "New";
        ContextMenu.Items.Add(mi);
        ContextMenu.Items.Add(mia);
    }

    private async void LoadData()
    {
        Invoices.Clear();
        var invoices = await _repository.GetAllAsync();
        invoices = invoices!.Where(x => x.Status!.Id != 6).Where(x => x.Type.Id == TypeInvoice.Id);

        foreach (var invoice in invoices)
        {
            Invoices.Add(invoice);
        }

        Nds = await _repository.GetAllNds();
    }

    #region Commands

    #region Add
    
    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted);

    private void OnAddCommandExecuted(object obj)
    {
        InvoiceView view = new();
        InvoiceViewModel viewModel = (InvoiceViewModel)view.DataContext;
        viewModel.Nds = Nds;
        viewModel.SenderModel = this;
        viewModel.Invoice.Type = TypeInvoice;
        if (TypeInvoice.Id == 8)
        {
            viewModel.VisibilityNumeric = Visibility.Visible;
            viewModel.VisibilityBankOrg = Visibility.Visible;
        }
        view.Show();
    }

    #endregion

    #region Edit
    
    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditCommandExecuted, EditCommandExecut);

    private bool EditCommandExecut(object arg)
    {
        return SelectedInvoice != null! && SelectedInvoice.Id != 0;
    }

    private void OnEditCommandExecuted(object obj)
    {
        InvoiceView view = new();
        InvoiceViewModel viewModel = (InvoiceViewModel)view.DataContext;
        viewModel.Nds = Nds;
        viewModel.Invoice = SelectedInvoice;
        viewModel.IsEdit = true;
        viewModel.SenderModel = this;
        if (TypeInvoice.Id == 8)
        {
            viewModel.VisibilityNumeric = Visibility.Visible;
            viewModel.VisibilityBankOrg = Visibility.Visible;
        }
        view.Show();
    }

    #endregion

    #region Print

    private ICommand? _printCommand;

    public ICommand PrintCommand => _printCommand
        ??= new RelayCommand(OnPrintCommandExecuted, EditCommandExecut);

    private void OnPrintCommandExecuted(object obj)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.DefaultExt = "*.xlsx";
        saveFileDialog.FileName = $"Счет на оплату № {SelectedInvoice.Number} от {SelectedInvoice.DateInvoice.ToShortDateString()}";
        saveFileDialog.Filter = "Microsoft Excel (*.xlsx)|*.xlsx";
        if (saveFileDialog.ShowDialog() == true)
        {
            InvoiceReportExcel.Print(saveFileDialog.FileName, SelectedInvoice);
        }
    }

    #endregion

    #region ContecstMenu

    #region billing 
    /// <summary>
    /// Выставление счета
    /// </summary>

    private ICommand? _billingCommand;

    public ICommand BillingCommand => _billingCommand
        ??= new RelayCommand(OnBillingExecuted, CanBillingExecuted);

    private bool CanBillingExecuted(object arg)
    {
        return SelectedInvoice!=null! &  SelectedInvoice!.Type.Id == 8 & SelectedInvoice.Status!.Id == 1;
    }

    private async void OnBillingExecuted(object obj)
    {
        SelectedInvoice.Status = await _statusRepository.GetByIdAsync(11);
        await _repository.SaveAsync(SelectedInvoice);
    }

    #endregion

    #region acceptance
    /// <summary>
    /// Принятие счета
    /// </summary>
    private ICommand? _acceptanceCommand;

    public ICommand AcceptanceCommand => _acceptanceCommand
        ??= new RelayCommand(OnAcceptanceExecuted, CanAcceptanceExecuted);

    private bool CanAcceptanceExecuted(object arg)
    {
        return SelectedInvoice != null! & SelectedInvoice!.Type.Id == 9 & SelectedInvoice.Status!.Id == 1;
    }

    private async void OnAcceptanceExecuted(object obj)
    {
        SelectedInvoice.Status = await _statusRepository.GetByIdAsync(8);
        await _repository.SaveAsync(SelectedInvoice);
    }

    #endregion

    #endregion

    #endregion
}