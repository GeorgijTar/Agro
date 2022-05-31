using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations;

namespace Agro.Domain.Base;

/// <summary>
/// Тип (документа, записи и т.д.)
/// </summary>
public class TypeDto : EntityDto
{
    public string Name { get; set; } = null!;

    public string TypeApplication { get; set; } = null!;
    public TypeDto() { }

    public TypeDto(string name, string typeApplication)
    {
        Name = name;
        TypeApplication = typeApplication;
    }
    public override string ToString() => Name;
}

