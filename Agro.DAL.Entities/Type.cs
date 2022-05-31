using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Тип (документа, записи и т.д.)
/// </summary>
public class Type : NamedEntity
{
    /// <summary>Статус</summary>
    [Required]
    public Status Status { get; set; } = null!;

    public Type() { }

    public Type(string name)
    {
        Name = name;
    }
    public override string ToString() => Name;
}

