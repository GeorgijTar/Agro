using System.Collections.ObjectModel;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Bank;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Warehouse.Coming;

/// <summary>
/// Порядок расчетов с контрагентом
/// </summary>
public class ComingTmcCalculations : Entity
{
    /// <summary> Счет учета расчетов с контрагентом </summary>
    private AccountingPlan _accountingPlan = null!;
    public AccountingPlan AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }

    /// <summary> Счет учета расчетов по авансам </summary>
    private AccountingPlan _accountingPlanPrepayment = null!;
    public AccountingPlan AccountingPlanPrepayment { get => _accountingPlanPrepayment; set => Set(ref _accountingPlanPrepayment, value); }

    #region CalculationMethod
    /// <summary> Автоматический зачет аванса </summary>
    private bool _autoCalculation;
    public bool AutoCalculation { get => _autoCalculation; set => Set(ref _autoCalculation, value); }

    /// <summary> Зачет ованса по документу (ручной) </summary>
    private bool _мanualCalculation;
    public bool ManualCalculation { get => _мanualCalculation; set => Set(ref _мanualCalculation, value); }

    /// <summary> Не зачитывать аванс </summary>
    private bool _noCalculation;
    public bool NoCalculation { get => _noCalculation; set => Set(ref _noCalculation, value); }

    /// <summary>
    /// Документы списаниря с расчетного счета для зачета аванса
    /// </summary>
    private ObservableCollection<DebitingAccount>? _debitingAccounts;
    public ObservableCollection<DebitingAccount>? DebitingAccounts { get => _debitingAccounts; set => Set(ref _debitingAccounts, value); }

    #endregion

}