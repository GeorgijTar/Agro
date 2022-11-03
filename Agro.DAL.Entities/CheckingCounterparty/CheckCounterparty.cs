using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.CheckingCounterparty.Components;
using Agro.DAL.Entities.Classifiers;

namespace Agro.DAL.Entities.CheckingCounterparty;

/// <summary>
/// Результат проверки контрагента
/// </summary>
public class CheckCounterparty: Entity
{
    /// <summary> Дата и время проверки контрагента </summary>
    private DateTime _date = DateTime.Now;
    public DateTime Date { get => _date; set => Set(ref _date, value); }

    /// <summary>Данные ЮЛ</summary>
    private DataUl? _dataUl;
    public DataUl? DataUl { get => _dataUl; set => Set(ref _dataUl, value); }

    /// <summary> Данные ИП </summary>
    private DataIp? _dataIp;
    public DataIp? DataIp { get => _dataIp; set => Set(ref _dataIp, value); }

    /// <summary> Результат проверки </summary>
    private string _resultStatus = null!;
    public string ResultStatus { get => _resultStatus; set => Set(ref _resultStatus, value); }

    /// <summary> Описание результатов проверки </summary>
    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); } 


   

}