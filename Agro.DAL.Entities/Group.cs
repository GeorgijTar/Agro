using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Группа
/// </summary>
public class Group : Entity
{
    public string Name { get; set; } = null!;

    /// <summary>Вышестоящая группа</summary>
    public Group? ParentGroup { get; set; }

    /// <summary>Дочерние группы</summary>
    public ICollection<Group>? ChildGroups { get; set; }

    public Group(){}

    public Group(string name, Group? parentGroup=null)
    {
        Name=name;
        ParentGroup=parentGroup;
    }
    public override string ToString() => Name;
}

