using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.General;
/// <summary>
/// Закрытый период
/// </summary>
public class ClosedPeriod : Entity
{
    /// <summary>
    /// Дата закрытого периода
    /// </summary>
    private DateTime _date;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary>
    /// Описание закрытого периода
    /// </summary>
    private string _description = null!;
    public string Description { get => _description; set => Set(ref _description, value); }
}
