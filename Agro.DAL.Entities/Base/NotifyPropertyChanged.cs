﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Agro.DAL.Entities.Base;

public abstract class NotifyPropertyChanged : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string? proppertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proppertyName));
    }

    /// <summary>
    /// Universal method for applying changes to ViewModels fields. 
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