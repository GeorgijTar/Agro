using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Статус документа
/// </summary>
public class Status : Entity
{
    public string Name { get; set; } = null!;
    

    public override string ToString() => Name;
}

