
using System.ComponentModel.DataAnnotations;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

public class NdsDto:NotifyPropertyChanged
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int Percent { get; set; }
}
