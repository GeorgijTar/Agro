
using Agro.DAL;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class StaffListPositionRepository: IBaseRepository<StaffListPosition>
{
    private readonly AgroDb _db;

    public StaffListPositionRepository(AgroDb db)
    {
        _db = db;
    }
    public async Task<IEnumerable<StaffListPosition>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.StaffListPositions
            .Include(s=>s.Post)
            .Include(s=>s.Division)
            .Include(s=>s.StaffList).ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<StaffListPosition?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.StaffListPositions
            .Include(s => s.Post)
            .Include(s => s.Division)
            .Include(s => s.StaffList)
            .FirstOrDefaultAsync(s=>s.Id==id,cancel).ConfigureAwait(false);
    }

    public Task<StaffListPosition> AddAsync(StaffListPosition item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<StaffListPosition> UpdateAsync(StaffListPosition item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(StaffListPosition item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
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