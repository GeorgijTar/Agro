using System.ComponentModel.DataAnnotations;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

/// <summary>
/// Статус документа
/// </summary>
public class StatusDto : EntityDto
{
    [Required]
    public string Name { get; set; }

    public ICollection<CounterpartyDto>? Counterparties { get; set; } = new HashSet<CounterpartyDto>();

    public ICollection<BankDetailsDto>? BankDetails { get; set; } = new HashSet<BankDetailsDto>();

    public override string ToString() => Name;

    public StatusDto()
    {
        Id = 1;
        Name = "Черновик";
    }
}

