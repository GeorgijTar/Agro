using System.ComponentModel.DataAnnotations;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

/// <summary>
/// Статус документа
/// </summary>
public class StatusDto : NotifyPropertyChanged
{
    private string _name;

    [Required]
    public string Name { get=>_name; set=>Set(ref _name, value); }

    public override string ToString() => Name;

    public StatusDto()
    {
        Id = 1;
        Name = "Черновик";
    }
}

