using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Agro.Domain.Base;
using Agro.Interfaces.Base.Repositories;
using Agro.Services.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using FNS.Api;

namespace Agro.WPF.ViewModels;
public class CounterpartyViewModel : ViewModel
{
    private string _title;
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<CounterpartyDto> _counters = new();

    private ObservableCollection<GroupDto> _groups = new();

    public ObservableCollection<GroupDto> Groups { get => _groups; set => Set(ref _groups, value); }

    private ObservableCollection<TypeDocDto> _types = new();

    public ObservableCollection<TypeDocDto> Types { get => _types; set => Set(ref _types, value); }


    private readonly IGroupRepository<GroupDto> _groupRep;

    private readonly ITypeRepository<TypeDocDto> _typeRep;
    private readonly ICounterpertyRepository<CounterpartyDto> _counterpartyRepository;
    private readonly IBankDetailsRepository<BankDetailsDto> _bankDetailsRepository;

    private List<BankDetailsDto> _banks = new();

    public ObservableCollection<CounterpartyDto> CounterpartyDtoCollection { get; set; }

    public CounterpartyViewModel(
        IGroupRepository<GroupDto> groupRep,
        ITypeRepository<TypeDocDto> typeRep,
        ICounterpertyRepository<CounterpartyDto> counterpartyRepository,
        IBankDetailsRepository<BankDetailsDto> bankDetailsRepository)
    {
        _groupRep = groupRep;
        _typeRep = typeRep;
        _counterpartyRepository = counterpartyRepository;
        _bankDetailsRepository = bankDetailsRepository;
        Title = "Новый контрагент";
        LoadList();
    }

    private async void LoadList()
    {
        var groups = await _groupRep.GetAllByTypeApplicationAsync("Контрагенты");
        foreach (var group in groups)
        {
            Groups.Add(group);
        }

        var types = await _typeRep.GetAllByTypeApplicationAsync("Контрагенты");
        foreach (var type in types)
        {
            Types.Add(type);
        }
    }

    #region Property

    private CounterpartyDto _selectedCounterpartyDto = new();
    public CounterpartyDto SelectedCounterpartyDto
    {
        get => _selectedCounterpartyDto;
        set
        {
            Set(ref _selectedCounterpartyDto, value);
            Status = value.Status;
            Name = value.Name;
            PayName = value.PayName;
            Inn = value.Inn;
            Kpp = value.Kpp;
            Ogrn = value.Ogrn!;
            Okpo = value.Okpo!;
            GroupDoc = value.Group!;
            TypeDoc = value.TypeDoc;
            Description = value.Description;
            BankDetailsCollection = GetBankDetails(value);
        }
    }

    private ObservableCollection<BankDetailsDto> GetBankDetails(CounterpartyDto bankDetails)
    {
        ObservableCollection<BankDetailsDto> bankDetailsCollection = new ObservableCollection<BankDetailsDto>();
        foreach (var res in bankDetails.BankDetails)
        {
            bankDetailsCollection.Add(res);
        }

        return bankDetailsCollection;

    }
    private StatusDto _status;

    public StatusDto Status { get => _status; set => Set(ref _status, value); }

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            Set(ref _name, value);
            SelectedCounterpartyDto.Name = value;
        }
    }

    private string _payName;
    public string PayName
    {
        get => _payName;
        set
        {
            Set(ref _payName, value);
            SelectedCounterpartyDto.PayName = value;
        }
    }

    private string _inn = string.Empty;

    public string Inn
    {
        get => _inn;
        set
        {
            Set(ref _inn, value);
            SelectedCounterpartyDto.Inn = value;
        }
    }

    private string _kpp;

    public string Kpp
    {
        get => _kpp;
        set
        {
            Set(ref _kpp, value);
            SelectedCounterpartyDto.Kpp = value;
        }
    }

    private string _ogrn;

    public string Ogrn
    {
        get => _ogrn;
        set
        {
            Set(ref _ogrn, value);
            SelectedCounterpartyDto.Ogrn = value;
        }
    }

    private string _okpo;

    public string Okpo
    {
        get => _okpo;
        set
        {
            Set(ref _okpo, value);
            SelectedCounterpartyDto.Okpo = value;
        }
    }

    private GroupDto _group;

    public GroupDto GroupDoc
    {
        get => _group;
        set
        {
            Set(ref _group, value);
            SelectedCounterpartyDto.Group = value;
        }
    }

    private TypeDocDto _typeDoc;

    public TypeDocDto TypeDoc
    {
        get => _typeDoc;
        set
        {
            Set(ref _typeDoc, value);
            SelectedCounterpartyDto.TypeDoc = value;
        }
    }

    private string _description;

    public string Description
    {
        get => _description;
        set
        {
            Set(ref _description, value);
            SelectedCounterpartyDto.Description = value;

        }
    }

    private BankDetailsDto _bankDetails;

    public BankDetailsDto SelectBankDetails
    {
        get => _bankDetails;
        set => Set(ref _bankDetails, value);
    }

    private ObservableCollection<BankDetailsDto> _bankDetailsCollection;
    public ObservableCollection<BankDetailsDto> BankDetailsCollection
    {
        get => _bankDetailsCollection;
        set
        {
            Set(ref _bankDetailsCollection, value);
            SelectedCounterpartyDto.BankDetails = value;
        }
    }

    private string message;

    public string Message
    {
        get => message;
        set => Set(ref message, value);
    }
    #endregion

    #region Command

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveCommandExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return true;
    }

    private async void OnSaveCommandExecuted(object p)
    {
        SelectedCounterpartyDto.Status = new() { Id = 5, Name = "Актуально" };
        try
        {
            if (SelectedCounterpartyDto.Id == 0)
            {
                CounterpartyEvent(await _counterpartyRepository.AddAsync(SelectedCounterpartyDto));
            }
            else
            {
                CounterpartyEvent(await _counterpartyRepository.UpdateAsync(SelectedCounterpartyDto));
            }

            var window = p as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
        catch (InvalidOperationException e)
        {
            MessageBox.Show(e.Message);
            return;
        }

    }

    #endregion

    #region AddBankDetails

    private ICommand? _addBankDetailsCommand;

    public ICommand AddBankDetailsCommand => _addBankDetailsCommand
        ??= new RelayCommand(OnAddBankDetailsCommandExecuted, AddBankDetailsCommandCon);

    private bool AddBankDetailsCommandCon(object arg)
    {
        if (SelectedCounterpartyDto.Id == 0) return false;
        return true;
    }

    private void OnAddBankDetailsCommandExecuted(object obj)
    {
        BankDetailsView bankDetailsView = new();
        var mod = bankDetailsView.DataContext as BankDetailsViewModel;
        if (mod != null)
        {
            mod.Title = $"Добавление банковских реквизитов для {Name}";
            mod.BankDetails = new();
            mod.Counterparty = SelectedCounterpartyDto;
            mod.BankDetailsEvent += Gridrefresh;
        }


        bankDetailsView.Show();
    }

    private void Gridrefresh(BankDetailsDto bankdetails)
    {
        var bank = BankDetailsCollection.FirstOrDefault(b => b.Id == bankdetails.Id);
        if (bank is null)
        {
            BankDetailsCollection.Add(bankdetails);
        }
        else
        {
            bank = bankdetails;

        }
    }

    #endregion

    #region EdeteBankDetails
    private ICommand? _edeteBankDetailsCommand;

    public ICommand EdeteBankDetailsCommand => _edeteBankDetailsCommand
        ??= new RelayCommand(OnEdeteBankDetailsCommandExecuted, EdeteBankDetailsCommandCon);

    private bool EdeteBankDetailsCommandCon(object arg)
    {
        if (SelectBankDetails is null) return false;
        return true;
    }

    private void OnEdeteBankDetailsCommandExecuted(object obj)
    {
        BankDetailsView bankDetailsView = new();
        var mod = bankDetailsView.DataContext as BankDetailsViewModel;
        if (mod != null)
        {
            mod.Title = $"Редактирование банковских реквизитов для {Name}";
            mod.BankDetails = SelectBankDetails;
            mod.Counterparty = SelectedCounterpartyDto;
            mod.BankDetailsEvent += Gridrefresh;
        }
        bankDetailsView.Show();
    }


    #endregion

    #region Delete

    private ICommand? _deleteBankDetailsCommand;

    public ICommand DeleteBankDetailsCommand => _deleteBankDetailsCommand
        ??= new RelayCommand(OnDeleteBankDetailsCommandExecuted, DeleteBankDetailsCommandCon);

    private async void OnDeleteBankDetailsCommandExecuted(object obj)
    {
        try
        {
            var resalt = MessageBox.Show("Вы действительно хотите удалить выделенные реквизиты", 
                "Контроль", MessageBoxButton.YesNo);
            if (resalt == MessageBoxResult.Yes)
            {
                if (await _bankDetailsRepository.DeleteAsync(SelectBankDetails))
                {
                    BankDetailsCollection.Remove(SelectBankDetails);
                }
            }
            else return;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

    }

    private bool DeleteBankDetailsCommandCon(object arg)
    {
        if (SelectBankDetails is null) return false;
        return true;
    }


    #endregion

    #region LoadbyIFNS

    private ICommand? _loadCommand;

    public ICommand LoadCommand => _loadCommand
        ??= new RelayCommand(OnLoadCommandExecuted, LoadCan);

    private bool LoadCan(object arg)
    {
        if (Inn is null) { return false; }
        else
        {
            if (Inn.Length == 10 || Inn.Length == 12) return true;
        }
        return false;

    }

    private async void OnLoadCommandExecuted(object p)
    {
        CounterpartyDto load;
        try
        {
            if (Inn.Length == 10)
            {
                load = await CheckoApi.GetUl(Inn);
            }
            else
            {
                load = await CheckoApi.GetIp(Inn);
            }
            SelectedCounterpartyDto = load;
            Message = "";
        }
        catch (InvalidOperationException e)
        {
            Message = e.Message;
        }
    }


    #endregion

    #endregion

    #region Event

    public delegate void CounterpartyHandler(CounterpartyDto counterparty);
    public event CounterpartyHandler CounterpartyEvent;

    #endregion
}
