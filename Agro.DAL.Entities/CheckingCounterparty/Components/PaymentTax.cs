
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

public class PaymentTax : Entity
{
    /// <summary> Наименование налога </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary> Сумма </summary>
    private float _amount;
    public float Amount { get => _amount; set => Set(ref _amount, value); } 

}