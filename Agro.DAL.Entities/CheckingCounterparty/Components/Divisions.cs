
using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;
/// <summary>
/// Подразделения
/// </summary>
public class Divisions : Entity
{
    /// <summary> Филиалы </summary>
    private ObservableCollection<Branch>? _branches;
    public ObservableCollection<Branch>? Branches { get => _branches; set => Set(ref _branches, value); }

    /// <summary> Представительства организации </summary>
    private ObservableCollection<Branch>? _representativeOffices;
    public ObservableCollection<Branch>? RepresentativeOffices { get => _representativeOffices; set => Set(ref _representativeOffices, value); } 


}
