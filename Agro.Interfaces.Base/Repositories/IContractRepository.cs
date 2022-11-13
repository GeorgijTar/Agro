using Agro.DAL.Entities;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Counter;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface IContractRepository<Contract> : IBaseRepository<Contract> where Contract : Entity
{

    public Task<bool> RemoveFile(ScanFile file, CancellationToken cancel = default);

    public Task<bool> RemoveSpecification(SpecificationContract speciication, CancellationToken cancel = default);

    public Task<IEnumerable<GroupDoc>> GetGroupsAsync(CancellationToken cancel = default);

    public Task<IEnumerable<Contract>?> GetAllByIdStatusAsync(int idStatus, CancellationToken cancel = default);
    public Task<IEnumerable<Contract>?> GetAllByNoIdStatusAsync(int idStatus, CancellationToken cancel = default);
}