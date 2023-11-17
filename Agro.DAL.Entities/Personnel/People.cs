using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Personnel;

/// <summary>
/// Физическое лицо
/// </summary>
public class People : Entity
{
    /// <summary>Статус</summary>
    private Status? _status = null!;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Имя</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Отчество</summary>
    private string _patronymic = null!;
    public string Patronymic { get => _patronymic; set => Set(ref _patronymic, value); }

    /// <summary>Фамилия</summary>
    private string _surname = null!;
    public string Surname { get => _surname; set => Set(ref _surname, value); }

    #region Падежи

    #region Фамилия
 /// <summary>Фамилия в родительном падеже</summary>
    private string? _surnameRp;
    public string? SurnameRp { get => _surnameRp; set => Set(ref _surnameRp, value); }

    /// <summary>Фамилия в дательном падеже</summary>
    private string? _surnameDp;
    public string? SurnameDp { get => _surnameDp; set => Set(ref _surnameDp, value); }

    /// <summary>Фамилия в творительном падеже</summary>
    private string? _surnameTp;
    public string? SurnameTp { get => _surnameTp; set => Set(ref _surnameTp, value); }

    #endregion

    #region Имя
    
    /// <summary>Имя в родительном падеже</summary>
    private string? _nameRp;
    public string? NameRp { get => _nameRp; set => Set(ref _nameRp, value); }

    /// <summary>Имя в дательном падеже</summary>
    private string? _nameDp;
    public string? NameDp { get => _nameDp; set => Set(ref _nameDp, value); }

    /// <summary>Имя в творительном падеже</summary>
    private string? _nameTp;
    public string? NameTp { get => _nameTp; set => Set(ref _nameTp, value); }

    #endregion

    #region Отчество
    /// <summary>Отчество в родительном падеже</summary>
    private string? _patronymicRp;
    public string? PatronymicRp{ get => _patronymicRp; set => Set(ref _patronymicRp, value); }

    /// <summary>Отчество в дательном падеже</summary>
    private string? _patronymicDp;
    public string? PatronymicDp { get => _patronymicDp; set => Set(ref _patronymicDp, value); }

    /// <summary>Отчество в творительном падеже</summary>
    private string? _patronymicTp;
    public string? PatronymicTp { get => _patronymicTp; set => Set(ref _patronymicTp, value); }

    #endregion

    #endregion


    /// <summary>Дата рождения</summary>
    private DateTime? _birthDate;
    public DateTime? BirthDate { get => _birthDate; set => Set(ref _birthDate, value); }

    /// <summary>ИНН</summary>
    private string? _inn;
    public string? Inn { get => _inn; set => Set(ref _inn, value); }

    /// <summary>СНИЛС</summary>
    private string? _snils;
    public string? Snils { get => _snils; set => Set(ref _snils, value); }

    /// <summary>Документ удостоверяющий личность</summary>
    private ObservableCollection<IdentityDocument>? _documents = new();
    public ObservableCollection<IdentityDocument>? Documents { get => _documents; set => Set(ref _documents, value); }

    private ObservableCollection<Employee> _employees = null!;
    public ObservableCollection<Employee> Employees { get => _employees; set => Set(ref _employees, value); }


    public override string ToString() => $"{Surname} {Name[0]}. {Patronymic[0]}.";
}