using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Counter;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Contract;
using Agro.WPF.ViewModels.InvoiceVM;
using Agro.WPF.Views.Windows;


namespace Agro.WPF.ViewModels;
public class ContractorsViewModel : ViewModel
{

    private readonly IBaseRepository<Counterparty> _counterpartyRepository;
    private readonly IBaseRepository<GroupDoc> _groupRepository;
    private readonly IBaseRepository<TypeDoc> _typeRepository;


    public ContractorsViewModel(
        IBaseRepository<Counterparty> counterpartyRepository,
        IBaseRepository<GroupDoc> groupRepository,
        IBaseRepository<TypeDoc> typeRepository)
    {
        _counterpartyRepository = counterpartyRepository;
        _groupRepository = groupRepository;
        _typeRepository = typeRepository;
        Initial();
    }

    private async void Initial()
    {
       await LoadGr();
       await LoadFiltr();
       
    }

    private ObservableCollection<GroupDoc>? _groups;
    public ObservableCollection<GroupDoc>? Groups { get=>_groups; set=>Set(ref _groups, value); }

    private ObservableCollection<TypeDoc>? _types;
    public ObservableCollection<TypeDoc>? Types { get=>_types; set=>Set(ref _types, value); }
    public ObservableCollection<Counterparty> Counterparties { get; set; } = new ();

    private object? _modelSender;
    public object? ModelSender { get => _modelSender; set => Set(ref _modelSender, value); }

    private Counterparty? _counterparty;
    public Counterparty? SelectedCounterparty

    {
        get => _counterparty;
        set => Set(ref _counterparty, value);
    }
    
   
    private TypeDoc ? _selectType;
    public TypeDoc? SelectedType
    {
        get => _selectType;
        set => Set(ref _selectType, value);
    }

    private GroupDoc? _selectedGroup;

    public GroupDoc? SelectedGroup
    {
        get => _selectedGroup;
        set => Set(ref _selectedGroup, value);
    }

    private async Task LoadFiltr()
    {
        Groups = new ObservableCollection<GroupDoc>();
        SelectedGroup = new GroupDoc() { Id = 0, Name = "Все" };
        Groups.Add(SelectedGroup);
        var groups = await _groupRepository.GetAllAsync();
        groups= groups!.Where(g => g.TypeApplication == "Контрагенты");
        foreach (var group in groups)
        {
            Groups.Add(group);
        }

        Types = new ObservableCollection<TypeDoc>();
        Types.Add(new TypeDoc() { Id = 0, Name = "Все" });
        var types = await _typeRepository.GetAllAsync();
        types = types!.Where(t => t.TypeApplication == "Контрагенты");
        foreach (var type in types)
        {
            Types.Add(type);
        }
        
    }
    private async Task LoadGr()
    {
        Counterparties.Clear();
        var counter = await _counterpartyRepository.GetAllAsync();
        counter = counter!.Where(x => x.Status!.Id == 5);
        if (counter == null!) return;
        foreach (var ct in counter)
        {
            Counterparties.Add(ct);
        }
        CollectionView = CollectionViewSource.GetDefaultView(Counterparties);
    }

    private string? _nameFilter;
    public string? NameFilter
    {
        get => _nameFilter;
        set
        {
            Set(ref _nameFilter, value);
            CollectionView.Filter = FilterByName;
        }
    }

    private string? _innFilter;
    public string? InnFilter { get=> _innFilter;
        set
        {
            Set(ref _innFilter, value);
            CollectionView.Filter = FilterByInn;
        } }


    private ICollectionView? _collectionView;
    public ICollectionView? CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    #region Command

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted, AddCan);

    private bool AddCan(object arg)
    {
        return true;
    }
    
    private void OnAddCommandExecuted(object p)
    {
        CounterpartyView counterpartyView = new();
        var mod= counterpartyView.DataContext as CounterpartyViewModel;
        mod!.Counterparty = new();
        mod.Title = "Создание нового контрагента";
        mod.CounterpartyEvent += GridRefreh;
        counterpartyView.Show();
    }

    private void GridRefreh(Counterparty counterparty)
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

    private void OnEdeteCommandExecuted(object obj)
    {
        CounterpartyView counterpartyView = new();
        var mod = counterpartyView.DataContext as CounterpartyViewModel;
        mod.Title = "Редактирование контрагента";
        mod.Counterparty = SelectedCounterparty!;
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
            var resalt = MessageBox.Show($"Вы действительно хотите удалить выбранного контрагента: {SelectedCounterparty!.Name} ?",
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


    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowCommandExecuted, SelectRowCan);

    private bool SelectRowCan(object arg)
    {
        return SelectedCounterparty is not null;
    }

    private void OnSelectRowCommandExecuted(object obj)
    {
        if (ModelSender != null!)
        {


            if (ModelSender is InvoiceViewModel invoice)
            {
                invoice.Invoice.Counterparty = SelectedCounterparty!;
            }

            if (ModelSender is ContractViewModel contract)
            {
                contract.Contract.Counterparty = SelectedCounterparty!;
            }

            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }

    }

    #endregion

    #region Filteres

    private bool FilterByName(object count)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            Counterparty? dto = count as Counterparty;
            return  dto!.Name.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByInn(object count)
    {
        if (!string.IsNullOrEmpty(InnFilter))
        {
            Counterparty? dto = count as Counterparty;
            return dto!.Inn.Contains(InnFilter);
        }
        return true;
    }

    private bool FilterByGroup(object count)
    {
        if (SelectedGroup!.Id != 0)
        {

        }

        if (!string.IsNullOrEmpty(InnFilter))
        {
            Counterparty? dto = count as Counterparty;
            return dto!.Group!.Name.Contains(SelectedGroup!.Name);
        }
        return true;
    }


    #endregion
}
