using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.TaxesType;

/// <summary>
/// Налоги
/// </summary>
public class Taxes : Entity
{
    /// <summary>
    /// Наименование налога
    /// </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }
    
    /// <summary>
    /// Правило определения счета учета
    /// </summary>
    private ICollection<RulesAccounting> _rulesAccountings = null!;
    public ICollection<RulesAccounting> RulesAccountings
    {
        get => _rulesAccountings;
        set => Set(ref _rulesAccountings, value);
    }
    
    private ICollection<TaxKbk> _taxKbk = null!;
    public ICollection<TaxKbk> TaxKbk { get => _taxKbk; set => Set(ref _taxKbk, value); }


}
