using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

/// <summary>
/// Статус документа
/// </summary>
public class StatusDto : EntityDto
{
    public string Name { get; set; } = null!;
    public StatusDto() { }

    public StatusDto(string name) => Name = name;

    public override string ToString() => Name;
}

