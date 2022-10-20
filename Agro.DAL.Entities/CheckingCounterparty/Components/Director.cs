using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Руководитель(лица, имеющие право действовать без доверенности)
/// </summary>
public class Director : Entity
{
    /// <summary>Признак ограничения доступа к сведениям от ФНС</summary>
    private bool _ogrDostup;
    public bool OgrDostup { get => _ogrDostup; set => Set(ref _ogrDostup, value); }

    /// <summary> Ф. И. О. </summary>
    private string _fio = null!;
    public string Fio { get => _fio; set => Set(ref _fio, value); }

    /// <summary> ИНН </summary>
    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    /// <summary> Вид должности </summary>
    private string _typePosition = null!;
    public string TypePosition { get => _typePosition; set => Set(ref _typePosition, value); }

    /// <summary> Должность </summary>
    private string _namePosition = null!;
    public string NamePosition { get => _namePosition; set => Set(ref _namePosition, value); }

    /// <summary>Признак недостоверности сведений</summary>
    private bool _unreliability;
    public bool Unreliability { get => _unreliability; set => Set(ref _unreliability, value); }

    /// <summary>Описание причины признания сведений недостоверными</summary>
    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); }

    /// <summary>Признак вхождения в список массовых руководителей от ФНС</summary>
    private bool _massManager;
    public bool MassManager { get => _massManager; set => Set(ref _massManager, value); }

    /// <summary>Признак дисквалификации</summary>
    private bool _disqualifiedPerson;
    public bool DisqualifiedPerson { get => _disqualifiedPerson; set => Set(ref _disqualifiedPerson, value); }

    /// <summary> Дата начала дисквалификации </summary>
    private DateTime _disqualifiedOn;
    public DateTime DisqualifiedOn { get => _disqualifiedOn; set => Set(ref _disqualifiedOn, value); }

    /// <summary> Дата окончания дисквалификации </summary>
    private DateTime _disqualifiedOff;
    public DateTime DisqualifiedOff { get => _disqualifiedOff; set => Set(ref _disqualifiedOff, value); }

    /// <summary>ОГРН других организаций, в которых это физлицо является руководителем</summary>
    private ObservableCollection<Ogrn>? _relatedGuide;
    public ObservableCollection<Ogrn>? RelatedGuide { get => _relatedGuide; set => Set(ref _relatedGuide, value); }

    /// <summary>ОГРН других организаций, в которых это физлицо является учредителем</summary>
    private ObservableCollection<Ogrn>? _relatedFoundation;
    public ObservableCollection<Ogrn>? RelatedFoundation { get => _relatedFoundation; set => Set(ref _relatedFoundation, value); } 
}
