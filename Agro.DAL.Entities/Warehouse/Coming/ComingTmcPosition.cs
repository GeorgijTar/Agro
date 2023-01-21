
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Storage;

namespace Agro.DAL.Entities.Warehouse.Coming;
/// <summary>
/// Позиции прихода
/// </summary>
public class ComingTmcPosition : Entity<Guid>
{
    private ComingTmc _comingTmc = null!;
    public ComingTmc ComingTmc { get => _comingTmc; set => Set(ref _comingTmc, value); }

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

    /// <summary> Ставка НДС по позиции </summary>
    private Nds _nds = null!;
    public Nds Nds { get => _nds; set => Set(ref _nds, value); }

    /// <summary> Сумма НДС по позиции </summary>
    private decimal _amountNds;
    public decimal AmountNds { get => _amountNds; set => Set(ref _amountNds, value); }

    /// <summary> Итоговая сумма по позиции </summary>
    private decimal _totalAmount;
    public decimal TotalAmount { get => _totalAmount; set => Set(ref _totalAmount, value); }

    private AccountingPlan _accountingAccount = null!;
    public AccountingPlan AccountingAccount { get => _accountingAccount; set => Set(ref _accountingAccount, value); }

    private AccountingPlan? _accountingAccountNds;
    public AccountingPlan? AccountingAccountNds { get => _accountingAccountNds; set => Set(ref _accountingAccountNds, value); }

    /// <summary> Место хранения ТМЦ </summary>
    private StorageLocation _storageLocation = null!;
    public StorageLocation StorageLocation { get => _storageLocation; set => Set(ref _storageLocation, value); }

    /// <summary> Способ учета НДС </summary>
    private AccountingMethodNds? _accountingMethodNds;
    public AccountingMethodNds? AccountingMethodNds { get => _accountingMethodNds; set => Set(ref _accountingMethodNds, value); }

}