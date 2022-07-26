
using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;
public class Nds: Entity
{
    private string _name = null!;
    [Required] 
    public string Name { get=>_name; set=>Set(ref _name, value); }

    private int _percent;
    [Required]
    public int Percent { get=>_percent; set=>Set(ref _percent, value); }

    private decimal _overPercent;
    [Required]
    public decimal OverPercent { get=>_overPercent; set=>Set(ref _overPercent, value); }


    public override string ToString() => Name;
}
