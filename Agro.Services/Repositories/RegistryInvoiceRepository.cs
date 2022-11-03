using Agro.DAL;
using Agro.Interfaces.Base.Repositories;
using Agro.DAL.Entities.InvoiceEntity;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{

    /// <summary>
    /// Репозиторий работы с реестром счетов на оплату
    /// </summary>
    public class RegistryInvoiceRepository: IRegistryInvoiceRepository<RegistryInvoice>
    {
        private readonly AgroDb _db;

        public RegistryInvoiceRepository(AgroDb db)
        {
            _db = db;
        }
        public async Task<IEnumerable<RegistryInvoice>?> GetAllAsync(CancellationToken cancel = default)
        {
            return await _db.RegistryInvoices
                .Include(r=>r.Invoices).ThenInclude(i=>i.Counterparty)
                .Include(r => r.Invoices).ThenInclude(i => i.BankDetails)
                .Include(r => r.Invoices).ThenInclude(i => i.BankDetailsOrg)
                .Include(r => r.Invoices).ThenInclude(i => i.Contract)
                .Include(r => r.Invoices).ThenInclude(i => i.History)
                .Include(r => r.Invoices).ThenInclude(i => i.ProductsInvoice)
                .Include(r => r.Invoices).ThenInclude(i => i.ScanFiles)
                .Include(r => r.Invoices).ThenInclude(i => i.Specification)
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
                .FirstOrDefaultAsync(r=>r.Id==id, cancel).ConfigureAwait(false);
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
            var ri =  _db.RegistryInvoices.Update(item);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return ri.Entity;
        }

        public Task<bool> DeleteAsync(RegistryInvoice item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public async Task<RegistryInvoice?> SetStatus(int idStatus, RegistryInvoice item, CancellationToken cancel = default)
        {
            item.Status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == idStatus, cancel).ConfigureAwait(false);
            return await UpdateAsync(item);
        }
    }
}
