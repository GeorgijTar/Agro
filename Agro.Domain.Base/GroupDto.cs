//using System.ComponentModel.DataAnnotations.Schema;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

/// <summary>
/// Группа
/// </summary>
public class GroupDto : EntityDto
{
    public string Name { get; set; } = null!;

    public string TypeApplication { get; set; } = null!;

    public override string ToString() => Name;
}

