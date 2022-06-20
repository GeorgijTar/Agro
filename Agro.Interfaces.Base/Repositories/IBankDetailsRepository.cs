using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Services.Repositories
{
    public interface IBankDetailsRepository<BankDetailsDto> :IBaseRepository<BankDetailsDto>
    {
        public Task<IEnumerable<BankDetailsDto>?> GetAllByCounterpartyAsync(int idCounterparty, CancellationToken cancel = default);
    }
}
