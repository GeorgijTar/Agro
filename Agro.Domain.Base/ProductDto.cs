
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;
public class ProductDto: NotifyPropertyChanged
{
    private string _nameMine=null!;
    [Required] 
    public string NameMini { get=>_nameMine; set=>Set(ref _nameMine, value); }

    private string _name = null!;
    [Required]
    public string Name { get=>_name; set=>Set(ref _name, value); }

    private string? _description;
    [MaxLength(225)]
    public string? Description { get=> _description; set=>Set(ref _description, value); }

    private StatusDto _status = null!;
    public StatusDto Status { get=> _status; set=>Set(ref _status, value); }
    
    private TypeDocDto _type = null!;
    public TypeDocDto Type { get=>_type; set=>Set(ref _type, value); }
    
    private GroupDto _group = null!;
    public GroupDto Group { get=>_group; set=>Set(ref _group, value); }

    private UnitOkeiDto _unit = null!;
    public UnitOkeiDto Unit { get=>_unit; set=>Set(ref _unit, value); }

    private NdsDto? _nds;
    public NdsDto? Nds { get=>_nds; set=>Set(ref _nds, value); }

    private string? _articleNumber;
    public string? ArticleNumber { get=> _articleNumber; set=>Set(ref _articleNumber, value); }

}
