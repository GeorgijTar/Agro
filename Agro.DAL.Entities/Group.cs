using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Группа
/// </summary>
public class Group : NamedEntity
{
    /// <summary>Вышестоящая группа</summary>
    public Group? ParentGroup { get; set; }

    /// <summary>Дочерние группы</summary>
    public ICollection<Group>? ChildGroups { get; set; }
}

