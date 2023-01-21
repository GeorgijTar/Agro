
using Agro.DAL;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Bank.Base;
using Agro.DAL.Entities.Bank.Pay;
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.TaxesType;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories.References;
public class ReferencesRepository: IReferencesRepository
{
    private readonly AgroDb _db;

    public ReferencesRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Status>?> GetAllStatusAsync(CancellationToken cancel = default)
    {
        return await _db.Statuses.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TypeDoc>?> GetAllTypeDocAsync(CancellationToken cancel = default)
    {
        return await _db.Types.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<GroupDoc>?> GetAllGroupDocAsync(CancellationToken cancel = default)
    {
        return await _db.Groups.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TypeOperationPay>?> GetAllTypeOperationPayAsync(CancellationToken cancel = default)
    {
        return await _db.TypeOperationsPay.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TypeCommitment>?> GetAllTypeCommitmentAsync(CancellationToken cancel = default)
    {
        return await _db.TypesCommitments.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TypeCashFlow>?> GetAllTypeCashFlowAsync(CancellationToken cancel = default)
    {
        return await _db.TypeCashFlow.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<BasisPayment>?> GetAllBasisPaymentAsync(CancellationToken cancel = default)
    {
        return await _db.BasisPayment.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TypeTransactions>?> GetAllTypeTransactionsAsync(CancellationToken cancel = default)
    {
        return await _db.TypeTransactions.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<PayerStatus>?> GetAllPayerStatusAsync(CancellationToken cancel = default)
    {
        return await _db.PayerStatus.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Nds>?> GetAllNdsAsync(CancellationToken cancel = default)
    {
        return await _db.Ndses.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<BankDetails>?> GetAllBankDetailsOrgAsync(CancellationToken cancel = default)
    {
        return await _db.BankDetails.Where(b=>b.Organization!=null!).ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Organization?> GetOrganizationAsync(CancellationToken cancel = default)
    {
        return await _db.Organizations.FirstOrDefaultAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TypePayment>?> GetAllTypesPaymentAsync(CancellationToken cancel = default)
    {
        return await _db.TypePayment.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<OrderPayment>?> GetAllOrderPaymentAsync(CancellationToken cancel = default)
    {
        return await _db.OrderPayment.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<AccountingPlan>?> GetAllAccountingPlanAsync(CancellationToken cancel = default)
    {
        return await _db.AccountingPlans.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<StorageLocation>?> GetAllStorageLocationAsync(CancellationToken cancel = default)
    {
        return await _db.StorageLocations.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Currency>?> GetAllCurrencyAsync(CancellationToken cancel = default)
    {
        return await _db.Currency.ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<AccountingMethodNds>?> GetAllAccountingMethodNdsAsync(CancellationToken cancel = default)
    {
        return await _db.AccountingMethodsNds.ToArrayAsync(cancel).ConfigureAwait(false);
    }
}
