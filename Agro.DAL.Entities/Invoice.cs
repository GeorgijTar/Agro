
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Counter;

namespace Agro.DAL.Entities;

/// <summary>
/// Счета
/// </summary>
public class Invoice : Entity
{
    /// <summary>Статус счета</summary>
    private Status _status = new();
    [Required]
    public virtual Status Status { get=> _status; set=>Set(ref _status, value); } 


    /// <summary>Номер счета</summary>
    private string _number = null!;
    [Required]
    public string Number { get=>_number; set=>Set(ref _number, value); }

    /// <summary>Дата счета</summary>
    private DateTime _dateInvoice = DateTime.Now;
    [Required]
    public DateTime DateInvoice { get=>_dateInvoice; set=>Set(ref _dateInvoice, value); }

    /// <summary>Тип счета</summary>
    private TypeDoc _type = null!;
    [Required]
    public virtual TypeDoc Type { get=> _type; set=>Set(ref _type, value); }
    
    /// <summary>Контрагент счета</summary>
    private Counterparty _counterparty = null!;
    [Required]
    public virtual Counterparty Counterparty { get=> _counterparty; set=>Set(ref _counterparty, value); }
    

    /// <summary>Платежные реквизиты контрагента счета</summary>
    private BankDetails _bankDetails = null!;
    [Required]
    public virtual BankDetails BankDetails { get=>_bankDetails; set=>Set(ref _bankDetails, value); }

    /// <summary>Договор</summary>
    private Contract? _contract;
    public Contract? Contract { get => _contract; set => Set(ref _contract, value); } 


    
    /// <summary>Сумма счета</summary>
    private decimal _amount;
    [Required]
    public decimal Amount { get=>_amount; set=>Set(ref _amount, value); }

    /// <summary>НДС</summary>
    private Nds _nds = null!;
    public virtual Nds Nds { get=>_nds; set=>Set(ref _nds, value); }

    /// <summary>Сумма НДС</summary>
    private decimal _amountNds;
    public decimal AmountNds { get=> _amountNds; set=>Set(ref _amountNds, value); }

    /// <summary>Сумма всего</summary>
    private decimal _totalAmount;
    public decimal TotalAmount { get=>_totalAmount; set=>Set(ref _totalAmount, value); }

    /// <summary>Описание счета</summary>
    private string? _description;
    public string? Description { get=> _description; set=>Set(ref _description, value); }

    /// <summary>Список товаров, услуг</summary>
    private FullyObservableCollection<ProductInvoice>? _productsInvoice = new();
    public virtual FullyObservableCollection<ProductInvoice>? ProductsInvoice { get=> _productsInvoice; set=>Set(ref _productsInvoice, value); }
    
    /// <summary>Прикрепленные файлы</summary>
    private ObservableCollection<ScanFile> ? _scanFiles = new ();
    public virtual ObservableCollection<ScanFile>? ScanFiles { get=> _scanFiles; set=>Set(ref _scanFiles, value); }

    /// <summary>Платежные реквизиты организации</summary>
    private BankDetails? _bankDetailsOrg;
    public virtual BankDetails? BankDetailsOrg { get=> _bankDetailsOrg; set=>Set(ref _bankDetailsOrg, value); }
    
    private ObservableCollection<History> ? _history = new();
    public virtual ObservableCollection<History>? History { get=> _history; set=>Set(ref _history, value); }

}
