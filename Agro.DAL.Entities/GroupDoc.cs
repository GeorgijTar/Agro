using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Группа
/// </summary>
public class GroupDoc : Entity
{
    public string Name { get; set; } = null!;

    public string TypeApplication { get; set; } = null!;


    public override string ToString() => Name;
}

