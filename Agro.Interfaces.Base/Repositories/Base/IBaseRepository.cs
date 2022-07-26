
using Agro.DAL.Entities.Base;

namespace Agro.Interfaces.Base.Repositories.Base
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<IEnumerable<T>?> GetAllAsync(CancellationToken cancel = default);
        
        Task<T?> GetByIdAsync(int id, CancellationToken cancel = default);

        Task<T> AddAsync(T item, CancellationToken cancel = default);

        Task<T> UpdateAsync(T item, CancellationToken cancel = default);

       async Task<T> SaveAsync(T item, CancellationToken cancel = default)
        {
            if (item.Id == 0)
            {
                return await AddAsync(item, cancel);
            }
            else
            {
                return await UpdateAsync(item, cancel);
            }
        }

        Task<bool> DeleteAsync(T item, CancellationToken cancel = default);

        Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default);
    }
}
