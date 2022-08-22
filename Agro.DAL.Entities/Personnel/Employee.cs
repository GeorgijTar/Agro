using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Personnel;

namespace Agro.DAL.Entities;
/// <summary>
/// Сотрудник
/// </summary>
public class Employee : Entity
{
    /// <summary>Статус</summary>
    private Status? _status = null!;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Табельный номер</summary>
    private string _tabNumber = null!;
    public string TabNumber { get => _tabNumber; set => Set(ref _tabNumber, value); }

    /// <summary>дразделение</summary>
    private Division _division = null!;
    public Division Division { get => _division; set => Set(ref _division, value); } 


    /// <summary>Связь с физ. лицом</summary>
    private People _people = null!;
    public People People { get => _people; set => Set(ref _people, value); }

    /// <summary>Должность</summary>
    private Post _post = null!;
    public Post Post { get => _post; set => Set(ref _post, value); } 



}