
using Agro.DAL;
using Agro.DAL.Entities.Kassa;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class AdvanceReportRepository:IAdvanceReportRepository
{

    private readonly AgroDb _db;

    public AdvanceReportRepository(AgroDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<AdvanceReport>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.AdvanceReport
            .Include(p=>p.Person).ThenInclude(p=>p.People)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<AdvanceReport?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.AdvanceReport
            .Include(p => p.Person).ThenInclude(p => p.People)
            .Include(p => p.Person).ThenInclude(p => p.Post)
            .Include(r=>r.AdvancesPp)
            .Include(r=>r.AdvancesRko)
            .Include(r=>r.Produkts)
            .Include(r=>r.AccountingPlanRegisters).ThenInclude(a=>a.Credit)
            .Include(r => r.AccountingPlanRegisters).ThenInclude(a => a.Debit)
            .Include(r => r.AccountingPlanRegisters).ThenInclude(a => a.ComingTmc)
           
            .FirstOrDefaultAsync(r=>r.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<AdvanceReport> AddAsync(AdvanceReport item, CancellationToken cancel = default)
    {
        if (item is null)
                throw new ArgumentNullException(nameof(item));
        var report = await _db.AdvanceReport.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return report.Entity;
    }

    public async Task<AdvanceReport> UpdateAsync(AdvanceReport item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        _db.AdvanceReport.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item;
    }

    public async Task<bool> DeleteAsync(AdvanceReport item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == 6);
        item.Status = status!;
        _db.AdvanceReport.Update(item);
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
