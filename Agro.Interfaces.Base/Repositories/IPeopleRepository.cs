
using Agro.DAL.Entities;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;
public interface IPeopleRepository : IBaseRepository<People>
{
    public Task<IEnumerable<IdentityDocument>?> GetAllDocumentsAsync(int idPeople, CancellationToken cancel = default);
    public Task<IdentityDocument?> GetDocumentAsync(int idPeople, CancellationToken cancel = default);
}
