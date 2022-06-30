using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

public class SpecificationContractDto : EntityDto
{
    /// <summary>Номер спецификации</summary>
    private string _number = null!;
    [Required]
    public string Number { get=> _number; set=> Set(ref _number, value); }

    /// <summary>Дата спецификации</summary>
    private DateTime _date;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary>Договор которому пренадлежит спецификация</summary>
    private ContractDto _contract = null!;
    [Required]
    public ContractDto Contract { get=>_contract; set=>Set(ref _contract, value); }

    /// <summary>Сумма спецификации</summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary>Примечание к спецификации</summary>
    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); }

    /// <summary>Прикрепленные файлы</summary>
    private ICollection<ScanFileDto>? _scanFile;
    public ICollection<ScanFileDto>? ScanFiles { get => _scanFile; set => Set(ref _scanFile, value); }
}
