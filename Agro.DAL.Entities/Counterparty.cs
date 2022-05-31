using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.DAL.Entities;

/// <summary>
/// Контрагент
/// </summary>
[Index(nameof(Inn), IsUnique = true, Name = "NameIndex")]
public class Counterparty : Entity
{
    public string Name { get; set; } = null!;

    /// <summary>Статус контрагента</summary>
    [Required]
    public Status Status { get; set; } = null!;

    /// <summary>Тип контрагента</summary>
    [Required]
    public Type Type { get; set; } = null!;

    /// <summary>Группа</summary>
    public Group? Group { get; set; }
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
    //public Address? ActualAddress { get; set; }

    public ICollection<BankDetails> BankDetails { get; set; } = new HashSet<BankDetails>();

}

