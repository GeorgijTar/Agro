using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Organization.RegInfoOrg;
/// <summary>
/// Регистрация в ФСС
/// </summary>
public class RegFss : Entity
{
    // <summary>Дата регистрации</summary>
    private DateTime? _dateReg;
    public DateTime? DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    /// <summary>Регистрационный номер</summary>
    private string _regNumber = null!;
    public string RegNumber { get => _regNumber; set => Set(ref _regNumber, value); }

    /// <summary>Код территориального органа ФСС</summary>
    private string? _codeFss;
    public string? CodeFss { get => _codeFss; set => Set(ref _codeFss, value); }

    /// <summary>Наименование территориального органа ФСС</summary>
    private string? _nameFss;
    public string? NameFss { get => _nameFss; set => Set(ref _nameFss, value); }
}