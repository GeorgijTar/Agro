
using System;
using System.Windows;
using Agro.Domain.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using Agro.Services.Repositories;
using static Agro.WPF.ViewModels.AccountingPlanViewModel;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.WPF.ViewModels;
public class AccountingPlanViewModel : ViewModel
{
    private readonly IBaseRepository<AccountingPlanDto> _repository;

    private string _title="Добавление нового счета Плана счетов";

    public string Title { get=>_title; set=>Set(ref _title, value); }

    private AccountingPlanDto? _accountingPlanDto;
    public AccountingPlanDto? AccountingPlanDto { get=>_accountingPlanDto; set=>Set(ref _accountingPlanDto, value); }

    public AccountingPlanViewModel(IBaseRepository<AccountingPlanDto> repository)
    {
        _repository = repository;

        AccountingPlanDto = new();
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted);

    private async void OnSaveExecuted(object p)
    {
        try
        {
            AccountingPlanDto!.Status = new StatusDto() { Id = 5 };
            var resalt = await _repository.SaveAsync(AccountingPlanDto!);
            AccountingPlanDto = resalt;
            AccountingEvent(resalt);
            var window = p as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
       
    }


    #endregion

    #region Event

    public delegate void AccountingHandler(AccountingPlanDto accounting);
    public event AccountingHandler AccountingEvent;

    #endregion

}
