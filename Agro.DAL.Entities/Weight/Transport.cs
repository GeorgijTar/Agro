
using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Weight;

public class Transport : Entity
{
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); } 

    /// <summary>Марка авто</summary>
    private string _carBrand = null!;
    public string CarBrand { get => _carBrand; set => Set(ref _carBrand, value); }

    /// <summary>Регистрационный номер</summary>
    private string _regNumber = null!;
    public string RegNumber { get => _regNumber; set => Set(ref _regNumber, value); }

    /// <summary>Регистрационный номер прицепа</summary>
    private string? _trailerNumber = null!;
    public string? TrailerNumber { get => _trailerNumber; set => Set(ref _trailerNumber, value); }

    /// <summary>Закрепленные водители</summary>
    private ObservableCollection<Driver>? _drivers = null!;
    public ObservableCollection<Driver>? Drivers { get => _drivers; set => Set(ref _drivers, value); } 


}