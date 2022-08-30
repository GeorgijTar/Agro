using Agro.DAL.Entities;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.Weight;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface IComingFieldRepository<ComingField> : IBaseRepository<ComingField> where ComingField : Entity
{
    public Task<int> GetNumber(ComingField coming, CancellationToken cancel = default);

    public Task<Status?> GetStatusById(int idStatus, CancellationToken cancel = default);

    public Task<IEnumerable<StorageLocation>?> GetAllStorageLocation(CancellationToken cancel = default);

    public Task<IEnumerable<Weight>?> GetAllWeight(CancellationToken cancel = default);

    
}