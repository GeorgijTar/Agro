using System;

using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class GroupRepository:IGroupRepository<GroupDoc>
    {
        private readonly AgroDB _db;

        public GroupRepository(AgroDB db)
        {
            _db = db;
        }
        public async Task<IEnumerable<GroupDoc>> GetAllAsync(CancellationToken cancel = default)
        {
            return await _db.Set<GroupDoc>().ToArrayAsync(cancel).ConfigureAwait(false);
        }

        public Task<GroupDoc> AddAsync(GroupDoc item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDoc> UpdateAsync(GroupDoc item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDoc> DeleteAsync(GroupDoc item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
