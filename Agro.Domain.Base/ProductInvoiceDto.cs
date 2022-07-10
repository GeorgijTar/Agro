using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Domain.Base;

/// <summary>
/// Позиции счета
/// </summary>
public class ProductInvoiceDto : EntityDto
{
    /// <summary>Товыр, услуга</summary>
    private ProductDto _product = null!;
    public ProductDto Product { get=>_product; set=>Set(ref _product, value); }

    /// <summary>Количество</summary>
    private decimal _quantity;
    public decimal Quantity { get=>_quantity; set=>Set(ref _quantity, value); }

    /// <summary>Цена</summary>
    private decimal  _price;
    public decimal UnitPrice { get=>_price; set=>Set(ref _price, value); }

    /// <summary>Сумма</summary>
    private decimal _amount;
    public decimal Amount { get=>_amount; set=>Set(ref _amount, value); }

    /// <summary>НДС</summary>
    private NdsDto _nds= null!;
    public NdsDto Nds { get=>_nds; set=>Set(ref _nds, value); }

    /// <summary>Сумма всего</summary>
    private decimal _totalAmount;
    public decimal TotalAmount { get=>_totalAmount; set=>Set(ref _totalAmount, value); }

    /// <summary>Ссылка на счет</summary>
    public InvoiceDto Invoice { get; set; } = null!;
}