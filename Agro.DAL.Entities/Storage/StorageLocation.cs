using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Organization;

namespace Agro.DAL.Entities.Storage;
/// <summary>
/// Место хранения (склад)
/// </summary>
public class StorageLocation : Entity
{
    public StorageLocation()
    {
        if (Storekeepers!.Count > 0)
        {
            foreach (var officialPerson in Storekeepers)
            {
                if (officialPerson.Status!.Id == 5)
                {
                    ActualStorekeeper = officialPerson;
                }
            }
        }
    }
    /// <summary>Статус</summary>
    private Status? _status = null!;
    public Status? Status { get => _status; set => Set(ref _status, value); } 

    /// <summary>Наименование</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    private OfficialPerson? _actualStorekeeper;

    [NotMapped]
    public OfficialPerson? ActualStorekeeper { get => _actualStorekeeper;set => Set(ref _actualStorekeeper, value); } 

    /// <summary>Кладовщики</summary>
    private ObservableCollection<OfficialPerson>? _storekeepers = new();
    public ObservableCollection<OfficialPerson>? Storekeepers { get => _storekeepers; set => Set(ref _storekeepers, value); }

    /// <summary>Отбор</summary>
    private string? _typeApplication;
    public string? TypeApplication { get => _typeApplication; set => Set(ref _typeApplication, value); }

    public override string ToString() => Name;


}