
using System.ComponentModel.DataAnnotations;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;
public class AccountingPlanDto:EntityDto
{
    private StatusDto _status=null!;
    public StatusDto Status { get=>_status; set=>Set(ref _status, value); }

    private string _name = null;
    /// <summary>Наименование счета</summary>
    [Required]
    public string Name { get=>_name; set=>Set(ref _name, value); }

    private string _code = null;
    /// <summary>Номер счета</summary>
    [Required]
    public string Code { get=>_code; set=>Set(ref _code, value); }

    private AccountingPlanDto? _parentPlan;
    /// <summary>Вышестоящий счет</summary>
    public AccountingPlanDto? ParentPlan { get=>_parentPlan; set=>Set(ref _parentPlan, value); }

    private bool _isSelect;
    /// <summary>Можно ли счет выбирать</summary>
    public bool IsSelect { get=>_isSelect; set=>Set(ref _isSelect, value); }

    private ICollection<AccountingPlanDto>? _childPlans;
    public ICollection<AccountingPlanDto>? ChildPlans { get=>_childPlans; set=>Set(ref _childPlans, value); } 
}
