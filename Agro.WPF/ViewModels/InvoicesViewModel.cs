
using System.Collections.ObjectModel;
using Agro.Domain.Base;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels;

public class InvoicesViewModel : ViewModel
{
    private string _title;
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<InvoiceDto> _invoices= new ();
    public ObservableCollection<InvoiceDto> Invoices { get => _invoices; set=>Set(ref _invoices, value);}

    public InvoicesViewModel()
    {
        
    }
}