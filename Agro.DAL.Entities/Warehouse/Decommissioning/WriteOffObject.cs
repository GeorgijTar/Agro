using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Warehouse.Decommissioning;
/// <summary>
/// Объекты списания (техника, здания, сооружения и т.д.)
/// </summary>
public class WriteOffObject: Entity
{
    /// <summary>
    /// Статус
    /// </summary>
    private Status _status = null!;
    public Status Status { get => _status; set => Set(ref _status, value); }

    /// <summary>
    /// Тип
    /// </summary>
    private TypeObject _typeObject = null!;
    public TypeObject TypeObject { get => _typeObject; set => Set(ref _typeObject, value); }

    /// <summary>
    /// Группа объекта списания
    /// </summary>
    private GroupObject? _groupObject = null!;
    public GroupObject? GroupObject { get => _groupObject; set => Set(ref _groupObject, value); }

    /// <summary>
    /// Наименование
    /// </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>
    /// Инвентарный номер (если есть)
    /// </summary>
    private string? _invNumber;
    public string? InvNumber { get => _invNumber; set => Set(ref _invNumber, value); }

    /// <summary>
    /// Регистрационный номер (если есть)
    /// </summary>
    private string? _regNumber;
    public string? RegNumber { get => _regNumber; set => Set(ref _regNumber, value); }

    /// <summary>
    /// примечание
    /// </summary>
    private string? _note;
    public string? Note { get => _note; set => Set(ref _note, value); }


}
