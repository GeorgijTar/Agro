using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.InvoiceEntity;

/// <summary>
/// Реестр счетов на оплату
/// </summary>
public class RegistryInvoice : Entity
{
    /// <summary> Статус реестра </summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); } 
    
    /// <summary> Номер реестра </summary>
    private int _number;
    public int Number { get => _number; set => Set(ref _number, value); }

    /// <summary> Дата реестра </summary>
    private DateTime _date = DateTime.Now;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary> Дата отправки реестра </summary>
    private DateTime? _dateDispatch;
    public DateTime? DateDispatch { get => _dateDispatch; set => Set(ref _dateDispatch, value); } 
    
    /// <summary> Счета входящие в реестр требующие подтверждение </summary>
    private ObservableCollection<Invoice>? _invoices;
    public ObservableCollection<Invoice>? Invoices { get => _invoices; set => Set(ref _invoices, value); }
   
}
