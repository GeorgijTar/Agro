
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Agronomy;
/// <summary>
/// Агрономическая культура
/// </summary>
public class Culture : Entity
{
    /// <summary>Статус</summary>
    private Status? _status;
   public Status? Status { get => _status; set => Set(ref _status, value); }

    
    /// <summary>Наименование</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Связь с продукцией</summary>
    private Product _product = null!;
    public Product Product {get => _product; set => Set(ref _product, value); }

    /// <summary>Год урожая</summary>
    private string _yearHarvest = null!;
    public string YearHarvest { get => _yearHarvest; set => Set(ref _yearHarvest, value); } 


}