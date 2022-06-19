using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations;

namespace Agro.Domain.Base;

/// <summary>
/// Тип (документа, записи и т.д.)
/// </summary>
public class TypeDocDto : EntityDto
{
    public string Name { get; set; } = null!;

    public string TypeApplication { get; set; } = null!;

    public override string ToString() => Name;
}

