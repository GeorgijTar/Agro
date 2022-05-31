using System.ComponentModel.DataAnnotations;

using Agro.Interfaces.Base.Entities;

namespace Agro.DAL.Entities.Base;

/// <summary>Именованная сущность</summary>
/// <typeparam name="TKey">Тип первичного ключа</typeparam>
public abstract class NamedEntity<TKey> : Entity<TKey>, INamedEntity<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>Имя</summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>Инициализация новой именованной сущности</summary>
    protected NamedEntity() { }

    /// <summary>Инициализация новой именованной сущности</summary>
    /// <param name="name">Имя</param>
    protected NamedEntity(string name) => this.Name = name;

    /// <summary>Инициализация новой именованной сущности</summary>
    /// <param name="id">Идентификатор</param>
    protected NamedEntity(TKey id) : base(id) { }

    /// <summary>Инициализация новой именованной сущности</summary>
    /// <param name="id">Идентификатор</param><param name="name">Имя</param>
    protected NamedEntity(TKey id, string name) : base(id) => this.Name = name;
    public override string ToString() => Name;
}

/// <summary>Именованная сущность</summary>
public abstract class NamedEntity : NamedEntity<int>, INamedEntity
{
    /// <summary>Инициализация новой именованной сущности</summary>
    protected NamedEntity() { }

    /// <summary>Инициализация новой именованной сущности</summary>
    /// <param name="name">Имя</param>
    protected NamedEntity(string name) : base(name) { }

    /// <summary>Инициализация новой именованной сущности</summary>
    /// <param name="id">Идентификатор</param>
    protected NamedEntity(int id) : base(id) { }

    /// <summary>Инициализация новой именованной сущности</summary>
    /// <param name="id">Идентификатор</param><param name="name">Имя</param>
    protected NamedEntity(int id, string name) : base(id, name) { }

    public override string ToString() => Name;
}
