
using System.Collections.ObjectModel;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.Personnel;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.Warehouse;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.DAL.Entities.Warehouse.Decommissioning;

namespace Agro.DAL.Entities.Registers;
/// <summary>
/// Регистр ТМЦ
/// </summary>
public class TmcRegister : Entity<Guid>
{
    
    /// <summary> Тип операции (приход, расход) </summary>
    private TypeDoc _typeDoc = null!;
    public TypeDoc TypeDoc { get => _typeDoc; set => Set(ref _typeDoc, value); }

    /// <summary> Дата записи </summary>
    private DateTime _dateRegister;
    public DateTime DateRegister { get => _dateRegister; set => Set(ref _dateRegister, value); }

    /// <summary> Родительский документ поступения </summary>
    private ComingTmc? _comingTmc;
    public ComingTmc? ComingTmc { get => _comingTmc; set => Set(ref _comingTmc, value); }

    private DecommissioningTmc? _decommissioningTmc;
    public DecommissioningTmc? DecommissioningTmc { get => _decommissioningTmc; set => Set(ref _decommissioningTmc, value); }

    /// <summary> Товар </summary>
    private Tmc _tmc = null!;
    public Tmc Tmc { get => _tmc; set => Set(ref _tmc, value); }

    /// <summary> Единица измерения </summary>
    private UnitOkei _unitOkei = null!;
    public UnitOkei UnitOkei { get => _unitOkei; set => Set(ref _unitOkei, value); }

    /// <summary> Количество товара </summary>
    private decimal _quantity;
    public decimal Quantity { get => _quantity; set => Set(ref _quantity, value); }

    /// <summary> Цена товара </summary>
    private decimal _price;
    public decimal Price { get => _price; set => Set(ref _price, value); }

    /// <summary> Сумма по позиции (сумма для учета ТМЦ) </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary> Сумма НДС по позиции </summary>
    private decimal _amountNds;
    public decimal AmountNds { get => _amountNds; set => Set(ref _amountNds, value); }

    private AccountingPlan _debit = null!;
    public AccountingPlan Debit { get => _debit; set => Set(ref _debit, value); }

    private AccountingPlan _credit = null!;
    public AccountingPlan Credit { get => _credit; set => Set(ref _credit, value); }
    
    /// <summary> Место хранения ТМЦ </summary>
    private StorageLocation _storageLocation = null!;
    public StorageLocation StorageLocation { get => _storageLocation; set => Set(ref _storageLocation, value); }

    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); }

}
