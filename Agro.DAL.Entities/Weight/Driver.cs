using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Weight;

public class Driver : Entity
{
    public Driver()
    {
        Transports=new ObservableCollection<Transport>();
    }

    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Фамилия</summary>
    private string _surname = null!;
    public string Surname { get => _surname; set => Set(ref _surname, value); }

    /// <summary>Имя</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Отчетво</summary>
    private string _patronymic = null!;
    public string Patronymic { get => _patronymic; set => Set(ref _patronymic, value); }

    /// <summary>Автомобили</summary>
    private ObservableCollection<Transport>? _transports ;
    public ObservableCollection<Transport>? Transports { get => _transports; set => Set(ref _transports, value); }

    public override string ToString() => $"{Surname} {Name[0]}. {Patronymic[0]}.";
}