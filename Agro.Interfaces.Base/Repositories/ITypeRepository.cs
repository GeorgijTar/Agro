

namespace Agro.Interfaces.Base.Repositories
{
    public interface ITypeRepository<TypeDoc>
    {
        Task<IEnumerable<TypeDoc>> GetAllAsync(CancellationToken cancel = default);

        Task<IEnumerable<TypeDoc>> GetAllByTypeApplicationAsync(string typeApplication, CancellationToken cancel = default);

        Task<TypeDoc> AddAsync(TypeDoc item, CancellationToken cancel = default);

        Task<TypeDoc> UpdateAsync(TypeDoc item, CancellationToken cancel = default);

        Task<TypeDoc> DeleteAsync(TypeDoc item, CancellationToken cancel = default);
    }
}
