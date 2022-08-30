using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Organization.RegInfoOrg;

public class RegFss : Entity
{
    private DateTime? _dateReg;
    public DateTime? DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    private string _regNumber = null!;
    public string RegNumber { get => _regNumber; set => Set(ref _regNumber, value); }

    private string? _codeFss = null!;
    public string? CodeFss { get => _codeFss; set => Set(ref _codeFss, value); }

    private string? _nameFss = null!;
    public string? NameFss { get => _nameFss; set => Set(ref _nameFss, value); }
}