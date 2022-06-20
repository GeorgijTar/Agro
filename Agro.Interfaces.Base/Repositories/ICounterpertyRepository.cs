using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories
{
    public interface ICounterpertyRepository<CounterpartyDto>:IBaseRepository<CounterpartyDto>
    {
        public Task<IEnumerable<CounterpartyDto>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default);
    }
}
