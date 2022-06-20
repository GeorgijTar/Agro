using System.Collections.ObjectModel;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Domain.Base;
using Agro.Interfaces;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;


namespace Agro.WPF.ViewModels;
public class ContractorsViewModel : ViewModel
{

    private readonly ICounterpertyRepository<CounterpartyDto> _counterpartyRepository;
 

    public ContractorsViewModel(
        ICounterpertyRepository<CounterpartyDto> counterpartyRepository)
    {
        _counterpartyRepository = counterpartyRepository;
       LoadGr(5);
    }

    public ObservableCollection<CounterpartyDto> Counterparties { get; set; } = new ObservableCollection<CounterpartyDto>();

    private CounterpartyDto _counterpartyDto = new CounterpartyDto();
    public CounterpartyDto SelectedCounterparty
    {
        get => _counterpartyDto;
        set => Set(ref _counterpartyDto, value);
    }
    
    private string _selectedStatus;

    public string SelectedStatus
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
    

    private async void LoadGr(int idStatus)
    {
        Counterparties.Clear();
        var counter = await _counterpartyRepository.GetAllByStatusAsync(idStatus);
        if (counter is null) return;
        foreach (var ct in counter)
        {
            Counterparties.Add(ct);
        }
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
        counterpartyView.Show();
    }

    private ICommand? _edeteCommand;

    public ICommand EdeteCommand => _edeteCommand
        ??= new RelayCommand(OnEdeteCommandExecuted, EdeteCan);

    private bool EdeteCan(object arg)
    {
        if (SelectedCounterparty is null) return false;
        if (SelectedCounterparty.Id==0) return false;
        return true;
    }

    private async void OnEdeteCommandExecuted(object obj)
    {
        CounterpartyView counterpartyView = new();
        var mod = counterpartyView.DataContext as CounterpartyViewModel;
        mod.Title = "Редактирование контрагента";
        mod.SelectedCounterpartyDto = SelectedCounterparty;
        mod.CounterpartyDtoCollection = Counterparties;
        counterpartyView.Show();
    }

    #endregion
}
