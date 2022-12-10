using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Bank.Pay;

/// <summary> Статус плательщика</summary>
public class PayerStatus : Entity
{
    /// <summary> Код </summary>
    private string _code = null!;
    public string Code { get => _code; set => Set(ref _code, value); }

    /// <summary> Наименование </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }
}
