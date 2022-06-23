
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories
{
    public interface IGroupRepository<GroupDto>:IBaseRepository<GroupDto>
    {
        public Task<IEnumerable<GroupDto>> GetAllByTypeApplicationAsync(string typeApplication,
            CancellationToken cancel = default);
    }
}
