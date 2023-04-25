
using Agro.DAL;
using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class CultureRepository:IBaseRepository<Culture>
{
    private readonly AgroDb _db;

    public CultureRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Culture>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.Cultures
            .Include(c=>c.Product)
            .Include(c=>c.Status)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Culture?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Cultures
            .Include(c => c.Product)
            .Include(c => c.Status)
            .FirstOrDefaultAsync(c=>c.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<Culture> AddAsync(Culture item, CancellationToken cancel = default)
    {
        var cult = await _db.Cultures.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return cult.Entity;
    }

    public async Task<Culture> UpdateAsync(Culture item, CancellationToken cancel = default)
    {
        var cult = _db.Cultures.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return cult.Entity;
    }

    public async Task<bool> DeleteAsync(Culture item, CancellationToken cancel = default)
    {
        var cult = _db.Cultures.Remove(item);
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
