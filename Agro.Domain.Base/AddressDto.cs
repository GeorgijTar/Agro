using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;
/// <summary>
/// 
/// </summary>
public class AddressDto: EntityDto
{
    /// <summary> Индекс </summary>
    public string PostalCode { get; set; } = null!;

    /// <summary> </summary>
    public string StringAddress { get; set; } = null!;

    public AddressDto()
    {
        
    }

    public AddressDto(string postalCode, string stringAddress)
    {
        PostalCode = postalCode;
        StringAddress = stringAddress;
    }
}
