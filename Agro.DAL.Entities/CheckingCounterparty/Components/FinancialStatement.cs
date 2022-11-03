
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

public class FinancialStatement : Entity
{
    private Ul _ul = null!;

    public Ul Ul
    {
        get => _ul;
        set => Set(ref _ul, value);
    }

    private CheckBalance _checkBalance = null!;
    public CheckBalance CheckBalance { get => _checkBalance; set => Set(ref _checkBalance, value); } 

}