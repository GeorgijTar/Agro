﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;
using Agro.WPF.ViewModels.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// План счетов
/// </summary>
public class AccountingPlan :  Entity
{
   
    private Status _status = null!;

    [Required, ForeignKey("StatusId")]
    public Status Status { get=>_status; set=>Set(ref _status, value); }

    public int StatusId { get; set; }

    /// <summary>Наименование счета</summary>
    private string _name = null!;

    [Required]
    public string Name { get=>_name; set=>Set(ref _name, value); } 

    /// <summary>Номер счета</summary>
    private string _code = null!;

    [Required]
    public string Code { get=>_code; set=>Set(ref _code, value); }

    /// <summary>Вышестоящий счет</summary>
    private AccountingPlan? _accountingPlan;

    [ForeignKey("ParentPlanId")]
    public AccountingPlan? ParentPlan { get=>_accountingPlan; set=>Set(ref _accountingPlan, value); }

    public int? ParentPlanId { get; set; }

    /// <summary>Можно ли счет выбирать</summary>
    private bool _isSelect;
    public bool IsSelect { get=>_isSelect; set=>Set(ref _isSelect, value); }

    private ICollection<AccountingPlan> ? _accounts;
    public ICollection<AccountingPlan>? ChildPlans { get=>_accounts; set=>Set(ref _accounts, value); }

}
