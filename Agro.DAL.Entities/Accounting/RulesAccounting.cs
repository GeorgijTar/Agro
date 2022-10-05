﻿
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Accounting;
/// <summary>
/// Правило определения счета учета
/// </summary>
public class RulesAccounting : Entity
{
    /// <summary>Статус</summary>
    private Status? _status = null!;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Счет учета МПЗ</summary>
    private AccountingPlan _accountingPlan = null!;
    public AccountingPlan AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }

    /// <summary>Счет учета НДС по приобретенным ценностям</summary>
    private AccountingPlan? _accountingPlanNds;
    public AccountingPlan? AccountingPlanNds { get => _accountingPlanNds; set => Set(ref _accountingPlanNds, value); }

    /// <summary>Описание</summary>
    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); }



}