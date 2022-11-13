using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class LoginRepository : ILoginRepository<User>
{
    private readonly AgroDb _db;

    public LoginRepository(AgroDb db)
    {
        _db = db;
    }

    public Task<IEnumerable<User>?> GetAllAsync(CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserAsync(string login, string password, CancellationToken cancel = default)
    {
      var user = await _db.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password, cancel)
            .ConfigureAwait(false);
      return user!;
    }

    public Task<User?> AddUserAsync(User user, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }
}
