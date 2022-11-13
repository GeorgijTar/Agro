using Agro.DAL.Entities.Base;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface ICheckCounterpartyRepository<CheckCounterparty> : IBaseRepository<CheckCounterparty>
    where CheckCounterparty : Entity
{
    public Task<CheckCounterparty?> GetByInnAsync(string inn, CancellationToken cancel = default);
}
    
