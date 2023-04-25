
using Agro.DAL;
using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class FieldRepository:IBaseRepository<Field>
{
    private readonly AgroDb _db;

    public FieldRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Field>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.Fields
            .Include(f=>f.Status)
            .Include(f=>f.ParentField)
            .Include(f=>f.Department)
            .Include(f=>f.LandPlots)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Field?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Fields
            .Include(f => f.Status)
            .Include(f => f.ParentField)
            .Include(f => f.Department)
            .Include(f => f.LandPlots)
            .FirstOrDefaultAsync(f=>f.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<Field> AddAsync(Field item, CancellationToken cancel = default)
    {
        var fl = await _db.Fields.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return fl.Entity;
    }

    public async Task<Field> UpdateAsync(Field item, CancellationToken cancel = default)
    {
        var fl =  _db.Fields.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return fl.Entity;
    }

    public async Task<bool> DeleteAsync(Field item, CancellationToken cancel = default)
    {
        _db.Fields.Remove(item);
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
