
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Warehouse.Coming;

namespace Agro.DAL.Entities.Registers;

/// <summary> Регистр проводок </summary>
public class AccountingPlanRegister : Entity<Guid>
{
    /// <summary> Дата записи в регистре </summary>
    private DateTime _dateReg;
    public DateTime DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    /// <summary> Счет дебит </summary>
    private AccountingPlan _debit = null!;
    public AccountingPlan Debit { get => _debit; set => Set(ref _debit, value); }

    /// <summary> Счет кредит </summary>
    private AccountingPlan _credit = null!;
    public AccountingPlan Credit { get => _credit; set => Set(ref _credit, value); }

    /// <summary> Сумма проводки </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary> Описание документа основания </summary>
    private string? _contaDoc;
    public string? ContaDoc { get => _contaDoc; set => Set(ref _contaDoc, value); }

    /// <summary> Описание действия </summary>
    private string? _contaAction;
    public string? ContaAction { get => _contaAction; set => Set(ref _contaAction, value); }

    /// <summary> Описание участника операции </summary>
    private string? _contaParty;
    public string? ContaParty { get => _contaParty; set => Set(ref _contaParty, value); }

    /// <summary> Описание объекта операции </summary>
    private string? _contaObject;
    public string? ContaObject { get => _contaObject; set => Set(ref _contaObject, value); }

    /// <summary> Родительский документ поступения </summary>
    private ComingTmc _comingTmc = null!;
    public ComingTmc ComingTmc { get => _comingTmc; set => Set(ref _comingTmc, value); }
}
