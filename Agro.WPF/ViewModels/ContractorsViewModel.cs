using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;


namespace Agro.WPF.ViewModels;
public class ContractorsViewModel : ViewModel
{

    private readonly ICounterpertyRepository<CounterpartyDto> _counterpartyRepository;
    private readonly IGroupRepository<GroupDto> _groupRepository;
    private readonly ITypeRepository<TypeDocDto> _typeRepository;
    private readonly IStatusRepository<StatusDto> _statusRepository;


    public ContractorsViewModel(
        ICounterpertyRepository<CounterpartyDto> counterpartyRepository,
        IGroupRepository<GroupDto> groupRepository, 
        ITypeRepository<TypeDocDto> typeRepository)
    {
        _counterpartyRepository = counterpartyRepository;
        _groupRepository = groupRepository;
        _typeRepository = typeRepository;
        Initial();
    }

    private async Task Initial()
    {
       await LoadGr(5);
       await LoadFiltr();
       
    }

    private ObservableCollection<GroupDto> _groups;
    public ObservableCollection<GroupDto> Groups { get=>_groups; set=>Set(ref _groups, value); }

    private ObservableCollection<TypeDocDto> _types;
    public ObservableCollection<TypeDocDto> Types { get=>_types; set=>Set(ref _types, value); }
    public ObservableCollection<CounterpartyDto> Counterparties { get; set; } = new ObservableCollection<CounterpartyDto>();

    private CounterpartyDto? _counterpartyDto;
    public CounterpartyDto? SelectedCounterparty

    {
        get => _counterpartyDto;
        set => Set(ref _counterpartyDto, value);
    }
    
    private string? _selectedStatus;

    public string? SelectedStatus
    {
        get => _selectedStatus;
        set
        {
            Set(ref _selectedStatus, value);
            string str=value.ToString();
            switch (value.ToString())
            {
                default: 
                    LoadGr(5);
                    break;
                case "System.Windows.Controls.ComboBoxItem: Актуально": 
                    LoadGr(5);
                    break;
                case "System.Windows.Controls.ComboBoxItem: Удалено":
                    LoadGr(6);
                    break;
                case "System.Windows.Controls.ComboBoxItem: Черновик":
                    LoadGr(1);
                    break;
            }
        }
    }
    
    private TypeDocDto ? _selecteType;
    public TypeDocDto? SelectedType
    {
        get => _selecteType;
        set => Set(ref _selecteType, value);
    }

    private GroupDto? _selectedGroup;

    public GroupDto? SelectedGroup
    {
        get => _selectedGroup;
        set => Set(ref _selectedGroup, value);
    }

    private async Task LoadFiltr()
    {
        Groups = new ObservableCollection<GroupDto>();
        SelectedGroup = new GroupDto() { Id = 0, Name = "Все" };
        Groups.Add(SelectedGroup);
        var groups = await _groupRepository.GetAllByTypeApplicationAsync("Контрагенты");
        foreach (var group in groups)
        {
            Groups.Add(group);
        }

        Types = new ObservableCollection<TypeDocDto>();
        Types.Add(new TypeDocDto() { Id = 0, Name = "Все" });
        var types = await _typeRepository.GetAllByTypeApplicationAsync("Контрагенты");
        foreach (var type in types)
        {
            Types.Add(type);
        }
        
    }
    private async Task LoadGr(int idStatus)
    {
        Counterparties.Clear();
        var counter = await _counterpartyRepository.GetAllByStatusAsync(idStatus);
        if (counter is null) return;
        foreach (var ct in counter)
        {
            Counterparties.Add(ct);
        }
        CollectionView = CollectionViewSource.GetDefaultView(Counterparties);
    }

    private string _nameFilter;
    public string NameFilter
    {
        get => _nameFilter;
        set
        {
            Set(ref _nameFilter, value);
            CollectionView.Filter = FilterByName;
        }
    }

    private string _innFilter;
    public string InnFilter { get=> _innFilter;
        set
        {
            Set(ref _innFilter, value);
            CollectionView.Filter = FilterByInn;
        } }


    private ICollectionView _collectionView;
    public ICollectionView CollectionView
    {
        get => _collectionView;
        set => Set(ref _collectionView, value);
    }

    #region Command

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted, AddCan);

    private bool AddCan(object arg)
    {
        return true;
    }
    
    private async void OnAddCommandExecuted(object p)
    {
        CounterpartyView counterpartyView = new();
        var mod= counterpartyView.DataContext as CounterpartyViewModel;
        mod.SelectedCounterpartyDto = new();
        mod.CounterpartyDtoCollection = Counterparties;
        mod.Title = "Создание нового контрагента";
        mod.CounterpartyEvent += GridRefreh;
        counterpartyView.Show();
    }

    private void GridRefreh(CounterpartyDto counterparty)
    {
        var counterpartyCol = Counterparties.FirstOrDefault(c => c.Id == counterparty.Id);
        if (counterpartyCol is null)
        {
            Counterparties.Add(counterparty);
        }
        else
        {
            counterpartyCol = counterparty;
        }
    }

    private ICommand? _edeteCommand;

    public ICommand EdeteCommand => _edeteCommand
        ??= new RelayCommand(OnEdeteCommandExecuted, EdeteCan);

    private bool EdeteCan(object arg)
    {
        if (SelectedCounterparty is null) return false;
        //if (SelectedCounterparty.Id==0) return false;
        return true;
    }

    private async void OnEdeteCommandExecuted(object obj)
    {
        CounterpartyView counterpartyView = new();
        var mod = counterpartyView.DataContext as CounterpartyViewModel;
        mod.Title = "Редактирование контрагента";
        mod.SelectedCounterpartyDto = SelectedCounterparty;
        mod.CounterpartyDtoCollection = Counterparties;
        mod.CounterpartyEvent += GridRefreh;
        counterpartyView.Show();
    }

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteCommandExecuted, DeleteCan);

    private async void OnDeleteCommandExecuted(object obj)
    {
        try
        {
            var resalt = MessageBox.Show($"Вы действительно хотите удалить выбранного контрагента: {SelectedCounterparty.Name} ?",
                "Контроль", MessageBoxButton.YesNo);
            if (resalt == MessageBoxResult.Yes)
            {
                if (await _counterpartyRepository.DeleteAsync(SelectedCounterparty))
                    Counterparties.Remove(SelectedCounterparty);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private bool DeleteCan(object arg)
    {
        if (SelectedCounterparty is null) return false;
        //if (SelectedCounterparty.Id == 0) return false;
        return true;
    }

    #endregion

    #region Filteres

    private bool FilterByName(object count)
    {
        if (!String.IsNullOrEmpty(NameFilter))
        {
            CounterpartyDto? dto = count as CounterpartyDto;
            return  dto!.Name.Contains(NameFilter);
        }
        return true;
    }

    private bool FilterByInn(object count)
    {
        if (!String.IsNullOrEmpty(InnFilter))
        {
            CounterpartyDto? dto = count as CounterpartyDto;
            return dto!.Inn.Contains(InnFilter);
        }
        return true;
    }

    #endregion
}
