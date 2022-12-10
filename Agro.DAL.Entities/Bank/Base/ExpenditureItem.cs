

using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Bank.Base;

/// <summary>
/// Статья расходов/доходов
/// </summary>
public class ExpenditureItem : Entity
{
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary> Наименование </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    private TypeCashFlow _typeCashFlow = null!;
    public TypeCashFlow TypeCashFlow { get => _typeCashFlow; set => Set(ref _typeCashFlow, value); }

    /// <summary>
    /// Направление дыижения ДС
    /// true - Доходы
    /// false - Расходы
    /// </summary>
    private bool _direction;
    public bool Direction { get => _direction; set => Set(ref _direction, value); }
}
