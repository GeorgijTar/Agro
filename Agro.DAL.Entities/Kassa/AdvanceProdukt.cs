using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.Warehouse;

namespace Agro.DAL.Entities.Kassa;
public class AdvanceProduct : Entity<Guid>
{
    /// <summary>
    /// Наименование документа основания
    /// </summary>
    private string _nameDoc = null!;
    public string NameDoc { get => _nameDoc; set => Set(ref _nameDoc, value); }

    /// <summary>
    /// Номер документа основания
    /// </summary>
    private string _numberDoc = null!;
    public string NumberDoc { get => _numberDoc; set => Set(ref _numberDoc, value); }

    /// <summary>
    /// Дата документаоснования
    /// </summary>
    private DateTime _dateDoc = DateTime.Now;
    public DateTime DateDoc { get => _dateDoc; set => Set(ref _dateDoc, value); }

    /// <summary>
    /// Номенклатура
    /// </summary>
    private Tmc _tmc = null!;
    public Tmc Tmc { get => _tmc; set => Set(ref _tmc, value); }

    /// <summary>
    /// Количество
    /// </summary>
    private decimal _quantity;
    public decimal Quantity { get => _quantity; set => Set(ref _quantity, value); }

    /// <summary>
    /// Цена
    /// </summary>
    private decimal _price;
    public decimal Price { get => _price; set => Set(ref _price, value); }

    /// <summary>
    /// Сумма
    /// </summary>
    private decimal _amount;
    public decimal Amount { get => _amount; set => Set(ref _amount, value); }

    /// <summary>
    /// Ставка НДС
    /// </summary>
    private Nds _nds = null!;
    public Nds Nds { get => _nds; set => Set(ref _nds, value); }

    /// <summary>
    /// Сумма НДС
    /// </summary>
    private decimal _amountNds;
    public decimal AmountNds { get => _amountNds; set => Set(ref _amountNds, value); }

    /// <summary>
    /// Всего сумма
    /// </summary>
    private decimal _totalAmount;
    public decimal TotalAmount { get => _totalAmount; set => Set(ref _totalAmount, value); }

    /// <summary>
    /// Счет учета
    /// </summary>
    private AccountingPlan _accountingPlan = null!;
    public AccountingPlan AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }

    /// <summary>
    /// Счет учета НДС
    /// </summary>
    private AccountingPlan _accountingPlanNds = null!;
    public AccountingPlan AccountingPlanNds { get => _accountingPlanNds; set => Set(ref _accountingPlanNds, value); }

    /// <summary>
    /// Контрагент
    /// </summary>
    private Counterparty? _counterparty;
    public Counterparty? Counterparty { get => _counterparty; set => Set(ref _counterparty, value); }
}

