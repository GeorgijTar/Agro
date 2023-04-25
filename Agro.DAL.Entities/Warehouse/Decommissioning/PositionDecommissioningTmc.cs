
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Storage;

namespace Agro.DAL.Entities.Warehouse.Decommissioning;

public class PositionDecommissioningTmc : Entity
{
    /// <summary> Guid </summary>
    private Guid _guid = Guid.NewGuid();
    public Guid Guid { get => _guid; set => Set(ref _guid, value); }
    
    /// <summary> Родительский документ списания </summary>
    private DecommissioningTmc _decommissioningTmc = null!;
    public DecommissioningTmc DecommissioningTmc { get => _decommissioningTmc; set => Set(ref _decommissioningTmc, value); }

    /// <summary> Списываемый ТМЦ </summary>
    private Tmc _tmc = null!;
    public Tmc Tmc { get => _tmc; set => Set(ref _tmc, value); }

    /// <summary> Единица измерения </summary>
    private UnitOkei _unitOkei = null!;
    public UnitOkei UnitOkei { get => _unitOkei; set => Set(ref _unitOkei, value); }

    /// <summary> Количество </summary>
    private decimal _quantity;
    public decimal Quantity { get => _quantity; set => Set(ref _quantity, value); }

    /// <summary> Цена  </summary>
    private decimal _price;
    public decimal Price { get => _price; set => Set(ref _price, value); }

    /// <summary> Сумма по позиции (сумма для учета ТМЦ) </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary>
    /// Счет учета ТМЦ
    /// </summary>
    private AccountingPlan _accountingPlan = null!;
    public AccountingPlan AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }

    /// <summary> Место хранения ТМЦ </summary>
    private StorageLocation _storageLocation = null!;
    public StorageLocation StorageLocation { get => _storageLocation; set => Set(ref _storageLocation, value); }
}
