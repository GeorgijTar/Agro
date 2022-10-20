using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Classifiers;
using Agro.DAL.Entities.Organization.RegInfoOrg;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Основная информация о ЮЛ
/// </summary>
public class DataUl : Entity
{
    /// <summary>ОГРН организации</summary>
    private string _ogrn = null!;
    public string Ogrn { get => _ogrn; set => Set(ref _ogrn, value); }

    /// <summary>ИНН</summary>
    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    ///<summary>КПП</summary>
    private string _kpp = null!;
    public string Kpp { get => _kpp; set => Set(ref _kpp, value); }
    
    /// <summary>ОКПО</summary>
    private string _okpo = null!;
    public string Okpo { get => _okpo; set => Set(ref _okpo, value); }
    
    /// <summary>Дата регистрации</summary>
    private DateTime _dateReg;
    public DateTime DateReg { get => _dateReg; set => Set(ref _dateReg, value); }

    /// <summary>Дата присвоения ОГРН</summary>
    private DateTime _dateOgrn;
    public DateTime DateROgrn { get => _dateOgrn; set => Set(ref _dateOgrn, value); }

    ///<summary>Сокращенное наименование</summary>
    private string _shortName = null!;
    public string ShortName { get => _shortName; set => Set(ref _shortName, value); }

    ///<summary>Полное наименование</summary>
    private string _fullName = null!;
    public string FullName { get => _fullName; set => Set(ref _fullName, value); }

    ///<summary>Статус</summary>
    private UrStatus? _status;
    public UrStatus? Status { get => _status; set => Set(ref _status, value); }

    ///<summary>Сведения о ликвидации</summary>
    private Likved? _likved;
    public Likved? Likved { get => _likved; set => Set(ref _likved, value); }

    /// <summary>Регион</summary>
    private Region _region = null!;
    public Region Region { get => _region; set => Set(ref _region, value); }

    /// <summary>Юридический адрес</summary>
    private LegalAddress _legalAddress = null!;
    public LegalAddress LegalAddress { get => _legalAddress; set => Set(ref _legalAddress, value); }

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

    /// <summary>Уставный капитал</summary>
    private AuthorizedCapital _authorizedCapital = null!;
    public AuthorizedCapital AuthorizedCapital { get => _authorizedCapital; set => Set(ref _authorizedCapital, value); }

    /// <summary>Управляющая организация</summary>
    private ManagingOrganization? _managingOrganization;
    public ManagingOrganization? ManagingOrganization { get => _managingOrganization; set => Set(ref _managingOrganization, value); }

    /// <summary> Руководители(лица, имеющие право действовать без доверенности) </summary>
    private ObservableCollection<Director> _director = null!;
    public ObservableCollection<Director> Director { get => _director; set => Set(ref _director, value); }

    private ObservableCollection<FounderFl>? _foundersFl;
    public ObservableCollection<FounderFl>? FoundersFl { get => _foundersFl; set => Set(ref _foundersFl, value); }

    /// <summary>Учредители(участники) Российские Юредические лица</summary>
    private ObservableCollection<FounderUl>? _foundersUl;
    public ObservableCollection<FounderUl>? FoundersUl { get => _foundersUl; set => Set(ref _foundersUl, value); }

    /// <summary>Учредители(участники) иностранные организации</summary>
    private ObservableCollection<FounderIn> _foundersIn = null!;
    public ObservableCollection<FounderIn> FoundersIn { get => _foundersIn; set => Set(ref _foundersIn, value); }

    /// <summary> Учредитель - Российская Федерация, субъекты РФ и муниципальные образования </summary>
    private ObservableCollection<FounderMoRf>? _foundersMoRf;
    public ObservableCollection<FounderMoRf>? FoundersMoRf { get => _foundersMoRf; set => Set(ref _foundersMoRf, value); }

    /// <summary> Юридические лица, находящиеся под управлением данной организации </summary>
    private ObservableCollection<Ul>? _relatedOrganizationsUpr;
    public ObservableCollection<Ul>? RelatedOrganizationsUpr { get => _relatedOrganizationsUpr; set => Set(ref _relatedOrganizationsUpr, value); }

    /// <summary> Юридические лица, учрежденные данной организацией</summary>
    private ObservableCollection<Ul>? _relatedOrganizationsFounded;
    public ObservableCollection<Ul>? RelatedOrganizationsFounded { get => _relatedOrganizationsFounded; set => Set(ref _relatedOrganizationsFounded, value); }

    /// <summary> Держатель реестра акционеров </summary>
    private HolderRegister _holderRegister = null!;
    public HolderRegister HolderRegister { get => _holderRegister; set => Set(ref _holderRegister, value); }

    /// <summary>Лицензии</summary>
    private ObservableCollection<License>? _licenses;
    public ObservableCollection<License>? Licenses { get => _licenses; set => Set(ref _licenses, value); }

    /// <summary> Подразделения организации </summary>
    private Divisions? _divisions;
    public Divisions? Divisions { get => _divisions; set => Set(ref _divisions, value); }

    /// <summary> Правопредшественники </summary>
    private ObservableCollection<UlShort>? _assignees;
    public ObservableCollection<UlShort>? Assignees { get => _assignees; set => Set(ref _assignees, value); }

    /// <summary> Правопреемники </summary>
    private ObservableCollection<UlShort>? _legalSuccessors;
    public ObservableCollection<UlShort>? LegalSuccessors { get => _legalSuccessors; set => Set(ref _legalSuccessors, value); }

    /// <summary> Дата последней выписки из ЕГРЮЛ </summary>
    private DateTime? _dateDischarge;
    public DateTime? DateDischarge { get => _dateDischarge; set => Set(ref _dateDischarge, value); }

    /// <summary> Контакты </summary>
    private Contacts? _contacts;
    public Contacts? Contacts { get => _contacts; set => Set(ref _contacts, value); }

    /// <summary> Налоги </summary>
    private Tax? _tax;
    public Tax? Tax { get => _tax; set => Set(ref _tax, value); }

    /// <summary>Информация о включении в Единый реестр субъектов малого и среднего предпринимательства/// </summary>
    private Rmsp? _rmsp;
    public Rmsp? Rmsp {get => _rmsp; set => Set(ref _rmsp, value); }

    /// <summary> Среднесписочная численность работников организации </summary>
    private int _srh;
    public int Srh { get => _srh; set => Set(ref _srh, value); }

    /// <summary> Признак включения в реестр недобросовестных поставщиков </summary>
    private bool _unscrupulous;
    public bool Unscrupulous { get => _unscrupulous ; set => Set(ref _unscrupulous , value); }

    /// <summary> Записи реестра недобросовестных поставщиков </summary>
    private UnscrupulousSupplierRecord? _unscrupulousSupplierRecord;
    public UnscrupulousSupplierRecord? UnscrupulousSupplierRecord { get => _unscrupulousSupplierRecord; set => Set(ref _unscrupulousSupplierRecord, value); }

    /// <summary> Признак присутствия дисквалифицированных лиц в руководстве организации </summary>
    private bool _disqualifiedPersons;
    public bool DisqualifiedPersons { get => _disqualifiedPersons; set => Set(ref _disqualifiedPersons, value); }

    /// <summary> Признак присутствия массовых руководителей </summary>
    private bool _massManagers;
    public bool MassManagers { get => _massManagers; set => Set(ref _massManagers, value); }

    /// <summary> Признак присутствия массовых учредителей </summary>
    private bool _massFounders;
    public bool MassFounders { get => _massFounders; set => Set(ref _massFounders, value); }

    /// <summary> Финансовая отчетность </summary>
    private ObservableCollection<CheckBalance>? _financialStatements;
    public ObservableCollection<CheckBalance>? FinancialStatements { get => _financialStatements; set => Set(ref _financialStatements, value); }

    /// <summary> Исполнительные производства </summary>
    private ObservableCollection<EnforcementProceedingRecord>? _enforcementProceedings;
    public ObservableCollection<EnforcementProceedingRecord>? EnforcementProceedings { get => _enforcementProceedings; set => Set(ref _enforcementProceedings, value);}

    /// <summary> Арбитражные дела </summary>
    private ObservableCollection<ArbitrationCasesRecord>? _arbitrationCasesRecords = null!;
    public ObservableCollection<ArbitrationCasesRecord>? ArbitrationCasesRecords { get => _arbitrationCasesRecords; set => Set(ref _arbitrationCasesRecords, value); } 


}