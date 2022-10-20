using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Organization.RegInfoOrg;

/// <summary>
/// Постановка на учет в налоговом органе
/// </summary>
public class RegFns : Entity
{
    /// <summary>Код налогового органа</summary>
    private string _codeFns = null!;
    public string CodeFns { get => _codeFns; set => Set(ref _codeFns, value); }
    
    /// <summary>Наименование налогового органа</summary>
    private string _nameFns = null!;
    public string NameFns { get => _nameFns; set => Set(ref _nameFns, value); }

    /// <summary>Адрес налогового органа</summary>
    private string _addressFns = null!;
    public string AddressFns { get => _addressFns; set => Set(ref _addressFns, value); }
}
