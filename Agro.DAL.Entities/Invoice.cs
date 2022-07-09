
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Счета
/// </summary>
public class Invoice : Entity
{
    /// <summary>Статус счета</summary>
    [Required, ForeignKey("StatusId")]
    public Status Status { get; set; } = null!;

    public int StatusId { get; set; }

    /// <summary>Номер счета</summary>
    [Required]
    public string Number { get; set; } = null!;

    /// <summary>Дата счета</summary>
    [Required]
    public DateTime DateInvoce { get; set; }

    /// <summary>Тип счета</summary>
    [Required, ForeignKey("TypeId")]
    public TypeDoc Type { get; set; } = null!;

    public int TypeId { get; set; }

    /// <summary>Контрагент счета</summary>
    [Required, ForeignKey("CounterpartyId")]
    public Counterparty Counterparty { get; set; } = null!;

    public int CounterpartyId { get; set; }

    /// <summary>Платежные реквизиты контрагента счета</summary>
    [Required, ForeignKey("BankDetailsId")]
    public BankDetails BankDetails { get; set; }= null!;

    public int BankDetailsId { get; set; }

    /// <summary>Сумма счета</summary>
    [Required]
    public decimal Amount { get; set; }

    /// <summary>Описание счета</summary>
    public string? Description { get; set; }

    /// <summary>Прикрепленные файлы</summary>
    public ICollection<ScanFile>? ScanFiles { get; set; }

    /// <summary>Платежные реквизиты организации</summary>
    public BankDetails? BankDetailsOrg { get; set; }

}
