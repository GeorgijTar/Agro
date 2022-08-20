

using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Organization;

public class Division : Entity

{
    private Status? _status = null!;
    public Status? Status { get => _status; set => Set(ref _status, value); } 


    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); } 



}