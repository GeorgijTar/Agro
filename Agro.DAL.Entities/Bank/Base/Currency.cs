using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Bank.Base;
/// <summary>
/// Валюта
/// </summary>
public class Currency : Entity
{
    /// <summary>
    /// Код валюты
    /// </summary>
    private string _code = null!;
    public string Code { get => _code; set => Set(ref _code, value); }

    /// <summary>
    /// Наименование валюты
    /// </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }
    
    /// <summary>
    /// Сокращенное наименорвание
    /// </summary>
    private string _abbreviated = null!;
    public string Abbreviated { get => _abbreviated; set => Set(ref _abbreviated, value); }
}
