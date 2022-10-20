using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Финансовая отчетность
/// </summary>
public class CheckBalance : Entity
{
    /// <summary> Отчетный год </summary>
    private int _year;
    public int Year { get => _year; set => Set(ref _year, value); }
    
    /// <summary>
    /// Строки фин. отчетности.
    /// </summary>
    private ObservableCollection<Balanceline>? _balancelines;
    public ObservableCollection<Balanceline>? Balancelines { get => _balancelines; set => Set(ref _balancelines, value); } 

}
