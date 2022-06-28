using System.ComponentModel;
using System.Runtime.CompilerServices;
using Agro.Interfaces.Base.Entities;

namespace Agro.Domain.Base.Base;

/// <summary>Сущность</summary>
/// <typeparam name="TKey">Тип первичного ключа</typeparam>
public abstract class EntityDto<TKey> : INotifyPropertyChanged, IEntity<TKey>, IEquatable<EntityDto<TKey>> where TKey : IEquatable<TKey>
{
    /// <summary>Первичный ключ</summary>
    public TKey Id { get; set; } = default!;

    protected EntityDto() { }

    protected EntityDto(TKey id) => Id = id;

    public bool Equals(EntityDto<TKey>? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (!other.GetType().IsAssignableTo(GetType())) return false;
        if (EqualityComparer<TKey>.Default.Equals(Id, default))
            return ReferenceEquals(this, other);
        return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((EntityDto<TKey>)obj);
    }

    public override int GetHashCode() =>
        EqualityComparer<TKey>.Default.Equals(Id, default)
            ? base.GetHashCode()
            : EqualityComparer<TKey>.Default.GetHashCode(Id);

    /// <summary>Оператор проверки на равенство двух сущностей</summary>
    /// <param name="left">Левый операнд</param><param name="right">Правый операнд</param>
    /// <returns>Истина, если значения левого и правого операнда равны</returns>
    public static bool operator ==(EntityDto<TKey> left, EntityDto<TKey> right) => Equals(left, right);

    /// <summary>Оператор проверки на неравенство двух сущностей</summary>
    /// <param name="left">Левый операнд</param><param name="right">Правый операнд</param>
    /// <returns>Истина, если значение левого операнда не равно значению правого операнда</returns>
    public static bool operator !=(EntityDto<TKey>? left, EntityDto<TKey> right) => !Equals(left, right);

    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string? proppertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proppertyName));
    }

    /// <summary>
    /// Универсальный способ применения изменений к полям. 
    /// </summary>
    /// <typeparam name="T">Any type of field.</typeparam>
    /// <param name="field">Reference to the current field.</param>
    /// <param name="value">New value for field.</param>
    /// <param name="propertyName">Name of property, that has called this method.</param>
    /// <returns></returns>
    public virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }


}

/// <summary>Сущность</summary>
public abstract class EntityDto : EntityDto<int>, IEntity
{
    protected EntityDto() { }

    protected EntityDto(int id) : base(id) { }
}