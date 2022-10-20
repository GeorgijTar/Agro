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

}
