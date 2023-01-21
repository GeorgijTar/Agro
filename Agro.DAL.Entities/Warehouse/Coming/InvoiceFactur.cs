
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Warehouse.Coming;
/// <summary>
/// Счет-фактура
/// </summary>
public class InvoiceFactur : Entity
{
    /// <summary> Статус документа </summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary> Документ прихода </summary>
    private IEnumerable<ComingTmc>? _comingTmc;
    public IEnumerable<ComingTmc>? ComingTmc { get => _comingTmc; set => Set(ref _comingTmc, value); }

    /// <summary> Номер документа </summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value); }

    /// <summary> Дата документа </summary>
    private DateTime? _date;
    public DateTime? Date { get => _date; set => Set(ref _date, value); }

}
