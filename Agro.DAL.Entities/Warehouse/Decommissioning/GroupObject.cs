
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Warehouse.Decommissioning;

/// <summary>
/// Группа объекта списания
/// </summary>
public class GroupObject : Entity
{
    // <summary> Статус </summary>
    private Status _status = null!;
    public Status Status { get => _status; set => Set(ref _status, value); }

    /// <summary>
    /// Наименование
    /// </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    public override string ToString()
    {
        return Name;
    }
}
