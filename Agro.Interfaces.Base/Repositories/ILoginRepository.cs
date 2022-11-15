
using Agro.DAL.Entities.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface ILoginRepository<User> where User : Entity
{
    Task<IEnumerable<User>?> GetAllAsync(CancellationToken cancel = default);

    Task<User?> GetUserAsync(string login, string password, CancellationToken cancel = default);

    Task<User?> AddUserAsync(User user, CancellationToken cancel = default);

    Task<bool> ExistsDb(CancellationToken cancel = default);
}