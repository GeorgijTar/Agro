using Agro.DAL.Entities.Base;
using System.Collections.ObjectModel;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;
/// <summary>
/// Учредители(участники) физические лица
/// </summary>
public class FounderFl : Entity
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
    
    /// <summary>Признак недостоверности сведений</summary>
    private bool _unreliability;
    public bool Unreliability { get => _unreliability; set => Set(ref _unreliability, value); }

    /// <summary>Описание причины признания сведений недостоверными</summary>
    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); }

    /// <summary>Признак вхождения в список массовых учредителей от ФНС</summary>
    private bool _massFounder;
    public bool MassFounder { get => _massFounder; set => Set(ref _massFounder, value); }

    /// <summary>Доля в уставном капитале</summary>
    private Share _share = null!;
    public Share Share { get => _share; set => Set(ref _share, value); }

    /// <summary>ОГРН других организаций, в которых это физлицо является руководителем</summary>
    private ObservableCollection<Ogrn>? _relatedGuide;
    public ObservableCollection<Ogrn>? RelatedGuide { get => _relatedGuide; set => Set(ref _relatedGuide, value); }

    /// <summary>ОГРН других организаций, в которых это физлицо является учредителем</summary>
    private ObservableCollection<Ogrn>? _relatedFoundation;
    public ObservableCollection<Ogrn>? RelatedFoundation { get => _relatedFoundation; set => Set(ref _relatedFoundation, value); }

}
