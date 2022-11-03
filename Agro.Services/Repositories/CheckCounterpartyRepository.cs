using Agro.DAL;
using Agro.DAL.Entities.CheckingCounterparty;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;


public class CheckCounterpartyRepository : ICheckCounterpartyRepository<CheckCounterparty>
{
    private readonly AgroDb _db;

    public CheckCounterpartyRepository(AgroDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<CheckCounterparty>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.CheckCounterparty
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Director)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Founder)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Licenses)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Likved)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Okveds)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Okato)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Okfs)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Okved)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Okogy)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Okopf)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.RegFns)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.RegFss)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.RegPfr)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Region)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Rmsp)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Oktmo)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.Status)
            .Include(c => c.DataIp).ThenInclude(dp => dp!.UnscrupulousSupplierRecord)

            .Include(c => c.DataUl).ThenInclude(dp => dp!.Director)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Founder)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Licenses)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Likved)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Okveds)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Okato)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Okfs)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Okved)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Okogy)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Okopf)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.RegFns)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.RegFss)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.RegPfr)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Region)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Rmsp)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Oktmo)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Status)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.UnscrupulousSupplierRecord)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.ArbitrationCasesRecords)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Assignees)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.LegalSuccessors)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.LegalAddress)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.AuthorizedCapital)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Emails)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Phones)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Web)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions).ThenInclude(d => d!.Branches)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions).ThenInclude(d => d!.RepresentativeOffices)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.EnforcementProceedings)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.ManagingOrganization)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.HolderRegister)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.RelatedOrganizationsFounded)
            .Include(c => c.DataUl).ThenInclude(dp => dp!.RelatedOrganizationsUpr)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<CheckCounterparty?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.CheckCounterparty
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Director)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Founder)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Licenses)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Likved)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Okveds)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Okato)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Okfs)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Okved)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Okogy)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Okopf)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.RegFns)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.RegFss)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.RegPfr)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Region)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Rmsp)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Oktmo)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.Status)
             .Include(c => c.DataIp).ThenInclude(dp => dp!.UnscrupulousSupplierRecord)

             .Include(c => c.DataUl).ThenInclude(dp => dp!.Director)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Founder)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Licenses)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Likved)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Okveds)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Okato)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Okfs)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Okved)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Okogy)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Okopf)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.RegFns)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.RegFss)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.RegPfr)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Region)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Rmsp)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Oktmo)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Status)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.UnscrupulousSupplierRecord)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.ArbitrationCasesRecords)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Assignees)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.LegalSuccessors)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.LegalAddress)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.AuthorizedCapital)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Emails)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Phones)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Web)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions).ThenInclude(d => d!.Branches)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions).ThenInclude(d => d!.RepresentativeOffices)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.EnforcementProceedings)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.ManagingOrganization)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.HolderRegister)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.RelatedOrganizationsFounded)
             .Include(c => c.DataUl).ThenInclude(dp => dp!.RelatedOrganizationsUpr)
             .FirstOrDefaultAsync(c => c.Id == id, cancel).ConfigureAwait(false);
    }

    public async Task<CheckCounterparty> AddAsync(CheckCounterparty item, CancellationToken cancel = default)
    {
        var check = (await _db.CheckCounterparty.AddAsync(item).ConfigureAwait(false)).Entity;
        await _db.SaveChangesAsync(cancel);
        return check;
    }

    public async Task<CheckCounterparty> UpdateAsync(CheckCounterparty item, CancellationToken cancel = default)
    {
        var check = (_db.CheckCounterparty.Update(item)).Entity;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return check;
    }

    public Task<bool> DeleteAsync(CheckCounterparty item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<CheckCounterparty?> GetByInnAsync(string inn, CancellationToken cancel = default)
    {
        return await _db.CheckCounterparty
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Director)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Founder)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Licenses)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Likved)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Okveds)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Okato)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Okfs)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Okved)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Okogy)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Okopf)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.RegFns)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.RegFss)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.RegPfr)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Region)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Rmsp)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Oktmo)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.Status)
              .Include(c => c.DataIp).ThenInclude(dp => dp!.UnscrupulousSupplierRecord)

              .Include(c => c.DataUl).ThenInclude(dp => dp!.Director)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Founder)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Licenses)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Likved)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Okveds)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Okato)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Okfs)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Okved)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Okogy)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Okopf)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.RegFns)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.RegFss)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.RegPfr)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Region)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Rmsp)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Oktmo)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Status)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.UnscrupulousSupplierRecord)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.ArbitrationCasesRecords)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Assignees)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.LegalSuccessors)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.LegalAddress)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.AuthorizedCapital)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Emails)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Phones)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions).ThenInclude(d => d!.Branches)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions).ThenInclude(d => d!.RepresentativeOffices)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.EnforcementProceedings)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.ManagingOrganization)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.HolderRegister)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.RelatedOrganizationsFounded)
              .Include(c => c.DataUl).ThenInclude(dp => dp!.RelatedOrganizationsUpr)
              .OrderByDescending(x => x.Date)
              .FirstOrDefaultAsync(c => c.DataIp!.Inn == inn || c.DataUl!.Inn == inn, cancel).ConfigureAwait(false);
    }

    public CheckCounterparty? GetByInn(string inn, CancellationToken cancel = default)
    {
        try
        {


            var result = _db.CheckCounterparty
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Director)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Founder)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Licenses)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Likved)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Okveds)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Okato)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Okfs)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Okved)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Okogy)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Okopf)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.RegFns)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.RegFss)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.RegPfr)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Region)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Rmsp)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Oktmo)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.Status)
                .Include(c => c.DataIp).ThenInclude(dp => dp!.UnscrupulousSupplierRecord)

                .Include(c => c.DataUl).ThenInclude(dp => dp!.Director)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Founder)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Licenses)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Likved)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Okveds)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Okato)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Okfs)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Okved)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Okogy)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Okopf)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.RegFns)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.RegFss)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.RegPfr)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Region)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Rmsp)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Oktmo)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Status)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.UnscrupulousSupplierRecord)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.ArbitrationCasesRecords)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Assignees)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.LegalSuccessors)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.LegalAddress)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.AuthorizedCapital)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Emails)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts).ThenInclude(c => c!.Phones)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Contacts)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions).ThenInclude(d => d!.Branches)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.Divisions).ThenInclude(d => d!.RepresentativeOffices)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.EnforcementProceedings)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.ManagingOrganization)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.HolderRegister)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.RelatedOrganizationsFounded)
                .Include(c => c.DataUl).ThenInclude(dp => dp!.RelatedOrganizationsUpr)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault(c => c.DataIp!.Inn == inn || c.DataUl!.Inn == inn);
           return result;
        }
        catch
        {
            Thread.Sleep(1000);
           return GetByInn(inn);
        }

        
    }
}
