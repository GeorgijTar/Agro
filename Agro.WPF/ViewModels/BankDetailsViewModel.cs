using System;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.Services.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using Bank.Api;

namespace Agro.WPF.ViewModels;
public class BankDetailsViewModel : ViewModel
{
    private readonly IBaseRepository<BankDetails> _repository;

    #region Property

    private string _title;
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    private BankDetails _details;

    public BankDetails BankDetails
    {
        get => _details;
        set
        {
            Set(ref _details, value);
            Name = value.NameBank;
            TitleBankDetails = value.Title;
            Bs = value.Bs;
            City = value.City;
            BiK = value.Bik;
            Ks = value.Ks;
            Description = value.Description;
            Status = value.Status;
            Counterparty = value.Counterparty;
        }
    }

    private string _titleBankDetails;

    public string TitleBankDetails
    {
        get => _titleBankDetails;
        set
        {
            Set(ref _titleBankDetails, value);
            BankDetails.Title = value;
        }
    }

    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            Set(ref _name, value);
            BankDetails.NameBank = value;
        }
    }

    private string _bs;

    public string Bs
    {
        get => _bs;
        set
        {
            Set(ref _bs, value);
            BankDetails.Bs = value;
        }
    }

    private string _city;

    public string City
    {
        get => _city;
        set
        {
            Set(ref _city, value);
            BankDetails.City = value;
        }
    }

    private string _bik;
    public string BiK
    {
        get => _bik;
        set
        {
            Set(ref _bik, value);
            BankDetails.Bik = value;
            GetBank(value);
        }
    }

    private async void GetBank(string value)
    {
        try
        {
            if (value == null || value.Length != 9) return;
            var bank = new BankDetails();
            bank = await ApiBank.GetBankByBik(value);
            Name = bank.NameBank;
            City = bank.City;
            Ks = bank.Ks;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
       
    }

    private string _ks;
    public string Ks
    {
        get => _ks;
        set
        {
            Set(ref _ks, value);
            BankDetails.Ks = value;
        }
    }

    private string _description;

    public string Description
    {
        get => _description;
        set
        {
            Set(ref _description, value);
            BankDetails.Description = value;
        }
    }

    private Status _status;

    public Status Status
    {
        get => _status;
        set
        {
            Set(ref _status, value);
            BankDetails.Status = value;
        }
    }

    private Counterparty _counterparty;

    public Counterparty Counterparty
    {
        get => _counterparty;
        set
        {
            Set(ref _counterparty, value);
            BankDetails.Counterparty = value;
        }
    }

    #endregion

    public BankDetailsViewModel(IBaseRepository<BankDetails> repository)
    {
        _repository = repository;
        Title = "Бфнковские реквизиты контрагента";
    }

    #region Command

    #region Save

    private ICommand? _saveBankDetailsCommand;

    public ICommand SaveBankDetailsCommand => _saveBankDetailsCommand
        ??= new RelayCommand(OnSaveBankDetailsCommandExecuted, SaveBankDetailsCan);
    private bool SaveBankDetailsCan(object arg)
    {
        return true;
    }

    private async void OnSaveBankDetailsCommandExecuted(object obj)
    {
        BankDetails.Status = new() { Id = 5, Name = "Актуально" };

        try
        {
            if (BankDetails.Id == 0)
            {
               
                BankDetailsEvent(await _repository.AddAsync(BankDetails));
            }
            else
            {
                BankDetailsEvent(await _repository.UpdateAsync(BankDetails));
            }

            if (obj is not null)
            {
                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                window.Close();
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
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

    #region Event

   public delegate void BankdetailsHandler(BankDetails bankDetails);
   public event BankdetailsHandler BankDetailsEvent;

    #endregion
}