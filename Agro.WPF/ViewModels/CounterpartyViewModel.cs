using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.Domain.Base;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using FNS.Api;

namespace Agro.WPF.ViewModels;
public class CounterpartyViewModel : ViewModel
{
    private string _title;
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<CounterpartyDto> _counters = new();

    private List<GroupDto> _groups = new();

    public List<GroupDto> Groups { get => _groups; set => Set(ref _groups, value); }

    private List<TypeDocDto> _types = new();

    public List<TypeDocDto> Types { get => _types; set => Set(ref _types, value); }


    private readonly IGroupRepository<GroupDto> _groupRep;

    private readonly ITypeRepository<TypeDocDto> _typeRep;
    private readonly ICounterpertyRepository<CounterpartyDto> _counterpertyRepository;

    private List<BankDetailsDto> _banks = new();

    public ObservableCollection<CounterpartyDto> CounterpartyDtoCollection { get; set; }

    public List<BankDetailsDto> BankDetails
    {
        get => _banks;
        set
        {
            Set(ref _banks, value);
            SelectedCounterpartyDto.BankDetails = value;
        }
    }

    public CounterpartyViewModel(
        IGroupRepository<GroupDto> groupRep,
        ITypeRepository<TypeDocDto> typeRep,
        ICounterpertyRepository<CounterpartyDto> counterpertyRepository)
    {
        _groupRep = groupRep;
        _typeRep = typeRep;
        _counterpertyRepository = counterpertyRepository;
        Title = "Новый контрагент";
        LoadList();
    }

    private async void LoadList()
    {
        var groups = await _groupRep.GetAllAsync().ConfigureAwait(false);
        Groups = groups!.ToList();

        var types = await _typeRep.GetAllAsync().ConfigureAwait(false);
        Types = types!.ToList();
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
            BankDetails = value.BankDetails.ToList();
        }
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
        bool result;
        SelectedCounterpartyDto.Status = new() { Id = 5, Name = "Актуально" };
        //try
        //{
            if (SelectedCounterpartyDto.Id == 0)
        {
            
            result = await _counterpertyRepository.AddAsync(SelectedCounterpartyDto);
            if (result)
            {
                CounterpartyDtoCollection.Add(SelectedCounterpartyDto);
            }
        }
        else
        {
            result = await _counterpertyRepository.UpdateAsync(SelectedCounterpartyDto);
            var item = CounterpartyDtoCollection.FirstOrDefault(
                i => i.Id == SelectedCounterpartyDto.Id);
            item = SelectedCounterpartyDto;
        }
        if (result)
        {
            var window = p as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null)
                window.Close();
        }
        //}
        //catch (InvalidOperationException e)
        //{
        //    MessageBox.Show(e.Message);
        //    return;
        //}

    }

    #endregion

    #region AddBankDetails



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
           Message=e.Message;
        }
    }


    #endregion

    #endregion
}
