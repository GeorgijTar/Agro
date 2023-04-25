
using Agro.DAL;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class PeopleRepository:IBaseRepository<People>
{
    private readonly AgroDb _db;

    public PeopleRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<People>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.People
            .Include(p=>p.Status)
            .Include(p=>p.Employees)
            .Include(p=>p.Documents)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<People?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.People
            .Include(p => p.Status)
            .Include(p => p.Employees)
            .Include(p => p.Documents)
            .FirstOrDefaultAsync(p=>p.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<People> AddAsync(People item, CancellationToken cancel = default)
    {
        var pl = await _db.People.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return pl.Entity;
    }

    public async Task<People> UpdateAsync(People item, CancellationToken cancel = default)
    {
        var pl =  _db.People.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return pl.Entity;
    }

    public async Task<bool> DeleteAsync(People item, CancellationToken cancel = default)
    {
         _db.People.Remove(item);
         await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
         return true;
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<DateTime> GetClosedPeriodAsync(CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }
}