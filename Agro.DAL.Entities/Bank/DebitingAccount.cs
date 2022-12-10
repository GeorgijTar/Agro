
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Bank.Base;
using Agro.DAL.Entities.Bank.Pay;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Counter;

namespace Agro.DAL.Entities.Bank;

/// <summary>
/// Документ списания с расчетного счета
/// </summary>
public class DebitingAccount : Entity
{
    /// <summary>Статус документа</summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary> Тип операции
    /// (оплата контрагенту, оплата налогов, оплата штрафов и т.д.)
    /// </summary>

    private TypeDoc? _typeOperation;
    public TypeDoc? TypeOperation { get => _typeOperation; set => Set(ref _typeOperation, value); }

    /// <summary> Ссылка на платежное поручение если оно есть </summary>
    private PaymentOrder? _paymentOrder;
    public PaymentOrder? PaymentOrder { get => _paymentOrder; set => Set(ref _paymentOrder, value); }

    /// <summary> Сумма списания с расчетного счета </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary> Ставка НДС</summary>
    private Nds _nds = null!;
    public virtual Nds Nds { get => _nds; set => Set(ref _nds, value); }

    /// <summary>Сумма НДС</summary>
    private decimal _amountNds;
    public decimal AmountNds { get => _amountNds; set => Set(ref _amountNds, value); }
    
    /// <summary> Плательщик </summary>
    private Organization.Organization _organization = null!;
    public Organization.Organization Organization { get => _organization; set => Set(ref _organization, value); }

    /// <summary> Банк плательщика </summary>
    private BankDetails _bankDetailsOrganization = null!;
    public BankDetails BankDetailsOrganization { get => _bankDetailsOrganization; set => Set(ref _bankDetailsOrganization, value); }

    /// <summary> Банк получателя  </summary>
    private BankDetails _bankDetailsCounterparty = null!;
    public BankDetails BankDetailsCounterparty { get => _bankDetailsCounterparty; set => Set(ref _bankDetailsCounterparty, value); }

    /// <summary> Получатель платежа (Контрагент) </summary>
    private Counterparty _counterparty = null!;
    public Counterparty Counterparty { get => _counterparty; set => Set(ref _counterparty, value); }

    /// <summary> Счет учета </summary>
    private AccountingPlan? _debit;
    public AccountingPlan? Debit { get => _debit; set => Set(ref _debit, value); }

    /// <summary> Счет расчетов </summary>
    private AccountingPlan? _credit;
    public AccountingPlan? Credit { get => _credit; set => Set(ref _credit, value); }

    /// <summary>Статья расходов</summary>
    private ExpenditureItem? _expenditureItem;
    public ExpenditureItem? ExpenditureItem { get => _expenditureItem; set => Set(ref _expenditureItem, value); }


}
