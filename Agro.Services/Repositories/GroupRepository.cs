using System;

using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class GroupRepository:IGroupRepository<GroupDto>
    {
        private readonly AgroDB _db;
        private readonly IMapper<GroupDto, GroupDoc> _map;

        public GroupRepository(AgroDB db, IMapper<GroupDto,GroupDoc> map)
        {
            _db = db;
            _map = map;
        }

        public async Task<IEnumerable<GroupDto>?> GetAllAsync(CancellationToken cancel = default)
        {
           var groups= await _db.Set<GroupDoc>().ToArrayAsync(cancel).ConfigureAwait(false);
           var grDto= groups.Select(g => _map.Map(g)).ToArray();
           return grDto;
        }

        public async Task<GroupDto?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            return _map.Map(await _db.Set<GroupDoc>().FirstAsync(g => g.Id == id, cancel).ConfigureAwait(false));
        }

        public Task<bool> AddAsync(GroupDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(GroupDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(GroupDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
