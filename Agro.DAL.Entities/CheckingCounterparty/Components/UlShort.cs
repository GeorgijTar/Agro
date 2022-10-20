
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Органы или юридические лица, осуществляющие права учредителя
/// </summary>
public class UlShort : Entity
{
    /// <summary>ОГРН организации</summary>
    private string _ogrn = null!;
    public string Ogrn { get => _ogrn; set => Set(ref _ogrn, value); }

    /// <summary>ИНН</summary>
    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    ///<summary>Полное наименование</summary>
    private string _fullName = null!;
    public string FullName { get => _fullName; set => Set(ref _fullName, value); }
}