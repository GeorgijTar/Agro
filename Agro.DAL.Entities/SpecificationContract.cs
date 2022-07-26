

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

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
    [Required, ForeignKey("ContractId")]
    public virtual Contract Contract { get; set; } = null!;

    public int ContractId { get; set; }

    /// <summary>Сумма спецификации</summary>
    public decimal Amount { get; set; }

    /// <summary>Примечание к спецификации</summary>
    public string? Description { get; set; }

    /// <summary>Прикрепленные файлы</summary>
    public virtual ICollection<ScanFile>? ScanFiles { get; set; }
}
