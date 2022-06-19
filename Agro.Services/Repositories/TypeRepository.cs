using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class TypeRepository:ITypeRepository<TypeDoc>
    {
        private readonly AgroDB _db;

        public TypeRepository(AgroDB db)
        {
            _db = db;
        }
        public async Task<IEnumerable<TypeDoc>> GetAllAsync(CancellationToken cancel = default)
        {
            return await _db.Set<TypeDoc>().ToArrayAsync(cancel).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TypeDoc>> GetAllByTypeApplicationAsync(string typeApplication, CancellationToken cancel = default)
        {
            return await _db.Set<TypeDoc>().Where(t=>t.TypeApplication==typeApplication).ToArrayAsync(cancel).ConfigureAwait(false);
        }

        public Task<TypeDoc> AddAsync(TypeDoc item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<TypeDoc> UpdateAsync(TypeDoc item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<TypeDoc> DeleteAsync(TypeDoc item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
