
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

public class Product : Entity
{

    [Required]
    public string NameMini { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;

    [MaxLength (225)]
    public string? Description { get; set; }

    [ForeignKey("StatusId")]
    public Status Status { get; set; } = null!;
    public int StatusId { get; set; }

    [ForeignKey("TypeId")]
    public TypeDoc Type { get; set; } = null!;

    public int TypeId { get; set; }

    [ForeignKey("GroupId")]
    public GroupDoc Group { get; set; }=null!;

    public int GroupId { get; set; }

    [ForeignKey("UnitId")]
    public UnitOkei Unit { get; set; }=null!;

    public int UnitId { get; set; }

    [ForeignKey("NdsId")]
    public Nds? Nds { get; set; }

    public int? NdsId { get; set; }

    public string? ArticleNumber { get; set; }
}
