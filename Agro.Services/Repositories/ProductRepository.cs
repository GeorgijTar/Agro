using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class ProductRepository : IBaseRepository<Product>
{
    private readonly AgroDb _db;

    public ProductRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Product>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.Products
            .Include(p=>p.Status)
            .Include(p=>p.Group)
            .Include(p=>p.Unit)
            .Include(p=>p.Nds)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
       return await _db.Products.FirstOrDefaultAsync(p=>p.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<Product> AddAsync(Product item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        await _db.Products.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return item;
    }

    public async Task<Product> UpdateAsync(Product item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        _db.Products.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item;
    }

    public async Task<bool> DeleteAsync(Product item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        _db.Products.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        var item = await _db.Products.FirstOrDefaultAsync(s => s.Id == id, cancel).ConfigureAwait(false);
        if (item is null)
            throw new ArgumentNullException($"Продукт с идентификатором {id} в базе данных не найден, возможно он уже удален");

        _db.Products.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }
}