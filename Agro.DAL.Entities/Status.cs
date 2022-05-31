using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Статус документа
/// </summary>
public class Status : NamedEntity
{
    public Status() { }

    public Status(string name) => Name = name;

    public override string ToString() => Name;
}

