

using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Weight;
/// <summary>
/// Поступление с поля
/// </summary>
public class ComingField : Entity

{
    /// <summary>Статус</summary>
    private Status _status = null!;
    public Status Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Номер документа</summary>
    private int _number;
    public int Number { get => _number; set => Set(ref _number, value); }

    /// <summary>Дата документа</summary>
    private DateTime _date = DateTime.Now;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary>Весовая</summary>
    private Weight _weight = null!;
    public Weight Weight { get => _weight; set => Set(ref _weight, value); }

    /// <summary>Место хранения</summary>
    private StorageLocation _storageLocation = null!;
    public StorageLocation StorageLocation { get => _storageLocation; set => Set(ref _storageLocation, value); }

    /// <summary>Поле</summary>
    private Field _field = null!;
    public Field Field { get => _field; set => Set(ref _field, value); }

    /// <summary>Культура</summary>
    private Culture _culture = null!;
    public Culture Culture { get => _culture; set => Set(ref _culture, value); }

    /// <summary>Водитель</summary>
    private Driver _driver = null!;
    public Driver Driver { get => _driver; set => Set(ref _driver, value); }

    /// <summary>Транспорт</summary>
    private Transport _transport = null!; 
    public Transport Transport {get => _transport; set => Set(ref _transport, value); }

    /// <summary>Вес брутто</summary>
    private double _vesBrutto;
    public double VesBrutto { get => _vesBrutto; set => Set(ref _vesBrutto, value); }

    /// <summary>Вес тара</summary>
    private double _vesTara;
    public double VesTara { get => _vesTara; set => Set(ref _vesTara, value); }

    /// <summary>Вес нетто</summary>
    private double _vesNetto;
    public double VesNetto { get => _vesNetto; set => Set(ref _vesNetto, value); } 
    
    /// <summary>Примечание</summary>
    private string _note = null!;
    public string Note { get => _note; set => Set(ref _note, value); }

}