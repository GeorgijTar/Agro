using System.Collections.ObjectModel;
using Agro.Dto.Base;

namespace Agro.Dto;
/// <summary>
/// ДТО модель документа списания
/// </summary>
public class DecommissioningTmcDto : BaseDto
{

    
    private int _idStatus;
    public int IdStatus { get => _idStatus; set => Set(ref _idStatus, value); }
    
    /// <summary>
    /// Наименование статуса документа списания
    /// </summary>
    private string _status = null!;
    public string Status { get => _status; set => Set(ref _status, value); }

    /// <summary>
    /// ИД статуса
    /// </summary>
    private int _statusId; 
    public int StatusId {get => _statusId; set => Set(ref _statusId, value); }

    /// <summary>
    /// Тип документа
    /// </summary>
    private string _typeDoc = null!;
    public string TypeDoc { get => _typeDoc; set => Set(ref _typeDoc, value); }
    /// <summary>
    /// Номер документа списания
    /// </summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value); }
    
    /// <summary>
    /// Дата документа списания
    /// </summary>
    private DateTime _date;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary>
    /// Наименование объекта списания
    /// </summary>
    private string _writeOffObject = null!;
    public string WriteOffObject { get => _writeOffObject; set => Set(ref _writeOffObject, value); }


    /// <summary>
    /// Инвентарный номер объекта списания
    /// </summary>
    private string _writeOffObjectInvNumber = null!;
    public string WriteOffObjectInvNumber { get => _writeOffObjectInvNumber; set => Set(ref _writeOffObjectInvNumber, value); }

    /// <summary>
    /// Регистрационный номер объекта списания
    /// </summary>
    private string _writeOffObjectRegNumber = null!;
    public string WriteOffObjectRegNumber { get => _writeOffObjectRegNumber; set => Set(ref _writeOffObjectRegNumber, value); }

    /// <summary>
    /// Сумма документа списания
    /// </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }
    
    /// <summary>
    /// Примечание к документу списания
    /// </summary>
    private string _note = null!;
    public string Note { get => _note; set => Set(ref _note, value); }

    /// <summary> Цель расходования </summary>
    private string _purposeExpenditure = null!;
    public string PurposeExpenditure { get => _purposeExpenditure; set => Set(ref _purposeExpenditure, value); }

    /// <summary>
    /// позиции документа списания
    /// </summary>
    private ObservableCollection<PositionDecommissioningTmcDto> _position = null!;
    public ObservableCollection<PositionDecommissioningTmcDto> Position { get => _position; set => Set(ref _position, value); }
}

