

using Agro.DAL.Entities;
using Agro.DAL.Entities.Bank.Base;
using Agro.DAL.Entities.Base;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface IExpenditureItemRepository<ExpenditureItem> : IBaseRepository<ExpenditureItem> where ExpenditureItem : Entity
{
    public Task<IEnumerable<ExpenditureItem>?> GetAllNoTrackingAsync(CancellationToken cancel = default);
   
    public Task<IEnumerable<ExpenditureItem>?> GetAllByDirectionNoTrackingAsync(bool isDirection=false, bool direction=false, CancellationToken cancel = default);

    public Task<IEnumerable<TypeCashFlow>?> GetAllTypeCashFlowNoTrackingAsync(CancellationToken cancel = default);

    public Task<TypeCashFlow?> GetTypeCashFlowByIdAsync(int id, CancellationToken cancel = default);

    public Task<Status?> GetStatusByIdAsync(int id, CancellationToken cancel = default);
}