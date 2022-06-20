using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class CounterpartyRepository : ICounterpertyRepository<CounterpartyDto>
    {
        private readonly AgroDB _db;
        private readonly IMapper<CounterpartyDto, Counterparty> _map;

        public CounterpartyRepository(AgroDB db, IMapper<CounterpartyDto, Counterparty> map)
        {
            _db = db;
            _map = map;
        }
        public async Task<IEnumerable<CounterpartyDto>?> GetAllAsync(CancellationToken cancel = default)
        {
            var col = await _db.Set<Counterparty>()
                 .Include(c => c.Status)
                 .Include(c => c.Group)
                 .Include(c => c.TypeDoc)
                 .Include(c => c.BankDetails)
                 .ToArrayAsync(cancel).ConfigureAwait(false);
            return col.Select(c => _map.Map(c)).ToArray();
        }

        public async Task<CounterpartyDto?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            return _map.Map(await _db.Set<Counterparty>().FirstAsync(c => c.Id == id, cancel).ConfigureAwait(false));
        }

        public async Task<bool> AddAsync(CounterpartyDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            _db.Entry(_map.Map(item)).State = EntityState.Added;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> UpdateAsync(CounterpartyDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var it = _map.Map(item);
            _db.Entry(it).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteAsync(CounterpartyDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var it = _map.Map(item);
            it.Status = await _db.Statuses.FirstAsync(s => s.Id == 6, cancel).ConfigureAwait(false);
            _db.Entry(it).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            var item = await _db.Counterparties.FirstAsync(i => i.Id == id, cancel).ConfigureAwait(false);
            if (item is null)
                throw new InvalidOperationException($"Запись с ID {id} не найдена.");
            item.Status = await _db.Statuses.FirstAsync(s => s.Id == 6, cancel).ConfigureAwait(false);
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<IEnumerable<CounterpartyDto>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default)
        {
            var col = await _db.Set<Counterparty>()
                 .Where(c => c.Status.Id == statusId)
                 .Include(c => c.Status)
                 .Include(c => c.Group)
                 .Include(c => c.TypeDoc)
                 .Include(c => c.BankDetails)
                 .ToArrayAsync(cancel).ConfigureAwait(false);
            return col.Select(c => _map.Map(c)).ToArray();
        }


    }
}
