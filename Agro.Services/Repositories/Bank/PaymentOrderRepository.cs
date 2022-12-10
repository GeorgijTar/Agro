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
    public Task<IEnumerable<PaymentOrder>?> GetAllAsync(CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentOrder?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentOrder> AddAsync(PaymentOrder item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentOrder> UpdateAsync(PaymentOrder item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
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
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Status?> GetStatusByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Statuses.FirstOrDefaultAsync(s=>s.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<ICollection<TypeOperationPay>?> GetAllTypeOprrationPayAsync(CancellationToken cancel = default)
    {
        return await _db.TypeOperationsPay.ToArrayAsync(cancel).ConfigureAwait(false);
    }
}

