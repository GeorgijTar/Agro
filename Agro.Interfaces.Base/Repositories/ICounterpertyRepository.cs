using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories
{
    public interface ICounterpertyRepository<Counterparty>:IBaseRepository<Counterparty>
    {
        public Task<IEnumerable<Counterparty>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default);
    }
}
