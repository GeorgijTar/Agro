using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class UnitRepository:IUnitRepository<UnitOkeiDto>
{
    private readonly AgroDB _db;
    private readonly IMapper<UnitOkeiDto, UnitOkei> _map;

    public UnitRepository(AgroDB db, IMapper<UnitOkeiDto, UnitOkei> map)
    {
        _db = db;
        _map = map;
    }
    public async Task<IEnumerable<UnitOkeiDto>?> GetAllAsync(CancellationToken cancel = default)
    {
        var unit = await _db.UnitsOkei
            .Include(u=>u.Status)
            .ToArrayAsync(cancel).ConfigureAwait(false);
        return unit.Select(p => _map.Map(p)).ToArray();
    }

    public Task<IEnumerable<UnitOkeiDto>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<UnitOkeiDto?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        UnitOkei? unit = await _db.UnitsOkei
            .Include(u=>u.Status)
            .FirstOrDefaultAsync(p => p.Id == id, cancel).ConfigureAwait(false);
        return _map.Map(unit);
    }

    public async Task<UnitOkeiDto> AddAsync(UnitOkeiDto item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        UnitOkei? unit = await _db.UnitsOkei.FirstOrDefaultAsync(p => p.Name == item.Name, cancel).ConfigureAwait(false);
        if (unit != null!)
            throw new InvalidOperationException($"Единица измерения с наименование {item.Name} уже есть в базе данных ID {unit.Id}");
        unit = _map.Map(item);
        _db.UnitsOkei.Add(unit);
        await _db.SaveChangesAsync(cancel);
        return _map.Map(unit, item);
    }

    public async Task<UnitOkeiDto> UpdateAsync(UnitOkeiDto item, CancellationToken cancel = default)
    {

        if (item is null)
            throw new ArgumentNullException(nameof(item));

        UnitOkei? unit = await _db.UnitsOkei.FirstOrDefaultAsync(p => p.Id == item.Id, cancel).ConfigureAwait(false);
        if (unit! == null!)
            throw new InvalidOperationException($"Единица измерения с ID {item.Id} в базе данных не найден");
        var uo = _map.Map(item, unit);
        _db.UnitsOkei.Update(uo);
        await _db.SaveChangesAsync(cancel);
        return _map.Map(uo, item);
    }

    public Task<UnitOkeiDto> SaveAsync(UnitOkeiDto item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(UnitOkeiDto item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        var unit = await _db.UnitsOkei.FirstOrDefaultAsync(c => c.Id == item.Id && c.StatusId != 6, cancel);
        if (unit is null)
            throw new InvalidOperationException($"Единица измерения с ID={item.Id} в базе данных не найден");
        unit.StatusId = 6;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        var item = await _db.UnitsOkei.FirstAsync(i => i.Id == id, cancel).ConfigureAwait(false);
        if (item is null)
            throw new InvalidOperationException($"Товар с ID={item.Id} в базе данных не найден");
        item.Status = await _db.Statuses.FirstAsync(s => s.Id == 6, cancel).ConfigureAwait(false);
        _db.Entry(item).State = EntityState.Modified;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return true;
    }

    public IEnumerable<UnitOkeiDto>? GetAll()
    {
        var unit =  _db.UnitsOkei
            .Include(u => u.Status)
            .ToArray();
        return unit.Select(p => _map.Map(p)).ToArray();
    }

    public UnitOkeiDto? GetById(int id)
    {
        throw new NotImplementedException();
    }
}
