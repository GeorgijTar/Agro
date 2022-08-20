using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Agronomy;

/// <summary>
/// Поле
/// </summary>
public class Field : Entity
{
    public Field()
    {
        LandPlots = new ObservableCollection<LandPlot>();
        Status = new Status();
    }
    /// <summary>Статус</summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Наименование</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Отделение</summary>
    private Department _department = null!;
    public Department Department { get => _department; set => Set(ref _department, value); }

    /// <summary>Площадь</summary>
    private double _areal;
    public double Areal { get => _areal; set => Set(ref _areal, value); }

    /// <summary>Родительское поле</summary>
    private Field? _parentField;
    public Field? ParentField { get => _parentField; set => Set(ref _parentField, value); }

    /// <summary>Земельные участки входящие в состав поля</summary>
    private ObservableCollection<LandPlot>? _landPlots;
    public ObservableCollection<LandPlot>? LandPlots { get => _landPlots; set => Set(ref _landPlots, value); }

    public override string ToString() => $"{Department.AbbreviatedName} п. {Name} ({Areal} га.)";
}
