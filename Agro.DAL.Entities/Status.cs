using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Статус документа
/// </summary>
public class Status : Entity
{
    [Required]
    public string Name { get; set; } = null!;
    
    public ICollection<Counterparty>? Counterparties { get; set; }= new HashSet<Counterparty>();

    public ICollection<BankDetails>? BankDetails { get; set; }= new HashSet<BankDetails>();
    public override string ToString() => Name;
}

