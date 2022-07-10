using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Позиции счета
/// </summary>
public class ProductInvoice : Entity
{
    /// <summary>Товыр, услуга</summary>
    [Required, ForeignKey("ProductId")]
    public Product Product { get; set; }= null!;

    public int ProductId { get; set; }

    /// <summary>Количество</summary>
    public decimal Quantity { get; set; }

    /// <summary>Цена</summary>
    public decimal UnitPrice { get; set; }

    /// <summary>Сумма</summary>
    public decimal Amount { get; set; }

    /// <summary>НДС</summary>
    [Required, ForeignKey("NdsId")]
    public Nds Nds { get; set; }= null!;

    public int NdsId { get; set; }

    /// <summary>Сумма всего</summary>
    public decimal TotalAmount { get; set; }

    /// <summary>Ссылка на счет</summary>
    [ForeignKey("InvoiceId")]
    public Invoice Invoice { get; set; } = null!;

    public int InvoiceId { get; set; }
}