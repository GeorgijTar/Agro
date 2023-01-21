
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Registers;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Accounting;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.TMC;
using Agro.WPF.Views.Windows;
using Agro.WPF.Views.Windows.TMC;

namespace Agro.WPF.ViewModels.Coming;

public class ComingTmcPositionViewModel : ViewModel
{
    private ComingTmcPosition _comingTmcPosition = new();
    public ComingTmcPosition ComingTmcPosition
    {
        get => _comingTmcPosition;
        set
        {
            Set(ref _comingTmcPosition, value);
            ComingTmcPosition.PropertyChanged += ComingTmcPositionChanged;
        }
    }
    private IEnumerable<Nds>? _ndsEnumerable;
    public IEnumerable<Nds>? NdsEnumerable { get => _ndsEnumerable; set => Set(ref _ndsEnumerable, value); }

    private IEnumerable<StorageLocation>? _storageLocations;
    public IEnumerable<StorageLocation>? StorageLocations { get => _storageLocations; set => Set(ref _storageLocations, value); }

    private AccountingPlan _accountingPlan = null!;
    public AccountingPlan AccountingPlan { get => _accountingPlan; set => Set(ref _accountingPlan, value); }

    private AccountingPlan _accountingPlanNds = null!;
    public AccountingPlan AccountingPlanNds { get => _accountingPlanNds; set => Set(ref _accountingPlanNds, value); }

    private IEnumerable<AccountingMethodNds>? _accountingMethodNds = null!;

    public IEnumerable<AccountingMethodNds>? AccountingMethodNds
    {
        get => _accountingMethodNds;
        set => Set(ref _accountingMethodNds, value);
    }
    public bool IsEdit { get; set; }
    public ComingTmcPositionViewModel()
    {
        StorageLocations = (Application.Current.Properties["StorageLocations"] as IEnumerable<StorageLocation>)!.OrderBy(s => s.Name);
        NdsEnumerable = Application.Current.Properties["Nds"] as IEnumerable<Nds>;
        AccountingMethodNds = Application.Current.Properties["AccountingMethodNds"] as IEnumerable<AccountingMethodNds>;
        ComingTmcPosition.PropertyChanged += ComingTmcPositionChanged;
        
    }
    private void ComingTmcPositionChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Quantity":
                Calc();
                break;
            case "Price":
                Calc();
                break;
            case "Amount":
                CalcNds();
                CalcTotal();
                break;
            case "AmountNds":
                CalcTotal();
                break;
            case "TotalAmount":
                CalcReverse();
                break;
            case "Nds":
                CalcNds();
                CalcTotal();
                break;
        }
    }

    private void Calc()
    {
        if (ComingTmcPosition != null!)
        {
            if (ComingTmcPosition.Quantity > 0 & ComingTmcPosition.Price > 0)
            {
                ComingTmcPosition.Amount = ComingTmcPosition.Quantity * ComingTmcPosition.Price;
            }
        }
    }

    private void CalcReverse()
    {
        if (ComingTmcPosition.Nds != null! && ComingTmcPosition.Quantity > 0)
        {
            ComingTmcPosition.Amount = ComingTmcPosition.TotalAmount / ComingTmcPosition.Nds.OverPercent;
            ComingTmcPosition.Price = ComingTmcPosition.Amount / ComingTmcPosition.Quantity;
        }
        
    }

    private void CalcNds()
    {
        if (ComingTmcPosition.Nds != null! && ComingTmcPosition.Amount > 0)
        {
            ComingTmcPosition.AmountNds = ComingTmcPosition.Amount * ComingTmcPosition.Nds.Percent / 100;
        }
    }

    private void CalcTotal()
    {
        ComingTmcPosition.TotalAmount = ComingTmcPosition.Amount + ComingTmcPosition.AmountNds;
    }


    #region Commands

    private ICommand? _showTmCommand;

    public ICommand ShowTmcCommand => _showTmCommand
        ??= new RelayCommand(OnShowTmcExecuted);

    private void OnShowTmcExecuted(object obj)
    {
        var view = new TmCsView();
        var model = view.DataContext as TmCsViewModel;
        model!.SenderModel = this;
        model.Title = "Выберите ТМЦ";
        view.ShowDialog();
    }

    private ICommand? _showAccountingPlansCommand;

    public ICommand ShowAccountingPlansCommand => _showAccountingPlansCommand
        ??= new RelayCommand(OnShowAccountingPlansExecuted);

    private void OnShowAccountingPlansExecuted(object obj)
    {
        var view = new AccountingPlansView();
        var model = view.DataContext as AccountingPlansViewModel;
        model!.SenderModel = this;
        model.SenderField = "AccountingAccount";
        model.Title = "Выберите счет учета";
        view.ShowDialog();
    }


    private ICommand? _showAccountingPlansNdsCommand;

    public ICommand ShowAccountingPlansNdsCommand => _showAccountingPlansNdsCommand
        ??= new RelayCommand(OnShowAccountingPlansNdsExecuted);

    private void OnShowAccountingPlansNdsExecuted(object obj)
    {
        var view = new AccountingPlansView();
        var model = view.DataContext as AccountingPlansViewModel;
        model!.SenderModel = this;
        model.SenderField = "AccountingAccountNds";
        model.Title = "Выберите счет учета авансов";
        view.ShowDialog();
    }

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        CloseWindow(obj);
    }

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return ComingTmcPosition.Nds != null! && ComingTmcPosition.Tmc != null! 
                                              && ComingTmcPosition.StorageLocation!=null! &&
                                              ComingTmcPosition.AccountingAccount!=null! &&
                                              ComingTmcPosition.AccountingAccountNds!=null!
                                                && (ComingTmcPosition.Quantity > 0 & 
                                                    ComingTmcPosition.TotalAmount > 0 &
                                                    ComingTmcPosition.Amount > 0
                                                    & ComingTmcPosition.Price > 0);
    }

    private void OnSaveExecuted(object obj)
    {
      
        if (SenderModel != null!)
        {
            if (SenderModel is ComingTmcViewModel comingTmcModel)
            {
                if (comingTmcModel.ComingTmc.Positions == null!) comingTmcModel.ComingTmc.Positions = new();
                if (!IsEdit)
                {
                    comingTmcModel.ComingTmc.Positions.Add(ComingTmcPosition);
                }
            }
            CloseWindow(obj);
        }
    }

    private void CloseWindow(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }
    #endregion
}