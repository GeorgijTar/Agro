﻿using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.DAL.Entities.TaxesType;

namespace Agro.DAL.Entities.Bank.Pay;

/// <summary>
/// Платежное поручение
/// </summary>
public class PaymentOrder : BaseDoc
{
    
    /// <summary> Тип операции
    /// (оплата контрагенту, оплата налогов, оплата штрафов и т.д.)
    /// </summary>
    private TypeOperationPay _typeOperation = null!;
    public TypeOperationPay TypeOperation { get => _typeOperation; set => Set(ref _typeOperation, value); }

    
    private TaxesType.Taxes? _tax;
    public TaxesType.Taxes? Tax { get => _tax; set => Set(ref _tax, value); }

    /// <summary> Вид обязательства (Налог, пеня, штраф, проценты)) </summary>
    private TypeCommitment? _typeCommitment = null!;
    public TypeCommitment? TypeCommitment { get => _typeCommitment; set => Set(ref _typeCommitment, value); }

    /// <summary> Счет на оплату </summary>
    private Invoice? _invoice = null!;
    public Invoice? Invoice { get => _invoice; set => Set(ref _invoice, value); }

    /// <summary> Ставка НДС</summary>
    private Nds _nds = null!;
    public virtual Nds Nds { get => _nds; set => Set(ref _nds, value); }

    /// <summary>Сумма НДС</summary>
    private decimal _amountNds;
    public decimal AmountNds { get => _amountNds; set => Set(ref _amountNds, value); }

    /// <summary> Примечание к платежному поручению </summary>
    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); }
    
   
    
    #region Реквизиты платежного поручения по приложению № 1 Положения Банка России от 29 июня 2021 года N 762-П
    
    /// <summary> Вид платежа (поле 5) </summary>
    private TypePayment? _typePayment;
    public TypePayment? TypePayment { get => _typePayment; set => Set(ref _typePayment, value); }

    /// <summary> Плательщик (поля 8 (наименование), 60 (ИНН), 102(КПП)) </summary>
    private Organization.Organization _organization = null!;
    public Organization.Organization Organization { get => _organization; set => Set(ref _organization, value); }

    /// <summary> Банк плательщика (поля 9(р/сч), 10 (наимеонование банка), 11 (БИК), 12 (к/сч) </summary>
    private BankDetails _bankDetailsOrganization = null!;
    public BankDetails BankDetailsOrganization { get => _bankDetailsOrganization; set => Set(ref _bankDetailsOrganization, value); }

    /// <summary> Банк получателя (поля 13 (наимеонование банка), 14(БИК), 15 (р/сч), 17(к/сч)   </summary>
    private BankDetails _bankDetailsCounterparty = null!;
    public BankDetails BankDetailsCounterparty { get => _bankDetailsCounterparty; set => Set(ref _bankDetailsCounterparty, value); }

    /// <summary>Получатель платежа (поля 16(Наименование получателя), 61 (ИНН), 103(КПП))</summary>
    private Counterparty _counterparty = null!;
    public Counterparty Counterparty { get => _counterparty; set => Set(ref _counterparty, value); }
    
    /// <summary> Вид операции (поле 18) </summary>
    private TypeTransactions _typeTransactions = null!;
    public TypeTransactions TypeTransactions { get => _typeTransactions; set => Set(ref _typeTransactions, value); }

    /// <summary> Срок платежа (поле 19) (Реквизит не заполняется, если иное не установлено Банком России) </summary>
    private DateTime? _paymentTerm;
    public DateTime? PaymentTerm { get => _paymentTerm; set => Set(ref _paymentTerm, value); }

    /// <summary> Назначение платежа кодовое(поле 20) </summary>
    private PaymentDestination? _paymentDestinationCode;
    public PaymentDestination? PaymentDestinationCode { get => _paymentDestinationCode; set => Set(ref _paymentDestinationCode, value); }

    /// <summary> Очередность платежа  (поле 21)</summary>
    private OrderPayment _orderPayment = null!;
    public OrderPayment OrderPayment { get => _orderPayment; set => Set(ref _orderPayment, value); }


    /// <summary> Код (поле 22) (Уникальный идентификатор платежа) </summary>
    private string _uip = "0";
    [MaxLength(25)]
    public string Uip { get => _uip; set => Set(ref _uip, value); }

    /// <summary> Резервное поле (поле 23) </summary>
    private string? _backupField ;
    public string? BackupField { get => _backupField; set => Set(ref _backupField, value); }

    /// <summary> Назначение платежа (поле 24) </summary>
    private string _purposePayment = null!;
    [MaxLength(210)]
    public string PurposePayment { get => _purposePayment; set => Set(ref _purposePayment, value); }
    
    /// <summary>Условие оплаты (поле 35) </summary>
    private string? _paymentTerms;
    [MaxLength(1)]
    public string? PaymentTerms { get => _paymentTerms; set => Set(ref _paymentTerms, value); }

    /// <summary> Срок для акцепта (поле 36) </summary>
    private string? _deadlineAcceptance;
    public string? DeadlineAcceptance { get => _deadlineAcceptance; set => Set(ref _deadlineAcceptance, value); }

    /// <summary> Код выплат (поле 110)</summary>
    private string? _payoutCode;
    public string? PayoutCode { get => _payoutCode; set => Set(ref _payoutCode, value); }

    /// <summary> Поступило в банк плательщика (поле 62) </summary>
    private DateTime? _dateReceiptBank;
    public DateTime? DateReceiptBank { get => _dateReceiptBank; set => Set(ref _dateReceiptBank, value); }

    /// <summary> Дата списания со счета плательщика (поле 71)(проставляется после обработки выписки банка) </summary>
    private DateTime? _dateDebiting;
    public DateTime? DateDebiting { get => _dateDebiting; set => Set(ref _dateDebiting, value); }

    #endregion
    
    #region Реквизиты платежного поручения по Приказу Минфина России от 12.11.2013 N 107н (реквизиты бюджетного платежа)

    /// <summary> Статус плательщика (поле 101) </summary>
    private PayerStatus? _payerStatus;
    public PayerStatus? PayerStatus { get => _payerStatus; set => Set(ref _payerStatus, value); }


    /// <summary>Код бюджетной классификации (поле 104)</summary>
    private string? _kbk;
    public string? Kbk { get => _kbk; set => Set(ref _kbk, value); }

    /// <summary>ОКТМО (поле 105)</summary>
    private string? _oktmo ;
    public string? Oktmo { get => _oktmo; set => Set(ref _oktmo, value); }

    /// <summary> Основание платежа (поле 106) </summary>
    private BasisPayment? _basisPayment;
    public BasisPayment? BasisPayment { get => _basisPayment; set => Set(ref _basisPayment, value); }

    /// <summary> Налоговый период (поле 107) </summary>
    private TaxPeriod? _taxPeriod ;
    public TaxPeriod? TaxPeriod { get => _taxPeriod; set => Set(ref _taxPeriod, value); }

    /// <summary> Номер документа (поле 108) </summary>
    private string? _numberDoc;
    public string? NumberDoc { get => _numberDoc; set => Set(ref _numberDoc, value); }

    /// <summary> Дата документа (поле 109) </summary>
    private string? _dateDoc;
    public string? DateDoc { get => _dateDoc; set => Set(ref _dateDoc, value); }

    /// <summary> Тип платежа (поле 110) (НЕ ЗАПОЛНЯЕТСЯ)</summary>
    private string? _nalogTypePayment;
    public string? NalogTypePayment { get => _nalogTypePayment; set => Set(ref _nalogTypePayment, value); }

    #endregion




   
    

   

}