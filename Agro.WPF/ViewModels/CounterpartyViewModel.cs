using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using FNS.Api;

namespace Agro.WPF.ViewModels;
public class CounterpartyViewModel : ViewModel
{
   


    private readonly IBaseRepository<GroupDoc> _groupRep;

    private readonly IBaseRepository<TypeDoc> _typeRep;
    private readonly IBaseRepository<Counterparty> _counterpartyRepository;
    private readonly IBaseRepository<BankDetails> _bankDetailsRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    public CounterpartyViewModel(
        IBaseRepository<GroupDoc> groupRep,
        IBaseRepository<TypeDoc> typeRep,
        IBaseRepository<Counterparty> counterpartyRepository,
        IBaseRepository<BankDetails> bankDetailsRepository,
        IBaseRepository<Status> statusRepository)
    {
        _groupRep = groupRep;
        _typeRep = typeRep;
        _counterpartyRepository = counterpartyRepository;
        _bankDetailsRepository = bankDetailsRepository;
        _statusRepository = statusRepository;
        Title = "Новый контрагент";
        LoadList();
    }

    private async void LoadList()
    {
        var groups = await _groupRep.GetAllAsync();
        groups = groups!.Where(g => g.TypeApplication == "Контрагенты").ToArray();

        foreach (var group in groups)
        {
            Groups.Add(group);
        }

        var types = await _typeRep.GetAllAsync();
        types = types!.Where(g => g.TypeApplication == "Контрагенты").ToArray();
        foreach (var type in types)
        {
            Types.Add(type);
        }
    }

    #region Property

    private string _title = "";
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<GroupDoc> _groups = new();

    public ObservableCollection<GroupDoc> Groups { get => _groups; set => Set(ref _groups, value); }

    private ObservableCollection<TypeDoc> _types = new();

    public ObservableCollection<TypeDoc> Types { get => _types; set => Set(ref _types, value); }

    private Counterparty _counterparty = new();
    public Counterparty Counterparty { get => _counterparty; set=> Set(ref _counterparty, value); }

    private BankDetails _selectBankDetails = null!;
    public BankDetails SelectBankDetails { get => _selectBankDetails; set => Set( ref _selectBankDetails, value); }

    private string _message =null!;
    public string Message { get => _message; set => Set(ref _message, value); }

    #endregion

    #region Commands

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveCommandExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return Counterparty.Group!.Name != null! 
               && Counterparty.TypeDoc!.Name != null! 
               && Counterparty.Name != null!
               && Counterparty.Inn != null!
               && Counterparty.Inn.Length >= 10
               && Counterparty.PayName != null!
               && Counterparty.PayName.Length > 5;
    }

    private async void OnSaveCommandExecuted(object p)
    {
        var ctr = await _counterpartyRepository.GetAllAsync();
        var ct =  ctr!.
            Where(c=>c.Inn==Counterparty.Inn).
            Where(c=>c.Id != Counterparty.Id)
            .Where(c=>c.Status.Id==5);
        if (ct.Any())
        {
            MessageBox.Show($"Контрагент с ИНН {Counterparty.Inn} уже есть в базе данных!", "Редактор контрагентов");
            return;
        }

        var status = await _statusRepository.GetByIdAsync(5);
        Counterparty.Status = status!;
        try
        {
            CounterpartyEvent(await _counterpartyRepository.SaveAsync(Counterparty));
           
            var window = p as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
        catch (InvalidOperationException e)
        {
            MessageBox.Show(e.Message);
        }

    }

    #endregion

    #region AddBankDetails

    private ICommand? _addBankDetailsCommand;

    public ICommand AddBankDetailsCommand => _addBankDetailsCommand
        ??= new RelayCommand(OnAddBankDetailsCommandExecuted);

   private void OnAddBankDetailsCommandExecuted(object obj)
    {
        BankDetailsView view = new();
        BankDetailsViewModel? viewModel = view.DataContext as BankDetailsViewModel;
        viewModel!.ViewSender = this;
        viewModel.BankDetails.Guid = Guid.NewGuid();
        viewModel.Title = $"Добавление банковских реквизитов для {Counterparty.Name}";
        view.ShowDialog();
    }
    

    #endregion

    #region EdeteBankDetails
    private ICommand? _edeteBankDetailsCommand;

    public ICommand EdeteBankDetailsCommand => _edeteBankDetailsCommand
        ??= new RelayCommand(OnEdeteBankDetailsCommandExecuted, EdeteBankDetailsCommandCon);

    private bool EdeteBankDetailsCommandCon(object arg)
    {
        if (SelectBankDetails == null!) return false;
        return true;
    }

    private void OnEdeteBankDetailsCommandExecuted(object obj)
    {
        BankDetailsView bankDetailsView = new();
        var mod = bankDetailsView.DataContext as BankDetailsViewModel;
        if (mod != null)
        {
            mod.Title = $"Редактирование банковских реквизитов для {Counterparty.Name}";
            mod.BankDetails = SelectBankDetails;
            mod.ViewSender = this;
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
                   Counterparty.BankDetails!.Remove(SelectBankDetails);
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

    }

    private bool DeleteBankDetailsCommandCon(object arg)
    {
        if (SelectBankDetails == null!) return false;
        return true;
    }


    #endregion

    #region LoadbyIFNS

    private ICommand? _loadCommand;

    public ICommand LoadCommand => _loadCommand
        ??= new RelayCommand(OnLoadCommandExecuted, LoadCan);

    private bool LoadCan(object arg)
    {
        if (Counterparty.Inn == null!) { return false; }
        else
        {
            if (Counterparty.Inn.Length == 10 || Counterparty.Inn.Length == 12) return true;
        }
        return false;

    }

    private async void OnLoadCommandExecuted(object p)
    {
        Counterparty load;
        try
        {
            if (Counterparty.Inn.Length == 10)
            {
                load = await CheckoApi.GetUl(Counterparty.Inn);
            }
            else
            {
                load = await CheckoApi.GetIp(Counterparty.Inn);
            }

            var id = Counterparty.Id;
            Counterparty = load;
            Counterparty.Id = id;
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

    public delegate void CounterpartyHandler(Counterparty counterparty);
    public event CounterpartyHandler CounterpartyEvent;

    #endregion
}
