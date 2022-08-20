using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Personnel;

/// <summary>
/// Штатное расписание
/// </summary>
public class StaffList : Entity
{
    /// <summary>Статус</summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Номер</summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value); }

    /// <summary>Дата составления</summary>
    private DateTime _date;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary>Дата начала действия</summary>
    private DateTime _startDate;
    public DateTime StartDate { get => _startDate; set => Set(ref _startDate, value); }

    /// <summary>Дата окончания действия</summary>
    private DateTime? _endDate;
    public DateTime? EndDate { get => _endDate; set => Set(ref _endDate, value); }

    /// <summary>Номер приказа</summary>
    private string _orderNumber = null!;
    public string OrderNamber { get => _orderNumber; set => Set(ref _orderNumber, value); }

    /// <summary>Дата приказа</summary>
    private DateTime _orderDate;
    public DateTime OrderDate { get => _orderDate; set => Set(ref _orderDate, value); }

    /// <summary>Примечание</summary>
    private string? _note;
    public string? Note { get => _note; set => Set(ref _note, value); } 

    
    /// <summary>Позиции штатного расписания</summary>
    private ObservableCollection<StaffListPosition>? _positions =new();
    public ObservableCollection<StaffListPosition>? Positions { get => _positions; set => Set(ref _positions, value); }

}