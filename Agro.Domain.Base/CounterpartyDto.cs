using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Domain.Base;

/// <summary>
/// Контрагент
/// </summary>

public class CounterpartyDto : EntityDto
{
    public CounterpartyDto()
    {
        Status = new StatusDto();
        TypeDoc = new TypeDocDto();
        Group = new GroupDto();
    }


    public string Name { get; set; } = null!;
    /// <summary>Статус контрагента</summary>
    //[ForeignKey("StatusDtoId")]
   public StatusDto Status { get; set; } = null!;
    //public int StatusDtoId { get; set; }
    /// <summary>Тип контрагента</summary>
    //[ForeignKey("TypeDocId")]
    public TypeDocDto TypeDoc { get; set; } = null!;
    //public int TypeDocId { get; set; }

    /// <summary>Группа</summary>
    //[ForeignKey("GroupId")]
    public GroupDto? Group { get; set; }
    //public int GroupId { get; set; }

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

