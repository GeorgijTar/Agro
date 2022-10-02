
using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

public class Product : Entity
{
    /// <summary>Статус</summary>
    private Status? _status = new();
    public  Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Сокращенное наименование</summary>
    private string _nameMini = null!;
    [Required]
    public string NameMini { get => _nameMini; set => Set(ref _nameMini, value); }

    /// <summary>Полное наименование (для документов)</summary>
    private string _name = null!;
    [Required]
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Примечание</summary>
    private string? _description;
    [MaxLength(225)]
    public string? Description { get => _description; set => Set(ref _description, value); }

    /// <summary>Группа готовой продукции</summary>
    private GroupDoc _group=new();
    public  GroupDoc Group { get=>_group; set=>Set(ref _group, value); }

    /// <summary>Единица измерения</summary>
    private UnitOkei _unit=new();
    public  UnitOkei Unit { get=>_unit; set=>Set(ref _unit, value); }

    /// <summary>НДС</summary>
    private Nds? _nds =new();
    public  Nds? Nds { get=>_nds; set=>Set(ref _nds, value); }

    /// <summary>Артикул</summary>
    private string? _articleNumber;
    public string? ArticleNumber { get=>_articleNumber; set=>Set(ref _articleNumber, value); }
}
