using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Organization;

namespace Agro.DAL.Entities.Personnel;

/// <summary>
/// Позиции штатного расписания
/// </summary>
public class StaffListPosition : Entity
{
    private StaffList _staffList = null!;
    public StaffList StaffList { get => _staffList; set => Set(ref _staffList, value); }

    /// <summary>Должность</summary>
    private Post _post = null!;
    public Post Post { get => _post; set => Set(ref _post, value); }

    /// <summary>Подразделение</summary>
    private Division _division = null!;
    public Division Division { get => _division; set => Set(ref _division, value); } 

    /// <summary>Количество ставок</summary>
    private float _quantity;
    public float Quantity { get => _quantity; set => Set(ref _quantity, value); }
}
