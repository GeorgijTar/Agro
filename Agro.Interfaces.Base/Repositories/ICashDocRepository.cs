

using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Weight;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface ICashDocRepository<DocCash> : IBaseRepository<Agro.DAL.Entities.Kassa.DocCash>
{
    public Task<ObservableCollection<DocCash>?> GetAllNoTrecAsync(CancellationToken cancel = default);

    public Task<int> GetNumberDocAsync(Agro.DAL.Entities.Kassa.DocCash doc, CancellationToken cancel = default);

    public Task<DocCash?> GetByIdNoTrecAsync(int idDocCash, CancellationToken cancel = default);

    public Task<decimal> GetBalanceCashAsync(CancellationToken cancel = default);

    public Task<decimal> GetBalanceCashByDateAsync(DateTime date, CancellationToken cancel = default);

    public Task<bool> SpendDocCashAsync(DocCash docCash, Status newStatus, CancellationToken cancel = default);

    public Task<bool> CancelSpendDocCashAsync(DocCash docCash, Status newStatus, CancellationToken cancel = default);

}
