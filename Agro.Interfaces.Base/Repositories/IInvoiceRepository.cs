using Agro.DAL.Entities;
using Agro.DAL.Entities.Base;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface IInvoiceRepository<Invoice> : IBaseRepository<Invoice> where Invoice : Entity
{
    public Task<string> GetNumber(Invoice invoice, CancellationToken cancel = default);

    public Task<Status?> GetStatusById(int idStatus, CancellationToken cancel = default);

    public Task<ICollection<BankDetails>?> GetAllBankDetailsOrg(CancellationToken cancel = default);

    public Task<bool> RemoveFile(ScanFile file, CancellationToken cancel = default);

    public Task<bool> RemoveProductInvoice(ProductInvoice product, CancellationToken cancel = default);

    public Task<ICollection<Nds>?> GetAllNds(CancellationToken cancel = default);

}