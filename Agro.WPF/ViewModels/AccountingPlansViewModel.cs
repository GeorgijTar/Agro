
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using Agro.Domain.Base;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using Agro.DAL.Entities;

namespace Agro.WPF.ViewModels;

public class AccountingPlansViewModel : ViewModel
{
    private readonly IBaseRepository<AccountingPlanDto> _repository;
    private string _title = "План счетов";
    
    public string Title { get=>_title; set=>Set(ref _title, value); } 

    private ObservableCollection<AccountingPlanDto> _accounts= new ();

    public ObservableCollection<AccountingPlanDto> Accounts { get=>_accounts; set=>Set(ref _accounts, value); }

    private AccountingPlanDto _selectAccountingPlan;

    public AccountingPlanDto SelectAccountingPlan { get=>_selectAccountingPlan; 
        set=>Set( ref _selectAccountingPlan, value); }
    public AccountingPlansViewModel(IBaseRepository<AccountingPlanDto> repository)
    {
        _repository = repository;
        SelectAccountingPlan=new AccountingPlanDto();
        LoadData();
    }

    private async void LoadData()
    {
        Accounts.Clear();
        var accounts = await _repository.GetAllByStatusAsync(5);
        foreach (var account in accounts!)
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

    private  void OnIsExpandedTrueExecuted(object p)
    {
       
    }

    private ICommand? _isExpandedFalseCommand;

    public ICommand IsExpandedFalseCommand => _isExpandedFalseCommand
        ??= new RelayCommand(OnIsExpandedFalseExecuted);

    private  void OnIsExpandedFalseExecuted(object p)
    {

    }

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object p)
    {
        var view = new AccountingPlanView();
        var model = view.DataContext as AccountingPlanViewModel;
        model!.AccountingPlanDto.ParentPlan = SelectAccountingPlan;
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
        model!.AccountingPlanDto = SelectAccountingPlan;
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
           var del= await _repository.DeleteAsync(SelectAccountingPlan);

           if (del)
           {
               MessageBox.Show($"Счет {SelectAccountingPlan.Code} помечен как архивный", "Редактор плана счетов");
               LoadData();
           }
        }
    }


    #endregion

}