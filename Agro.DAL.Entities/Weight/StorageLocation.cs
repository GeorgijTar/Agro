
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Weight;
/// <summary>
/// Место хранения (склад)
/// </summary>
public class StorageLocation : Entity
{
    /// <summary>Наименование</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Кладовщик</summary>
    private Employee _storekeeper = null!;
    public Employee Storekeeper { get => _storekeeper; set => Set(ref _storekeeper, value); }

    /// <summary>Отбор</summary>
    private string? _typeApplication;
    public string? TypeApplication { get => _typeApplication; set => Set(ref _typeApplication, value); }


}