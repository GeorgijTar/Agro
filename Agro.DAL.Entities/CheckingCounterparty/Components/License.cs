
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Полученные лицензии
/// </summary>
public class License : Entity
{
    /// <summary> Номер </summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value); }

    /// <summary> Дата выдачи </summary>
    private DateTime _date;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary> Орган, выдавший лицензию </summary>
    private string _licOrg = null!;
    public string LicOrg { get => _licOrg; set => Set(ref _licOrg, value); }

    /// <summary> Виды лицензируемой деятельности </summary>
    private string _licView = null!;
    public string LicView { get => _licView; set => Set(ref _licView, value); } 

}