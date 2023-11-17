
using Agro.DAL.Entities.Bank.Base;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Kassa.Base;

/// <summary>
/// Статья доходов или расходов
/// </summary>
public class ItemExpenditureOrIncome : Entity
{
    /// <summary>
    /// Наименование статьи
    /// </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>
    /// Вид движения денежных средств (ДДС)
    /// </summary>
    private TypeCashFlow? _typeCashFlow;
    public TypeCashFlow? TypeCashFlow { get => _typeCashFlow; set => Set(ref _typeCashFlow, value); }

    
    
    public override string ToString()
    {
        return Name;
    }

}
