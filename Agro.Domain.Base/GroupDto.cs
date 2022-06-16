using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

/// <summary>
/// Группа
/// </summary>
public class GroupDto : EntityDto
{
    public string Name { get; set; } = null!;
    /// <summary>Вышестоящая группа</summary>
    public GroupDto? ParentGroup { get; set; }

    /// <summary>Дочерние группы</summary>
    public ICollection<GroupDto>? ChildGroups { get; set; }

    public override string ToString() => Name;
}

