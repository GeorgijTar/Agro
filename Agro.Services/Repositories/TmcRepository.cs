using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.DAL;
using Agro.DAL.Entities.Warehouse;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class TmcRepository: IBaseRepository<Tmc>
    {
        private readonly AgroDb _db;

        public TmcRepository(AgroDb db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Tmc>?> GetAllAsync(CancellationToken cancel = default)
        {
            return await _db.Tmc
                .Include(t=>t.RulesAccountings!).ThenInclude(r=>r.AccountingPlan)
                .Include(t => t.RulesAccountings!).ThenInclude(r => r.AccountingPlanNds)
                .Include(t => t.RulesAccountings!).ThenInclude(r => r.Status)
                .Include(t => t.Status)
                .Include(t=>t.Group)
                .Include(t=>t.Unit)
                .ToArrayAsync(cancel).ConfigureAwait(false);
        }

        public async Task<Tmc?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            return await _db.Tmc
                .Include(t => t.RulesAccountings!).ThenInclude(r => r.AccountingPlan)
                .Include(t => t.RulesAccountings!).ThenInclude(r => r.AccountingPlanNds)
                .Include(t => t.RulesAccountings!).ThenInclude(r => r.Status)
                .Include(t => t.Status)
                .Include(t => t.Group)
                .Include(t => t.Unit)
                .FirstOrDefaultAsync(t=>t.Id==id, cancel).ConfigureAwait(false);
        }

        public async Task<Tmc> AddAsync(Tmc item, CancellationToken cancel = default)
        {
            var tmc=await _db.Tmc.AddAsync(item, cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(cancel);
            return tmc.Entity;
        }

        public async Task<Tmc> UpdateAsync(Tmc item, CancellationToken cancel = default)
        {
            var tmc =  _db.Tmc.Update(item);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return tmc.Entity;
        }

        public async Task<bool> DeleteAsync(Tmc item, CancellationToken cancel = default)
        {
            _db.Tmc.Remove(item);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
