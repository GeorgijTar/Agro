﻿
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace Agro.DAL.Entities.Base;

[DebuggerStepThrough]
[Serializable]
public class FullyObservableCollection<T> : ObservableCollection<T>
    where T : INotifyPropertyChanged
{
    public FullyObservableCollection() { }

    public FullyObservableCollection(List<T> list) : base(list)
    {
        ObserveAll();
    }

    public FullyObservableCollection(IEnumerable<T> enumerable) : base(enumerable)
    {
        ObserveAll();
    }

    /// <summary> Событие изменения свойства </summary>
    public event EventHandler<ItemPropertyChangedEventArgs> ItemPropertyChanged;

    protected override void ClearItems()
    {
        foreach (var item in Items)
        {
            item.PropertyChanged -= ChildPropertyChanged;
        }

        base.ClearItems();
    }

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
        {
            foreach (T item in e.OldItems)
            {
                item.PropertyChanged -= ChildPropertyChanged;
            }
        }

        if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
        {
            foreach (T item in e.NewItems)
            {
                item.PropertyChanged += ChildPropertyChanged;
            }
        }

        base.OnCollectionChanged(e);
    }

    protected void OnItemPropertyChanged(ItemPropertyChangedEventArgs e)
    {
        ItemPropertyChanged?.Invoke(this, e);
    }

    protected void OnItemPropertyChanged(int index, PropertyChangedEventArgs e)
    {
        OnItemPropertyChanged(new ItemPropertyChangedEventArgs(index, e));
    }

    private void ChildPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var typedSender = (T)sender;
        var i = Items.IndexOf(typedSender);

        if (i < 0)
        {
            throw new ArgumentException("Received property notification from item not in collection");
        }

        OnItemPropertyChanged(i, e);
    }

    private void ObserveAll()
    {
        foreach (var item in Items)
        {
            item.PropertyChanged += ChildPropertyChanged;
        }
    }
}

/// <summary>
///     Аргументы с параметрами для события <see cref="FullyObservableCollection{T}.ItemPropertyChanged" />.
/// </summary>
public class ItemPropertyChangedEventArgs : PropertyChangedEventArgs
{
    /// <summary>
    ///     Конструктор для создания класса <see cref="ItemPropertyChangedEventArgs" />.
    /// </summary>
    /// <param name="index">Индекс в коллекции для изменения.</param>
    /// <param name="name">Имя свойства, которое изменилось.</param>
    public ItemPropertyChangedEventArgs(int index, string name) : base(name)
    {
        CollectionIndex = index;
    }

    /// <summary>
    ///     Уонструктор для создания класса <see cref="ItemPropertyChangedEventArgs" />.
    /// </summary>
    /// <param name="index">Индекс.</param>
    /// <param name="args">Экземпляр <see cref="PropertyChangedEventArgs" /> содержащий измененные данные.</param>
    public ItemPropertyChangedEventArgs(int index, PropertyChangedEventArgs args) : this(index, args.PropertyName) { }

    /// <summary>
    ///     Индекс в коллекции, где произошло изменнеие.
    /// </summary>
    /// <value>
    ///     Индекс в родительской коллекции.
    /// </value>
    public int CollectionIndex { get; }
}