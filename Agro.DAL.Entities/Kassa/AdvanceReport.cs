
using System.Collections.ObjectModel;
using Agro.DAL.Entities.Bank.Pay;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Personnel;
using Agro.DAL.Entities.Registers;

namespace Agro.DAL.Entities.Kassa;
/// <summary>
/// Авансовый отчет
/// </summary>
public class AdvanceReport : BaseDoc
{
    /// <summary>
    /// Подотчетное лицо
    /// </summary>
    private Employee _person = null!;
    public Employee Person { get => _person; set => Set(ref _person, value); }

    /// <summary>
    /// Назначение аванса
    /// </summary>
    private string _appointment = null!;
    public string Appointment { get => _appointment; set => Set(ref _appointment, value); }

    /// <summary>
    /// Авансы выданные (PKO)
    /// </summary>
    private ObservableCollection<DocCash> _advancesRko = new();
    public ObservableCollection<DocCash> AdvancesRko { get => _advancesRko; set => Set(ref _advancesRko, value); }

    /// <summary>
    /// Авансы выданные (Платежное поручение)
    /// </summary>
    private ObservableCollection<PaymentOrder> _advancesPp = new();
    public ObservableCollection<PaymentOrder> AdvancesPp { get => _advancesPp; set => Set(ref _advancesPp, value); }

    /// <summary>
    /// Товары по авансовому отчету
    /// </summary>
    private ObservableCollection<AdvanceProduct> _produkts = null!;
    public ObservableCollection<AdvanceProduct> Produkts { get => _produkts; set => Set(ref _produkts, value); }

    /// <summary>
    /// Сумма перерасхода
    /// </summary>
    private decimal _amountOverspending;
    public decimal AmountOverspending { get => _amountOverspending; set => Set(ref _amountOverspending, value); }

    /// <summary>
    /// Сумма остатка
    /// </summary>
    private decimal _balanceAmount;
    public decimal BalanceAmount { get => _balanceAmount; set => Set(ref _balanceAmount, value); }

    /// <summary>
    /// Приложение документов
    /// </summary>
    private string _annexesDoc = null!;
    public string AnnexesDoc { get => _annexesDoc; set => Set(ref _annexesDoc, value); }

    /// <summary>
    /// Прилажение листов
    /// </summary>
    private string _annexesSheet = null!;
    public string AnnexesSheet { get => _annexesSheet; set => Set(ref _annexesSheet, value); }

    /// <summary>
    /// Комментарий
    /// </summary>
    private string _comment = null!;
    public string Comment { get => _comment; set => Set(ref _comment, value); }

    /// <summary>
    /// Проводки
    /// </summary>
    private ObservableCollection<AccountingPlanRegister> _accountingPlanRegisters = null!;
    public ObservableCollection<AccountingPlanRegister> AccountingPlanRegisters 
    { get => _accountingPlanRegisters; set => Set(ref _accountingPlanRegisters, value); }

  

}
