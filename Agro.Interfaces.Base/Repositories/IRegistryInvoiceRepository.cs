using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface IRegistryInvoiceRepository<RegistryInvoice> : IBaseRepository<RegistryInvoice> where RegistryInvoice : Entity
{
    public Task<RegistryInvoice> SetStatusAsync(int idStatus, RegistryInvoice item, CancellationToken cancel = default);

    public Task<Status?> GetStatusAsync(int idStatus, CancellationToken cancel = default);

    public Task<RegistryInvoice> AcceptanceAsync(RegistryInvoice item, CancellationToken cancel = default);

    public Task<RegistryInvoice> RejectAsync(RegistryInvoice item, CancellationToken cancel = default);
    

    public Task<IEnumerable<Invoice>?> GetRegisterAcceptAsync(CancellationToken cancel = default);

    public Task<int> GetNumberRegisterAsync(CancellationToken cancel = default);

    public Task<IEnumerable<RegistryInvoice>> GetAllByIdAsync(int idStatus, CancellationToken cancel = default);

    public Task<IEnumerable<RegistryInvoice>> GetAllByIdNoAsync(int idStatus, CancellationToken cancel = default);

    public Task<Invoice?> GetInvoseScanFilesAsync(int invoiceId, CancellationToken cancel = default);

    public  Task<RegistryInvoice> DeleteRegAsync(RegistryInvoice item, CancellationToken cancel = default);

}
