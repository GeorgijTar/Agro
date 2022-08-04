
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Agronomy;
/// <summary>
/// Отделение
/// </summary>
public class Department : Entity
{
    /// <summary>Статус</summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Наименование сокращенное</summary>
    private string _abbreviatedName = null!;
    public string AbbreviatedName { get => _abbreviatedName; set => Set(ref _abbreviatedName, value); }

    /// <summary>Наименование</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Список полей</summary>
    private IEnumerable<Field>? _fields;
    public IEnumerable<Field>? Fields { get => _fields; set => Set(ref _fields, value); } 

    public override string ToString() => Name;
}