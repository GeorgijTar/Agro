using Agro.DAL;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Bank.Pay;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories.Bank;

public class PaymentOrderRepository : IPaymentOrderRepository<PaymentOrder>
{
    private readonly AgroDb _db;

    public PaymentOrderRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<PaymentOrder>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.PaymentOrder
            .Include(p => p.Status)
            .Include(p => p.Counterparty)
            .Include(p => p.BankDetailsOrganization)
            .Include(p => p.Invoice)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<PaymentOrder?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.PaymentOrder
            .Include(p=>p.BankDetailsCounterparty)
            .Include(p=>p.BankDetailsOrganization)
            .Include(p=>p.BasisPayment)
            .Include(p=>p.Counterparty)
            .Include(p=>p.Invoice)
            .Include(p=>p.Nds)
            .Include(p=>p.Organization)
            .Include(p=>p.OrderPayment)
            .Include(p=>p.PayerStatus)
            .Include(p=>p.PaymentDestinationCode)
            .Include(p=>p.Status)
            .Include(p=>p.TaxPeriod)
            .Include(p=>p.TypeOperation)
            .Include(p=>p.TypePayment)
            .FirstOrDefaultAsync(p=>p.Id==id, cancel)
            .ConfigureAwait(false);
    }

    public async Task<PaymentOrder> AddAsync(PaymentOrder item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var result = await _db.PaymentOrder.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return result.Entity;
    }

    public async Task<PaymentOrder> UpdateAsync(PaymentOrder item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var result = await _db.PaymentOrder.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == item.Id, cancel)
            .ConfigureAwait(false);
        if (result! == null!)
        {
            throw new ArgumentNullException($"{nameof(item)} не найден в БД");
        }
        var updateResult = (_db.PaymentOrder.Update(item)).Entity;
        await _db.SaveChangesAsync(cancel);
        return updateResult;
    }

    public Task<bool> DeleteAsync(PaymentOrder item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<PaymentOrder>?> GetAllNoTrackingAsync(CancellationToken cancel = default)
    {
        return await _db.PaymentOrder.AsNoTracking()
            .Include(p => p.Status)
            .Include(p => p.Counterparty)
            .Include(p => p.BankDetailsOrganization)
            .Include(p => p.Invoice)
            .Include(p=>p.TypeOperation)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<int> GetNumberAsync(CancellationToken cancel = default)
    {
        int max=0;

        if (_db.PaymentOrder
            .Where(s => s.Date.Year == DateTime.Now.Year)
            .Any(p => p.Status!.Id != 6))
        {
            max = await _db.PaymentOrder
                .Where(p=>p.Status!.Id!=6)
                .Where(s=>s.Date.Year==DateTime.Now.Year)
                .MaxAsync(p => p.Number);
        }
       
        return max + 1;
    }

}

