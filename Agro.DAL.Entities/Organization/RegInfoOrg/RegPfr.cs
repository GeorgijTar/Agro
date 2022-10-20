using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Organization.RegInfoOrg;

/// <summary>
/// Регистрация в ПФР
/// </summary>
public class RegPfr : Entity
{
    /// <summary>Дата регистрации</summary>
    private DateTime? _dateReg;
    public DateTime? DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    /// <summary>Регистрационный номер</summary>
    private string _regNumber = null!;
    public string RegNumber { get => _regNumber; set => Set(ref _regNumber, value); }

    /// <summary>Код территориального органа ПФР</summary>
    private string? _codePfr = null!;
    public string? CodePfr { get => _codePfr; set => Set(ref _codePfr, value); }

    /// <summary>Наименование территориального органа ПФР</summary>
    private string? _namePfr = null!;
    public string? NamePfr { get => _namePfr; set => Set(ref _namePfr, value); }
}

