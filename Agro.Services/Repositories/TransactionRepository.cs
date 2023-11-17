

using System.Collections.ObjectModel;
using Agro.DAL.Entities.Registers;
using Agro.Dto;
using Agro.Interfaces.Base.Repositories;

namespace Agro.Services.Repositories;
public class TransactionRepository:ITransactionRepository
{
    public async Task<ObservableCollection<TransactionDto>> ConvertBaseTransactionToDtoAsync(ObservableCollection<AccountingPlanRegister> accountingPlanRegisters, CancellationToken cancel = default)
    {
        var transactionDto = new ObservableCollection<TransactionDto>();
        foreach (var planRegister in accountingPlanRegisters)
        {
            transactionDto.Add(new TransactionDto()
            {
                Id = planRegister.Id,
                Date = planRegister.DateReg,
                DebitCod = planRegister.Debit.Code,
                DebitName = planRegister.Debit.Name,
                CreditCod = planRegister.Credit.Code,
                CreditName = planRegister.Credit.Name,
                Amount = planRegister.Amount,
                ContaDoc = planRegister.ContaDoc,
                ContaAction = planRegister.ContaAction,
                ContaObject = planRegister.ContaObject,
                ContaParty = planRegister.ContaParty
            });
        }

        return transactionDto;
    }
}
