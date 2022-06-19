using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Группа
/// </summary>
public class GroupDoc : Entity
{
    public string Name { get; set; } = null!;

    /// <summary>Вышестоящая группа</summary>
   //[ForeignKey("ParentId")]
    public GroupDoc? ParentGroup { get; set; }
    //public int? ParentId { get; set; }

    /// <summary>Дочерние группы</summary>
    public ICollection<GroupDoc>? ChildGroups { get; set; }

    
    public override string ToString() => Name;
}

