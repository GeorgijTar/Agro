using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.TaxesType;

public class TaxKbk : Entity
{
    /// <summary>
    /// КБК налога
    /// </summary>
    private Kbk _kbk = null!;
    public Kbk Kbk { get => _kbk; set => Set(ref _kbk, value); }

    /// <summary>
    /// Вид обязательства (Налог, пеня, штраф, проценты))
    /// </summary>
    private TypeCommitment _typeCommitment = null!;
    public TypeCommitment TypeCommitment { get => _typeCommitment; set => Set(ref _typeCommitment, value); }

    /// <summary>
    /// Ссылка на налог
    /// </summary>
    private Taxes _tax = null!;
    public Taxes Tax { get => _tax; set => Set(ref _tax, value); }
}
