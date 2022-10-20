using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;
/// <summary>
/// Информация о налогах и сборах
/// </summary>
public class Tax: Entity
{
    /// <summary> Применяемые ообые режимы налогообложения, такие как "ЕСХН", "УСН", "ЕНВД" и "СРП" </summary>
    private string? _mode;
    public string? Mode { get => _mode; set => Set(ref _mode, value); }

    /// <summary> Уплаченные налоги и сборы </summary>
    private ObservableCollection<PaymentTax>? _paymentTaxes;
    public ObservableCollection<PaymentTax>? PaymentTaxes { get => _paymentTaxes; set => Set(ref _paymentTaxes, value); }

    /// <summary> Сумма уплаченных налогов и сборов </summary>
    private float? _payAmount;
    public float? PayAmount { get => _payAmount; set => Set(ref _payAmount, value); }

    /// <summary> Сумма недоимки по налогам и сборам </summary>
    private float? _arrearsAmount;
    public float? ArrearsAmount { get => _arrearsAmount; set => Set(ref _arrearsAmount, value); } 

}