
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using Agro.DAL.Entities.Accounting;

namespace Agro.WPF.ViewModels.Accounting;

public class AccountingPlansViewModel : ViewModel
{
    private readonly IBaseRepository<AccountingPlan> _repository;
    private string _title = "План счетов";

    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<AccountingPlan> _accounts = new();

    public ObservableCollection<AccountingPlan> Accounts { get => _accounts; set => Set(ref _accounts, value); }

    private AccountingPlan? _selectAccountingPlan;

    public AccountingPlan? SelectAccountingPlan
    {
        get => _selectAccountingPlan;
        set => Set(ref _selectAccountingPlan, value);
    }
    public AccountingPlansViewModel(IBaseRepository<AccountingPlan> repository)
    {
        _repository = repository;
        SelectAccountingPlan = new AccountingPlan();
        LoadData();
    }
    
    public object SenderModel { get; set; }

    public string SenderField { get; set; }

    private async void LoadData()
    {
        Accounts.Clear();
        var accounts = await _repository.GetAllAsync();
        accounts = accounts!.Where(a => a.StatusId == 5);
        foreach (var account in accounts)
        {
            if (account.ParentPlan! == null!)
            {
                Accounts.Add(account);
            }
        }

    }

    #region Commands

    private ICommand? _isExpandedTrueCommand;

    public ICommand IsExpandedTrueCommand => _isExpandedTrueCommand
        ??= new RelayCommand(OnIsExpandedTrueExecuted);

    private void OnIsExpandedTrueExecuted(object p)
    {

    }

    private ICommand? _isExpandedFalseCommand;

    public ICommand IsExpandedFalseCommand => _isExpandedFalseCommand
        ??= new RelayCommand(OnIsExpandedFalseExecuted);

    private void OnIsExpandedFalseExecuted(object p)
    {

    }

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object p)
    {
        var view = new AccountingPlanView();
        var model = view.DataContext as AccountingPlanViewModel;
        model!.AccountingPlan.ParentPlan = SelectAccountingPlan;
        view.Show();
    }

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        if (SelectAccountingPlan.Id != 0) return true;
        return false;
    }

    private void OnEditExecuted(object p)
    {
        var view = new AccountingPlanView();
        var model = view.DataContext as AccountingPlanViewModel;
        model.Title = $"Редактирование счета {SelectAccountingPlan.Code} {SelectAccountingPlan.Name}";
        model!.AccountingPlan = SelectAccountingPlan;
        view.Show();
    }

    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object p)
    {
        LoadData();
    }



    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        if (SelectAccountingPlan.Id != 0) return true;
        return false;
    }

    private async void OnDeleteExecuted(object p)
    {
        var resalt = MessageBox.Show("Вы действительно хотите удалить выбранный счет", "Редактор плана счетов", MessageBoxButton.YesNo);
        if (resalt == MessageBoxResult.Yes)
        {
            var del = await _repository.DeleteAsync(SelectAccountingPlan);

            if (del)
            {
                MessageBox.Show($"Счет {SelectAccountingPlan.Code} помечен как архивный", "Редактор плана счетов");
                LoadData();
            }
        }
    }

    private ICommand? _doubleClickCommand;

    public ICommand DoubleClickCommand => _doubleClickCommand
        ??= new RelayCommand(OnDoubleClickExecuted, CanDoubleClickExecuted);

    private bool CanDoubleClickExecuted(object arg)
    {
        return SelectAccountingPlan!.IsSelect == true;
    }

    private void OnDoubleClickExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is RulesAccountingViewModel model)
            {
                if (SenderField == "AccountingPlan")
                {
                    model.RulesAccounting.AccountingPlan = SelectAccountingPlan!;
                }
                else if (SenderField== "AccountingPlanNds")
                {
                    model.RulesAccounting.AccountingPlanNds = SelectAccountingPlan!;
                }

                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
    }

    #endregion

}