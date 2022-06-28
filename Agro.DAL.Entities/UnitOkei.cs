using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;
public class UnitOkei: Entity
{
    [Required]
    [ForeignKey("StatusId")]
    public Status Status { get; set; } = null!;

    public  int StatusId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Abbreviation { get; set; }= null!;

    [Required]
    public string OkeiCode { get; set; } = null!;

    public override string ToString() => Abbreviation;


}
