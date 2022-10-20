using Agro.DAL.Entities.Base;


namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary> Адрес электронной почты </summary>
public class Email : Entity
{
    /// <summary> Email </summary>
    private string _email = null!;
    public string Mail { get => _email; set => Set(ref _email, value); } 

}
