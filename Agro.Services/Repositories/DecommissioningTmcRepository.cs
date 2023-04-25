using System.Collections.ObjectModel;
using Agro.DAL;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Registers;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.Dto;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories
{
    public class DecommissioningTmcRepository: IDecommissioningTmcRepository<DecommissioningTmc>
    {
        private readonly AgroDb _db;

        public DecommissioningTmcRepository(AgroDb db)
        {
            _db = db;
        }
        public async Task<IEnumerable<DecommissioningTmc>?> GetAllAsync(CancellationToken cancel = default)
        {
           return await _db.DecommissioningTmc
               .AsNoTrackingWithIdentityResolution()
               .Include(d=>d.WriteOffObject)
               .Include(d=>d.Status)
               .Include(d=>d.History)
               .Include(d=>d.AccountingPlanRegisters)
               .Include(d=>d.DecommissioningStorno)
               .Include(d=>d.TypeDoc)
               .Include(d=>d.Storekeeper).ThenInclude(s=>s.People)
               .Include(d=>d.Mol).ThenInclude(m=>m.People)
               .Include(d=>d.Positions).ThenInclude(p=>p.Tmc)
               .Include(d => d.Positions).ThenInclude(p => p.AccountingPlan)
               .Include(d => d.Positions).ThenInclude(p => p.UnitOkei)
               .Include(d => d.Positions).ThenInclude(p => p.StorageLocation)
               .Include(d=>d.PurposeExpenditure).ThenInclude(p=>p.AccountingPlan)
               .ToArrayAsync(cancel).ConfigureAwait(false);
        }

        public async  Task<DecommissioningTmc?> GetByIdAsync(int id, CancellationToken cancel = default)
        {
           return await _db.DecommissioningTmc
               .Include(d => d.WriteOffObject)
               .Include(d => d.Status)
               .Include(d => d.History)
               .Include(d => d.AccountingPlanRegisters)
               .Include(d => d.DecommissioningStorno)
               .Include(d => d.TypeDoc)
               .Include(d => d.Storekeeper).ThenInclude(s => s.People)
               .Include(d => d.Mol).ThenInclude(m => m.People)
               .Include(d => d.Positions).ThenInclude(p => p.Tmc)
               .Include(d => d.Positions).ThenInclude(p => p.AccountingPlan)
               .Include(d => d.Positions).ThenInclude(p => p.UnitOkei)
               .Include(d => d.Positions).ThenInclude(p => p.StorageLocation)
               .Include(d => d.PurposeExpenditure).ThenInclude(p => p.AccountingPlan)
               .FirstOrDefaultAsync(d=>d.Id==id, cancel).ConfigureAwait(false);
        }

        public async Task<DecommissioningTmc> AddAsync(DecommissioningTmc item, CancellationToken cancel = default)
        {
            var decommissioningTmc = await _db.DecommissioningTmc.AddAsync(item, cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(cancel);
            return decommissioningTmc.Entity;
        }

        public async Task<DecommissioningTmc> UpdateAsync(DecommissioningTmc item, CancellationToken cancel = default)
        {
            if (item == null!)
            {
                throw new ArgumentNullException($"Попытка обновления в БД пустого элемента");
            }

            var decommissioningTmcDb = await _db.DecommissioningTmc.FirstOrDefaultAsync(c => c.Id == item.Id, cancel).ConfigureAwait(false);
            if (decommissioningTmcDb! == null!)
            {
                throw new ArgumentNullException($"В базе данных не найден документ № {item.Number} от {item.Date}");
            }

            var decommissioningTmc = _db.DecommissioningTmc.Update(item);
            await _db.SaveChangesAsync(cancel);
            return decommissioningTmc.Entity;
        }

        public Task<bool> DeleteAsync(DecommissioningTmc item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public async Task<DateTime> GetClosedPeriodAsync(CancellationToken cancel = default)
        {
            return await _db.ClosedPeriod.MaxAsync(c => c.Date, cancel).ConfigureAwait(false);
        }

        public async Task<DecommissioningTmcDto> GetDecommissioningTmcDtoAsync(DecommissioningTmc item, CancellationToken cancel = default)
        {
            var decommissioning = item;
            DecommissioningTmcDto decommissioningDto = new()
            {
                Id = decommissioning.Id,
                IdStatus = decommissioning.Status!.Id,
                Status = decommissioning.Status!.Name,
                StatusId = decommissioning.Status!.Id,
                TypeDoc = decommissioning.TypeDoc.Name,
                Number = decommissioning.Number.ToString(),
                Date = decommissioning.Date,
                WriteOffObject = decommissioning.WriteOffObject.Name,
                WriteOffObjectInvNumber = decommissioning.WriteOffObject.InvNumber!,
                WriteOffObjectRegNumber = decommissioning.WriteOffObject.RegNumber!,
                PurposeExpenditure = decommissioning.PurposeExpenditure.Name,
                Note = decommissioning.Note!
            };

            if (decommissioning.Positions.Count > 0)
            {
                decommissioningDto.Amount = decommissioning.Positions.Sum(p => p.Amount);
                decommissioningDto.Position = new();
                foreach (var position in decommissioning.Positions)
                {
                    var pos = new PositionDecommissioningTmcDto()
                    {
                        Id = position.Id,
                        IdTmc = position.Tmc.Id,
                        Guid = position.Guid,
                        NameTmc = position.Tmc.Name,
                        UnitOkei = position.UnitOkei.Abbreviation,
                        Quantity = position.Quantity,
                        Price = position.Price,
                        Amount = position.Amount,
                        AccountingPlan = position.AccountingPlan.Code,
                        StorageLocation = position.StorageLocation.Name,
                    };
                    decommissioningDto.Position.Add(pos);
                }
            }
            return decommissioningDto;
        }

        public async Task<DecommissioningTmcDto> GetDecommissioningTmcDtoByIdAsync(int id, CancellationToken cancel = default)
        {
            var decommissioning = await GetByIdAsync(id, cancel);
            DecommissioningTmcDto decommissioningDto = new()
            {
                Id = decommissioning!.Id,
                IdStatus = decommissioning.Status!.Id,
                Status = decommissioning.Status!.Name,
                StatusId = decommissioning.Status!.Id,
                TypeDoc = decommissioning.TypeDoc.Name,
                Number = decommissioning.Number.ToString(),
                Date = decommissioning.Date,
                WriteOffObject = decommissioning.WriteOffObject.Name,
                PurposeExpenditure = decommissioning.PurposeExpenditure.Name,
                WriteOffObjectInvNumber = decommissioning.WriteOffObject.InvNumber!,
                WriteOffObjectRegNumber = decommissioning.WriteOffObject.RegNumber!,
                Note = decommissioning.Note!
            };

            if (decommissioning.Positions.Count > 0)
            {
                decommissioningDto.Amount = decommissioning.Positions.Sum(p => p.Amount);
                decommissioningDto.Position = new();
                foreach (var position in decommissioning.Positions)
                {
                    var pos = new PositionDecommissioningTmcDto()
                    {
                        Id = position.Id,
                        Guid = position.Guid,
                        IdTmc = position.Tmc.Id,
                        NameTmc = position.Tmc.Name,
                        UnitOkei = position.UnitOkei.Abbreviation,
                        Quantity = position.Quantity,
                        Price = position.Price,
                        Amount = position.Amount,
                        AccountingPlan = position.AccountingPlan.Code,
                        StorageLocation = position.StorageLocation.Name,
                    };
                    decommissioningDto.Position.Add(pos);
                }
            }

            return decommissioningDto;
        }

        public async Task<ObservableCollection<DecommissioningTmcDto>> GetAllDecommissioningTmcDtoAsync(CancellationToken cancel = default)
        {
            ObservableCollection<DecommissioningTmcDto> collection = new();
            var collectionBase = await GetAllAsync(cancel);
            foreach (var tmc in collectionBase)
            {
                collection.Add(await GetDecommissioningTmcDtoAsync(tmc));
            }

            return collection;
        }

        public async Task<int> GetRegNumberAsync(DateTime date, CancellationToken cancel = default)
        {
            int max = 0;

            if (_db.DecommissioningTmc
                .Where(s => s.Date.Year == date.Year)
                .Any(p => p.Status!.Id != 6))
            {
                max = await _db.DecommissioningTmc
                    .Where(p => p.Status!.Id != 6)
                    .Where(s => s.Date.Year == date.Year)
                    .MaxAsync(p => p.Number, cancel);
            }

            return max + 1;
        }

        public async Task<bool> DeleteAccountingRegisterRangePlanAsync(IEnumerable<AccountingPlanRegister> accountingPlanRegisters, CancellationToken cancel = default)
        {
            _db.AccountingPlanRegisters.RemoveRange(accountingPlanRegisters);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteTmcRegisterRangePlanAsync(IEnumerable<TmcRegister> tmcRegisters, CancellationToken cancel = default)
        {
            _db.TmcRegisters.RemoveRange(tmcRegisters);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }
    }
}
