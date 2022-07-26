using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;
/// <summary>
/// 
/// </summary>
public class Address: Entity
{
    /// <summary>Населенный пункт</summary>
    private string _city=null!;
    public string City { get=>_city; set=>Set(ref _city, value); }

    /// <summary>Юридическийй адрес в РФ</summary>
    private string _addressRf= null!;
    public string AddressRf { get=>_addressRf; set=>Set(ref _addressRf, value); }

    /// <summary>Идентификатор ГАР (Государственный адресный реестр)</summary>
    private string _garId = null!;

    public string GarId { get=>_garId; set=>Set(ref _garId, value); }

    /// <summary>Признак недостоверности сведений</summary>
    private bool _unreliability;
    public bool Unreliability { get=>_unreliability; set=>Set(ref _unreliability, value);}

    /// <summary>Описание причины признания сведений недостоверными</summary>
    private string _unreliabilityDescription;
    public string UnreliabilityDescription { get => _unreliabilityDescription; set => Set(ref _unreliabilityDescription, value); }

}
