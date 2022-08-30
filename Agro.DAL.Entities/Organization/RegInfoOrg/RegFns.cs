using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Organization.RegInfoOrg;
public class RegFns : Entity
{
    private string _codeFns = null!;
    public string CodeFns { get => _codeFns; set => Set(ref _codeFns, value); }

    private DateTime? _dateReg;
    public DateTime? DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    private string _nameFns = null!;
    public string NameFns { get => _nameFns; set => Set(ref _nameFns, value); }

    private string _addressFns = null!;
    public string AddressFns { get => _addressFns; set => Set(ref _addressFns, value); }
}
