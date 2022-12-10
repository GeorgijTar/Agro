﻿using Agro.DAL.Entities;
using Agro.DAL.Entities.Bank.Pay;
using Agro.DAL.Entities.Base;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface IPaymentOrderRepository<PaymentOrder> : IBaseRepository<PaymentOrder> where PaymentOrder : Entity
{
    public Task<ICollection<PaymentOrder>?> GetAllNoTrackingAsync(CancellationToken cancel = default);

    public Task<Status?> GetStatusByIdAsync(int id, CancellationToken cancel = default);

    public Task<ICollection<TypeOperationPay>?> GetAllTypeOprrationPayAsync (CancellationToken cancel = default);
}

