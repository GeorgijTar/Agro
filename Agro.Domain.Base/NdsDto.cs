
using System.ComponentModel.DataAnnotations;
using Agro.Domain.Base.Base;

namespace Agro.Domain.Base;

public class NdsDto: EntityDto
{
    private string _name;
    [Required]
    public string Name { get=> _name; set=>Set(ref _name, value); }


    private int _percent;
    [Required]
    public int Percent { get=> _percent; set=> Set(ref _percent, value); }

    public override string ToString() => Name;
}

