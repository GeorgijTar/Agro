using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
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

        public async Task<BankDetailsDto> AddAsync(BankDetailsDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var dbItem = _map.Map(item);
            var x= await _db.BankDetails.AddAsync(dbItem, cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(cancel);
            return _map.Map(x.Entity);
        }

        public async Task<BankDetailsDto> UpdateAsync(BankDetailsDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var _dbBankDetails=await _db.BankDetails.FirstOrDefaultAsync(b=>b.Id==item.Id, cancel).ConfigureAwait(false);
            if (_dbBankDetails is null)
                throw new InvalidOperationException($" Банковские реквизиты с id {item.Id} в базе не найден");
            var _bankDetails = _map.Map(item, _dbBankDetails);
            var resalt= _db.BankDetails.Update(_bankDetails);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return _map.Map(resalt.Entity);
        }

        public async Task<bool> DeleteAsync(BankDetailsDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var bankDb= await _db.BankDetails.FirstOrDefaultAsync(b=>b.Id==item.Id);
            if (bankDb is null)
                throw new InvalidOperationException($"Запись с Id={item.Id} в базе данных не найдене, возможно она была удалена ранее");
            var bd = _map.Map(item, bankDb);
            _db.BankDetails.Remove(bd);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            var item = await _db.BankDetails.FirstAsync(i => i.Id == id, cancel).ConfigureAwait(false);
            if (item is null)
                throw new InvalidOperationException($"Запись с ID {id} в базе данных не найдена, возможно она была удалена ранее");
            _db.BankDetails.Remove(item);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

    }
}
