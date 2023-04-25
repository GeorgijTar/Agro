using Agro.DAL;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class PurposeExpenditureRepository : IBaseRepository<PurposeExpenditure>
{
    private readonly AgroDb _db;

    public PurposeExpenditureRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<PurposeExpenditure>?> GetAllAsync(CancellationToken cancel = default)
    {
       return await _db.PurposeExpenditures
           .Include(p=>p.AccountingPlan)
           .Include(p=>p.Status)
           .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<PurposeExpenditure?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.PurposeExpenditures
            .Include(p => p.AccountingPlan)
            .Include(p => p.Status)
            .FirstOrDefaultAsync(p=>p.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<PurposeExpenditure> AddAsync(PurposeExpenditure item, CancellationToken cancel = default)
    {
        var obj = await _db.PurposeExpenditures.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return obj.Entity;
    }

    public async Task<PurposeExpenditure> UpdateAsync(PurposeExpenditure item, CancellationToken cancel = default)
    {
        var obj = _db.PurposeExpenditures.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return obj.Entity;
    }

    public Task<bool> DeleteAsync(PurposeExpenditure item, CancellationToken cancel = default)
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
