
using Microsoft.Extensions.DependencyInjection;

namespace Agro.WPF.ViewModels;

public class ViewModelLocator
{
    public ContractorsViewModel ContractorsModel => App.Services.GetRequiredService<ContractorsViewModel>();

    public CounterpartyViewModel CounterpartyModel => App.Services.GetRequiredService<CounterpartyViewModel>();

    public BankDetailsViewModel BankDetailsModel => App.Services.GetRequiredService<BankDetailsViewModel>();



}