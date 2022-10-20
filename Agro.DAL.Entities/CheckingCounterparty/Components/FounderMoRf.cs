using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Учредитель - Российская Федерация, субъекты РФ и муниципальные образования
/// </summary>
public class FounderMoRf: Entity
{
    /// <summary>Признак ограничения доступа к сведениям от ФНС</summary>
    private bool _ogrDostup;
    public bool OgrDostup { get => _ogrDostup; set => Set(ref _ogrDostup, value); }

    /// <summary> Тип учредителя, принимает значения "РОССИЙСКАЯ ФЕДЕРАЦИЯ", "СУБЪЕКТ РФ" или "МУНИЦИПАЛЬНОЕ ОБРАЗОВАНИЕ" </summary>
    private string _type = null!;
    public string Type { get => _type; set => Set(ref _type, value); }
    
    /// <summary> Регион </summary>
    private Region _region = null!;
    public Region Region { get => _region; set => Set(ref _region, value); }

    /// <summary> Органы или юридические лица, осуществляющие права учредителя </summary>
    private ObservableCollection<UlShort>? _orgsMo;
    public ObservableCollection<UlShort>? OrgsMo { get => _orgsMo; set => Set(ref _orgsMo, value); }

    /// <summary> Физические лица, осуществляющие права учредителя </summary>
    private ObservableCollection<FlMo>? _flsMo;
    public ObservableCollection<FlMo>? FlsMo { get => _flsMo; set => Set(ref _flsMo, value); }

    /// <summary>Признак недостоверности сведений</summary>
    private bool _unreliability;
    public bool Unreliability { get => _unreliability; set => Set(ref _unreliability, value); }

    /// <summary>Описание причины признания сведений недостоверными</summary>
    private string? _description;
    public string? Description { get => _description; set => Set(ref _description, value); }

    /// <summary>Доля в уставном капитале</summary>
    private Share _share = null!;
    public Share Share { get => _share; set => Set(ref _share, value); }

}
