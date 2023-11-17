using System.Collections.ObjectModel;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.DAL.Entities.Kassa.Base;
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Personnel;
using Agro.DAL.Entities.Registers;
using Agro.DAL.Entities.Storage;

namespace Agro.DAL.Entities.Kassa;
public class DocCash : BaseDoc
{
  /// <summary>
    /// Тип документа (приход/расход)
    /// </summary>
    private TypeDoc _typeDoc = null!;
    public TypeDoc TypeDoc { get => _typeDoc; set => Set(ref _typeDoc, value); }

    /// <summary>
    /// Вид операции
    /// </summary>
    private TypeOperationCash? _typeOperationCash;
    public TypeOperationCash? TypeOperationCash { get => _typeOperationCash; set => Set(ref _typeOperationCash, value); }

    /// <summary>
    /// Статья доходов или расходов
    /// </summary>
    private ItemExpenditureOrIncome? _itemExpenditureOrIncome;
    public ItemExpenditureOrIncome? ItemExpenditureOrIncome { get => _itemExpenditureOrIncome; set => Set(ref _itemExpenditureOrIncome, value); }

    /// <summary>
    /// НДС
    /// </summary>
    private Nds? _nds;
    public Nds? Nds { get => _nds; set => Set(ref _nds, value); }

    /// <summary>
    /// Сумма НДС
    /// </summary>
    private decimal _amountNds;
    public decimal AmountNds { get => _amountNds; set => Set(ref _amountNds, value); }

    /// <summary>
    /// Организация
    /// </summary>
    private Organization.Organization _organization = null!;
    public Organization.Organization Organization { get => _organization; set => Set(ref _organization, value); }

    /// <summary>
    /// Структурное подразделение
    /// </summary>
    private Division? _division;
    public Division? Division { get => _division; set => Set(ref _division, value); }

    /// <summary>
    /// Дебит (Кор. счет, субсчет)
    /// </summary>
    private AccountingPlan _debit = null!;
    public AccountingPlan Debit { get => _debit; set => Set(ref _debit, value); }

    /// <summary>
    /// Кредит (Кор. счет, субсчет)
    /// </summary>
    private AccountingPlan _credit = null!;
    public AccountingPlan Credit { get => _credit; set => Set(ref _credit, value); }

    /// <summary>
    /// Человек при расчете с подотчетными лицами
    /// </summary>
    private People? _people;
    public People? People { get => _people; set => Set(ref _people, value); }

    /// <summary>
    /// Контрагент при расчете с контрагентами
    /// </summary>
    private Counterparty? _counterparty;
    public Counterparty? Counterparty { get => _counterparty; set => Set(ref _counterparty, value); }

    /// <summary>
    /// Договор
    /// </summary>
    private Contract? _contract;
    public Contract? Contract { get => _contract; set => Set(ref _contract, value); }

    /// <summary>
    /// Счет на оплату
    /// </summary>
    private Invoice? _invoice;
    public Invoice? Invoice { get => _invoice; set => Set(ref _invoice, value); }

    /// <summary>
    /// Банковские реквизиты при получении наличных в банке
    /// </summary>
    private BankDetails? _bankDetailsOrg;
    public BankDetails? BankDetailsOrg { get => _bankDetailsOrg; set => Set(ref _bankDetailsOrg, value); }

    /// <summary>
    /// Склад при расчете со складом
    /// </summary>
    private StorageLocation? _storageLocation;
    public StorageLocation? StorageLocation { get => _storageLocation; set => Set(ref _storageLocation, value); }

    /// <summary>
    /// Примечание
    /// </summary>
    private string? _note;
    public string? Note { get => _note; set => Set(ref _note, value); }
    
  

    #region Данные печатной формы

    /// <summary>
    /// Кому выдано/От кого принято
    /// </summary>
    private string? _from;
    public string? From { get => _from; set => Set(ref _from, value); }

    /// <summary>
    /// Документ по которому выдан расход (паспорт)
    /// </summary>
    private string? _foundationDoc;
    public string? FoundationDoc { get => _foundationDoc ; set => Set(ref _foundationDoc , value); }

    /// <summary>
    /// Основание документа
    /// </summary>
    private string? _footing;
    public string? Footing { get => _footing; set => Set(ref _footing, value); }

    /// <summary>
    /// Приложение к документу
    /// </summary>
    private string? _applicationDoc;
    public string? ApplicationDoc { get => _applicationDoc; set => Set(ref _applicationDoc, value); }


    /// <summary>
    /// Проводки
    /// </summary>
    private ObservableCollection<AccountingPlanRegister> _accountingPlanRegisters = null!;

    public ObservableCollection<AccountingPlanRegister> AccountingPlanRegisters { get => _accountingPlanRegisters;
        set => Set(ref _accountingPlanRegisters, value); }

    /// <summary>
    /// Руководитель
    /// </summary>
    private Employee? _director;
    public Employee? Director { get => _director; set => Set(ref _director, value); }

    /// <summary>
    /// Главный бухгалтер
    /// </summary>
    private Employee? _generalAccountant;
    public Employee? GeneralAccountant { get => _generalAccountant; set => Set(ref _generalAccountant, value); }

    /// <summary>
    /// Кассир
    /// </summary>
    private Employee?_cashier;
    public Employee? Cashier { get => _cashier; set => Set(ref _cashier, value); }

    #endregion
}
