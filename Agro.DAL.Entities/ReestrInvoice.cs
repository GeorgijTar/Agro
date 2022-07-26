
using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

public class ReestrInvoice : Entity
{
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value);}


    private DateTime _dateReestr = DateTime.Now;
    public DateTime DateReestr { get => _dateReestr; set => Set(ref _dateReestr, value); }


    private Status _status = null!;
    public virtual Status Status { get => _status; set => Set(ref _status, value); }

    
    private DateTime _dateSend;
    public DateTime DateSend { get => _dateSend; set => Set(ref _dateSend, value); }


    private ObservableCollection<Invoice> _invoices = new();
    public virtual ObservableCollection<Invoice> Invoices { get => _invoices; set => Set(ref _invoices, value); }


    private DateTime _dateValidation;
    public DateTime DateValidation { get => _dateValidation; set => Set(ref _dateValidation, value); }

    private decimal _amountReestr;

    public decimal AmountReestr { get => _amountReestr; set => Set(ref _amountReestr, value); } 



}
