
using Agro.DAL.Entities;
using Agro.DAL;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class InvoiceRepository : IBaseRepository<InvoiceDto>
{
    private readonly AgroDB _db;
    private readonly IMapper<InvoiceDto, Invoice> _map;

    public InvoiceRepository(AgroDB db, IMapper<InvoiceDto, Invoice> map)
    {
        _db = db;
        _map = map;
    }

    public async Task<IEnumerable<InvoiceDto>?> GetAllAsync(CancellationToken cancel = default)
    {
        var invoices = await _db.Invoices
            .Include(i=>i.Status)
            .Include(i=>i.Counterparty)
            .Include(i=>i.BankDetails)
            .Include(i=>i.Type)
            .Include(i=>i.ScanFiles)
            .Include(i=>i.BankDetailsOrg)
            .OrderBy(i=>i.Number)
            .ToArrayAsync();
            
        return invoices.Select(i => _map.Map(i)).OrderBy(i=>i.DateInvoce).ToArray();
    }

    public async Task<IEnumerable<InvoiceDto>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default)
    {
        var invoices = await _db.Invoices
            .Where(i=>i.StatusId==statusId)
            .Include(i => i.Status)
            .Include(i => i.Counterparty)
            .Include(i => i.BankDetails)
            .Include(i => i.Type)
            .Include(i => i.ScanFiles)
            .Include(i => i.BankDetailsOrg)
            .OrderBy(i => i.Number)
            .ToArrayAsync();

        return invoices.Select(i => _map.Map(i)).OrderBy(i => i.DateInvoce).ToArray();
    }

    public Task<InvoiceDto?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<InvoiceDto> AddAsync(InvoiceDto item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<InvoiceDto> UpdateAsync(InvoiceDto item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<InvoiceDto> SaveAsync(InvoiceDto item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(InvoiceDto item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<InvoiceDto>? GetAll()
    {
        throw new NotImplementedException();
    }

    public InvoiceDto? GetById(int id)
    {
        throw new NotImplementedException();
    }
}