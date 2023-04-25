
using Agro.DAL;
using Agro.DAL.Entities.Storage;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class StorageLocationRepository : IBaseRepository<StorageLocation>
{
    private readonly AgroDb _db;

    public StorageLocationRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<StorageLocation>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.StorageLocations
            .Include(s=>s.Storekeepers)!.ThenInclude(s=>s.Employee).ThenInclude(e=>e.People)
            .Include(s => s.Storekeepers)!.ThenInclude(s => s.Employee).ThenInclude(e => e.Division)
            .Include(s => s.Storekeepers)!.ThenInclude(s => s.Employee).ThenInclude(e => e.Post)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<StorageLocation?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.StorageLocations
            .Include(s => s.Storekeepers)!.ThenInclude(s => s.Employee).ThenInclude(e => e.People)
            .Include(s => s.Storekeepers)!.ThenInclude(s => s.Employee).ThenInclude(e => e.Division)
            .Include(s => s.Storekeepers)!.ThenInclude(s => s.Employee).ThenInclude(e => e.Post)
            .FirstOrDefaultAsync(s=>s.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<StorageLocation> AddAsync(StorageLocation item, CancellationToken cancel = default)
    {
       var sl = await  _db.StorageLocations.AddAsync(item, cancel).ConfigureAwait(false);
       await _db.SaveChangesAsync(cancel);
       return sl.Entity;
    }

    public async Task<StorageLocation> UpdateAsync(StorageLocation item, CancellationToken cancel = default)
    {
        var sl =  _db.StorageLocations.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return sl.Entity;
    }

    public async Task<bool> DeleteAsync(StorageLocation item, CancellationToken cancel = default)
    {
        _db.StorageLocations.Remove(item);
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