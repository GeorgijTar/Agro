using System.ComponentModel.DataAnnotations;

namespace Agro.DAL.Entities.Base;

/// <summary>
/// Контрагент
/// </summary>
public class Counterparty : NamedEntity
{
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

    public string? Okpo { get; set; }
}

