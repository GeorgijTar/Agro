using Agro.DAL.Entities.Base;
using System.Collections.ObjectModel;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Запись об арбитражном деле
/// </summary>
public class ArbitrationCasesRecord : Entity
{
    /// <summary> Номер дела </summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value); }

    /// <summary> UUID дела </summary>
    private string? _guid;
    public string? Guid { get => _guid; set => Set(ref _guid, value); }

    /// <summary> Ссылка на страницу в Картотеке арбитражных дел </summary>
    private string _link = null!;
    public string Link { get => _link; set => Set(ref _link, value); }

    /// <summary> Дата возбуждения </summary>
    private DateTime _dateInitiation;
    public DateTime DateInitiation { get => _dateInitiation; set => Set(ref _dateInitiation, value); }

    /// <summary> Наименование суда, в котором рассматривалось дело </summary>
    private string _nameCourt = null!;
    public string NameCourt { get => _nameCourt; set => Set(ref _nameCourt, value); }

    /// <summary> Истцы </summary>
    private ObservableCollection<PlaintiffDefendant>? _plaintiff;
    public ObservableCollection<PlaintiffDefendant>? Plaintiff { get => _plaintiff; set => Set(ref _plaintiff, value); }
    
    /// <summary> Ответчики </summary>
    private ObservableCollection<PlaintiffDefendant>? _defendant;
    public ObservableCollection<PlaintiffDefendant>? Defendant { get => _defendant; set => Set(ref _defendant, value); }
}
