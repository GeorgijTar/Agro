
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using Microsoft.Win32;
using ReportExcelLib;

namespace Agro.WPF.ViewModels;

public class InvoicesViewModel : ViewModel
{
    private readonly IInvoiceRepository<Invoice> _repository;

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

    public InvoicesViewModel(IInvoiceRepository<Invoice> repository)
    {
        _repository = repository;
        LoadData();
        this.PropertyChanged += TypeChanged;
    }

    private void TypeChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "TypeInvoice")
        {
            if (TypeInvoice.Id == 10)
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
        invoices = invoices!.Where(x => x.Status.Id != 6).Where(x => x.Type.Id == TypeInvoice.Id);

        foreach (var invoice in invoices)
        {
            Invoices.Add(invoice);
}

        Nds = await _repository.GetAllNds();
    }

    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted);

    private void OnAddCommandExecuted(object obj)
    {
        InvoiceView view = new();
        InvoiceViewModel viewModel = (InvoiceViewModel)view.DataContext;
        viewModel.Nds = Nds;
        viewModel.Invoice.Type = TypeInvoice;
        if (TypeInvoice.Id == 10)
        {
            viewModel.VisibilityNumeric = Visibility.Visible;
            viewModel.VisibilityBankOrg = Visibility.Visible;
        }
        view.Show();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditCommandExecuted, EditCommandExecut);

    private bool EditCommandExecut(object arg)
    {
       return SelectedInvoice !=null! && SelectedInvoice.Id != 0;
    }

    private void OnEditCommandExecuted(object obj)
    {
        InvoiceView view = new();
        InvoiceViewModel viewModel = (InvoiceViewModel)view.DataContext;
        viewModel.Nds = Nds;
        viewModel.Invoice = SelectedInvoice;
        viewModel.IsEdit = true;
        if (TypeInvoice.Id == 10)
        {
            viewModel.VisibilityNumeric = Visibility.Visible;
            viewModel.VisibilityBankOrg = Visibility.Visible;
        }
        view.Show();
    }

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
}