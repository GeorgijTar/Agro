using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Counter;

public class SpecificationContract : Entity
{
    /// <summary>Тип спецификации</summary>
    private TypeDoc _type = null!;
    [Required, ForeignKey("TypeId")]
    public TypeDoc Type { get => _type; set => Set(ref _type, value); }


    /// <summary>Номер спецификации</summary>
     
    private string _number = null!;
    [Required]
    public string Number { get => _number; set => Set(ref _number, value); } 
    

    /// <summary>Дата спецификации</summary>
    
    private DateTime _date = DateTime.Now;
    public DateTime Date { get => _date; set => Set(ref _date, value); }


    /// <summary>Договор которому пренадлежит спецификация</summary>

    private Contract _contract = null!;
    public Contract Contract { get => _contract; set => Set(ref _contract, value); } 

    
    /// <summary>Сумма спецификации</summary>

    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); } 


    /// <summary>Примечание к спецификации</summary>

    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); } 

   
}
