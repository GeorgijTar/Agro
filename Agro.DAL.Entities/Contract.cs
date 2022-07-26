
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

public class Contract : Entity
{
    /// <summary>Статус договора</summary>
    [Required, ForeignKey("StatusId")]
    public virtual Status Status { get; set; } = null!;

    public int StatusId { get; set; }

    /// <summary>Тип договора</summary>
    [Required, ForeignKey("TypeId")]
    public virtual TypeDoc Type { get; set; } = null!;

    public int TypeId { get; set; }

    /// <summary>Группа договора</summary>
    [Required, ForeignKey("GroupId")]
    public virtual GroupDoc Group { get; set; } = null!;

    public int GroupId { get; set; }

    /// <summary>Номер договора</summary>
    public string Number { get; set; } = null!;

    /// <summary>Дата договора</summary>
    public DateTime Date { get; set; }

    /// <summary>Контрагент по договору</summary>
    [Required, ForeignKey("CounterpartyId")]
    public virtual Counterparty Counterparty { get; set; } = null!;

    public int CounterpartyId { get; set; }

    /// <summary>Платежные реквизиты контрагента договора</summary>
    [Required, ForeignKey("BankDetailsId")]
    public virtual BankDetails BankDetails { get; set; } = null!;

    public int BankDetailsId { get; set; }

    /// <summary>Предмет договора</summary>
    public string Subject { get; set; } = null!;

    /// <summary>Сумма договора</summary>
    public decimal Amount { get; set; }

    /// <summary>Примечание к договору</summary>
    public string? Description { get; set; }

    /// <summary>Прикрепленные файлы</summary>
    public virtual ICollection<ScanFile>? ScanFiles { get; set; } 

}
