using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.Bank;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Accounting;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels.Coming;
public class ComingTmcCalculationsViewModel:ViewModel
{
    private ComingTmcCalculations _comingTmcCalculations = null!;

    private bool _isEnabled;
    public bool IsEnabled { get => _isEnabled; set => Set(ref _isEnabled, value); }

    private DebitingAccount _selectedDebitingAccount = null!;
    public DebitingAccount SelecteDebitingAccount { get => _selectedDebitingAccount; set => Set(ref _selectedDebitingAccount, value); }

    private Counterparty? _counterparty;
    public Counterparty? Counterparty { get => _counterparty; set => Set(ref _counterparty, value); }
    public ComingTmcCalculations ComingTmcCalculations
    {
        get => _comingTmcCalculations;
        set
        {
            Set(ref _comingTmcCalculations, value);
            ComingTmcCalculations.PropertyChanged += CalculationsPropertyChanged;
        }
    }

    private void CalculationsPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "ManualCalculation":
                if (ComingTmcCalculations.ManualCalculation)
                {
                    ComingTmcCalculations.DebitingAccounts = new();
                    IsEnabled=true;
                }
                else
                {
                    ComingTmcCalculations.DebitingAccounts = null!;
                    IsEnabled=false;
                }
                break;
        }
    }

    #region Commands

    private ICommand? _showAccountingPlaneCommand;

    public ICommand ShowAccountingPlaneCommand => _showAccountingPlaneCommand
        ??= new RelayCommand(OnShowAccountingPlaneExecuted);

    private void OnShowAccountingPlaneExecuted(object obj)
    {
        var view = new AccountingPlansView();
        var model = view.DataContext as AccountingPlansViewModel;
        model!.SenderModel = this;
        model.SenderField = (string)obj;
        model.Title = "Выберите счет плпна счетов";
        view.ShowDialog();
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

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return ComingTmcCalculations !=null! && ComingTmcCalculations.AccountingPlan !=null!
            && ComingTmcCalculations.AccountingPlanPrepayment !=null! 
            && (ComingTmcCalculations.ManualCalculation | ComingTmcCalculations.AutoCalculation 
                                                              | ComingTmcCalculations.NoCalculation);
    }

    private void OnSaveExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is ComingTmcViewModel coming)
            {
                coming.ComingTmc.ComingTmcCalculations.AccountingPlan = ComingTmcCalculations.AccountingPlan;
                coming.ComingTmc.ComingTmcCalculations.AccountingPlanPrepayment = ComingTmcCalculations.AccountingPlanPrepayment;
                coming.ComingTmc.ComingTmcCalculations.AutoCalculation = ComingTmcCalculations.AutoCalculation;
                coming.ComingTmc.ComingTmcCalculations.ManualCalculation = ComingTmcCalculations.ManualCalculation;
                coming.ComingTmc.ComingTmcCalculations.NoCalculation = ComingTmcCalculations.NoCalculation;
                coming.ComingTmc.ComingTmcCalculations.DebitingAccounts = ComingTmcCalculations.DebitingAccounts;
                coming.ComingTmc.ComingTmcCalculations.Id = ComingTmcCalculations.Id;
            }
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }

    #endregion
}