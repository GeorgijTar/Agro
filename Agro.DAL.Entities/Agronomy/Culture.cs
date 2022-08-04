
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Agronomy;
/// <summary>
/// Агрономическая культура
/// </summary>
public class Culture : Entity
{
    /// <summary>Наименование</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Связь с продукцией</summary>
    private Product _product = null!;
    public Product Product {get => _product; set => Set(ref _product, value); } 
    
}