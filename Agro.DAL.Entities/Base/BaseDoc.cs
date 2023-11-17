
using System.Collections.ObjectModel;

namespace Agro.DAL.Entities.Base;

/// <summary>
/// Базовый клас для сущности документа
/// </summary>
public class BaseDoc : Entity
{

    /// <summary>
    /// Статус документа
    /// </summary>
    private Status _status = null!;
    public Status Status
    {
        get => _status;
        set => Set(ref _status, value);
    }

    /// <summary>
    /// Номер документа
    /// </summary>
    private string _number = null!;

    public string Number
    {
        get => _number;
        set => Set(ref _number, value);
    }

    /// <summary>
    /// Дата документа
    /// </summary>
    private DateTime _date;

    public DateTime Date
    {
        get => _date;
        set => Set(ref _date, value);
    }
    /// <summary>
    /// Пользователь создатель документа
    /// </summary>
    private User _userCreator = null!;

    public User UserCreator
    {
        get => _userCreator;
        set => Set(ref _userCreator, value);
    }

    /// <summary>
    /// История изменения документа
    /// </summary>
    private ObservableCollection<History> _histories = new();

    public ObservableCollection<History> Histories
    {
        get => _histories;
        set => Set(ref _histories, value);
    }


    /// <summary>
    /// Сумма документа
    /// </summary>
    private decimal _amount;

    public decimal Amount
    {
        get => _amount;
        set => Set(ref _amount, value);
    }
}
