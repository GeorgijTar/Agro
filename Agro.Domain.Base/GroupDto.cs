//using System.ComponentModel.DataAnnotations.Schema;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

/// <summary>
/// Группа
/// </summary>
public class GroupDto : EntityDto
{
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    private string? _typeApplication;
    public string? TypeApplication { get => _typeApplication; set => Set(ref _typeApplication, value); }

    public override string ToString() => Name;
}

