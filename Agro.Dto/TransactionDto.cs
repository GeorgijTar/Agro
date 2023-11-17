
using Agro.Dto.Base;

namespace Agro.Dto;
public class TransactionDto : BaseDto
{
    private Guid _id;
    public Guid Id { get => _id; set => Set(ref _id, value); }

    private DateTime _date;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    private string _debitCod = null!;
    public string DebitCod{ get => _debitCod; set => Set(ref _debitCod, value); }

    private string _debitName = null!;
    public string DebitName { get => _debitName; set => Set(ref _debitName, value); }

    private string _creditCod = null!;
    public string CreditCod { get => _creditCod; set => Set(ref _creditCod, value); }

    private string _creditName = null!;
    public string CreditName { get => _creditName; set => Set(ref _creditName, value); }

    /// <summary> Сумма проводки </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }
    /// <summary> Описание документа основания </summary>
    private string? _contaDoc;
    public string? ContaDoc { get => _contaDoc; set => Set(ref _contaDoc, value); }

    /// <summary> Описание действия </summary>
    private string? _contaAction;
    public string? ContaAction { get => _contaAction; set => Set(ref _contaAction, value); }

    /// <summary> Описание участника операции </summary>
    private string? _contaParty;
    public string? ContaParty { get => _contaParty; set => Set(ref _contaParty, value); }

    /// <summary> Описание объекта операции </summary>
    private string? _contaObject;
    public string? ContaObject { get => _contaObject; set => Set(ref _contaObject, value); }

}
