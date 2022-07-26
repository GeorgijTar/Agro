using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore.Internal;

namespace Agro.DAL.Entities;

/// <summary>
/// Тип (документа, записи и т.д.)
/// </summary>
public class TypeDoc : Entity
{
   
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    private string _typeApplication =null!;
    public string TypeApplication { get => _typeApplication; set => Set(ref _typeApplication, value); }

    public override string ToString() => Name;
    
}

