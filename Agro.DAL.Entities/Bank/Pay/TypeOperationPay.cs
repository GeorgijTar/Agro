using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Bank.Pay;
/// <summary>
/// Тип операции платежа
/// </summary>
public class TypeOperationPay : Entity
{
    /// <summary> Наименование опервации </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    private bool _isEnabled;
    public bool IsEnabled { get => _isEnabled; set => Set(ref _isEnabled, value); }
}
