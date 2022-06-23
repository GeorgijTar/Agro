using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Тип (документа, записи и т.д.)
/// </summary>
public class TypeDoc : Entity
{
    public string Name { get; set; } = null!;

    public string TypeApplication { get; set; } = null!;

    
   
    public override string ToString() => Name;
}

