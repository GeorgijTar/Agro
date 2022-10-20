using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Управляющая организация
/// </summary>
public class ManagingOrganization : Entity
{
    /// <summary>Признак ограничения доступа к сведениям от ФНС</summary>
    private bool _ogrDostup;
    public bool OgrDostup { get => _ogrDostup; set => Set(ref _ogrDostup, value); }

    /// <summary>ОГРН организации</summary>
    private string _ogrn = null!;
    public string Ogrn { get => _ogrn; set => Set(ref _ogrn, value); }

    /// <summary>ИНН</summary>
    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    ///<summary>Полное наименование</summary>
    private string _fullName = null!;
    public string FullName { get => _fullName; set => Set(ref _fullName, value); }

    /// <summary>Страна, в том случае, если управляющая организация является иностранной</summary>
    private string? _inCountry;
    public string? Incountry { get => _inCountry; set => Set(ref _inCountry, value); }

    /// <summary>Адрес, в том случае, если управляющая организация является иностранной</summary>
    private string? _inAddress;
    public string? InAddress { get => _inAddress; set => Set(ref _inAddress, value); }

    /// <summary>Регистрационный номер, в том случае, если управляющая организация является иностранной</summary>
    private string? _inRegNumber ;
    public string? InRegNumber { get => _inRegNumber; set => Set(ref _inRegNumber, value); }

    /// <summary>
    /// Дата регистрации, в том случае, если управляющая организация является иностранной
    /// </summary>
    private string? _inDateReg;
    public string? IndateReg { get => _inDateReg; set => Set(ref _inDateReg, value); }

    /// <summary>Признак недостоверности сведений</summary>
    private bool _unreliability;
    public bool Unreliability { get => _unreliability; set => Set(ref _unreliability, value); }

    /// <summary>Описание причины признания сведений недостоверными</summary>
    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); }




}
