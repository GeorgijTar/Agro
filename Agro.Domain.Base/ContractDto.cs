using System.ComponentModel.DataAnnotations;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

public class ContractDto : EntityDto
{
    /// <summary>Статус договора</summary>
    private StatusDto _status = null!;
    [Required]
    public StatusDto Status { get=>_status; set=>Set(ref _status, value); }

    /// <summary>Тип договора</summary>
    private TypeDocDto _type = null!;
    [Required]
    public TypeDocDto Type { get=>_type; set=>Set(ref _type, value); }

    /// <summary>Группа договора</summary>
    private GroupDto _group = null!;
    [Required]
    public GroupDto Group { get=>_group; set=>Set(ref _group, value); }

    /// <summary>Номер договора</summary>
    private string _namber = null!;
    public string Number { get=>_namber; set=>Set(ref _namber, value); }

    /// <summary>Дата договора</summary>
    private DateTime _date;
    public DateTime Date { get=>_date; set=>Set(ref _date, value); }

    /// <summary>Контрагент по договору</summary>
    private CounterpartyDto _counterparty = null!;
    [Required]
    public CounterpartyDto Counterparty { get=> _counterparty; set=>Set(ref _counterparty, value); }

    /// <summary>Платежные реквизиты контрагента договора</summary>
    private BankDetailsDto _bankDetails = null!;
    [Required]
    public BankDetailsDto BankDetails { get=> _bankDetails; set=>Set(ref _bankDetails, value); }

    /// <summary>Предмет договора</summary>
    private string _subject = null!;
    public string Subject { get=>_subject; set=>Set(ref _subject, value); }

    /// <summary>Сумма договора</summary>
    private decimal _amount;
    public decimal Amount { get=>_amount; set=>Set(ref _amount, value); }

    /// <summary>Примечание к договору</summary>
    private string? _description;
    public string? Description { get=> _description; set=>Set(ref _description, value); }

    /// <summary>Прикрепленные файлы</summary>
    private ICollection<ScanFileDto>? _scanFile;
    public ICollection<ScanFileDto>? ScanFiles { get=> _scanFile; set=>Set(ref _scanFile, value); } 

}
