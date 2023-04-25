
using System.Collections.ObjectModel;
using Agro.DAL;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Registers;
using Agro.DAL.Entities.Warehouse;
using Agro.Dto.Warehouse;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

public class TmcSprRepository:ITmcSprRepository<Tmc>
{
    private readonly AgroDb _db;

    public TmcSprRepository(AgroDb db)
    {
        _db = db;
    }

    public async Task<ObservableCollection<TmcSprDto>?> GetAllAsync(CancellationToken cancel = default)
    {

        var spr = await _db.TmcRegisters
            .Include(t=>t.Tmc)
            .Include(t=>t.StorageLocation)
            .Include(t=>t.UnitOkei)
            .Include(t=>t.TypeDoc)
            .Include(t=>t.Debit)
            .Include(t=>t.Credit)
            .ToArrayAsync(cancel).ConfigureAwait(false);


        var reg1 = spr
            .Where(t => t.TypeDoc.Id == 25)
            .GroupBy(t=> new {t.Tmc, t.Debit, t.StorageLocation, t.UnitOkei});

        var col = new ObservableCollection<TmcSprDto>();
        foreach (var tm in reg1)
        {
            col.Add(new TmcSprDto()
            {
                Id = tm.Key.Tmc.Id,
                NameTmc = tm.Key.Tmc.Name,
                Article = tm.Key.Tmc.ArticleNumber!,
                IdUnit = tm.Key.UnitOkei.Id,
                Unit = tm.Key.UnitOkei.Abbreviation,
                Quantity = 
                    (spr
                        .Where(s=>s.TypeDoc.Id==25)
                        .Where(s => s.Tmc == tm.Key.Tmc)
                        .Where(s => s.Debit == tm.Key.Debit)
                        .Where(s => s.StorageLocation == tm.Key.StorageLocation)
                        .Where(s => s.UnitOkei == tm.Key.UnitOkei)
                        .Sum(s=>s.Quantity)) - (spr
                        .Where(s => s.TypeDoc.Id == 26)
                        .Where(s => s.Tmc == tm.Key.Tmc)
                        .Where(s => s.Credit == tm.Key.Debit)
                        .Where(s => s.StorageLocation == tm.Key.StorageLocation)
                        .Where(s => s.UnitOkei == tm.Key.UnitOkei)
                        .Sum(s=>s.Quantity)),
                Amount = (spr
                    .Where(s => s.TypeDoc.Id == 25)
                    .Where(s => s.Tmc == tm.Key.Tmc)
                    .Where(s => s.Debit == tm.Key.Debit)
                    .Where(s => s.StorageLocation == tm.Key.StorageLocation)
                    .Where(s => s.UnitOkei == tm.Key.UnitOkei)
                    .Sum(s => s.Amount)) - (spr
                    .Where(s => s.TypeDoc.Id == 26)
                    .Where(s => s.Tmc == tm.Key.Tmc)
                    .Where(s => s.Credit == tm.Key.Debit)
                    .Where(s => s.StorageLocation == tm.Key.StorageLocation)
                    .Where(s => s.UnitOkei == tm.Key.UnitOkei)
                    .Sum(s => s.Amount)),
                IdAccountingPlan = tm.Key.Debit.Id,
                AccountingPlanCode = tm.Key.Debit.Code,
                IdStorageLocation = tm.Key.StorageLocation.Id,
                StorageLocation = tm.Key.StorageLocation.Name,
            });
        }
        return col;
    }

    public async Task<Tmc?> GetTmcByIdAsync(int idTmc, CancellationToken cancel = default)
    {
        return await _db.Tmc.FirstOrDefaultAsync(t => t.Id == idTmc, cancel).ConfigureAwait(false);
    }

    public async Task<ObservableCollection<TmcRegister>> GetHistoriTmcByIdAsync(int idTmc, CancellationToken cancel = default)
    {
        var coll = await _db.TmcRegisters
            .Include(t => t.ComingTmc).ThenInclude(c=>c!.Counterparty)
            .Include(t => t.DecommissioningTmc).ThenInclude(d=>d!.Mol).ThenInclude(m=>m.People)
            .Include(t => t.DecommissioningTmc).ThenInclude(d => d!.WriteOffObject)
            .Include(t => t.Credit)
            .Include(t => t.Debit)
            .Include(t => t.StorageLocation)
            .Include(t => t.Tmc)
            .Include(t => t.TypeDoc)
            .Include(t => t.UnitOkei)
            .Where(t => t.Tmc.Id == idTmc).ToArrayAsync(cancel).ConfigureAwait(false);
        var obsColl = new ObservableCollection<TmcRegister>();
        foreach (var register in coll)
        {
            obsColl.Add(register);
        }
        return obsColl;
    }

    public async Task<ObservableCollection<TmcRegister>> GetHistoriTmcByIdAsync(int idTmc, int idSl, CancellationToken cancel = default)
    {
        var coll = await _db.TmcRegisters
            .Include(t => t.ComingTmc).ThenInclude(c => c!.Counterparty)
            .Include(t => t.DecommissioningTmc).ThenInclude(d => d!.Mol).ThenInclude(m => m.People)
            .Include(t => t.DecommissioningTmc).ThenInclude(d => d!.WriteOffObject)
            .Include(t => t.Credit)
            .Include(t => t.Debit)
            .Include(t => t.StorageLocation)
            .Include(t => t.Tmc)
            .Include(t => t.TypeDoc)
            .Include(t => t.UnitOkei)
            .Where(t => t.Tmc.Id == idTmc)
            .Where(t=>t.StorageLocation.Id==idSl)
            .ToArrayAsync(cancel).ConfigureAwait(false);
        var obsColl = new ObservableCollection<TmcRegister>();
        foreach (var register in coll)
        {
            obsColl.Add(register);
        }
        return obsColl;
    }

    public async Task<TmcSprDto?> GetRemainsTmcByIdLsApAsync(int idTmc, int idLs, int idAp, CancellationToken cancel = default)
    {
        var spr = await _db.TmcRegisters
            .Include(t=>t.UnitOkei)
            .Include(t=>t.StorageLocation)
            .Include(t=>t.Tmc)
            .Include(t=>t.Debit)
            .Where(t => t.Tmc.Id == idTmc)
            .Where(t=>t.StorageLocation.Id==idLs)
            .ToArrayAsync(cancel)
            .ConfigureAwait(false);
        TmcRegister tmcRegister=spr.FirstOrDefault()!;

        TmcSprDto tmcSpr = new TmcSprDto()
        {
            Id = tmcRegister.Tmc.Id,
            Article = tmcRegister.Tmc.ArticleNumber!,
            NameTmc = tmcRegister.Tmc.Name,
            IdUnit = tmcRegister.UnitOkei.Id,
            Unit = tmcRegister.UnitOkei.Name,
            IdStorageLocation = tmcRegister.StorageLocation.Id,
            StorageLocation = tmcRegister.StorageLocation.Name,
            IdAccountingPlan = tmcRegister.Debit.Id,
            AccountingPlanCode = tmcRegister.Debit.Code,
            Quantity = (spr
                .Where(s=>s.TypeDoc.Id==25)
                .Where(s=>s.Debit.Id==idAp)
                .Where(s=>s.StorageLocation.Id==idLs)
                .Sum(s=>s.Quantity)
                )-
                (spr
                    .Where(s => s.TypeDoc.Id == 26)
                    .Where(s => s.Credit.Id == idAp)
                    .Where(s => s.StorageLocation.Id == idLs)
                    .Sum(s => s.Quantity)),
            Amount = (spr
                         .Where(s => s.TypeDoc.Id == 25)
                         .Where(s => s.Debit.Id == idAp)
                         .Where(s => s.StorageLocation.Id == idLs)
                         .Sum(s => s.Amount)
                     ) -
                     (spr
                         .Where(s => s.TypeDoc.Id == 26)
                         .Where(s => s.Credit.Id == idAp)
                         .Where(s => s.StorageLocation.Id == idLs)
                         .Sum(s => s.Amount)),

        };
        return tmcSpr;

    }

    public async Task<UnitOkei?> GetUnitByIdAsync(int idUnit, CancellationToken cancel = default)
    {
        return await _db.UnitsOkei.FirstOrDefaultAsync(u=>u.Id==idUnit, cancel).ConfigureAwait(false);
    }

    public async Task<AccountingPlan?> GetAccountingByIdAsync(int idAccounting, CancellationToken cancel = default)
    {
        return  await _db.AccountingPlans.FirstOrDefaultAsync(a=>a.Id==idAccounting, cancel).ConfigureAwait(false);
    }
}
