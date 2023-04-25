using Agro.Dto.Base;

namespace Agro.Dto;
public class HistoryDto : BaseDto
{
    /// <summary>Дата события</summary>
    private DateTime _eventDate;
    public DateTime EventDate { get => _eventDate; set => Set(ref _eventDate, value); }

    /// <summary>Событие</summary>
    private string _eventHistory = null!;
    public string EventHistory { get => _eventHistory; set => Set(ref _eventHistory, value); }

    /// <summary>Создатель события</summary>
    private string _user = null!;
    public virtual string User { get => _user; set => Set(ref _user, value); }

}

