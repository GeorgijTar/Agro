
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// План счетов
/// </summary>
public class AccountingPlan : Entity
{
    [Required, ForeignKey("StatusId")]
    public Status Status { get; set; } = null!;

    public int StatusId { get; set; }

    /// <summary>Наименование счета</summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>Номер счета</summary>
    [Required]
    public string Code { get; set; } = null!;

    /// <summary>Вышестоящий счет</summary>
    [ForeignKey("ParentPlanId")]
    public AccountingPlan? ParentPlan { get; set; }

    public int? ParentPlanId { get; set; }

    /// <summary>Можно ли счет выбирать</summary>
    public bool IsSelect { get; set; }

    public ICollection<AccountingPlan>? ChildPlans { get; set; }

}
