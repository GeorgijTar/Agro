using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.DAL.Entities.Registers;
using Agro.Dto;

namespace Agro.Interfaces.Base.Repositories
{
    public interface ITransactionRepository
    {
        public Task<ObservableCollection<TransactionDto>> ConvertBaseTransactionToDtoAsync
            (ObservableCollection<AccountingPlanRegister> accountingPlanRegisters, 
                CancellationToken cancel = default);
    }
}
