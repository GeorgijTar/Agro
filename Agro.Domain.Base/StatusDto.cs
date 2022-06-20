using System.ComponentModel.DataAnnotations;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

/// <summary>
/// Статус документа
/// </summary>
public class StatusDto : EntityDto
{
    [Required]
    public string Name { get; set; } = null!;
  
    public override string ToString() => Name;

    public StatusDto()
    {
        Id = 1;
        Name = "Черновик";
    }
}

