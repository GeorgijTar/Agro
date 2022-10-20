using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Физические лица, осуществляющие права учредителя 
/// </summary>
public class FlMo : Entity
{
    private string _fio = null!;
    public string Fio { get => _fio; set => Set(ref _fio, value); }

    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); } 


}