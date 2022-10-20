using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Classifiers;
/// <summary>
/// Виды экономической деятельности
/// </summary>
public class Okved : BaseClassifier
{
    /// <summary>
    /// Версия справочника ОКВЭД, принимает значения "2001" или "2014"
    /// </summary>
    private string? _version;
    public string? Version { get => _version; set => Set(ref _version, value); } 

}
