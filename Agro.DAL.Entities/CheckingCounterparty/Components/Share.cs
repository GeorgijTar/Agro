using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Доля в уставном капитале
/// </summary>
public class Share : Entity
{
    /// <summary>Номинальная стоимость доли, руб.</summary>
    private float _nominal;
    public float Nominal { get => _nominal; set => Set(ref _nominal, value); }

    /// <summary> Размер доли, процент </summary>
    private float _percent;
    public float Percent { get => _percent; set => Set(ref _percent, value); } 



}
