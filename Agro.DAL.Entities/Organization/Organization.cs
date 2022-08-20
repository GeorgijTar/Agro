
using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Classifiers;
using Agro.DAL.Entities.RegInfoOrg;

namespace Agro.DAL.Entities.Organization;
public class Organization : Entity
{
    public Organization()
    {
        Okved = new();
        Okopf = new();
        Okfs = new();
        Okogy = new();
        Okato = new();
        Oktmo = new();
        RegFns = new();
        RegPfr = new();
        RegFss = new();
        AddressUr = new();
        BankDetails = new();
    }
    /// <summary>Сокращенное наименование</summary>
    private string _abbreviatedName = null!;
    public string AbbreviatedName { get => _abbreviatedName; set => Set(ref _abbreviatedName, value); }

    /// <summary>Полное наименование</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    private string _kpp = null!;
    public string Kpp { get => _kpp; set => Set(ref _kpp, value); }

    private string _ogrn = null!;
    public string Ogrn { get => _ogrn; set => Set(ref _ogrn, value); }

    private string _okpo = null!;
    public string Okpo { get => _okpo; set => Set(ref _okpo, value); }

    private Okved _okved = null!;
    public virtual Okved Okved { get => _okved; set => Set(ref _okved, value); }

    private Okopf? _okopf;
    public virtual Okopf? Okopf { get => _okopf; set => Set(ref _okopf, value); }

    private Okfs? _okfs;
    public virtual Okfs? Okfs { get => _okfs; set => Set(ref _okfs, value); }

    private Okogy? _okogy;
    public virtual Okogy? Okogy { get => _okogy; set => Set(ref _okogy, value); }


    private Okato? _okato;
    public virtual Okato? Okato { get => _okato; set => Set(ref _okato, value); }


    private Oktmo? _oktmo;
    public virtual Oktmo? Oktmo { get => _oktmo; set => Set(ref _oktmo, value); }


    private RegFns? _regFns;
    public virtual RegFns? RegFns { get => _regFns; set => Set(ref _regFns, value); }


    private RegPfr? _regPfr;
    public virtual RegPfr? RegPfr { get => _regPfr; set => Set(ref _regPfr, value); }


    private RegFss? _regFss;
    public virtual RegFss? RegFss { get => _regFss; set => Set(ref _regFss, value); }


    private ObservableCollection<BankDetails> _bankDetails = null!;
    public virtual ObservableCollection<BankDetails> BankDetails { get => _bankDetails; set => Set(ref _bankDetails, value); }

    private Address? _addressUr;
    public virtual Address? AddressUr { get => _addressUr; set => Set(ref _addressUr, value); }

    /// <summary>Руководитель</summary>
    private Employee? _director;
    public Employee? Director { get => _director; set => Set(ref _director, value); }

    /// <summary>Главбух</summary>
    private Employee? _generalAccountant;
    public Employee? GeneralAccountant { get => _generalAccountant; set => Set(ref _generalAccountant, value); }

    /// <summary>Кассир</summary>
    private Employee? _cashier;
    public Employee? Cashier { get => _cashier; set => Set(ref _cashier, value); }

    /// <summary>Кадровик</summary>
    private Employee? _hr;
    public Employee? Hr { get => _hr; set => Set(ref _hr, value); }

    /// <summary>Подразделения</summary>
    private ObservableCollection<Division>? _divisions = null!;
    public ObservableCollection<Division>? Divisions { get => _divisions; set => Set(ref _divisions, value); } 


}
