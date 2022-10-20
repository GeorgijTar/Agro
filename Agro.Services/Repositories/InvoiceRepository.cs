using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class InvoiceRepository : IInvoiceRepository<Invoice>
{
    private readonly AgroDb _db;

    public InvoiceRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Invoice>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.Invoices
            .Include(i => i.Status!)
            .Include(i => i.Counterparty).ThenInclude(c=>c.ActualAddress!)
            .Include(i => i.BankDetails)
            .Include(i => i.BankDetailsOrg).ThenInclude(b=>b!.Organization!).ThenInclude(o=>o.AddressUr!)
            .Include(i => i.BankDetailsOrg).ThenInclude(b => b!.Organization!).ThenInclude(o=>o.Director!.Post)
            .Include(i => i.BankDetailsOrg).ThenInclude(b => b!.Organization!).ThenInclude(o => o.Director!.People)
            .Include(i => i.Nds)
            .Include(i => i.ProductsInvoice!)
            .ThenInclude(p => p.Product)
            .ThenInclude(p => p.Unit)
            .Include(i => i.Type)
            .Include(i=>i.Specification)
            .Include(i=>i.Contract)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Invoice?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Invoices
            .Include(i => i.Status!)
            .Include(i => i.Counterparty).ThenInclude(c => c.ActualAddress!)
            .Include(i => i.BankDetails)
            .Include(i => i.BankDetailsOrg).ThenInclude(b => b!.Organization!).ThenInclude(o => o.AddressUr!)
            .Include(i => i.BankDetailsOrg).ThenInclude(b => b!.Organization!).ThenInclude(o => o.Director!.Post)
            .Include(i => i.BankDetailsOrg).ThenInclude(b => b!.Organization!).ThenInclude(o => o.Director!.People)
            .Include(i => i.Nds)
            .Include(i => i.ProductsInvoice!)
            .ThenInclude(p => p.Product)
            .ThenInclude(p => p.Unit)
            .Include(i => i.Type)
            .Include(i => i.Specification)
            .Include(i => i.Contract)
            .FirstOrDefaultAsync(i => i.Id == id, cancel).ConfigureAwait(false);
    }

    public async Task<Invoice> AddAsync(Invoice item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var table = _db.Set<Invoice>();
        await table.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return item;
    }

    public async Task<Invoice> UpdateAsync(Invoice item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        _db.Invoices.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item;
    }
    public async Task<bool> DeleteAsync(Invoice item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var table = _db.Set<Invoice>();
        table.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        var table = _db.Set<Invoice>();
        var item = await table.FirstOrDefaultAsync(s => s.Id == id, cancel).ConfigureAwait(false);
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        table.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<string> GetNumber(Invoice invoice, CancellationToken cancel = default)
    {
        var inv = await _db.Invoices
            .Where(i => i.Status!.Id != 6)
            .Where(i => i.Type == invoice.Type)
            .Where(i => i.DateInvoice.Year == invoice.DateInvoice.Year)
            .ToArrayAsync(cancel).ConfigureAwait(false);
        if (inv == null! || inv.Length == 0)
            return "1";
        var max = inv.Max(i => i.Number);
        return (int.Parse(max!) + 1).ToString();
    }

    public async Task<Status?> GetStatusById(int idStatus, CancellationToken cancel = default)
    {
        return await _db.Statuses.FirstOrDefaultAsync(s => s.Id == idStatus, cancel).ConfigureAwait(false);
    }

    public async Task<ICollection<BankDetails>?> GetAllBankDetailsOrg(CancellationToken cancel = default)
    {
        return await _db.BankDetails.Where(b => b.Organization != null!).ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<bool> RemoveFile(ScanFile file, CancellationToken cancel = default)
    {
        _db.ScanFiles.Remove(file);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> RemoveProductInvoice(ProductInvoice product, CancellationToken cancel = default)
    {
        _db.ProductsInvoice.Remove(product);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<ICollection<Nds>?> GetAllNds(CancellationToken cancel = default)
    {
        return await _db.Ndses.ToArrayAsync(cancel).ConfigureAwait(false);
    }
}