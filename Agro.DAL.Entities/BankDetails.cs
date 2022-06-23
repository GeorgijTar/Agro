using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Банковские реквизиты
/// </summary>
public class BankDetails : Entity
{
    public string Title { get; set; } = null!;

    /// <summary>Статус реквизитов</summary>
   [Required]
    [ForeignKey("StatusId")]
    public Status Status { get; set; } = null!;

    public int StatusId { get; set; }

    [Required]
    [ForeignKey("CounterpartyId")]
    public Counterparty Counterparty { get; set; }= null!;

    public int CounterpartyId { get; set; }

    /// <summary>Наименование банка</summary>
    [Required]
    public string NameBank { get; set; } = null!;

    /// <summary>Город банка</summary>
    public string City { get; set; } = null!;

    /// <summary>Расчетный счет</summary>
    [Required, MaxLength(20)]
    public string Bs { get; set; } = null!;

    /// <summary>БИК банка</summary>
    [Required, MaxLength(9)]
    public string Bik { get; set; } = null!;

    /// <summary>Кор. счет</summary>
    [Required, MaxLength(20)]
    public string Ks { get; set; } = null!;

    /// <summary>Примечание</summary>
    [MaxLength(225)]
    public string? Description { get; set; }


   public override string ToString() => $"{Bs} в {NameBank}";
}

