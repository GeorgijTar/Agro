

using Agro.DAL;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class WriteOffObjectRepository: IBaseRepository<WriteOffObject>
{
    private readonly AgroDb _db;

    public WriteOffObjectRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<WriteOffObject>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.WriteOffObjects
            .Include(w=>w.GroupObject)
            .Include(w=>w.TypeObject)
            .OrderBy(w=>w.TypeObject.Name)
            .ThenBy(w=>w.GroupObject.Name)
            .ThenBy(w=>w.Name)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<WriteOffObject?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.WriteOffObjects
            .Include(w => w.GroupObject)
            .Include(w => w.TypeObject)
            .FirstOrDefaultAsync(w=>w.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<WriteOffObject> AddAsync(WriteOffObject item, CancellationToken cancel = default)
    {
        var obj = await _db.WriteOffObjects.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return obj.Entity;
    }

    public async Task<WriteOffObject> UpdateAsync(WriteOffObject item, CancellationToken cancel = default)
    {
        var obj = _db.WriteOffObjects.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return obj.Entity;
    }

    public Task<bool> DeleteAsync(WriteOffObject item, CancellationToken cancel = default)
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
