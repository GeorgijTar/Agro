using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.CheckingCounterparty;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface IRegistryInvoiceRepository<RegistryInvoice> : IBaseRepository<RegistryInvoice> where RegistryInvoice : Entity
{
    public Task<RegistryInvoice?> SetStatus(int idStatus, RegistryInvoice item, CancellationToken cancel = default);

}
