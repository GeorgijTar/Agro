using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;
/// <summary>
/// Особый режим налогообложения
/// </summary>
public class ModeNalog : Entity
{

    /// <summary>
    /// Наименование особого режима налогообложения
    /// </summary>
    private string _mode = null!;

    public string Mode { get => _mode; set => Set(ref _mode, value); } 

}
