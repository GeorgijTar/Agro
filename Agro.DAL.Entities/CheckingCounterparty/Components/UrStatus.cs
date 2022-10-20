using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;
/// <summary>
/// Статус записи в ЕГРЮЛ(ИП)
/// </summary>
public class UrStatus : Entity
{
    /// <summary>Признак ограничения доступа к сведениям от ФНС</summary>
    private bool _ogrDostup;
    public bool OgrDostup { get => _ogrDostup; set => Set(ref _ogrDostup, value); }

    /// <summary>Код статуса по справочнику СЮЛСТ</summary>
    private string _code = null!;
    public string Code { get => _code; set => Set(ref _code, value); }

    /// <summary>Описание статуса</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); } 


}