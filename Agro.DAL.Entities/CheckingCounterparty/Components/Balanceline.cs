using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary> Строка финансовой отчетности </summary>
public class Balanceline : Entity
{
    /// <summary> Код строки фин. отчетности </summary>
    private string _lineCode = null!;
    public string LineCode { get => _lineCode; set => Set(ref _lineCode, value); }

    /// <summary> Сумма строки фин. отчетности </summary>
    private int _lineAmount;
    public int LineAmount { get => _lineAmount; set => Set(ref _lineAmount, value); }

    /// <summary> Сумма за предыдущий год</summary>
    private int? _amountPreviousYear;
    public int? AmountPreviousYear { get => _amountPreviousYear; set => Set(ref _amountPreviousYear, value); }

    /// <summary> Сумма за год, предшествующий предыдущему</summary>
    private int _amountPrecedingPreviousYear;
    public int AmountPrecedingPreviousYear { get => _amountPrecedingPreviousYear; set => Set(ref _amountPrecedingPreviousYear, value); } 

}
