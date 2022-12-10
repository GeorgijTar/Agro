

using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Bank.Pay;
public class TaxPeriod : Entity
{
    private string? _tax1;
    [MaxLength (2)]
    public string? Tax1 { get => _tax1; set => Set(ref _tax1, value); }

    private string? _tax2 ;
    [MaxLength(2)]
    public string? Tax2 { get => _tax2; set => Set(ref _tax2, value); }

    private string? _taxYear;
    [MaxLength(4)]
    public string? TaxYear { get => _taxYear; set => Set(ref _taxYear, value); }
}
