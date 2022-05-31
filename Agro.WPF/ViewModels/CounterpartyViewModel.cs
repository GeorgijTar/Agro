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
using Type = Agro.DAL.Entities.Type;

namespace Agro.WPF.ViewModels
{
    public class CounterpartyViewModel : ViewModel
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IMapper<GroupDto> _mapperGroup;
        private readonly IRepository<Type> _typeRepository;
        private readonly IMapper<TypeDto> _mapperType;

        private string kpp;

        public string Kpp
        {
            get => kpp;
            set
            {
                Set(ref kpp, value);
                SelectedCounterparty.Kpp = value;
            }
        }

        private string ogrn;

        public string Ogrn
        {
            get => ogrn;
            set
            {
                Set(ref ogrn, value);
                SelectedCounterparty.Ogrn = value;
            }
        }

    private string okpo;
        public string Okpo
        {
            get => okpo;
            set
            {
                Set(ref okpo, value); 
                SelectedCounterparty.Okpo = value;
            }
        }

        private string inn;
        public string Inn
        {
            get => inn;
            set
            {
                Set(ref inn, value);
                SelectedCounterparty.Inn = value;
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                Set(ref name, value);
                SelectedCounterparty.Name = value;
            }
        }

        private string payName;
        public string PayName
        {
            get => payName;
            set
            {
                Set(ref payName, value);
                SelectedCounterparty.PayName = value;
            }
        }

        private string messeg;

        public string Messeg
        {
            get => messeg;
            set => Set(ref messeg, value);
        }
        public CounterpartyViewModel(
            IRepository<Group> groupRepository,
            IRepository<Type> typeRepository,
            IMapper<GroupDto> mapperGroup,
            IMapper<TypeDto> mapperType)
        {
            _groupRepository = groupRepository;
            _mapperGroup = mapperGroup;
            _typeRepository = typeRepository;
            _mapperType = mapperType;
            LoadGr();
            SelectedCounterparty = new CounterpartyDto();
        }
        public ObservableCollection<GroupDto> Groups { get; set; } = new ObservableCollection<GroupDto>();
        public ObservableCollection<TypeDto> Types { get; set; } = new ObservableCollection<TypeDto>();
        //public ObservableCollection<CounterpartyDto> CounterpartiesCollection { get; set; }
        private TypeDto selectedType;
        public TypeDto SelectedType { 
            get=>selectedType;
            set
            {
                Set(ref selectedType, value); 
                SelectedCounterparty.Type=value;
            }
        }

        public GroupDto selectedGroup;
        public GroupDto SelectedGroup
        {
            get=> selectedGroup;
            set
            {
                Set(ref selectedGroup, value);
                SelectedCounterparty.Group=value;
            }
        }

        private CounterpartyDto _counterpartyDto;
        public CounterpartyDto SelectedCounterparty { get=> _counterpartyDto; set=> Set(ref _counterpartyDto, value); }

        private async void LoadGr()
        {
            Groups.Clear();

            var col = await _groupRepository.GetAllAsync(default);
            foreach (var cl in col)
            {
                Groups.Add(_mapperGroup.Map(cl));
            }
            Types.Clear();
            var typeCol= await _typeRepository.GetAllAsync(default);
            var tCol = typeCol.Where(t => t.TypeApplication == "Counterparty").ToArray();
            foreach (var t in tCol)
            {
                Types.Add(_mapperType.Map(t));
            }

            SelectedCounterparty.Inn = "";
        }


        #region Command

        private ICommand _LoadServersCommand;

        public ICommand LoadDataCommand => _LoadServersCommand
            ??= new RelayCommand(OnLoadServersCommandExecuted, Can);

        private bool Can(object arg)
        {
            if (Inn is null) return false;
           if (Inn.Length==10 || Inn.Length==12 )
               return true;
           else
           {
               return false;
           }
        }


        private async void OnLoadServersCommandExecuted(object p)
        {
            try
            {

            
            CounterpartyDto countr;
            if (Inn.Length == 10)
            {
                countr = await CheckoApi.GetUl(Inn);
            }
            else if (Inn.Length == 12)
            {
                countr = await CheckoApi.GetIp(Inn);
            }
            else
            {
                return;
            }
            Kpp = countr.Kpp;
            Ogrn= countr.Ogrn;
            Name= countr.Name;
            PayName= countr.PayName;
            Okpo= countr.Okpo;
            }
            catch (InvalidOperationException e)
            {
                Messeg=e.Message;
                return;
            }

        }

        #endregion

    }
}
