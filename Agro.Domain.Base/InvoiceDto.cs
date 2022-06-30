
using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations;

namespace Agro.Domain.Base;

/// <summary>
/// Счета вытавленные и полученные
/// </summary>
public class InvoiceDto : EntityDto
{
    /// <summary>Статус счета</summary>
    private StatusDto _status = null!;
    [Required]
    public StatusDto Status { get=>_status; set=>Set(ref _status, value); }

    /// <summary>Номер счета</summary>
    private string _number = null!;
    [Required]
    public string Number { get=>_number; set=>Set(ref _number, value); }

    /// <summary>Дата счета</summary>
    private DateTime _date;
    [Required]
    public DateTime DateInvoce { get=>_date; set=>Set(ref _date, value); }

    /// <summary>Тип счета</summary>
    private TypeDocDto _type = null!;
    [Required]
    public TypeDocDto Type { get=>_type; set=>Set(ref _type, value); }

    /// <summary>Контрагент счета</summary>
    private CounterpartyDto _counterparty = null!;
    [Required]
    public CounterpartyDto Counterparty { get=>_counterparty; set=>Set(ref _counterparty, value); }

    /// <summary>Платежные реквизиты контрагента счета</summary>
    private  BankDetailsDto _bankDetails = null!;
    [Required]
    public BankDetailsDto BankDetails { get=>_bankDetails; set=>Set(ref _bankDetails, value); }

    /// <summary>Сумма счета</summary>
    private decimal _amount;
    [Required]
    public decimal Amount { get=>_amount; set=>Set(ref _amount, value); }

    /// <summary>Описание счета</summary>
    private string? _description;
    public string? Description { get=>_description; set=>Set(ref _description, value); }

    /// <summary>Прикрепленные файлы</summary>
    private ICollection<ScanFileDto>? _scanFiles;
    public ICollection<ScanFileDto>? ScanFiles { get=> _scanFiles; set=>Set(ref _scanFiles, value); }
}
