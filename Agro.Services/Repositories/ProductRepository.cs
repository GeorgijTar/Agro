
using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class ProductRepository:IProductRepository<ProductDto>
{
    private readonly AgroDB _db;
    private readonly IMapper<ProductDto, Product> _map;

    public ProductRepository(AgroDB db, IMapper<ProductDto, Product> map)
    {
        _db = db;
        _map = map;
    }

    public async Task<IEnumerable<ProductDto>?> GetAllAsync(CancellationToken cancel = default)
    {
        var products = await _db.Products
            .Include(p=>p.Status)
            .Include(p=>p.Group)
            .Include(p => p.Type)
            .Include(p => p.Unit)
            .Include(p => p.Nds)
            .ToArrayAsync(cancel).ConfigureAwait(false);
        return products.Select(p=>_map.Map(p)).ToArray();
    }

    public async Task<IEnumerable<ProductDto>?> GetAllByStatusAsync(int idStatus, CancellationToken cancel = default)
    {
        var products = await _db.Products
            .Where(p=>p.StatusId==idStatus)
            .Include(p => p.Status)
            .Include(p => p.Group)
            .Include(p => p.Type)
            .Include(p => p.Unit)
            .Include(p => p.Nds)
            .ToArrayAsync(cancel).ConfigureAwait(false);
        return products.Select(p => _map.Map(p)).ToArray();
    }

    public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        var products = await _db.Products
            .Include(p => p.Status)
            .Include(p => p.Group)
            .Include(p => p.Type)
            .Include(p => p.Unit)
            .Include(p => p.Nds)
            .FirstOrDefaultAsync(p=>p.Id==id, cancel).ConfigureAwait(false);
        return _map.Map(products);
    }

    public async Task<ProductDto> AddAsync(ProductDto item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        Product? productDb= await _db.Products.FirstOrDefaultAsync(p=>p.Name==item.Name, cancel).ConfigureAwait(false);
        if (productDb!= null!)
            throw new InvalidOperationException($"Товар с наименование {item.Name} уже есть в базе данных ID {productDb.Id}");
        productDb = _map.Map(item);
        _db.Products.Add(productDb);
       await _db.SaveChangesAsync(cancel);
       return _map.Map(productDb, item);
    }

    public async Task<ProductDto> UpdateAsync(ProductDto item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        Product? productDb = await _db.Products.FirstOrDefaultAsync(p => p.Id == item.Id, cancel).ConfigureAwait(false);
        if (productDb! == null!)
            throw new InvalidOperationException($"Товар с ID {item.Id} в базе данных не найден");
       var pd = _map.Map(item, productDb);
        _db.Products.Update(pd);
        await _db.SaveChangesAsync(cancel);
        return _map.Map(pd, item);
    }

    public async Task<bool> DeleteAsync(ProductDto item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var productDb = await _db.Products.FirstOrDefaultAsync(c => c.Id == item.Id && c.StatusId != 6, cancel);
        if (productDb is null)
            throw new InvalidOperationException($"Товар с ID={item.Id} в базе данных не найден");
        productDb.StatusId = 6;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        var item = await _db.Products.FirstAsync(i => i.Id == id, cancel).ConfigureAwait(false);
        if (item is null)
            throw new InvalidOperationException($"Товар с ID={item.Id} в базе данных не найден");
        item.Status = await _db.Statuses.FirstAsync(s => s.Id == 6, cancel).ConfigureAwait(false);
        _db.Entry(item).State = EntityState.Modified;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }
}
