
using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class NdsRepository:INdsRepository<NdsDto>
{
    private readonly AgroDB _db;
    private readonly IMapper<NdsDto, Nds> _map;

    public NdsRepository(AgroDB db, IMapper<NdsDto, Nds> map)
    {
        _db = db;
        _map = map;
    }
    public async Task<IEnumerable<NdsDto>?> GetAllAsync(CancellationToken cancel = default)
    {
        var nds = await _db.Ndses
            .ToArrayAsync(cancel).ConfigureAwait(false);
        return nds.Select(n => _map.Map(n)).ToArray();
    }

    public Task<IEnumerable<NdsDto>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<NdsDto?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        Nds? unit = await _db.Ndses
            .FirstOrDefaultAsync(p => p.Id == id, cancel).ConfigureAwait(false);
        return _map.Map(unit);
    }

    public async Task<NdsDto> AddAsync(NdsDto item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        Nds? unit = await _db.Ndses.FirstOrDefaultAsync(p => p.Percent == item.Percent, cancel).ConfigureAwait(false);
        if (unit != null!)
            throw new InvalidOperationException($"Единица измерения с процентом {item.Percent} уже есть в базе данных ID {unit.Id}");
        unit = _map.Map(item);
        _db.Ndses.Add(unit);
        await _db.SaveChangesAsync(cancel);
        return _map.Map(unit, item); 
    }

    public Task<NdsDto> UpdateAsync(NdsDto item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<NdsDto> SaveAsync(NdsDto item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(NdsDto item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<NdsDto>? GetAll()
    {
        var nds =  _db.Ndses.ToArray();
        return nds.Select(n => _map.Map(n)).ToArray();
    }

    public NdsDto? GetById(int id)
    {
        throw new NotImplementedException();
    }
}
