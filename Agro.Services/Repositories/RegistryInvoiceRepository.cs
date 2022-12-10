using Agro.DAL;
using Agro.Interfaces.Base.Repositories;
using Agro.DAL.Entities.InvoiceEntity;
using Microsoft.EntityFrameworkCore;
using Agro.DAL.Entities;

namespace Agro.Services.Repositories;

/// <summary>
/// Репозиторий работы с реестром счетов на оплату
/// </summary>
public class RegistryInvoiceRepository : IRegistryInvoiceRepository<RegistryInvoice>
{
    private readonly AgroDb _db;

    public RegistryInvoiceRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<RegistryInvoice>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.RegistryInvoices
            .Include(r => r.Invoices).ThenInclude(i => i.Counterparty)
            .Include(r => r.Invoices).ThenInclude(i => i.Status)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<RegistryInvoice?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.RegistryInvoices
            .Include(r => r.Invoices).ThenInclude(i => i.Counterparty)
            .Include(r => r.Invoices).ThenInclude(i => i.BankDetails)
            .Include(r => r.Invoices).ThenInclude(i => i.BankDetailsOrg)
            .Include(r => r.Invoices).ThenInclude(i => i.Contract)
            .Include(r => r.Invoices).ThenInclude(i => i.History)
            .Include(r => r.Invoices).ThenInclude(i => i.ProductsInvoice)
            .Include(r => r.Invoices).ThenInclude(i => i.ScanFiles)
            .Include(r => r.Invoices).ThenInclude(i => i.Specification)
            .Include(r => r.Invoices).ThenInclude(i => i.Status)
            .FirstOrDefaultAsync(r => r.Id == id, cancel).ConfigureAwait(false);
    }

    public async Task<RegistryInvoice> AddAsync(RegistryInvoice item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var ri = await _db.RegistryInvoices.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return ri.Entity;
    }

    public async Task<RegistryInvoice> UpdateAsync(RegistryInvoice item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var ri = _db.RegistryInvoices.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return ri.Entity;
    }

    public async Task<bool> DeleteAsync(RegistryInvoice item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }


    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<RegistryInvoice> SetStatusAsync(int idStatus, RegistryInvoice item, CancellationToken cancel = default)
    {
        item.Status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == idStatus, cancel).ConfigureAwait(false);
        return await UpdateAsync(item);
    }

    public async Task<Status?> GetStatusAsync(int idStatus, CancellationToken cancel = default)
    {
        return await _db.Statuses.FirstOrDefaultAsync(s => s.Id == idStatus, cancel).ConfigureAwait(false);
    }

    public async Task<RegistryInvoice> AcceptanceAsync(RegistryInvoice item, CancellationToken cancel = default)
    {
        var statusItem = item.Status;
        try
        {
            item.Status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == 18, cancel);
            var status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == 9, cancel);
            foreach (var invoice in item.Invoices)
            {
                invoice.Status = status;
            }
            await _db.SaveChangesAsync(cancel);
        }
        catch (Exception)
        {
            item.Status = statusItem;
        }
        return item;
    }

    public async Task<RegistryInvoice> RejectAsync(RegistryInvoice item, CancellationToken cancel = default)
    {
        var statusItem = item.Status;
        try
        {
            item.Status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == 19, cancel);
            var status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == 20, cancel);
            foreach (var invoice in item.Invoices)
            {
                invoice.Status = status;
            }
            await _db.SaveChangesAsync(cancel);
        }
        catch (Exception)
        {
            item.Status = statusItem;
        }
        return item;
    }

    public async Task<IEnumerable<Invoice>?> GetRegisterAcceptAsync(CancellationToken cancel = default)
    {
        //decimal limit = await _db.Sittings.Select(s => s.LimitAmountInvoice).FirstAsync(cancel);
        return await _db.Invoices
            .Include(i => i.Counterparty)
            .Include(i => i.Status)
            .Where(i => i.Status!.Id == 8)/*.Where(i => i.TotalAmount > limit)*/
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<int> GetNumberRegisterAsync(CancellationToken cancel = default)
    {
        return _db.RegistryInvoices.Any() ? await _db.RegistryInvoices.MaxAsync(r => r.Number, cancel) + 1 : 1;
    }

    public async Task<IEnumerable<RegistryInvoice>> GetAllByIdAsync(int idStatus, CancellationToken cancel = default)
    {
        return await _db.RegistryInvoices
            .Include(r => r.Invoices).ThenInclude(i => i.Counterparty)
            .Include(r => r.Invoices).ThenInclude(i => i.Status)
            .Where(r => r.Status!.Id == idStatus)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<RegistryInvoice>> GetAllByIdNoAsync(int idStatus, CancellationToken cancel = default)
    {
        return await _db.RegistryInvoices
            .Include(r => r.Invoices).ThenInclude(i => i.Counterparty)
            .Include(r => r.Invoices).ThenInclude(i => i.Status)
            .Where(r => r.Status!.Id != idStatus)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Invoice?> GetInvoseScanFilesAsync(int invoiceId, CancellationToken cancel = default)
    {
        return await _db.Invoices.Include(I => I.ScanFiles)
            .FirstOrDefaultAsync(I => I.Id == invoiceId)
            .ConfigureAwait(false);
    }

    public async Task<RegistryInvoice> DeleteRegAsync(RegistryInvoice item, CancellationToken cancel = default)
    {
        item.Status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == 6, cancel);
        foreach (var invoice in item.Invoices)
        {
            invoice.Status= await _db.Statuses.FirstOrDefaultAsync(s => s.Id == 8, cancel);
        }
        item.Invoices = null!;
       return await UpdateAsync(item, cancel).ConfigureAwait(false);
    }
}
