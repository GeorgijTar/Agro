using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.TaxesType;
/// <summary>
/// Вид обязательства (Налог, пеня, штраф, проценты))
/// </summary>
public class TypeCommitment : Entity
{
    /// <summary> Наименование вида обязательства </summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }
}