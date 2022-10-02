using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.DAL;
using Agro.DAL.Entities.Counter;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class CounterpartyRepository: IBaseRepository<Counterparty>
    {
        private readonly AgroDb _db;

        public CounterpartyRepository(AgroDb db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Counterparty>?> GetAllAsync(CancellationToken cancel = default)
        {
            return await _db.Counterparties
                .Include(c=>c.Group)
                .Include(c=>c.ActualAddress)
                .Include(c=>c.BankDetails)
                .Include(c=>c.TypeDoc)
                .Include(c=>c.Status)
                .ToArrayAsync(cancel).ConfigureAwait(false);
        }

        public async Task<Counterparty?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            return await _db.Counterparties
                .Include(c => c.Group)
                .Include(c => c.ActualAddress)
                .Include(c => c.BankDetails)
                .Include(c => c.TypeDoc)
                .Include(c => c.Status)
                .FirstOrDefaultAsync(c=>c.Id==id, cancel).ConfigureAwait(false);
        }

        public async Task<Counterparty> AddAsync(Counterparty item, CancellationToken cancel = default)
        {
            var contr=await _db.Counterparties.AddAsync(item, cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(cancel);
            return contr.Entity;

        }

        public async Task<Counterparty> UpdateAsync(Counterparty item, CancellationToken cancel = default)
        {
            var contr =  _db.Counterparties.Update(item);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return contr.Entity;
        }

        public async Task<bool> DeleteAsync(Counterparty item, CancellationToken cancel = default)
        {
            item.Status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == 6, cancel).ConfigureAwait(false);
            var contr = _db.Counterparties.Update(item);
            await _db.SaveChangesAsync(cancel);
            return true;
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
