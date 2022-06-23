using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class TypeRepository:ITypeRepository<TypeDocDto>
    {
        private readonly AgroDB _db;
        private readonly IMapper<TypeDocDto, TypeDoc> _map;

        public TypeRepository(AgroDB db, IMapper<TypeDocDto, TypeDoc> map)
        {
            _db = db;
            _map = map;
        }
        public async Task<IEnumerable<TypeDocDto>?> GetAllAsync(CancellationToken cancel = default)
        {
            var types = await _db.Set<TypeDoc>().ToArrayAsync(cancel).ConfigureAwait(false);
            return types.Select(t => _map.Map(t)).ToArray();
        }

        public async Task<TypeDocDto?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            return _map.Map(await _db.Set<TypeDoc>().FirstAsync(t => t.Id == id, cancel).ConfigureAwait(false));
        }

        public async Task<IEnumerable<TypeDocDto>> GetAllByTypeApplicationAsync(string typeApplication, CancellationToken cancel = default)
        {
            var types = await _db.Set<TypeDoc>().Where(t=>t.TypeApplication==typeApplication).ToArrayAsync(cancel).ConfigureAwait(false);
            return types.Select(t => _map.Map(t)).ToArray();
        }

        public Task<TypeDocDto> AddAsync(TypeDocDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<TypeDocDto> UpdateAsync(TypeDocDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TypeDocDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
