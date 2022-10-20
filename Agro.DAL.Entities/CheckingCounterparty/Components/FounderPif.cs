using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

public class FounderPif : Entity
{
    /// <summary>Признак ограничения доступа к сведениям от ФНС</summary>
    private bool _ogrDostup;
    public bool OgrDostup { get => _ogrDostup; set => Set(ref _ogrDostup, value); }

    ///<summary>Полное наименование ПИФа</summary>
    private string _fullName = null!;
    public string FullName { get => _fullName; set => Set(ref _fullName, value); }

    /// <summary>Управляющая организация</summary>
    private ManagingOrganization? _managingOrganization;
    public ManagingOrganization? ManagingOrganization { get => _managingOrganization; set => Set(ref _managingOrganization, value); }

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
