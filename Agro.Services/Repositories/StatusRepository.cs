using Agro.DAL;
using System.Linq;
using System.Linq.Expressions;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class StatusRepository:IStatusRepository<StatusDto>
    {
        private readonly AgroDB _db;
        private readonly IMapper<StatusDto, Status> _map;
        private IQueryable queryable;
        public StatusRepository(AgroDB db, IMapper<StatusDto, Status> map)
        {
            _db = db;
            _map = map;
            queryable = _db.Statuses;
        }
        public async Task<IEnumerable<StatusDto>?> GetAllAsync(CancellationToken cancel = default)
        {
            var statuses = await _db.Set<Status>().ToArrayAsync(cancel).ConfigureAwait(false);
            return statuses.Select(s => _map.Map(s)).ToArray();
        }

        public Task<IEnumerable<StatusDto>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<StatusDto?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<StatusDto> AddAsync(StatusDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<StatusDto> UpdateAsync(StatusDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<StatusDto> SaveAsync(StatusDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(StatusDto item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusDto>? GetAll()
        {
            throw new NotImplementedException();
        }

        public StatusDto? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
