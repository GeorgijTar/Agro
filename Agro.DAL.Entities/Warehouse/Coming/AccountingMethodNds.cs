using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Warehouse.Coming;
public class AccountingMethodNds : Entity
{
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    public override string ToString()
    {
        return Name;
    }
}