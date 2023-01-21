using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.TaxesType;
/// <summary>
/// Код бюджетной кассификации
/// </summary>
public class Kbk : Entity
{
    /// <summary>
    /// Код администратора поступлений
    /// </summary>
    [MaxLength (3)]
    private string _receiptAdministratorCode = null!;
    public string ReceiptAdministratorCode
    {
        get => _receiptAdministratorCode; set => Set(ref _receiptAdministratorCode, value);
    }

    /// <summary>
    /// Код вида доходов
    /// </summary>
    [MaxLength (10)]
    private string _incomeTypeCode = null!;
    public string IncomeTypeCode { get => _incomeTypeCode; set => Set(ref _incomeTypeCode, value); }

    /// <summary>
    /// Код подвида доходов
    /// </summary>
    [MaxLength(4)]
    private string _incomeSubspeciesCode = null!;
    public string IncomeSubspeciesCode
    {
        get => _incomeSubspeciesCode; set => Set(ref _incomeSubspeciesCode, value);
    }

    /// <summary>
    /// Код операции сектора государственного управления
    /// </summary>
    [MaxLength(3)]
    private string _kosgu = null!;
    public string Kosgu { get => _kosgu; set => Set(ref _kosgu, value); }


}
