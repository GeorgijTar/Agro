using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    [ForeignKey("StatusId")]
    public Status Status { get; set; } = null!;

    public  int StatusId { get; set; }

    /// <summary>Тип контрагента</summary>
   [ForeignKey("TypeDocId")]
    public TypeDoc? TypeDoc { get; set; } = null!;

    public  int? TypeDocId { get; set; }

    /// <summary>Группа</summary>
    [ForeignKey("GroupId")]
    public GroupDoc? Group { get; set; }

    public int GroupId { get; set; }

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

    /// <summary>Примечание</summary>
    [MaxLength(225)]
    public string? Description { get; set; }

    public ICollection<BankDetails>? BankDetails { get; set; } = new HashSet<BankDetails>();

}

