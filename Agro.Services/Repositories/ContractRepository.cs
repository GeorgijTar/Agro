using Agro.DAL;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Counter;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class ContractRepository:IContractRepository<Contract>
{
    private readonly AgroDb _db;

    public ContractRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Contract>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.Contracts
            .Include(c=>c.Counterparty)
            .Include(c=>c.BankDetailsOrg).ThenInclude(b=>b.Organization)
            .Include(c=>c.BankDetails)
            .Include(c=>c.Group)
            .Include(c=>c.Type)
            .Include(c=>c.ScanFiles)
            .OrderBy(c=>c.Date)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Contract?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Contracts
            .Include(c => c.Counterparty)
            .Include(c => c.BankDetailsOrg).ThenInclude(b => b.Organization)
            .Include(c => c.BankDetails)
            .Include(c => c.Group)
            .Include(c => c.Type)
            .Include(c => c.ScanFiles)
            .FirstOrDefaultAsync(c=>c.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<Contract> AddAsync(Contract item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var contract= (await _db.Contracts.AddAsync(item, cancel).ConfigureAwait(false)).Entity;
        await _db.SaveChangesAsync(cancel);
        return contract;
    }

    public async Task<Contract> UpdateAsync(Contract item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var contract =(_db.Contracts.Update(item)).Entity;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return contract;
    }

    public async Task<bool> DeleteAsync(Contract item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        _db.Contracts.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        var item = await _db.Contracts.FirstOrDefaultAsync(s => s.Id == id, cancel).ConfigureAwait(false);
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        _db.Contracts.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> RemoveFile(ScanFile file, CancellationToken cancel = default)
    {
        _db.ScanFiles.Remove(file);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> RemoveSpecification(SpecificationContract speciication, CancellationToken cancel = default)
    {
        _db.Specifications.Remove(speciication);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<IEnumerable<GroupDoc>> GetGroupsAsync(CancellationToken cancel = default)
    {
        return await _db.Groups.Where(g => g.TypeApplication == "Контракт").ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Contract>?> GetAllByIdStatusAsync(int idStatus, CancellationToken cancel = default)
    {
        return await _db.Contracts
            .Include(c => c.Counterparty)
            .Include(c => c.BankDetailsOrg).ThenInclude(b => b.Organization)
            .Include(c => c.BankDetails)
            .Include(c => c.Group)
            .Include(c => c.Type)
            .Include(c => c.ScanFiles)
            .Where(c=>c.Status!.Id==idStatus)
            .OrderBy(c => c.Date)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Contract>?> GetAllByNoIdStatusAsync(int idStatus, CancellationToken cancel = default)
    {
        return await _db.Contracts
            .Include(c => c.Counterparty)
            .Include(c => c.BankDetailsOrg).ThenInclude(b => b.Organization)
            .Include(c => c.BankDetails)
            .Include(c => c.Group)
            .Include(c => c.Type)
            .Include(c => c.ScanFiles)
            .Where(c => c.Status!.Id != idStatus)
            .OrderBy(c => c.Date)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }
}
