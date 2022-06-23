
using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;
public class Nds: Entity
{
    [Required] 
    public string Name { get; set; } = null!;

    [Required]
    public int Percent { get; set; }
}
