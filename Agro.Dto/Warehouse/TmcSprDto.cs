using Agro.Dto.Base;

namespace Agro.Dto.Warehouse;
public class TmcSprDto : BaseDto
{
    /// <summary>
    /// Наименование ТМЦ
    /// </summary>
    private string _nameTmc = null!;
    public string NameTmc { get => _nameTmc; set => Set(ref _nameTmc, value); }

    /// <summary>
    /// Артикул
    /// </summary>
    private string _article = null!;
    public string Article { get => _article; set => Set(ref _article, value);}

    /// <summary>
    /// Ид единицы измерения
    /// </summary>
    private int _idUnit; 
    public int IdUnit { get => _idUnit; set => Set(ref _idUnit, value); }

    /// <summary>
    /// Единица измерения
    /// </summary>
    private string _unit = null!;
    public string Unit { get => _unit; set => Set(ref _unit, value); }

    /// <summary>
    /// Количество
    /// </summary>
    private decimal _quantity;
    public decimal Quantity { get => _quantity; set => Set(ref _quantity, value); }

    /// <summary>
    /// Цена
    /// </summary>
    
    public decimal Price => Math.Round(Amount / Quantity,2, MidpointRounding.AwayFromZero);

    /// <summary>
    /// Сумма
    /// </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary>
    /// Ид счета
    /// </summary>
    private int _idAccountingPlan;
    public int IdAccountingPlan {get => _idAccountingPlan; set => Set(ref _idAccountingPlan, value); }

    /// <summary>
    /// Счет учета ТМЦ
    /// </summary>
    private string _accountingPlanCode = null!;
    public string AccountingPlanCode { get => _accountingPlanCode; set => Set(ref _accountingPlanCode, value); }

    /// <summary>
    /// Id места хранения
    /// </summary>
    private int _idStorageLocation;
    public int IdStorageLocation { get => _idStorageLocation; set => Set(ref _idStorageLocation, value); }

    /// <summary>
    /// Место хранения ТМЦ
    /// </summary>
    private string _storageLocation = null!;
    public string StorageLocation { get => _storageLocation; set => Set(ref _storageLocation, value); }
}
