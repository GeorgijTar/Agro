
using Agro.DAL;
using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class DepartmentRepository : IBaseRepository<Department>
{
    private readonly AgroDb _db;

    public DepartmentRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Department>?> GetAllAsync(CancellationToken cancel = default)
    {
       return await _db.Departments
           .Include(d=>d.Status)
           .Include(d => d.Fields!).ThenInclude(f => f.ParentField)
           .Include(d => d.Fields!).ThenInclude(f => f.LandPlots)
           .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Department?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Departments
            .Include(d => d.Status)
            .Include(d => d.Fields!).ThenInclude(f => f.ParentField)
            .Include(d => d.Fields!).ThenInclude(f => f.LandPlots)
            .FirstOrDefaultAsync(d=>d.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<Department> AddAsync(Department item, CancellationToken cancel = default)
    {
        var dep = (await _db.Departments.AddAsync(item).ConfigureAwait(false)).Entity;
        await _db.SaveChangesAsync(cancel);
        return dep;
    }

    public async Task<Department> UpdateAsync(Department item, CancellationToken cancel = default)
    {
        var dep = (_db.Departments.Update(item)).Entity;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return dep;
    }

    public async Task<bool> DeleteAsync(Department item, CancellationToken cancel = default)
    {
        var dep = (_db.Remove(item)).Entity;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<DateTime> GetClosedPeriodAsync(CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }
}
