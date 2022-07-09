
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;
public interface IInvoiceRepository<InvoiceDto> : IBaseRepository<InvoiceDto>
{
    Task<string> GetNumber(CancellationToken cancel = default);


}
