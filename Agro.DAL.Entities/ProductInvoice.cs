using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.InvoiceEntity;

namespace Agro.DAL.Entities;

/// <summary>
/// Позиции счета
/// </summary>
public class ProductInvoice : Entity
{
    /// <summary>Товыр, услуга</summary>
    private Product _product = new();
    [Required]
    public virtual Product Product { get => _product; set => Set(ref _product, value); }

    /// <summary>Количество</summary>
    private decimal _quantity;
    public decimal Quantity { get => _quantity; set => Set(ref _quantity, value); }

    /// <summary>Цена</summary>
    private decimal _unitPrice;
    public decimal UnitPrice { get => _unitPrice; set => Set(ref _unitPrice, value); }

    /// <summary>Сумма</summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary>НДС</summary>
    private Nds _nds = new();
    [Required]
    public virtual Nds Nds { get => _nds; set => Set(ref _nds, value); }

    /// <summary>Сумма НДС</summary>
    private decimal _amountNds;
    public decimal AmountNds { get => _amountNds; set => Set(ref _amountNds, value); }

    /// <summary>Сумма всего</summary>
    private decimal _totalAmount;
    public decimal TotalAmount { get => _totalAmount; set => Set(ref _totalAmount, value); }

    /// <summary>Ссылка на счет</summary>
    private Invoice _invoice = new();
    public virtual Invoice Invoice { get => _invoice; set => Set(ref _invoice, value); }

}