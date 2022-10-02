using Agro.DAL.Entities;
using Agro.DAL.Entities.Base;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface IContractRepository<Contract> : IBaseRepository<Contract> where Contract : Entity
{

    public Task<bool> RemoveFile(ScanFile file, CancellationToken cancel = default);

}