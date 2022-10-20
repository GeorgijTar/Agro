using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Регтон
/// </summary>
public class Region : Entity
{
    /// <summary>Код региона РФ</summary>
    private string _code = null!;
    public string Code { get => _code; set => Set(ref _code, value); }

    /// <summary>Наименование региона РФ</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

}