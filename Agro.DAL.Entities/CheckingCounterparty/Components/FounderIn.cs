
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Учредители(участники) Иностранное Юредическое лицо
/// </summary>
public class FounderIn : Entity
{
    /// <summary>Признак ограничения доступа к сведениям от ФНС</summary>
    private bool _ogrDostup;
    public bool OgrDostup { get => _ogrDostup; set => Set(ref _ogrDostup, value); }

    ///<summary>Полное наименование</summary>
    private string _fullName = null!;
    public string FullName { get => _fullName; set => Set(ref _fullName, value); }

    /// <summary> Страна </summary>
    private string _country = null!;
    public string Country { get => _country; set => Set(ref _country, value); }

    /// <summary>Адрес</summary>
    private string _address = null!;
    public string Address { get => _address; set => Set(ref _address, value); }

    /// <summary>Регистрационный номер</summary>
    private string _regNumber = null!;
    public string RegNumber { get => _regNumber; set => Set(ref _regNumber, value); }

    /// <summary>Дата регистрации</summary>
    private DateTime _dateReg;
    public DateTime DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    /// <summary>Признак недостоверности сведений</summary>
    private bool _unreliability;
    public bool Unreliability { get => _unreliability; set => Set(ref _unreliability, value); }

    /// <summary>Описание причины признания сведений недостоверными</summary>
    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); }

    /// <summary>Доля в уставном капитале</summary>
    private Share _share = null!;
    public Share Share { get => _share; set => Set(ref _share, value); }

}
