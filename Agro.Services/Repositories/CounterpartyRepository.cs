using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class CounterpartyRepository:ICounterpertyRepository<Counterparty>
    {
        private readonly AgroDB _db;

        public CounterpartyRepository(AgroDB db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Counterparty>?> GetAllAsync(CancellationToken cancel = default)
        {
          return await _db.Set<Counterparty>().AsNoTracking()
              .Include(c => c.Status)
              .Include(c => c.Group)
              .Include(c => c.TypeDoc)
              .ToArrayAsync(cancel).ConfigureAwait(false);
        }

        public async Task<Counterparty?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            return await _db.Set<Counterparty>().FirstAsync(c => c.Id == id, cancel);
        }

        public async Task<bool> AddAsync(Counterparty item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> UpdateAsync(Counterparty item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            _db.Entry(item).State= EntityState.Modified;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public Task<bool> DeleteAsync(Counterparty item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Counterparty>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default)
        {
            return await _db.Set<Counterparty>().AsNoTracking()
                .Where(c => c.Status.Id == statusId)
                .Include(c => c.Status)
                .Include(c => c.Group)
                .Include(c => c.TypeDoc)
                .ToArrayAsync(cancel).ConfigureAwait(false);
        }

       
    }
}
