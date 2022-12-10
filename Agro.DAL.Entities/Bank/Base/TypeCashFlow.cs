using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Bank.Base;

/// <summary>
/// Вид движения денежных средств
/// </summary>
public class TypeCashFlow : Entity
{
    /// <summary> Код </summary>
    private string _code = null!;
    public string Code { get => _code; set => Set(ref _code, value); }

    /// <summary> Наименование </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>
    /// Направление дыижения ДС
    /// true - Доходы
    /// false - Расходы
    /// </summary>
    private bool _direction;
    public bool Direction { get => _direction; set => Set(ref _direction, value); }
}