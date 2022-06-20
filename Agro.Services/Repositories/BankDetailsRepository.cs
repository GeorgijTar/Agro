using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class BankDetailsRepository : IBankDetailsRepository<BankDetailsDto>
    {
        private readonly AgroDB _db;
        private readonly IMapper<BankDetailsDto, BankDetails> _map;

        public BankDetailsRepository(AgroDB db, IMapper<BankDetailsDto, BankDetails> map)
        {
            _db = db;
            _map = map;
        }

        public async Task<IEnumerable<BankDetailsDto>?> GetAllAsync(CancellationToken cancel = default)
        {
            var bd = await _db.Set<BankDetails>()
                .Include(b => b.Status)
                .Include(b => b.Counterparty)
                .ToArrayAsync(cancel).ConfigureAwait(false);
            return bd.Select(c => _map.Map(c)).ToArray();
        }

        public async Task<IEnumerable<BankDetailsDto>?> GetAllByCounterpartyAsync(
            int idCounterparty,
            CancellationToken cancel = default)
        {
            var bd = await _db.Set<BankDetails>().Where(b => b.Counterparty.Id == idCounterparty)
                .Include(b => b.Status)
                .Include(b => b.Counterparty)
                .ToArrayAsync(cancel).ConfigureAwait(false);
            return bd.Select(c => _map.Map(c)).ToArray();
        }

        public async Task<BankDetailsDto?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            return _map.Map(await _db.Set<BankDetails>()
                .FirstAsync(b => b.Id == id, cancel)
                .ConfigureAwait(false));
        }

        public async Task<bool> AddAsync(BankDetailsDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            _db.Entry(_map.Map(item)).State = EntityState.Added;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> UpdateAsync(BankDetailsDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            _db.Entry(_map.Map(item)).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteAsync(BankDetailsDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var bd = _map.Map(item);
            bd.Status = await _db.Statuses.FirstAsync(s => s.Id == 6).ConfigureAwait(false);
            _db.Entry(bd).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            var item = await _db.BankDetails.FirstAsync(i => i.Id == id, cancel).ConfigureAwait(false);
            if (item is null)
                throw new InvalidOperationException($"Запись с ID {id} в базе данных не найдена.");
            item.Status = await _db.Statuses.FirstAsync(s => s.Id == 6, cancel).ConfigureAwait(false);
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

    }
}
