
using System;
using System.Windows;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;

namespace Agro.WPF.ViewModels.Accounting;
public class AccountingPlanViewModel : ViewModel
{
    private readonly IBaseRepository<AccountingPlan> _repository;

    private string _title = "Добавление нового счета Плана счетов";

    public string Title { get => _title; set => Set(ref _title, value); }

    private AccountingPlan _accountingPlan;
    public AccountingPlan AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }

    public AccountingPlanViewModel(IBaseRepository<AccountingPlan> repository)
    {
        _repository = repository;

        AccountingPlan = new();
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted);

    private async void OnSaveExecuted(object p)
    {
        try
        {
            AccountingPlan!.Status = new Status() { Id = 5 };
            var resalt = await _repository.SaveAsync(AccountingPlan!);
            AccountingPlan = resalt;
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

    public delegate void AccountingHandler(AccountingPlan accounting);
    public event AccountingHandler AccountingEvent;

    #endregion

}
