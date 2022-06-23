
using System.ComponentModel.DataAnnotations;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;
public class UnitOkeiDto:NotifyPropertyChanged
{
    [Required]
    public StatusDto Status { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Abbreviation { get; set; } = null!;

    [Required]
    public string OkeiCode { get; set; } = null!;
}
