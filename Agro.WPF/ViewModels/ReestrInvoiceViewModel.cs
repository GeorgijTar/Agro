
using Agro.DAL.Entities;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;

namespace Agro.WPF.ViewModels;
public class ReestrInvoiceViewModel:ViewModel
{
    private ReestrInvoice _reestrInvoice = null!;
    public ReestrInvoice ReestrInvoice { get => _reestrInvoice; set => Set(ref _reestrInvoice, value); }
    

    private Invoice _selectInvoice = null!;
    public Invoice SelectInvoice { get => _selectInvoice; set => Set(ref _selectInvoice, value); }

    #region Commands

    #region RemoveInvoice

    private ICommand? _removeInvoice;

    public ICommand RemoveInvoice => _removeInvoice
        ??= new RelayCommand(RemoveInvoiceInCommand, RemoveInvoiceCanExecute);

    private bool RemoveInvoiceCanExecute(object arg)
    {
        return SelectInvoice != null!;
    }

    private void RemoveInvoiceInCommand(object obj)
    {
        ReestrInvoice.Invoices.Remove(SelectInvoice);
    }

    #endregion

    #endregion
}
