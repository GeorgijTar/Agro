
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels;

public class InvoicesViewModel : ViewModel
{
    private readonly IBaseRepository<Invoice> _repository;
    
    private string _title ="Счета";
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<Invoice> _invoices= new ();

    public ObservableCollection<Invoice> Invoices { get => _invoices; set=>Set(ref _invoices, value);}

    private Invoice _selectedInvoice=new ();

    public Invoice SelectedInvoice { get => _selectedInvoice; set => Set(ref _selectedInvoice, value); }

    private TypeDoc _typeInvoice=new ();

    public TypeDoc TypeInvoice { get => _typeInvoice; set => Set(ref _typeInvoice, value); }
    

    public InvoicesViewModel(IBaseRepository<Invoice> repository)
    {
        _repository = repository;
        LoadData();
    }

    private async void LoadData()
    {
        Invoices.Clear();
        var invoices = await _repository.GetAllAsync();
        invoices= invoices!.Where(x => x.StatusId == 5).Where(x=>x.TypeId==TypeInvoice.Id);

        foreach (var invoice in invoices)
        {
            Invoices.Add(invoice);
        }
    }

    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted);

    private void OnAddCommandExecuted(object obj)
    {
        InvoiceView view = new();
        InvoiceViewModel viewModel = (InvoiceViewModel)view.DataContext;
        viewModel.Invoice.Type = TypeInvoice;
        view.Show();
    }

    #endregion
}