using Microsoft.Extensions.DependencyInjection;

namespace Agro.WPF.ViewModels
{
    public class ViewModelLocator
    {
        public CounterpartyViewModel CounterpartyModel => App.Services.GetRequiredService<CounterpartyViewModel>();
       
    }
}
