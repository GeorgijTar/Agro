
using Agro.Dto.Base;

namespace Agro.Dto;

public class PositionDecommissioningTmcDto : BaseDto
{
    private Guid _guid;
    public Guid Guid { get => _guid; set => Set(ref _guid, value);
    }
    /// <summary> ИД ТМЦ </summary>
    private int _idTmc;
    public int IdTmc { get => _idTmc; set => Set(ref _idTmc, value); }

    /// <summary> Наименование ТМЦ </summary>
    private string _nameTmc = null!;
    public string NameTmc { get => _nameTmc; set => Set(ref _nameTmc, value); }

    /// <summary> Единица измерения </summary>
    private string _unitOkei = null!;
    public string UnitOkei { get => _unitOkei; set => Set(ref _unitOkei, value); }

    /// <summary> Количество </summary>
    private decimal _quantity;
    public decimal Quantity { get => _quantity; set => Set(ref _quantity, value); }

    /// <summary> Цена  </summary>
    private decimal _price;
    public decimal Price { get => _price; set => Set(ref _price, value); }

    /// <summary> Сумма по позиции (сумма для учета ТМЦ) </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary> Счет учета ТМЦ </summary>
    private string _accountingPlan = null!;
    public string AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }

    /// <summary> Склад </summary>
    private string _storageLocation = null!;
    public string StorageLocation { get => _storageLocation; set => Set(ref _storageLocation, value); } }
