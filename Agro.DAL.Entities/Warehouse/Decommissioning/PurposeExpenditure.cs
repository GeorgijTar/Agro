
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Warehouse.Decommissioning;

/// <summary>
/// Цель расходования
/// </summary>
public class PurposeExpenditure : Entity
{
    /// <summary>
    /// Статус
    /// </summary>
    private Status _status = null!;
    public Status Status { get => _status; set => Set(ref _status, value); }
    
    /// <summary>
    /// Наименование
    /// </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>
    /// Правило определения счета списания
    /// </summary>
    private AccountingPlan _accountingPlan = null!;
    public AccountingPlan AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }

    /// <summary>
    /// Примечание
    /// </summary>
    private string? _note;
    public string? Note { get => _note; set => Set(ref _note, value); } }