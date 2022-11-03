
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Информация о включении в Единый реестр субъектов малого и среднего предпринимательства
/// </summary>
public class Rmsp : Entity
{
    /// <summary>
    /// Категория реестра МСП, принимает значения "МИКРОПРЕДПРИЯТИЕ", "МАЛОЕ ПРЕДПРИЯТИЕ" или "СРЕДНЕЕ ПРЕДПРИЯТИЕ"
    /// </summary>
    private string? _cat = null!;
    public string? Cat { get => _cat; set => Set(ref _cat, value); }


    /// <summary>
    /// Дата включения в реестр
    /// </summary>
    private DateTime? _date;
    public DateTime? Date { get => _date; set => Set(ref _date, value); } 


}
