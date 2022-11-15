using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Agronomy;

/// <summary>
/// Земельный участок
/// </summary>
public class LandPlot : Entity
{
    /// <summary>Статус</summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); } 

    /// <summary>Кадастровый номер</summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value); }

    /// <summary>Площадь участка</summary>
    private double _area;
    public double Area { get => _area; set => Set(ref _area, value); }

    /// <summary>Кадастровая стоимость</summary>
    private decimal _cost;
    public decimal Cost { get => _cost; set => Set(ref _cost, value); }

    /// <summary>Балансовая стоимость стоимость</summary>
    private decimal _balanceValue;
    public decimal BalanceValue { get => _balanceValue; set => Set(ref _balanceValue, value); }

    /// <summary>Тип собственности</summary>
    private TypeDoc? _type;
    public TypeDoc? Type { get => _type; set => Set(ref _type, value); }


    private ObservableCollection<Field> _fields = null!;
    public ObservableCollection<Field> Fields { get => _fields; set => Set(ref _fields, value); } 


}