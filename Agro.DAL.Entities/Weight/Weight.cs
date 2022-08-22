using Agro.DAL.Entities.Base;


namespace Agro.DAL.Entities.Weight;

public class Weight : Entity
{
    /// <summary>Статус</summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Наименование</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

   
    private Employee? _weigher;
    public Employee? Weigher { get => _weigher; set => Set(ref _weigher, value); }

    
    private string? _terminal;
    public string? Terminal { get => _terminal; set => Set(ref _terminal, value); }

    public override string ToString() => Name;

}
