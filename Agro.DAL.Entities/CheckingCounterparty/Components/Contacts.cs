using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Контакты
/// </summary>
public class Contacts : Entity
{
    /// <summary> Номера телефонов </summary>
    private ObservableCollection<Phone>?_phones;
    public ObservableCollection<Phone>? Phones { get => _phones; set => Set(ref _phones, value); }

    /// <summary> Адреса электронной почты </summary>
    private ObservableCollection<Email>? _emails;
    public ObservableCollection<Email>? Emails { get => _emails; set => Set(ref _emails, value); }

    private string? _web;
    public string? Web { get => _web; set => Set(ref _web, value); } 


}
