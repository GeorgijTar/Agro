using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Kassa.Base;

/// <summary>
/// Вид операции
/// </summary>
public class TypeOperationCash: Entity

{
    /// <summary>
    /// Тип документа
    /// </summary>
    private TypeDoc _typeDoc = null!;
    public TypeDoc TypeDoc { get => _typeDoc; set => Set(ref _typeDoc, value); }

    /// <summary>
    /// Наименование
    /// </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>
    /// Статья доходов или расходов
    /// </summary>
    private ItemExpenditureOrIncome? _itemExpenditureOrIncome;
    public ItemExpenditureOrIncome? ItemExpenditureOrIncome { get => _itemExpenditureOrIncome; set => Set(ref _itemExpenditureOrIncome, value); }

    private AccountingPlan? _accountingPlan;
    public AccountingPlan? AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }

    /// <summary>
    /// Признак формирования проводки
    /// </summary>
    private bool _isAccountingPlan;
    public bool IsAccountingPlan { get => _isAccountingPlan; set => Set(ref _isAccountingPlan, value); }


    public override string ToString()
    {
        return Name;
    }
}
