

using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Classifiers;

public class BaseClassifier:Entity
{
    private string? _code;
    public string? Code { get => _code; set => Set(ref _code, value); }

    private string? _name;
    public string? Name { get => _name; set => Set(ref _name, value); }

    public override string ToString() => $"{Code} {Name}";
}