using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Warehouse;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Accounting;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Personnel;
using Agro.WPF.Views.Windows;
using Agro.WPF.Views.Windows.Decommissioning;
using Agro.WPF.Views.Windows.Personnel;
using Agro.WPF.Views.Windows.Warehouse;
using Agro.WPF.Views.Windows.Warehouse.Decommissioning;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Decommissioning;

public class DecommissioningTmcViewModel : ViewModel
{
    private readonly IDecommissioningTmcRepository<DecommissioningTmc> _decommissioningTmcRepository;
    private readonly IHelperNavigation _helperNavigation;
    private readonly INotificationManager _notificationManager;
    private readonly ITmcSprRepository<Tmc> _tmcSprRepository;

    private DecommissioningTmc _decommissioningTmc = new();
    public DecommissioningTmc DecommissioningTmc { get => _decommissioningTmc; set => Set(ref _decommissioningTmc, value); }

    private IEnumerable<TypeDoc> _typeDocs = null!;
    public IEnumerable<TypeDoc> TypeDocs { get => _typeDocs; set => Set(ref _typeDocs, value); }

    private Visibility _visibility = Visibility.Collapsed;
    public Visibility Visibility { get => _visibility; set => Set(ref _visibility, value); }

    private bool _isReadOnly;
    public bool IsReadOnly { get => _isReadOnly; set => Set(ref _isReadOnly, value); }

    private TypeDoc _selectedTypeDoc = null!;
    public TypeDoc SelectedTypeDoc
    {
        get => _selectedTypeDoc;
        set
        {
            Set(ref _selectedTypeDoc, value);
            if (value.Id == 27)
            {
                Visibility = Visibility.Collapsed;
                IsReadOnly = false;
            }
            else
            {
                Visibility = Visibility.Visible;
                IsReadOnly = true;
            }
            DecommissioningTmc.TypeDoc = value;
        }
    }

    private PositionDecommissioningTmc _selectedPosition = null!;
    public PositionDecommissioningTmc SelectedPosition { get => _selectedPosition; set => Set(ref _selectedPosition, value); }

    public DecommissioningTmcViewModel(
        IDecommissioningTmcRepository<DecommissioningTmc> decommissioningTmcRepository,
        IHelperNavigation helperNavigation,
        INotificationManager notificationManager,
        ITmcSprRepository<Tmc> tmcSprRepository)
    {
        _decommissioningTmcRepository = decommissioningTmcRepository;
        _helperNavigation = helperNavigation;
        _notificationManager = notificationManager;
        _tmcSprRepository = tmcSprRepository;
        DecommissioningTmc.Positions = new();
        _decommissioningTmc.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1);
        DecommissioningTmc.Storekeeper = (Application.Current.Properties["CurrentUser"] as User)!.Employee!;
        LoadData();
    }

    private void LoadData()
    {
        TypeDocs = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.Where(s =>
            s.TypeApplication == "ДокументСписанияТМЦ");
    }

    #region Commands

    #region AddPosition
    private ICommand? _addPositionCommand;

    public ICommand AddPositionCommand => _addPositionCommand
        ??= new RelayCommand(OnAddPositionExecuted);

    private void OnAddPositionExecuted(object obj)
    {
        var view = new PositionDecommissioningTmcView();
        var model = view.DataContext as PositionDecommissioningTmcViewModel;
        model!.SenderModel = this;
        model.Position = new();
        view.ShowDialog();
    }
    #endregion

    #region EditPosition

    private ICommand? _editCommand;

    public ICommand EditPositionCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        return SelectedPosition != null!;
    }

    private async void OnEditExecuted(object obj)
    {
        var view = new PositionDecommissioningTmcView();
        var model = view.DataContext as PositionDecommissioningTmcViewModel;
        model!.SenderModel = this;
        model.Position = SelectedPosition;
        model.TmcSprDto = await _tmcSprRepository.GetRemainsTmcByIdLsApAsync(SelectedPosition.Tmc.Id,
            SelectedPosition.StorageLocation.Id, SelectedPosition.AccountingPlan.Id);
        model.IsEdit = true;
        view.ShowDialog();
    }

    #endregion

    #region ShowAccountings

    private ICommand? _showAccountingsCommand;

    public ICommand ShowAccountingsCommand => _showAccountingsCommand
        ??= new RelayCommand(OnShowAccountingsExecuted);

    private void OnShowAccountingsExecuted(object obj)
    {
        var view = new AccountingPlansView();
        var model = view.DataContext as AccountingPlansViewModel;
        model!.SenderModel = this;
        model.Title = "Выберите счет учета затрат";
        view.ShowDialog();
    }

    #endregion

    #region ClearAccounting

    private ICommand? _clearAccountingCommand;

    public ICommand ClearAccountingCommand => _clearAccountingCommand
        ??= new RelayCommand(OnClearAccountingExecuted, ClearAccountingCan);

    private bool ClearAccountingCan(object arg)
    {
        return DecommissioningTmc.AccountingPlan != null!;
    }

    private void OnClearAccountingExecuted(object obj)
    {
        DecommissioningTmc.AccountingPlan = null!;
    }

    #endregion

    #region ShowEmployes

    private ICommand? _showEmployesCommand;

    public ICommand ShowEmployesCommand => _showEmployesCommand
        ??= new RelayCommand(OnShowEmployesExecuted);

    private void OnShowEmployesExecuted(object obj)
    {
        var view = new EmployeesView();
        var model = view.DataContext as EmployeesViewModel;
        model!.SenderModel = this;
        model.SenderModelPole = (obj as string)!;
        view.ShowDialog();
    }

    #endregion

    #region ClearMol

    private ICommand? _clearMolCommand;

    public ICommand ClearMolCommand => _clearMolCommand
        ??= new RelayCommand(OnClearMolExecuted, ClearMolCan);

    private bool ClearMolCan(object arg)
    {
        return DecommissioningTmc.Mol != null!;
    }

    private void OnClearMolExecuted(object obj)
    {
        DecommissioningTmc.Mol = null!;
    }

    #endregion

    #region ClearStorekeeper

    private ICommand? _clearStorekeeperCommand;

    public ICommand ClearStorekeeperCommand => _clearStorekeeperCommand
        ??= new RelayCommand(OnClearStorekeeperExecuted, ClearStorekeeperCan);

    private bool ClearStorekeeperCan(object arg)
    {
        return DecommissioningTmc.Storekeeper != null!;
    }

    private void OnClearStorekeeperExecuted(object obj)
    {
        DecommissioningTmc.Storekeeper = null!;
    }

    #endregion

    #region ShowWriteOffObject

    private ICommand? _showWriteOffObjectCommand;

    public ICommand ShowWriteOffObjectCommand => _showWriteOffObjectCommand
        ??= new RelayCommand(OnShowWriteOffObjectExecuted);

    private void OnShowWriteOffObjectExecuted(object obj)
    {
        var view = new WriteOffObjectsView();
        var model = view.DataContext as WriteOffObjectsViewModel;
        model!.SenderModel = this;
        model.Title = "Выбирите объект списания";
        view.ShowDialog();
    }

    #endregion

    #region ClearWriteOffObject

    private ICommand? _clearWriteOffObjectCommand;

    public ICommand ClearWriteOffObjectCommand => _clearWriteOffObjectCommand
        ??= new RelayCommand(OnClearWriteOffObjectExecuted, ClearWriteOffObjectCan);

    private bool ClearWriteOffObjectCan(object arg)
    {
        return DecommissioningTmc.WriteOffObject != null!;
    }

    private void OnClearWriteOffObjectExecuted(object obj)
    {
        DecommissioningTmc.WriteOffObject = null!;
    }

    #endregion

    #region ShowPurpose

    private ICommand? _showPurposeCommand;

    public ICommand ShowPurposeCommand => _showPurposeCommand
        ??= new RelayCommand(OnShowPurposeExecuted);

    private void OnShowPurposeExecuted(object obj)
    {
        var view = new PurposeExpendituresView();
        var model = view.DataContext as PurposeExpendituresViewModel;
        model!.SenderModel = this;
        model.Title = "Выбирите цель расходования ТМЦ";
        view.ShowDialog();
    }

    #endregion

    #region ClearPurpose

    private ICommand? _clearPurposeCommand;

    public ICommand ClearPurposeCommand => _clearPurposeCommand
        ??= new RelayCommand(OnClearPurposeExecuted, ClearPurposeCan);

    private bool ClearPurposeCan(object arg)
    {
        return DecommissioningTmc.PurposeExpenditure != null!;
    }

    private void OnClearPurposeExecuted(object obj)
    {
        DecommissioningTmc.PurposeExpenditure = null!;
    }

    #endregion

    #region TrashPosition

    private ICommand? _trashPositionCommand;

    public ICommand TrashPositionCommand => _trashPositionCommand
        ??= new RelayCommand(OnTrashPositionExecuted, TrashPositionCan);

    private bool TrashPositionCan(object arg)
    {
        return SelectedPosition != null!;
    }

    private void OnTrashPositionExecuted(object obj)
    {
        DecommissioningTmc.Positions.Remove(SelectedPosition);
    }

    #endregion

    #region Save
    
    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        if (DecommissioningTmc.TypeDoc == null!) return false;
        if (DecommissioningTmc.TypeDoc.Id == 27)
        {
            return DecommissioningTmc.Positions.Count > 0 && DecommissioningTmc.WriteOffObject != null!
                                                          && DecommissioningTmc.AccountingPlan != null!
                                                          && DecommissioningTmc.PurposeExpenditure != null!
                                                          && DecommissioningTmc.Mol != null!
                                                          && DecommissioningTmc.Storekeeper != null!;
        }
        if (DecommissioningTmc.TypeDoc.Id == 28)
        {
            return DecommissioningTmc.Positions.Count > 0 && DecommissioningTmc.WriteOffObject != null!
                                                          && DecommissioningTmc.AccountingPlan != null!
                                                          && DecommissioningTmc.PurposeExpenditure != null!
                                                          && DecommissioningTmc.Mol != null!
                                                          && DecommissioningTmc.Storekeeper != null!
                                                          && DecommissioningTmc.DecommissioningStorno != null!;
        }

        return true;
    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {
            DecommissioningTmc.Number = await _decommissioningTmcRepository.GetRegNumberAsync(DecommissioningTmc.Date);
            if (DecommissioningTmc.History == null!)
            {
                DecommissioningTmc.History = new ObservableCollection<History>();
            }

            string eventHistory;

            eventHistory = DecommissioningTmc.Id == 0 ? "Создание документа" : "Редактирование документа";

            DecommissioningTmc.History.Add(new History()
                {
                    EventDate = DateTime.Now,
                    EventHistory = eventHistory,
                    User = (Application.Current.Properties["CurrentUser"] as User)!,
                });
            var dec = await _decommissioningTmcRepository.SaveAsync(DecommissioningTmc);
            if (SenderModel != null!)
            {
                if (SenderModel is DecommissioningTmcsViewModel model)
                {
                    var decm = model.DecommissioningTmcCollection.FirstOrDefault(d => d.Id == dec.Id);
                    if (decm != null)
                    {
                        var index = model.DecommissioningTmcCollection.IndexOf(decm);
                        model.DecommissioningTmcCollection[index] = await _decommissioningTmcRepository.GetDecommissioningTmcDtoAsync(dec);
                    }
                    else
                    {
                        model.DecommissioningTmcCollection.Add(await _decommissioningTmcRepository.GetDecommissioningTmcDtoAsync(dec));
                    }
                }
            }
            _notificationManager.Show("Редактор документов",
                "Документ успешно добавлен в БД", NotificationType.Information);

            _helperNavigation.ClosePage(TabItem);
        }
        catch (Exception e)
        {
            
           var message = e.InnerException != null! ? e.InnerException.Message : e.Message;

            _notificationManager.Show("Редактор документов", 
                $"При сохранении документа произошла ошибка: {message}", 
                NotificationType.Error);
        }
    }

    #endregion

    #region Close

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        _helperNavigation.ClosePage(TabItem);
    }

    #endregion

    #endregion
}
