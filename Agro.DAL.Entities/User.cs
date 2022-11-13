
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Personnel;

namespace Agro.DAL.Entities;

public class User : Entity
{
    private string _login = null!;
    public string Login { get => _login; set => Set(ref _login, value); }

    private string _password = null!;
    public string Password { get => _password; set => Set(ref _password, value); }

    /// <summary> Ссылка на сотрудника </summary>
    private Employee? _employee = null!;
    public Employee? Employee { get => _employee; set => Set(ref _employee, value); }
}
