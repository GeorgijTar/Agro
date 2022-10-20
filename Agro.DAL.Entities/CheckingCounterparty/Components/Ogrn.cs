using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// ОГРН (используется для списков)
/// </summary>
public class Ogrn : Entity
{
    /// <summary>
    /// Номер Огрн
    /// </summary>
    private string _numberOgrn = null!;
    public string NumberOgrn { get => _numberOgrn; set => Set(ref _numberOgrn, value); } 

}
