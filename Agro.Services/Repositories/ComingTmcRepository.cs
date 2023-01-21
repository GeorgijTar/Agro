using Agro.DAL;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Agro.Services.Repositories;

public class ComingTmcRepository : IComingTmcRepository<ComingTmc>
{
    private readonly AgroDb _db;

    public ComingTmcRepository(AgroDb db)
    {
        _db = db;
    }
    public Task<IEnumerable<ComingTmc>?> GetAllAsync(CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ComingTmc?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
       return await _db.ComingTmc
           .Include(c=>c.ComingTmcCalculations)
           .Include(c => c.Counterparty)
           .Include(c => c.Positions).ThenInclude(p=>p.AccountingAccountNds)
           .Include(c => c.Positions).ThenInclude(p => p.StorageLocation)
           .Include(c => c.Positions).ThenInclude(p => p.Tmc)
           .Include(c => c.Positions).ThenInclude(p => p.UnitOkei)
           .Include(c=>c.Positions).ThenInclude(r=>r.AccountingAccount)
           .Include(c => c.Positions).ThenInclude(p=>p.Nds)
           .Include(c=>c.TmcRegisters)!.ThenInclude(r=>r.Credit)
           .Include(c => c.TmcRegisters)!.ThenInclude(r => r.Debit)
           .Include(c => c.TmcRegisters)!.ThenInclude(r => r.Tmc)
           .Include(c => c.TmcRegisters)!.ThenInclude(r => r.StorageLocation)
           .Include(c=>c.AccountingPlanRegisters)!.ThenInclude(a=>a.Credit)
           .Include(c => c.AccountingPlanRegisters)!.ThenInclude(a => a.Debit)
           .Include(c=>c.History)!.ThenInclude(h=>h.User).ThenInclude(u=>u.Employee!.People)
           .Include(c => c.InvoiceFactur)
           .Include(c=>c.ScanFiles)
           .Include(c => c.Status)
           .FirstOrDefaultAsync(c=>c.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<ComingTmc> AddAsync(ComingTmc item, CancellationToken cancel = default)
    {
        if (item == null!)
        {
            throw new ArgumentNullException($"Попытка добавления в БД пустого элемента");
        }

        var com = await _db.ComingTmc.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return com.Entity;
    }

    public async Task<ComingTmc> UpdateAsync(ComingTmc item, CancellationToken cancel = default)
    {
        if (item == null!)
        {
            throw new ArgumentNullException($"Попытка обновления в БД пустого элемента");
        }

        var itemDb = await _db.ComingTmc.FirstOrDefaultAsync(c => c.Id == item.Id, cancel).ConfigureAwait(false);
        if (itemDb! == null!)
        {
            throw new ArgumentNullException($"В базе данных не найден документ № {item.RegNumber} от {item.RegDate}");
        }

        var com = _db.ComingTmc.Update(item);
        await _db.SaveChangesAsync(cancel);
        return com.Entity;
    }

    public Task<bool> DeleteAsync(ComingTmc item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetRegNumberAsync(CancellationToken cancel = default)
    {
        int max = 0;

        if (_db.ComingTmc
            .Where(s => s.RegDate.Year == DateTime.Now.Year)
            .Any(p => p.Status!.Id != 6))
        {
            max = await _db.ComingTmc
                .Where(p => p.Status!.Id != 6)
                .Where(s => s.RegDate.Year == DateTime.Now.Year)
                .MaxAsync(p => p.RegNumber, cancel);
        }

        return max + 1;
    }

    public async Task<IEnumerable<ComingTmc>?> GetAllNoTrackingAsync(CancellationToken cancel = default)
    {
        return await _db.ComingTmc
            .Include(c=>c.Status)
            .Include(c => c.Counterparty)
            .Include(c => c.TmcRegisters)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<ComingTmc> SetStatusAsync(int idStatus, ComingTmc item, CancellationToken cancel = default)
    {
        var com = await _db.ComingTmc.FirstOrDefaultAsync(c => c.Id == item.Id, cancel).ConfigureAwait(false);
        if (com! == null!)
        {
            throw new ArgumentNullException($"В базе данных не найден документ № {item.RegNumber} от {item.RegDate}");
        }

        com.Status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == idStatus, cancel);
        await UpdateAsync(com, cancel);
        return com;

    }

    public async Task<bool> DeleteAccountingRegister(Guid idAr, CancellationToken cancel = default)
    {
        var ar = await _db.AccountingPlanRegisters.FirstOrDefaultAsync(
            a => a.Id == idAr, cancel).ConfigureAwait(false);
        if (ar! == null!){ throw new ArgumentNullException($"В базе данных не найдена запись"); }
        _db.AccountingPlanRegisters.Remove(ar);
        await _db.SaveChangesAsync(cancel);
        return true;
    }

    public async Task<bool> DeleteTmcRegister(Guid idAr, CancellationToken cancel = default)
    {
        var tmcRegister = await _db.TmcRegisters.FirstOrDefaultAsync(
            a => a.Id == idAr, cancel).ConfigureAwait(false);
        if (tmcRegister! == null!) { throw new ArgumentNullException($"В базе данных не найдена запись"); }
        _db.TmcRegisters.Remove(tmcRegister);
        await _db.SaveChangesAsync(cancel);
        return true;
    }
}

