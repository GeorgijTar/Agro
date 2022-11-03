using Agro.DAL.Entities.Base;
using System.Collections.ObjectModel;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

public class Founder : Entity
{
    // <summary>Учредители(участники) физические лица</summary>
    private ObservableCollection<FounderFl>? _foundersFl;
    public ObservableCollection<FounderFl>? FoundersFl { get => _foundersFl; set => Set(ref _foundersFl, value); }

    /// <summary>Учредители(участники) Российские Юредические лица</summary>
    private ObservableCollection<FounderUl>? _foundersUl;
    public ObservableCollection<FounderUl>? FoundersUl { get => _foundersUl; set => Set(ref _foundersUl, value); }

    /// <summary>Учредители(участники) иностранные организации</summary>
    private ObservableCollection<FounderIn>?_foundersIn;
    public ObservableCollection<FounderIn>? FoundersIn { get => _foundersIn; set => Set(ref _foundersIn, value); }

    /// <summary>Учредители(участники) Паевые инвестиционные фонды</summary>
    private ObservableCollection<FounderPif>? _foundersPif;
    public ObservableCollection<FounderPif>? FoundersPif { get => _foundersPif; set => Set(ref _foundersPif, value); }

    /// <summary> Учредитель - Российская Федерация, субъекты РФ и муниципальные образования </summary>
    private ObservableCollection<FounderMoRf>? _foundersMoRf;
    public ObservableCollection<FounderMoRf>? FoundersMoRf { get => _foundersMoRf; set => Set(ref _foundersMoRf, value); }

}
