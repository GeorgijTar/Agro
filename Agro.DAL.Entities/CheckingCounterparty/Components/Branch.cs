
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;
/// <summary>
/// Филиал
/// </summary>
public class Branch : Entity
{
    /// <summary>Признак ограничения доступа к сведениям от ФНС</summary>
    private bool _ogrDostup;
    public bool OgrDostup { get => _ogrDostup; set => Set(ref _ogrDostup, value); }

    ///<summary>Полное наименование</summary>
    private string _fullName = null!;
    public string FullName { get => _fullName; set => Set(ref _fullName, value); }

    ///<summary>КПП</summary>
    private string _kpp = null!;
    public string Kpp { get => _kpp; set => Set(ref _kpp, value); }

    /// <summary>Российский адрес</summary>
    private LegalAddress? _legalAddress;
    public LegalAddress? LegalAddress { get => _legalAddress; set => Set(ref _legalAddress, value); }

    /// <summary> Страна </summary>
    private string? _country;
    public string? Country { get => _country; set => Set(ref _country, value); }

    /// <summary>Иностранный адрес</summary>
    private LegalAddress? _inAddress;
    public LegalAddress? InAddress { get => _inAddress; set => Set(ref _inAddress, value); }
}
