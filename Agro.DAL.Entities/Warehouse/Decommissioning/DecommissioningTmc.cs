using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Registers;
using System.Collections.ObjectModel;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Personnel;

namespace Agro.DAL.Entities.Warehouse.Decommissioning;
/// <summary>
/// Документ списания 
/// </summary>
public class DecommissioningTmc : Entity
{
    /// <summary> Статус документа списания </summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }
    /// <summary> Номер документа </summary>
    private int _number;
    public int Number { get => _number; set => Set(ref _number, value); }

    /// <summary> Дата документа </summary>
    private DateTime _date = DateTime.Now;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary> Тип документа (списание или сторнирование) </summary>
    private TypeDoc _typeDoc = null!;
    public TypeDoc TypeDoc { get => _typeDoc; set => Set(ref _typeDoc, value); }

    /// <summary> Сторнируемый документ </summary>
    private DecommissioningTmc? _decommissioningStorno;
    public DecommissioningTmc? DecommissioningStorno { get => _decommissioningStorno; set => Set(ref _decommissioningStorno, value); }

    /// <summary> Цель расходования </summary>
    private PurposeExpenditure _purposeExpenditure = null!;
    public PurposeExpenditure PurposeExpenditure { get => _purposeExpenditure; set => Set(ref _purposeExpenditure, value); }

    /// <summary> Объект списания </summary>
    private WriteOffObject _writeOffObject = null!;
    public WriteOffObject WriteOffObject { get => _writeOffObject; set => Set(ref _writeOffObject, value); }

    /// <summary> Кладовщик </summary>
    private Employee _storekeeper = null!;
    public Employee Storekeeper { get => _storekeeper; set => Set(ref _storekeeper, value); }

    /// <summary> Материально ответственное лицо </summary>
    private Employee _mol = null!;
    public Employee Mol { get => _mol; set => Set(ref _mol, value); }

    /// <summary> Счет учета расходов </summary>
    private AccountingPlan _accountingPlan = null!;
    public AccountingPlan AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }
    
    /// <summary> Позиции документа списания </summary>
    private FullyObservableCollection<PositionDecommissioningTmc> _positions = null!;
    public FullyObservableCollection<PositionDecommissioningTmc> Positions { get => _positions; set => Set(ref _positions, value); }
    
    /// <summary> Записи в регистри ТМЦ </summary>
    private ObservableCollection<TmcRegister>? _tmcRegisters;
    public ObservableCollection<TmcRegister>? TmcRegisters { get => _tmcRegisters; set => Set(ref _tmcRegisters, value); }

    /// <summary> Записи в регистре проводок </summary>
    private ObservableCollection<AccountingPlanRegister>? _accountingPlanRegisters;
    public ObservableCollection<AccountingPlanRegister>? AccountingPlanRegisters { get => _accountingPlanRegisters; set => Set(ref _accountingPlanRegisters, value); }

    /// <summary>История изменения документа </summary>
    private ObservableCollection<History> _history = new();
    public virtual ObservableCollection<History> History { get => _history; set => Set(ref _history, value); }

    /// <summary> Примечание </summary>
    private string? _note;
    public string? Note { get => _note; set => Set(ref _note, value); }
}
