using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.TMC;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels.Accounting;

public class RulesAccountingViewModel : ViewModel
{
    private readonly IBaseRepository<AccountingPlan> _accountingRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;

    public string Title { get => _title; set => Set(ref _title, value); }


    private RulesAccounting _rulesAccounting = new();
    public RulesAccounting RulesAccounting { get => _rulesAccounting; set => Set(ref _rulesAccounting, value); }

    public object SenderModel { get; set; } = null!;

    private IEnumerable<AccountingPlan>? _accountingPlans;

    public IEnumerable<AccountingPlan>? AccountingPlans
    { get => _accountingPlans; set => Set(ref _accountingPlans, value); }

    public RulesAccountingViewModel(
        IBaseRepository<AccountingPlan> accountingRepository,
        IBaseRepository<Status> statusRepository)
    {
        _accountingRepository = accountingRepository;
        _statusRepository = statusRepository;
        LoadData();
    }

    private async void LoadData()
    {
        var acc = await _accountingRepository.GetAllAsync();
        acc = acc!.Where(a => a.IsSelect).Where(a => a.StatusId == 5).ToArray();
        AccountingPlans = acc;
    }

    #region Commands

    private ICommand? _showCommand;

    public ICommand ShowCommand => _showCommand
        ??= new RelayCommand(OnShowExecuted);

    private void OnShowExecuted(object obj)
    {
        var view = new AccountingPlansView();
        var mod = view.DataContext as AccountingPlansViewModel;
        mod!.SenderModel = this;
        mod.SenderField = "AccountingPlan";
        view.ShowDialog();
    }

    private ICommand? _showCommandNds;

    public ICommand ShowCommandNds => _showCommandNds
        ??= new RelayCommand(OnShowNdsExecuted);

    private void OnShowNdsExecuted(object obj)
    {
        var view = new AccountingPlansView();
        var mod = view.DataContext as AccountingPlansViewModel;
        mod!.SenderModel = this;
        mod.SenderField = "AccountingPlanNds";
        view.ShowDialog();
    }

    private ICommand? _clearAccCommand;

    public ICommand ClearAccCommand => _clearAccCommand
        ??= new RelayCommand(OnClearAccExecuted, CanClearAccExecuted);

    private bool CanClearAccExecuted(object arg)
    {
        return RulesAccounting.AccountingPlan != null!;
    }

    private void OnClearAccExecuted(object obj)
    {
        RulesAccounting.AccountingPlan= null!;
    }

    private ICommand? _clearAccNdsCommand;

    public ICommand ClearAccNdsCommand => _clearAccNdsCommand
        ??= new RelayCommand(OnClearAccNdsExecuted, CanClearAccNdsExecuted);

    private bool CanClearAccNdsExecuted(object arg)
    {
        return RulesAccounting.AccountingPlanNds != null!;
    }

    private void OnClearAccNdsExecuted(object obj)
    {
        RulesAccounting.AccountingPlanNds = null!;
    }

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
       return RulesAccounting.AccountingPlanNds!= null! && RulesAccounting.AccountingPlan!= null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        RulesAccounting.Status = await _statusRepository.GetByIdAsync(5);
        if (SenderModel != null!)
        {
            if (SenderModel is TmcViewModel senderModel)
            {
                if (senderModel.Tmc.RulesAccountings is null) senderModel.Tmc.RulesAccountings = new();
                var rul=senderModel.Tmc.RulesAccountings.FirstOrDefault(r=>Equals(RulesAccounting, r));
                if (rul is null)
                {
                    senderModel.Tmc.RulesAccountings.Add(RulesAccounting);
                }
                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
    }

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    #endregion
}