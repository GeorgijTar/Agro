using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Counter;

public class SpecificationContract : Entity
{
    /// <summary>Тип спецификации</summary>
    [Required, ForeignKey("TypeId")]
    public virtual TypeDoc Type { get; set; } = null!;

    public int TypeId { get; set; }

    /// <summary>Номер спецификации</summary>
    [Required]
    public string Number { get; set; } = null!;

    /// <summary>Дата спецификации</summary>
    public DateTime Date { get; set; }

    /// <summary>Договор которому пренадлежит спецификация</summary>
 
    public virtual Contract Contract { get; set; } = null!;
    
    /// <summary>Сумма спецификации</summary>
    public decimal Amount { get; set; }

    /// <summary>Примечание к спецификации</summary>
    public string? Description { get; set; }

    /// <summary>Прикрепленные файлы</summary>
    public virtual ICollection<ScanFile>? ScanFiles { get; set; }
}
