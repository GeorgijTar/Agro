

using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories
{
    public interface ITypeRepository<TypeDocDto> :IBaseRepository<TypeDocDto>
    {
        public Task<IEnumerable<TypeDocDto>> GetAllByTypeApplicationAsync(string typeApplication,
            CancellationToken cancel = default);
    }
}
