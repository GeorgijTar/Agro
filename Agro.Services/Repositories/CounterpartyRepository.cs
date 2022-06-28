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

        public async Task<CounterpartyDto> AddAsync(CounterpartyDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var dbCounterparty = _map.Map(item);
            var resalt = await _db.Counterparties.AddAsync(dbCounterparty, cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return _map.Map(resalt.Entity);
        }

        public async Task<CounterpartyDto> UpdateAsync(CounterpartyDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            Counterparty? dbCounterparty = _db.Counterparties.FirstOrDefault(c => c.Id == item.Id);
            if (dbCounterparty is null)
                throw new InvalidOperationException($" Контрагент с id {item.Id} в базе не найден");
            var it = _map.Map(item, dbCounterparty);
            var resalt= _db.Counterparties.Update(it);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return _map.Map(resalt.Entity);
        }

        public async Task<bool> DeleteAsync(CounterpartyDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var counterparty= await _db.Counterparties.FirstOrDefaultAsync(c => c.Id == item.Id && c.StatusId!=6, cancel);
            if (counterparty is null)
                throw new InvalidOperationException($"Контрагент с ID={item.Id} в базе данных не найден");
            counterparty.StatusId = 6;
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

        public IEnumerable<CounterpartyDto>? GetAll()
        {
            throw new NotImplementedException();
        }

        public CounterpartyDto? GetById(int id)
        {
            throw new NotImplementedException();
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
