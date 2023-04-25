using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.Registers;

namespace Agro.DAL.Entities.Warehouse.Coming;
/// <summary>
/// Документ поступления ТМЦ от поставщтков
/// </summary>
public class ComingTmc : Entity
{
    /// <summary> Статус документа поступления </summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary> Номер входящего документа </summary>
    private string _numberDoc = null!;
    public string NumberDoc { get => _numberDoc; set => Set(ref _numberDoc, value); }

    /// <summary> Дата входящего документа </summary>
    private DateTime _dateDoc = DateTime.Now;
    public DateTime DateDoc { get => _dateDoc; set => Set(ref _dateDoc, value); }

    /// <summary> Регистрационный номер документа </summary>
    private int _regNumber;
    public int RegNumber { get => _regNumber; set => Set(ref _regNumber, value); }

    /// <summary> Дата регистрации документа (принятия к учету) </summary>
    private DateTime _regDate = DateTime.Now;
    public DateTime RegDate { get => _regDate; set => Set(ref _regDate, value); }

    /// <summary> Получен оригинал документа? </summary>
    private bool _isOriginal;
    public bool IsOriginal { get => _isOriginal; set => Set(ref _isOriginal, value); }

    /// <summary> Контрагент-поставщик </summary>
    private Counterparty _counterparty = null!;
    public Counterparty Counterparty { get => _counterparty; set => Set(ref _counterparty, value); }

    /// <summary> Позиции (товары) документа поступления </summary>
    private FullyObservableCollection<ComingTmcPosition> _positions = new ();
    public FullyObservableCollection<ComingTmcPosition> Positions {get => _positions; set => Set(ref _positions, value); }

    /// <summary> Сумма документа </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary> Сумма НДС по документу </summary>
    private decimal _amountNds;
    public decimal AmountNds { get => _amountNds; set => Set(ref _amountNds, value); }

    /// <summary> Общая сумма по документу </summary>
    private decimal _totalAmount;
    public decimal TotalAmount { get => _totalAmount; set => Set(ref _totalAmount, value); }

    /// <summary>  Примечание </summary>
    private string? _note;
    public string? Note { get => _note; set => Set(ref _note, value); }

    /// <summary> Порядок расчетов с контрагентом </summary>
    private ComingTmcCalculations _comingTmcCalculations = null!;
    public ComingTmcCalculations ComingTmcCalculations { get => _comingTmcCalculations; set => Set(ref _comingTmcCalculations, value); }

    /// <summary>Прикрепленные файлы</summary>
    private ObservableCollection<ScanFile>? _scanFiles = new();
    public virtual ObservableCollection<ScanFile>? ScanFiles { get => _scanFiles; set => Set(ref _scanFiles, value); }

    /// <summary>История изменения документа </summary>
    private ObservableCollection<History>? _history = new();
    public virtual ObservableCollection<History>? History { get => _history; set => Set(ref _history, value); }

    /// <summary> Счет фактура </summary>
    private InvoiceFactur? _invoiceFactur;
    public InvoiceFactur? InvoiceFactur { get => _invoiceFactur; set => Set(ref _invoiceFactur, value); }

    /// <summary> Записи в регистри ТМЦ </summary>
    private ObservableCollection<TmcRegister>? _tmcRegisters;
    public ObservableCollection<TmcRegister>? TmcRegisters { get => _tmcRegisters; set => Set(ref _tmcRegisters, value); }

    /// <summary> Записи в регистре проводок </summary>
    private ObservableCollection<AccountingPlanRegister>? _accountingPlanRegisters;
    public ObservableCollection<AccountingPlanRegister>? AccountingPlanRegisters { get => _accountingPlanRegisters; set => Set(ref _accountingPlanRegisters, value); }

    /// <summary> Документ поступления является УПД </summary>
    private bool _isUpd;
    public bool IsUpd { get => _isUpd; set => Set(ref _isUpd, value); }

}
