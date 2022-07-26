
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;
public class People : Entity
{
    /// <summary>Имя</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Отчество</summary>
    private string _patronymic = null!;
    public string Patronymic { get => _patronymic; set => Set(ref _patronymic, value); }

    /// <summary>Фамилия</summary>
    private string _surname = null!;
    public string Surname { get => _surname; set => Set(ref _surname, value); }

    /// <summary>Дата рождения</summary>
    private DateTime _birthDate;
    public DateTime BirthDate { get => _birthDate; set => Set(ref _birthDate, value); }

    /// <summary>ИНН</summary>
    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    /// <summary>СНИЛС</summary>
    private string _snils = null!;
    public string Snils { get => _snils; set => Set(ref _snils, value); }

    /// <summary>Документ удостоверяющий личность</summary>
    private Document _identityDocument = null!;
    public Document IdentityDocument { get => _identityDocument; set => Set(ref _identityDocument, value); }


}