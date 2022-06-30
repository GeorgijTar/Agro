using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations;

namespace Agro.Domain.Base;

/// <summary>
/// Тип (документа, записи и т.д.)
/// </summary>
public class TypeDocDto : EntityDto
{
   
    
    private string _name;

    [Required]
    public string Name { get=>_name; set=>Set(ref _name, value); }

    private string _typeApplication;

    [Required]
    public string TypeApplication { get=> _typeApplication; set=>Set(ref _typeApplication, value); }


    public override string ToString() => Name;
}

