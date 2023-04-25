
using Agro.DAL;
using Agro.DAL.Entities.Weight;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class DriverRepository : IBaseRepository<Driver>
{
    private readonly AgroDb _db;

    public DriverRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Driver>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.Drivers
            .Include(d=>d.Status)
            .Include(d=>d.Transports)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Driver?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Drivers
            .Include(d => d.Status)
            .Include(d => d.Transports)
            .FirstOrDefaultAsync(d=>d.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<Driver> AddAsync(Driver item, CancellationToken cancel = default)
    {
        var dr = await _db.Drivers.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return dr.Entity;
    }

    public async Task<Driver> UpdateAsync(Driver item, CancellationToken cancel = default)
    {
        var dr =  _db.Drivers.Update(item);
        await _db.SaveChangesAsync(cancel);
        return dr.Entity;
    }

    public Task<bool> DeleteAsync(Driver item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
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