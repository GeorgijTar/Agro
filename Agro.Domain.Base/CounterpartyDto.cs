using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations;

namespace Agro.Domain.Base;

/// <summary>
/// Контрагент
/// </summary>

public class CounterpartyDto : EntityDto
{

    public string Name { get; set; } = null!;
    /// <summary>Статус контрагента</summary>
    [Required]
    public StatusDto Status { get; set; } = null!;

    /// <summary>Тип контрагента</summary>
    [Required]
    public TypeDto Type { get; set; } = null!;

    /// <summary>Группа</summary>
    public GroupDto? Group { get; set; }
    /// <summary>Платежное наименование контрагента</summary>
    [Required, MaxLength(255)]
    public string PayName { get; set; } = null!;

    /// <summary>ИНН контрагента</summary>
    [Required, MinLength(10), MaxLength(12)]
    public string Inn { get; set; } = null!;

    /// <summary>КПП контрагента</summary>
    [Required, MaxLength(9)]
    public string Kpp { get; set; } = null!;

    /// <summary>ОГРН контрагента</summary>
    public string? Ogrn { get; set; }

    /// <summary>ОКПО контрагента</summary>
    public string? Okpo { get; set; }
    
    /// <summary>Фактический адрес контрагента</summary>
    //public AddressDto? ActualAddress { get; set; }

    public ICollection<BankDetailsDto> BankDetails { get; set; } = new HashSet<BankDetailsDto>();

}

