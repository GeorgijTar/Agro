using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;
public class Ul : Entity
{
    /// <summary>ОГРН организации</summary>
    private string _ogrn = null!;
    public string Ogrn { get => _ogrn; set => Set(ref _ogrn, value); }

    /// <summary>ИНН</summary>
    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    ///<summary>КПП</summary>
    private string? _kpp;
    public string? Kpp { get => _kpp; set => Set(ref _kpp, value); }

    ///<summary>Сокращенное наименование</summary>
    private string? _shortName;
    public string? ShortName { get => _shortName; set => Set(ref _shortName, value); }

    ///<summary>Полное наименование</summary>
    private string _fullName = null!;
    public string FullName { get => _fullName; set => Set(ref _fullName, value); }

    /// <summary>Дата регистрации</summary>
    private string? _dateReg;
    public string? DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    /// <summary> Статус </summary>
    private string _status = null!;
    public string Status { get => _status; set => Set(ref _status, value); }

    /// <summary> Дата ликвидации </summary>
    private string _dateLikvid = null!;
    public string DateLikvid { get => _dateLikvid; set => Set(ref _dateLikvid, value); }

    /// <summary> Код региона РФ </summary>
    private string _codeRegion = null!;
    public string CodeRegion { get => _codeRegion; set => Set(ref _codeRegion, value); }

    /// <summary>Юридический адрес </summary>
    private string _urAddress = null!;
    public string UrAddress { get => _urAddress; set => Set(ref _urAddress, value); }

    /// <summary> Основной вид деятельности согласно ОКВЭД </summary>
    private string _okved = null!;
    public string Okved { get => _okved; set => Set(ref _okved, value); } 



}