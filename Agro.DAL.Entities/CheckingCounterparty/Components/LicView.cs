using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Вид лицензируемой деятельности
/// </summary>
public class LicView : Entity
{

    /// <summary>
    /// Наименование вида лицензируемой деятельности
    /// </summary>
    private string _viewLic = null!;

    public string ViewLic
    {
        get => _viewLic;
        set => Set(ref _viewLic, value);
    } 

}
