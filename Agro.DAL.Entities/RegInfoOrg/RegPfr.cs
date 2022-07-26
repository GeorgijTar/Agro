using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.RegInfoOrg;
public class RegPfr : Entity
{
    private DateTime? _dateReg;
    public DateTime? DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    private string _regNumber = null!;
    public string RegNumber { get => _regNumber; set => Set(ref _regNumber, value); }

    private string? _codePfr = null!;
    public string? CodePfr { get => _codePfr; set => Set(ref _codePfr, value); }

    private string? _namePfr = null!;
    public string? NamePfr { get => _namePfr; set => Set(ref _namePfr, value); }
}

