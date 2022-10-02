

using Agro.DAL;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;
public class StaffListRepository : IBaseRepository<StaffList>
{
    private readonly AgroDb _db;

    public StaffListRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<StaffList>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.StaffList
            .Include(s=>s.Status!)
            .Include(s=>s.Positions!).ThenInclude(p=>p.Division)
            .Include(s => s.Positions!).ThenInclude(p => p.Post)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<StaffList?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.StaffList
            .Include(s => s.Status!)
            .Include(s => s.Positions!).ThenInclude(p => p.Division)
            .Include(s => s.Positions!).ThenInclude(p => p.Post)
            .FirstOrDefaultAsync(s=>s.Id==id, cancel).ConfigureAwait(false);
    }

    public async Task<StaffList> AddAsync(StaffList item, CancellationToken cancel = default)
    {
        var stafflist = await _db.StaffList.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return stafflist.Entity;
    }

    public async Task<StaffList> UpdateAsync(StaffList item, CancellationToken cancel = default)
    {
        var stafflist =  _db.StaffList.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return stafflist.Entity;
    }

    public async Task<bool> DeleteAsync(StaffList item, CancellationToken cancel = default)
    {
        _db.StaffList.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }
}
