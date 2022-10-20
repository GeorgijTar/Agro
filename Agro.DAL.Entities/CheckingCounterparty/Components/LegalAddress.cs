using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;
/// <summary>Юридический адрес</summary>
public class LegalAddress : Entity
{
    /// <summary>Населенный пункт</summary>
    private string _locality = null!;
    public string Locality { get => _locality; set => Set(ref _locality, value); }

    /// <summary>Юридическийй адрес в РФ</summary>
    private string _address = null!;
    public string Address { get => _address; set => Set(ref _address, value); }

    /// <summary>Идентификатор ГАР(Государственный адресный реестр)</summary>
    private string? _idGar;
    public string? IdGar { get => _idGar; set => Set(ref _idGar, value); }

    /// <summary>Признак недостоверности сведений</summary>
    private bool _unreliability;
    public bool Unreliability { get => _unreliability; set => Set(ref _unreliability, value); }

    /// <summary>Описание причины признания сведений недостоверными</summary>
    private string? _description = null!;
    public string? Description { get => _description; set => Set(ref _description, value); } 



}
