using System.Formats.Asn1;
using Agro.DAL;
using Agro.DAL.Entities;
using Agro.Interfaces;
using Agro.Domain.Base;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class AccountingPlanRepository: IBaseRepository<AccountingPlanDto>
    {
        private readonly AgroDB _db;
        private readonly IMapper<AccountingPlanDto, AccountingPlan> _map;

        public AccountingPlanRepository(AgroDB db, IMapper<AccountingPlanDto, AccountingPlan> map)
        {
            _db = db;
            _map = map;
        }
        public async Task<IEnumerable<AccountingPlanDto>?> GetAllAsync(CancellationToken cancel = default)
        {
            var accountings = await _db.AccountingPlans
                .Include(a => a.Status)
                .ToArrayAsync(cancel).ConfigureAwait(false);
            return accountings.Select(a => _map.Map(a)).ToArray();
        }

        public async Task<IEnumerable<AccountingPlanDto>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default)
        {
            var accountings = await _db.AccountingPlans
                .Where(a=>a.StatusId==statusId)
                .Include(p=>p.ChildPlans)
                .Include(p=>p.ParentPlan)
                .Include(a => a.Status)
                .OrderBy(p=>p.Code)
                .OrderBy(p => p.Id)
                .ToArrayAsync(cancel).ConfigureAwait(false);
            return accountings.Select(a => _map.Map(a)).ToArray();
        }

        public async Task<AccountingPlanDto?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
            var accountings = await _db.AccountingPlans
                .Include(a => a.Status)
                .Include(a => a.ParentPlan)
                .FirstOrDefaultAsync(a => a.Id == id, cancel).ConfigureAwait(false);
            return _map.Map(accountings);
        }

        public async Task<AccountingPlanDto> AddAsync(AccountingPlanDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var dbItem = _map.Map(item);
            var x = await _db.AccountingPlans.AddAsync(dbItem, cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(cancel);
            return _map.Map(x.Entity);
        }

        public async Task<AccountingPlanDto> UpdateAsync(AccountingPlanDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var dbAccountings = await _db.AccountingPlans.FirstOrDefaultAsync(b => b.Id == item.Id, cancel).ConfigureAwait(false);
            if (dbAccountings is null)
                throw new InvalidOperationException($" Счет плана счетов с id {item.Id} в базе не найден");
            var _bankDetails = _map.Map(item, dbAccountings);
            var resalt = _db.AccountingPlans.Update(dbAccountings);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return _map.Map(resalt.Entity);
        }

        public async Task<AccountingPlanDto> SaveAsync(AccountingPlanDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (item.Id == 0)
            {
                return await AddAsync(item, cancel);
            }
            else
            {
                return await UpdateAsync(item, cancel);
            }
        }

        public async Task<bool> DeleteAsync(AccountingPlanDto item, CancellationToken cancel = default)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            var dbAccountings = await _db.AccountingPlans.FirstOrDefaultAsync(b => b.Id == item.Id).ConfigureAwait(false);
            if (dbAccountings is null)
                throw new InvalidOperationException($"Запись с Id={item.Id} в базе данных не найдене, возможно она была удалена ранее");
            var bd = _map.Map(item, dbAccountings);
            bd.StatusId = 6;
           await _db.SaveChangesAsync(cancel);
           return true;
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountingPlanDto>? GetAll()
        {
            throw new NotImplementedException();
        }

        public AccountingPlanDto? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
