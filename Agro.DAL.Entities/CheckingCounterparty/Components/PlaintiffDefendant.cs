using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Истец/Ответчик
/// </summary>
public class PlaintiffDefendant : Entity
{
    /// <summary>ИНН</summary>
    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    ///<summary>Наименование или Ф. И. О.</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>адрес</summary>
    private LegalAddress _address = null!;
    public LegalAddress Address { get => _address; set => Set(ref _address, value); }
}
