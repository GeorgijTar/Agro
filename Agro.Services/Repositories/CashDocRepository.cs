

using System.Collections.ObjectModel;
using Agro.DAL;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Kassa;
using Agro.DAL.Entities.Registers;
using Agro.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agro.Services.Repositories;

/// <summary>
/// Реализация интерфейса репозитория кассовых документов
/// </summary>
public class CashDocRepository : ICashDocRepository<DocCash>
{
    private readonly AgroDb _db;

    public CashDocRepository(AgroDb db)
    {
        _db = db;
    }

    public async Task<ObservableCollection<DocCash>?> GetAllNoTrecAsync(CancellationToken cancel = default)
    {
        var coll = await _db.DocsCash.AsNoTrackingWithIdentityResolution()
              .Include(d => d.People)
              .Include(d => d.Debit)
              .Include(d => d.Credit)
              .Include(d => d.TypeDoc)
              .Include(d => d.TypeOperationCash)
              .Include(d => d.Status).ToArrayAsync(cancel).ConfigureAwait(false);
        ObservableCollection<DocCash> docsCash = new ObservableCollection<DocCash>();
        foreach (var doc in coll)
        {
            docsCash.Add(doc);
        }
        return docsCash;
    }

    public async Task<int> GetNumberDocAsync(DocCash doc, CancellationToken cancel = default)
    {
        try
        {
            var docNumber = int.Parse(await _db.DocsCash
            .Where(d => d.TypeDoc == doc.TypeDoc)
            .Where(d => d.Date.Year == doc.Date.Year)
            .Where(d => d.Status.Id != 6)
            .MaxAsync(d => d.Number, cancel).ConfigureAwait(false));
            return docNumber + 1;
        }
        catch
        {
            return 1;
        }

    }

    public async Task<DocCash?> GetByIdNoTrecAsync(int idDocCash, CancellationToken cancel = default)
    {
        return await _db.DocsCash.AsNoTrackingWithIdentityResolution()
            .Include(d => d.People)
            .Include(d => d.Debit)
            .Include(d => d.Credit)
            .Include(d => d.TypeDoc)
            .Include(d => d.TypeOperationCash)
            .Include(d => d.Status)
            .Include(d => d.AccountingPlanRegisters)
            .Include(d=>d.Organization)
            .Include(d=>d.Division)
            .Include(d=>d.Nds)
            .Include(d=>d.Cashier).ThenInclude(c=>c!.People)
            .Include(d=>d.GeneralAccountant).ThenInclude(c => c!.People)
            .Include(d=>d.Director).ThenInclude(c => c!.People)
            .Include(d => d.Director).ThenInclude(c => c!.Post)
            .FirstOrDefaultAsync(d => d.Id == idDocCash, cancel)
            .ConfigureAwait(false);
    }

    public async Task<decimal> GetBalanceCashAsync(CancellationToken cancel = default)
    {

        var coming = await _db.DocsCash.AsNoTracking()
            .Where(d => d.Status.Id == 26)
            .Where(d => d.TypeDoc.Id == 31)
            .SumAsync(d => d.Amount, cancel).ConfigureAwait(false);

        var expenditure = await _db.DocsCash.AsNoTracking()
            .Where(d => d.Status.Id == 26)
            .Where(d => d.TypeDoc.Id == 32)
            .SumAsync(d => d.Amount, cancel).ConfigureAwait(false);

        return (coming - expenditure);

    }

    public async Task<decimal> GetBalanceCashByDateAsync(DateTime date, CancellationToken cancel = default)
    {
        var coming = await _db.DocsCash.AsNoTracking()
            .Where(d => d.Status.Id == 26)
            .Where(d => d.TypeDoc.Id == 31)
            .Where(d => d.Date <= date)
            .SumAsync(d => d.Amount, cancel).ConfigureAwait(false);

        var expenditure = await _db.DocsCash.AsNoTracking()
            .Where(d => d.Status.Id == 26)
            .Where(d => d.TypeDoc.Id == 32)
            .Where(d => d.Date <= date)
            .SumAsync(d => d.Amount, cancel).ConfigureAwait(false);

        return (coming - expenditure);
    }

    public async Task<bool> SpendDocCashAsync(DocCash docCash, Status newStatus, CancellationToken cancel = default)
    {
        if (docCash.TypeOperationCash!.IsAccountingPlan)
        {
            AccountingPlanRegister register = new AccountingPlanRegister()
            {
                DateReg = docCash.Date,
                Debit = docCash.Debit,
                Credit = docCash.Credit,
                ContaAction = docCash.TypeOperationCash!.Name,
                DocCash = docCash
            };

            if (docCash.TypeDoc.Id == 31)
            {
                register.ContaDoc =
                    $"Приходный кассовый ордер № {docCash.Number} от {docCash.Date.ToShortDateString()}";
                register.ContaObject = "Поступление наличных денежных средств в кассу организации";
                register.Amount = docCash.Amount;
            }
            else if (docCash.TypeDoc.Id == 32)
            {
                register.ContaDoc =
                    $"Расходный кассовый ордер № {docCash.Number} от {docCash.Date.ToShortDateString()}";
                register.ContaObject = "Выбытие наличных денежных средств из кассы организации";
                register.Amount = docCash.Amount;
            }

            if (docCash.People != null!)
                register.ContaParty =
                    $"{docCash.People.Surname} {docCash.People.Name[0]}. {docCash.People.Patronymic[0]}";
            if (docCash.Counterparty != null!) register.ContaParty = docCash.Counterparty.Name;
            if (docCash.BankDetailsOrg != null!)
                register.ContaParty = $"{docCash.BankDetailsOrg.NameBank} ({docCash.BankDetailsOrg.Bs})";
            if (docCash.AccountingPlanRegisters == null!) docCash.AccountingPlanRegisters = new();
            docCash.AccountingPlanRegisters.Add(register);
        }

        docCash.Status = newStatus;
        _db.DocsCash.Update(docCash);
        await _db.SaveChangesAsync(cancel);

        return true;

    }

    public async Task<bool> CancelSpendDocCashAsync(DocCash docCash, Status newStatus, CancellationToken cancel = default)
    {

        if (docCash == null!) throw new ArgumentNullException("Для выполнения операции требуется передача документа" + "");
        if (newStatus == null!) throw new ArgumentNullException("Для выполнения операции требуется " + "передача статуса документа");
        if (docCash.AccountingPlanRegisters != null! && docCash.AccountingPlanRegisters.Count == 0)
        {
            //_db.AccountingPlanRegisters.RemoveRange(docCash.AccountingPlanRegisters);
            docCash.AccountingPlanRegisters.Clear();
        }

        docCash.Status = newStatus;
        _db.DocsCash.Update(docCash);
        await _db.SaveChangesAsync(cancel);
        return true;
    }

    public async Task<IEnumerable<DocCash>?> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.DocsCash
            .Include(d => d.Organization)
            .Include(d => d.Counterparty)
            .Include(d => d.Credit)
            .Include(d => d.Debit)
            .Include(d => d.Division)
            .Include(d => d.ItemExpenditureOrIncome)
            .Include(d => d.People)
            .Include(d => d.Nds)
            .Include(d => d.Status)
            .Include(d => d.TypeDoc)
            .Include(d => d.TypeOperationCash)
            .Include(d => d.Contract)
            .Include(d => d.BankDetailsOrg)
            .Include(d => d.Histories)
            .Include(d => d.AccountingPlanRegisters)
            .ToArrayAsync(cancel).ConfigureAwait(false);
    }

    public async Task<DocCash?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        var doc=
        await _db.DocsCash
            .Include(d => d.Organization)
            .Include(d => d.Counterparty)
            .Include(d => d.Credit)
            .Include(d => d.Debit)
            .Include(d => d.Division)
            .Include(d => d.ItemExpenditureOrIncome)
            .Include(d => d.People)
            .Include(d => d.Nds)
            .Include(d => d.Status)
            .Include(d => d.TypeDoc)
            .Include(d => d.TypeOperationCash)
            .Include(d => d.AccountingPlanRegisters)
            .Include(d=>d.Director).ThenInclude(d=>d!.People)
            .Include(d => d.Director).ThenInclude(d => d!.Post)
            .Include(d=>d.Cashier).ThenInclude(c=>c!.People)
            .Include(d=>d.GeneralAccountant).ThenInclude(g=>g!.People)
            .FirstOrDefaultAsync(d => d.Id == id, cancel).ConfigureAwait(false);
        return doc;
    }

    public async Task<DocCash> AddAsync(DocCash item, CancellationToken cancel = default)
    {
        var doc = await _db.DocsCash.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel);
        return doc.Entity;
    }

    public async Task<DocCash> UpdateAsync(DocCash item, CancellationToken cancel = default)
    {
        var doc = (_db.DocsCash.Update(item)).Entity;
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return doc;
    }

    public Task<bool> DeleteAsync(DocCash item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public Task<DateTime> GetClosedPeriodAsync(CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }
}