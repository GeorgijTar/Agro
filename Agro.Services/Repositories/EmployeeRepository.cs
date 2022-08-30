

using Agro.DAL;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class EmployeeRepository : IBaseRepository<Employee>
{
    private readonly AgroDb _db;

    public EmployeeRepository(AgroDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Employee>?> GetAllAsync(CancellationToken cancel = default)
    {
       return await _db.Employee
           .Include(e=>e.People)
           .Include(e=>e.Division)
           .Include(e=>e.Status)
           .Include(e=>e.Post)
           .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<Employee?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Employee
            .Include(e => e.People)
            .Include(e => e.Division)
            .Include(e => e.Status)
            .Include(e => e.Post)
            .FirstOrDefaultAsync(e=>e.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<Employee> AddAsync(Employee item, CancellationToken cancel = default)
    {
        var ep= await _db.Employee.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return ep.Entity;
    }

    public async Task<Employee> UpdateAsync(Employee item, CancellationToken cancel = default)
    {
        var ep =  _db.Employee.Update(item);
        await _db.SaveChangesAsync(cancel);
        return ep.Entity;
    }

    public async Task<bool> DeleteAsync(Employee item, CancellationToken cancel = default)
    {
        _db.Employee.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }
}
