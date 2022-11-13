using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Глобальные настройки приложения
/// </summary>
public class Sitting : Entity
{
    /// <summary> Минимальная сумма для оплаты счетов без подтверждения</summary>
    private decimal _limitAmountInvoice;
    public decimal LimitAmountInvoice { get => _limitAmountInvoice; set => Set(ref _limitAmountInvoice, value); } 

}
