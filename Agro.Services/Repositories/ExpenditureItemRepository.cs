
using System.Xml.Serialization;
using Agro.DAL;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Bank.Base;
using Agro.DAL.Entities.Base;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class ExpenditureItemRepository : IExpenditureItemRepository<ExpenditureItem>
{
    private readonly AgroDb _db;

    public ExpenditureItemRepository(AgroDb db)
    {
        _db = db;
    }
    public Task<IEnumerable<ExpenditureItem>?> GetAllAsync(CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ExpenditureItem?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.ExpenditureItems
            .FirstOrDefaultAsync(e => e.Id == id, cancel)
            .ConfigureAwait(false);
    }

    public async Task<ExpenditureItem> AddAsync(ExpenditureItem item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var result = await _db.ExpenditureItems.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return result.Entity;
    }

    public async Task<ExpenditureItem> UpdateAsync(ExpenditureItem item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var result = await _db.ExpenditureItems.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == item.Id, cancel)
            .ConfigureAwait(false);
        if (result! == null!)
        {
            throw new ArgumentNullException($"{nameof(item)} не найден в БД");
        }
        var updateResult = (_db.ExpenditureItems.Update(item)).Entity;
        await _db.SaveChangesAsync(cancel);
        return updateResult;
    }

    public Task<bool> DeleteAsync(ExpenditureItem item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ExpenditureItem>?> GetAllNoTrackingAsync(CancellationToken cancel = default)
    {
        return await _db.ExpenditureItems.AsNoTracking()
            .Include(e => e.TypeCashFlow)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ExpenditureItem>?> GetAllByDirectionNoTrackingAsync(bool isDirection, bool direction, CancellationToken cancel = default)
    {
        if (direction)
        {
            return await _db.ExpenditureItems.AsNoTracking()
            .Where(e => e.Direction == direction)
            .Where(e => e.Status!.Id != 7)
            .Include(e => e.TypeCashFlow)
            .Include(e => e.Status)
            .ToArrayAsync(cancel).ConfigureAwait(false);
        }
        else
        {
            return await _db.ExpenditureItems.AsNoTracking()
                .Where(e => e.Status!.Id != 7)
                .Include(e => e.TypeCashFlow)
                .Include(e=>e.Status)
                .ToArrayAsync(cancel).ConfigureAwait(false);
        }
        
    }

    public async Task<IEnumerable<TypeCashFlow>?> GetAllTypeCashFlowNoTrackingAsync(CancellationToken cancel = default)
    {
        return await _db.TypeCashFlow.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<TypeCashFlow?> GetTypeCashFlowByIdAsync(int id, CancellationToken cancel = default)
    {
        return await  _db.TypeCashFlow
            .FirstOrDefaultAsync(t=>t.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<Status?> GetStatusByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Statuses.FirstOrDefaultAsync(s => s.Id == id, cancel).ConfigureAwait(false);
    }
}
