using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;
public class UnitOkei: Entity
{
   private string _name = null!;
    [Required]
    public string Name { get=>_name; set=>Set(ref _name, value); } 

    private string _abbreviation = null!;
    [Required]
    public string Abbreviation { get=>_abbreviation; set=>Set(ref _abbreviation, value); }

    private string _okeiCode = null!;
    [Required]
    public string OkeiCode { get=>_okeiCode; set=>Set(ref _okeiCode, value); }

    public override string ToString() => Abbreviation;


}
