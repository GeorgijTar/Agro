using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;
/// <summary>
/// 
/// </summary>
public class Address: Entity
{
    /// <summary> Индекс </summary>
    public string PostalCode { get; set; } = null!;

    /// <summary> </summary>
    public string StringAddress { get; set; } = null!;

    

}
