
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;
public interface IProductRepository<ProductDto> :IBaseRepository<ProductDto>
{
    public Task<IEnumerable<ProductDto>?> GetAllByStatusAsync(int idStatus, CancellationToken cancel = default);
}
