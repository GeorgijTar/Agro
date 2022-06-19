using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using FNS.Api;
using TypeDoc = Agro.DAL.Entities.TypeDoc;

namespace Agro.WPF.ViewModels
{
    public class CounterpartyViewModel : ViewModel
    {
        
        private readonly IMapper<CounterpartyDto, Counterparty> _mapperCounterpaty;
        private readonly ICounterpertyRepository<Counterparty> _counterpartyRepository;

       
        public CounterpartyViewModel(
            IMapper<CounterpartyDto, Counterparty> mapperCounterpaty,
            ICounterpertyRepository<Counterparty> counterpartyRepository)
        {
            
            _mapperCounterpaty = mapperCounterpaty;
            _counterpartyRepository = counterpartyRepository;
            LoadGr();
            SelectedCounterparty = new CounterpartyDto();
        }
       
        public ObservableCollection<CounterpartyDto> Counterparties { get; set; } = new ObservableCollection<CounterpartyDto>();

       private CounterpartyDto _counterpartyDto;
        public CounterpartyDto SelectedCounterparty
        {
            get => _counterpartyDto;
            set
            {
                Set(ref _counterpartyDto, value);
            }
        }

        private async void LoadGr()
        {
            Counterparties.Clear();
            var couner = await _counterpartyRepository.GetAllAsync(default);
            foreach (var ct in couner)
            {
                Counterparties.Add(_mapperCounterpaty.Map(ct));
            }
        }


        #region Command

        private ICommand? _loadServersCommand;

        public ICommand LoadDataCommand => _loadServersCommand
            ??= new RelayCommand(OnLoadServersCommandExecuted, Can);

        private bool Can(object arg)
        { 
            return true;
        }


        private async void OnLoadServersCommandExecuted(object p)
        {

        }


        private ICommand? _saveCommand;

        public ICommand SaveCommand => _saveCommand
            ??= new RelayCommand(OnSaveCommandExecuted, CanSave);

        private bool CanSave(object arg)
        {
            return true;
        }

        private async void OnSaveCommandExecuted(object obj)
        {

        }

        #endregion
    }
}
