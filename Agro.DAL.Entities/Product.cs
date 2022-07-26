
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

public class Product : Entity
{
    private string _nameMini = null!;
    [Required]
    public string NameMini { get => _nameMini; set => Set(ref _nameMini, value); }

    
    private string _name = null!;
    [Required]
    public string Name { get => _name; set => Set(ref _name, value); }


    private string? _description = null!;
    [MaxLength(225)]
    public string? Description { get => _description; set => Set(ref _description, value); }

    private Status _status = new();
    public virtual Status Status { get=>_status; set=>Set(ref _status, value); }
    

    private TypeDoc _type=new();
    public virtual TypeDoc Type { get=>_type; set=>Set(ref _type, value); }


    private GroupDoc _group=new();
    public virtual GroupDoc Group { get=>_group; set=>Set(ref _group, value); }
    

    private UnitOkei _unit=new();
    public virtual UnitOkei Unit { get=>_unit; set=>Set(ref _unit, value); }
    

    private Nds? _nds =new();
    public virtual Nds? Nds { get=>_nds; set=>Set(ref _nds, value); }


    private string? _articleNumber;
    public string? ArticleNumber { get=>_articleNumber; set=>Set(ref _articleNumber, value); }
}
