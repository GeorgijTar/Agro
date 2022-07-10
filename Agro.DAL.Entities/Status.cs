using Agro.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Agro.DAL.Entities;

/// <summary>
/// Статус документа
/// </summary>
public class Status : Entity
{
    [Required]
    public string Name { get; set; } = null!;

    public override string ToString() => Name;
}

