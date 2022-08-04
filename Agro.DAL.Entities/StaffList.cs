
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Штатное расписание
/// </summary>
public class StaffList : Entity
{
    /// <summary>Статус</summary>
    private Status _status = null!;
    public Status Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Номер</summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value); }

    /// <summary>Дата</summary>
    private DateTime _date;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary>Должность</summary>
    private Post _post = null!;
    public Post Post { get => _post; set => Set(ref _post, value); }

    /// <summary>Количество ставок</summary>
    private double _quantity;
    public double Quantity { get => _quantity; set => Set(ref _quantity, value); } 


}