
using Agro.DAL.Entities;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels;
public class InvoiceViewModel:ViewModel
{
    private string _title = "Новый счет";

    public string Title { get=>_title; set=>Set(ref _title, value); }

    private Invoice _invoice = new();

    public  Invoice Invoice { get => _invoice; set => Set(ref _invoice, value); }
}
