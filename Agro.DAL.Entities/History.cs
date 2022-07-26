
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// История докуменита
/// </summary>
public class History : Entity
{
    /// <summary>Дата события</summary>
    private DateTime _eventDate;
    public DateTime EventDate { get=>_eventDate; set=>Set(ref _eventDate, value) ; }

    /// <summary>Событие</summary>
    private string _eventHistory = null!;
    public string EventHistory { get=>_eventHistory; set=>Set(ref _eventHistory, value);}

    /// <summary>Создатель события</summary>
    private User _user = null!;
    public virtual User User { get=>_user; set=>Set(ref _user, value); }
}