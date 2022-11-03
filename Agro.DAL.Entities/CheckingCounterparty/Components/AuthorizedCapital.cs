using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Уставный капитал
/// </summary>
public class AuthorizedCapital : Entity
{
    /// <summary>
    /// Тип капитала, принимает значения
    /// "УСТАВНЫЙ КАПИТАЛ",
    /// "СКЛАДОЧНЫЙ КАПИТАЛ",
    /// "УСТАВНЫЙ ФОНД",
    /// "ПАЕВЫЕ ВЗНОСЫ" или "ПАЕВОЙ ФОНД"
    /// </summary>
    private string _type = null!;
    public string Type { get => _type; set => Set(ref _type, value); }

    /// <summary>Размер капитала, руб.</summary>
    private long _amount;
    public long Amount { get => _amount; set => Set(ref _amount, value); } 

}
