
namespace Agro.Interfaces.Base.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>?> GetAllAsync(CancellationToken cancel = default);
        Task<T?> GetByIdAsync(int id, CancellationToken cancel = default);
        Task<T> AddAsync(T item, CancellationToken cancel = default);
        Task<T> UpdateAsync(T item, CancellationToken cancel = default);
        Task<bool> DeleteAsync(T item, CancellationToken cancel = default);
        Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default);
        public IEnumerable<T>? GetAll();

        public T? GetById(int id);
    }
}
