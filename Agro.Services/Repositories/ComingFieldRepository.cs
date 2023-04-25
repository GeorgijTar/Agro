

using Agro.DAL;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.Weight;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class ComingFieldRepository: IComingFieldRepository<ComingField>
{
    private readonly AgroDb _db;

    public ComingFieldRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<ComingField>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.ComingFields
            .Include(c=>c.Driver)
            .Include(c => c.Weight)
            .Include(c => c.Culture)
            .Include(c => c.Transport)
            .Include(c => c.Field).ThenInclude(f=>f.Department)
            .Include(c => c.StorageLocation)
            .Include(c => c.Status)
            .ToArrayAsync(cancel).ConfigureAwait(false);

    }

    public async Task<ComingField?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.ComingFields
            .Include(c => c.Driver)
            .Include(c => c.Weight)
            .Include(c => c.Culture)
            .Include(c => c.Transport)
            .Include(c => c.Field).ThenInclude(f=>f.Department)
            .Include(c => c.StorageLocation)
            .Include(c => c.Status)
            .FirstOrDefaultAsync(c=>c.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<ComingField> AddAsync(ComingField item, CancellationToken cancel = default)
    {
       var com = await _db.ComingFields.AddAsync(item, cancel).ConfigureAwait(false);
       await _db.SaveChangesAsync(cancel);
       return com.Entity;
    }

    public async Task<ComingField> UpdateAsync(ComingField item, CancellationToken cancel = default)
    {
        var com =  _db.ComingFields.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return com.Entity;
    }

    public async Task<bool> DeleteAsync(ComingField item, CancellationToken cancel = default)
    {
        _db.ComingFields.Remove(item);
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

    public async Task<int> GetNumber(ComingField coming, CancellationToken cancel = default)
    {
        try
        {
            var numb = await _db.ComingFields
            .Where(c=>c.Date.Year==coming.Date.Year)
            .Where(c=>c.Status!.Id!=6)
            .MaxAsync(c=>c.Number, cancel)
            .ConfigureAwait(false);
            return numb;

        }
        catch (Exception e)
        {
            return 0;
        }
      
    }

    public async Task<Status?> GetStatusById(int idStatus, CancellationToken cancel = default)
    {
        return await _db.Statuses.FirstOrDefaultAsync(s => s.Id == idStatus, cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<StorageLocation>?> GetAllStorageLocation(CancellationToken cancel = default)
    {
        return await _db.StorageLocations.Where(s => s.Status!.Id == 5).ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Weight>?> GetAllWeight(CancellationToken cancel = default)
    {
        return await _db.Weights.Where(w=>w.Status!.Id==5).ToArrayAsync(cancel).ConfigureAwait(false);
    }
}
