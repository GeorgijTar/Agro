using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Organization;
using Bank.Api;


namespace Agro.WPF.ViewModels;
public class BankDetailsViewModel : ViewModel
{


    #region Property
    private readonly IBaseRepository<BankDetails> _repository;
    private readonly IBaseRepository<Status> _statusRepository;

    private string _title = "Добавление банковских реквизитов";
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    private BankDetails _details = new();
    public BankDetails BankDetails { get => _details; set => Set(ref _details, value); }

    private object? _viewModelSender;
    public object? ViewSender { get => _viewModelSender; set => Set(ref _viewModelSender, value); }

    private string _message = null!;
    public string Message { get => _message; set => Set(ref _message, value); }

    #endregion

    public BankDetailsViewModel(IBaseRepository<BankDetails> repository, IBaseRepository<Status> statusRepository)
    {
        _repository = repository;
        _statusRepository = statusRepository;
        Title = "Банковские реквизиты контрагента";
        BankDetails.PropertyChanged += GetBank;
    }

    private async void GetBank(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Bik")
        {
            if (BankDetails.Bik.Length == 9)
            {
                try
                {
                    var bd = await Get.GetBankByBik(BankDetails.Bik);
                    Message = "";
                    BankDetails.NameBank = bd.NameBank;
                    BankDetails.City = bd.City;
                    BankDetails.Ks = bd.Ks;
                }
                catch (InvalidOperationException exception)
                {
                    Message = exception.Message;
                }
                catch(Exception ex)
                {
                    Message = ex.Message;
                }
                
            }

        }
    }

    #region Command

    #region Save

    private ICommand? _saveBankDetailsCommand;

    public ICommand SaveBankDetailsCommand => _saveBankDetailsCommand
        ??= new RelayCommand(OnSaveBankDetailsCommandExecuted, SaveBankDetailsCan);
    private bool SaveBankDetailsCan(object arg)
    {
       return BankDetails.Bs !=null! && BankDetails.NameBank !=null! && BankDetails.Bik !=null! && BankDetails.Ks !=null!;
    }

    private async void OnSaveBankDetailsCommandExecuted(object? obj)
    {
        var status = await _statusRepository.GetByIdAsync(5);
        BankDetails.Status = status!;

        if (ViewSender is OrganizationViewModel organizationViewModel)
        {
            var bankD = organizationViewModel.Organization.BankDetails.FirstOrDefault(c => c.Guid == BankDetails.Guid);
            if (bankD is null)
            {
                organizationViewModel.Organization.BankDetails.Add(BankDetails);
            }
            else
            {
                bankD = BankDetails;
            }
        }

        if (ViewSender is CounterpartyViewModel counterpartyViewModel)
        {
            if (BankDetails.Id == 0)
            {
                counterpartyViewModel.Counterparty.BankDetails!.Add(BankDetails);
            }
            else
            {
                var bankD = counterpartyViewModel.Counterparty.BankDetails!.FirstOrDefault(c => c.Id == BankDetails.Id);
                if (bankD is null)
                {
                    counterpartyViewModel.Counterparty.BankDetails!.Add(BankDetails);
                }
                else
                {
                    bankD = BankDetails;
                }
            }
        }

        if (obj is not null)
        {
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            window.Close();
        }
    }

    #endregion

    #region Close

    private ICommand? _closeBankDetailsCommand;

    public ICommand CloseBankDetailsCommand => _closeBankDetailsCommand
        ??= new RelayCommand(OnCloseBankDetailsCommandExecuted);

    private void OnCloseBankDetailsCommandExecuted(object? obj)
    {
        if (obj is not null)
        {
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            window.Close();
        }
    }

    #endregion

    #endregion
}