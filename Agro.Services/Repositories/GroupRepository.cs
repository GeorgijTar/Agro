using System;

using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class GroupRepository : IGroupRepository<GroupDto>
    {
        private readonly AgroDB _db;
        private readonly IMapper<GroupDto, GroupDoc> _map;

        public GroupRepository(AgroDB db, IMapper<GroupDto, GroupDoc> map)
        {
            _db = db;
            _map = map;
        }

        public async Task<IEnumerable<GroupDto>?> GetAllAsync(CancellationToken cancel = default)
        {
            IEnumerable<GroupDoc>? groups = await _db.Groups.ToArrayAsync(cancel).ConfigureAwait(false);
            var grDto = groups.Select(g => _map.Map(g)).ToArray();
            return grDto;
        }

        public async Task<IEnumerable<GroupDto>> GetAllByTypeApplicationAsync(string typeApplication, CancellationToken cancel = default)
        {
            try
            {
                var groups = await _db.Set<GroupDoc>().Where(t => t.TypeApplication == typeApplication).ToArrayAsync(cancel).ConfigureAwait(false);
                return groups.Select(g => _map.Map(g)).ToArray();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<GroupDto>? GetAllByTypeApplication(string typeApplication)
        {
            var groups =  _db.Set<GroupDoc>().Where(t => t.TypeApplication == typeApplication).ToArray();
            return groups.Select(g => _map.Map(g)).ToArray();
        }

        public async Task<GroupDto?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            return _map.Map(await _db.Set<GroupDoc>().FirstAsync(g => g.Id == id, cancel).ConfigureAwait(false));
        }

        public Task<GroupDto> AddAsync(GroupDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDto> UpdateAsync(GroupDto item, CancellationToken cancel = default)
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

        public IEnumerable<GroupDto>? GetAll()
        {
            IEnumerable<GroupDoc>? groups =  _db.Groups.ToArray();
            var grDto = groups.Select(g => _map.Map(g)).ToArray();
            return grDto;
        }

        public GroupDto? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
