using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;
/// <summary>
/// Номер телефона
/// </summary>
public class Phone : Entity
{
    /// <summary>
    /// Номер телефона
    /// </summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value);
    }

}
