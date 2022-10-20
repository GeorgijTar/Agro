using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Сведения о ликвидации (Прекращении деятельности)
/// </summary>
public class Likved : Entity
{
    /// <summary>Дата ликвидации (прекращения деятельности)</summary>
    private string _date = null!;
    public string Date { get => _date; set => Set(ref _date, value); }

    /// <summary>Причина ликвидации (прекращения деятельности)</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); } 


}
