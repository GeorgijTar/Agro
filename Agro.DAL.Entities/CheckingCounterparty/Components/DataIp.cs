using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Classifiers;
using Agro.DAL.Entities.Organization.RegInfoOrg;


namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Основная информация об ИП
/// </summary>
public class DataIp : Entity
{
    /// <summary> ОГРНИП </summary>
    private string _ogrnIp = null!;
    public string OgrnIp { get => _ogrnIp; set => Set(ref _ogrnIp, value); }

    /// <summary>ИНН</summary>
    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    /// <summary>ОКПО</summary>
    private string _okpo = null!;
    public string Okpo { get => _okpo; set => Set(ref _okpo, value); }

    /// <summary>Дата регистрации</summary>
    private DateTime _dateReg;
    public DateTime DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    /// <summary>Дата присвоения ОГРН</summary>
    private DateTime _dateOgrn;
    public DateTime DateROgrn { get => _dateOgrn; set => Set(ref _dateOgrn, value); }

    /// <summary> Ф.И.О. </summary>
    private string _fio = null!;
    public string Fio { get => _fio; set => Set(ref _fio, value); }

    /// <summary>Наименование типа индивидуального предпринимателя</summary>
    private string _type = null!;
    public string Type { get => _type; set => Set(ref _type, value); }

    /// <summary> Сокращеное наименование типа индивидуального предпринимателя </summary>
    private string _shortType = null!;
    public string ShortType { get => _shortType; set => Set(ref _shortType, value); }

    /// <summary> Пол, принимает значения "М" или "Ж" </summary>
    private string _gender = null!;
    public string Gender { get => _gender ; set => Set(ref _gender , value); }

    ///<summary>Статус</summary>
    private UrStatus? _status;
    public UrStatus? Status { get => _status; set => Set(ref _status, value); }

    ///<summary>Сведения о прекращении деятельности</summary>
    private Likved? _likved;
    public Likved? Likved { get => _likved; set => Set(ref _likved, value); }

    /// <summary>Регион</summary>
    private Region _region = null!;
    public Region Region { get => _region; set => Set(ref _region, value); }

    /// <summary> Населенный пункт </summary>
    private string _locality = null!;
    public string Locality { get => _locality; set => Set(ref _locality, value); }

    /// <summary>Основной вид экономической деятельности</summary>
    private Okved _okved = null!;
    public Okved Okved { get => _okved; set => Set(ref _okved, value); }

    /// <summary>Дополнительные виды экономической деятельности</summary>
    private ObservableCollection<Okved>? _okveds;
    public ObservableCollection<Okved>? Okveds { get => _okveds; set => Set(ref _okveds, value); }

    /// <summary>Организационно-правовая форма</summary>
    private Okopf _okopf = null!;
    public Okopf Okopf { get => _okopf; set => Set(ref _okopf, value); }

    /// <summary>Форма собственности</summary>
    private Okfs _okfs = null!;
    public Okfs Okfs { get => _okfs; set => Set(ref _okfs, value); }

    /// <summary>Общероссийский классификатор органов государственной власти и управления</summary>
    private Okogy _okogy = null!;
    public Okogy Okogy { get => _okogy; set => Set(ref _okogy, value); }

    /// <summary>Общероссийский классификатор объектов административно-территориального деления</summary>
    private Okato _okato = null!;
    public Okato Okato { get => _okato; set => Set(ref _okato, value); }

    /// <summary>Общероссийский классификатор территорий муниципальных образований</summary>
    private Oktmo _oktmo = null!;
    public Oktmo Oktmo { get => _oktmo; set => Set(ref _oktmo, value); }

    /// <summary>Постановка на учет в налоговом органе</summary>
    private RegFns _regFns = null!;
    public RegFns RegFns { get => _regFns; set => Set(ref _regFns, value); }

    /// <summary>Регистрация в ПФР</summary>
    private RegPfr _regPfr = null!;
    public RegPfr RegPfr { get => _regPfr; set => Set(ref _regPfr, value); }

    /// <summary>Регистрация в ФСС</summary>
    private RegFss _regFss = null!;
    public RegFss RegFss { get => _regFss; set => Set(ref _regFss, value); }

    /// <summary> Организации, в которых данный предприниматель является руководителем</summary>
    private ObservableCollection<Ul>? _director;
    public ObservableCollection<Ul>? Director { get => _director; set => Set(ref _director, value); }

    /// <summary>Организации, в которых данный предприниматель является учредителем</summary>
    private ObservableCollection<Ul>? _founder;
    public ObservableCollection<Ul>? Founder { get => _founder; set => Set(ref _founder, value); }

    /// <summary>Лицензии</summary>
    private ObservableCollection<License>? _licenses;
    public ObservableCollection<License>? Licenses { get => _licenses; set => Set(ref _licenses, value); }

    /// <summary> Дата последней выписки из ЕГРИП </summary>
    private DateTime? _dateDischarge;
    public DateTime? DateDischarge { get => _dateDischarge; set => Set(ref _dateDischarge, value); }

    /// <summary>Информация о включении в Единый реестр субъектов малого и среднего предпринимательства/// </summary>
    private Rmsp? _rmsp;
    public Rmsp? Rmsp { get => _rmsp; set => Set(ref _rmsp, value); }

    /// <summary> Признак включения в реестр недобросовестных поставщиков </summary>
    private bool _unscrupulous;
    public bool Unscrupulous { get => _unscrupulous; set => Set(ref _unscrupulous, value); }

    /// <summary> Записи реестра недобросовестных поставщиков </summary>
    private UnscrupulousSupplierRecord? _unscrupulousSupplierRecord;
    public UnscrupulousSupplierRecord? UnscrupulousSupplierRecord { get => _unscrupulousSupplierRecord; set => Set(ref _unscrupulousSupplierRecord, value); }

    /// <summary> Признак присутствия массовых руководителей </summary>
    private bool _massManagers;
    public bool MassManagers { get => _massManagers; set => Set(ref _massManagers, value); }

    /// <summary> Признак присутствия массовых учредителей </summary>
    private bool _massFounders;
    public bool MassFounders { get => _massFounders; set => Set(ref _massFounders, value); }

}
