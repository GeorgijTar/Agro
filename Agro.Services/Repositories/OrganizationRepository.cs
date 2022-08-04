using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class OrganizationRepository : IBaseRepository<Organization>
{
    private readonly AgroDb _db;

    public OrganizationRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Organization>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.Organizations
            .Include(o=>o.Director).ThenInclude(d=>d!.People)
            .Include(o=>o.Director).ThenInclude(d=>d!.Post)
            .Include(o=>o.AddressUr)
            .Include(o=>o.GeneralAccountant).ThenInclude(p=>p!.People)
            .Include(o => o.GeneralAccountant).ThenInclude(p => p!.Post)
            .Include(o=>o.BankDetails).ThenInclude(b=>b.Status)
            .Include(o=>o.Okato)
            .Include(o=>o.Okfs)
            .Include(o=>o.Okogy)
            .Include(o=>o.Okopf)
            .Include(o => o.Oktmo)
            .Include(o => o.Okved)
            .Include(o => o.RegFns)
            .Include(o => o.RegFss)
            .Include(o => o.RegPfr)
            .Include(o=>o.Cashier).ThenInclude(c=>c!.People)
            .Include(o => o.Cashier).ThenInclude(c => c!.Post)
            .Include(o => o.Hr).ThenInclude(h => h!.People)
            .Include(o => o.Hr).ThenInclude(h => h!.Post)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Organization?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Organizations
            .Include(o => o.Director).ThenInclude(d => d!.People)
            .Include(o => o.Director).ThenInclude(d => d!.Post)
            .Include(o => o.AddressUr)
            .Include(o => o.GeneralAccountant).ThenInclude(p => p!.People)
            .Include(o => o.GeneralAccountant).ThenInclude(p => p!.Post)
            .Include(o => o.BankDetails).ThenInclude(b => b.Status)
            .Include(o => o.Okato)
            .Include(o => o.Okfs)
            .Include(o => o.Okogy)
            .Include(o => o.Okopf)
            .Include(o => o.Oktmo)
            .Include(o => o.Okved)
            .Include(o => o.RegFns)
            .Include(o => o.RegFss)
            .Include(o => o.RegPfr)
            .Include(o => o.Cashier).ThenInclude(c => c!.People)
            .Include(o => o.Cashier).ThenInclude(c => c!.Post)
            .Include(o => o.Hr).ThenInclude(h => h!.People)
            .Include(o => o.Hr).ThenInclude(h => h!.Post)
            .FirstOrDefaultAsync(o=>o.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<Organization> AddAsync(Organization item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        
        await _db.Organizations.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return item;
    }

    public async Task<Organization> UpdateAsync(Organization item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        _db.Organizations.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item;
    }

    public async Task<bool> DeleteAsync(Organization item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        _db.Organizations.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        var item = await _db.Organizations.FirstOrDefaultAsync(s => s.Id == id, cancel).ConfigureAwait(false);
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        _db.Organizations.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }
}