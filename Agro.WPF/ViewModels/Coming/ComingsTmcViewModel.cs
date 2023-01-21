
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Registers;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Pages.Coming;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Coming;

public class ComingsTmcViewModel : ViewModel
{
    private readonly IComingTmcRepository<ComingTmc> _comingTmcRepository;
    private readonly IHelperNavigation _helperNavigation;
    private readonly INotificationManager _notificationManager;

    /// <summary>
    /// Коллекция документов поступления
    /// </summary>
    private ObservableCollection<ComingTmc> _comingsTmc = new();
    public ObservableCollection<ComingTmc> ComingsTmc { get => _comingsTmc; set => Set(ref _comingsTmc, value); }

    /// <summary>
    /// Выбраный документ поступления
    /// </summary>
    private ComingTmc _selectedComingTmc = null!;
    public ComingTmc SelectedComingTmc { get => _selectedComingTmc; set => Set(ref _selectedComingTmc, value); }

    public ComingsTmcViewModel(IComingTmcRepository<ComingTmc> comingTmcRepository,
        IHelperNavigation helperNavigation,
        INotificationManager notificationManager)
    {
        _comingTmcRepository = comingTmcRepository;
        _helperNavigation = helperNavigation;
        _notificationManager = notificationManager;
        LoadData();
    }

    private async void LoadData()
    {
        try
        {
            ComingsTmc.Clear();
            StatusList.Clear();
            StatusList.Add(new Status() { Id = 0, Name = "Все" });
            var com = await _comingTmcRepository.GetAllNoTrackingAsync();
            foreach (var comingTmc in com!)
            {
                if (comingTmc.Status!.Id != 6)
                {
                    ComingsTmc.Add(comingTmc);
                }

                if (StatusList.FirstOrDefault(s => s.Id == comingTmc.Status.Id)! == null!)
                {
                    StatusList.Add(comingTmc.Status);
                }
            }

            CollectionView = CollectionViewSource.GetDefaultView(ComingsTmc);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"При загрузке данны возникла ошибка: {e.Message}", NotificationType.Error);

        }

    }

    #region Filter

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    private DateTime? _dateDocOn;

    public DateTime? DateDocOn
    {
        get => _dateDocOn;
        set
        {
            Set(ref _dateDocOn, value);
            CollectionView.Filter = FilterByDateDoc;
        }
    }

    private bool FilterByDateDoc(object obj)
    {
        if (DateDocOn <= DateDocOff)
        {
            var dto = obj as ComingTmc;
            return dto!.DateDoc.Date >= DateDocOn!.Value.Date & dto.DateDoc.Date <= DateDocOff!.Value.Date;
        }

        return true;
    }

    private DateTime? _dateDocOff;

    public DateTime? DateDocOff
    {
        get => _dateDocOff;
        set
        {
            Set(ref _dateDocOff, value);
            CollectionView.Filter = FilterByDateDoc;
        }
    }

    private DateTime? _dateRegOn;

    public DateTime? DateRefOn
    {
        get => _dateRegOn;
        set
        {
            Set(ref _dateRegOn, value);
            CollectionView.Filter = FilterByDateReg;
        }
    }

    private bool FilterByDateReg(object obj)
    {
        if (DateRefOn <= DateRegOff)
        {
            var dto = obj as ComingTmc;
            return dto!.RegDate.Date >= DateRefOn!.Value.Date & dto.RegDate.Date <= DateRegOff!.Value.Date;
        }

        return true;
    }
    private DateTime? _dateRegOff;

    public DateTime? DateRegOff
    {
        get => _dateRegOff;
        set
        {
            Set(ref _dateRegOff, value);
            CollectionView.Filter = FilterByDateReg;
        }
    }

    private string _numberDoc = null!;

    public string NumberDoc
    {
        get => _numberDoc;
        set
        {
            Set(ref _numberDoc, value);
            CollectionView.Filter = FilterByNumber;
        }
    }

    private bool FilterByNumber(object obj)
    {
        if (!string.IsNullOrEmpty(NumberDoc))
        {
            var dto = obj as ComingTmc;
            return dto!.NumberDoc.ToUpper().Contains(NumberDoc.ToUpper());
        }
        return true;
    }

    private string _inn = null!;

    public string Inn
    {
        get => _inn;
        set
        {
            Set(ref _inn, value);
            CollectionView.Filter = FilterByInn;
        }
    }

    private bool FilterByInn(object obj)
    {
        if (!string.IsNullOrEmpty(Inn))
        {
            var dto = obj as ComingTmc;
            return dto!.Counterparty.Inn.ToUpper().Contains(Inn.ToUpper());
        }
        return true;
    }


    private string _counterpartyName = null!;

    public string CounterpartyName
    {
        get => _counterpartyName;
        set
        {
            Set(ref _counterpartyName, value);
            CollectionView.Filter = FilterByName;
        }
    }

    private bool FilterByName(object obj)
    {
        if (!string.IsNullOrEmpty(CounterpartyName))
        {
            var dto = obj as ComingTmc;
            return dto!.Counterparty.Name.ToUpper().Contains(CounterpartyName.ToUpper()) |
                   dto.Counterparty.PayName.ToUpper().Contains(CounterpartyName.ToUpper());
        }
        return true;
    }

    private ObservableCollection<Status> _statusList = new();
    public ObservableCollection<Status> StatusList { get => _statusList; set => Set(ref _statusList, value); }

    private Status _status = null!;

    public Status Status
    {
        get => _status;
        set { Set(ref _status, value); }
    }

    #endregion

    #region Commands

    #region Add

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        try
        {
            var page = new ComingTmcPage();
            var model = page.DataContext as ComingTmcViewModel;
            model!.TabItem = _helperNavigation.OpenPage(page, "Новый документ поступления");
            model.SenderModel = this;
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"При открытии страницы возникла ошибка: {e.Message}", NotificationType.Error);
        }

    }

    #endregion

    #region Edit

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        return SelectedComingTmc != null! && SelectedComingTmc.Status!.Id == 1;
    }

    private async void OnEditExecuted(object obj)
    {
        try
        {
            var page = new ComingTmcPage();
            var model = page.DataContext as ComingTmcViewModel;
            model!.TabItem = _helperNavigation.OpenPage(page, $"Редактирование документа поступления № " +
                                                              $"{SelectedComingTmc.RegNumber} от " +
                                                              $"{SelectedComingTmc.RegDate.ToShortDateString()}");
            model.ComingTmc = (await _comingTmcRepository.GetByIdAsync(SelectedComingTmc.Id))!;
            model.SenderModel = this;
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"При открытии страницы возникла ошибка: {e.Message}", NotificationType.Error);
        }
    }

    #endregion

    #region DocumentExecution
    /// <summary>
    /// Проведение документа
    /// </summary>

    private ICommand? _documentExecutionCommand;

    public ICommand DocumentExecutionCommand => _documentExecutionCommand
        ??= new RelayCommand(OnDocumentExecutionExecuted, DocumentExecutionCan);

    private bool DocumentExecutionCan(object arg)
    {
        return SelectedComingTmc != null! && SelectedComingTmc.Status!.Id == 1;
    }

    private async void OnDocumentExecutionExecuted(object obj)
    {
        try
        {
            var coming = await _comingTmcRepository.GetByIdAsync(SelectedComingTmc.Id);
            var registrsTmc = new ObservableCollection<TmcRegister>();
            var registrAccounting = new ObservableCollection<AccountingPlanRegister>();
            foreach (var position in coming!.Positions)
            {
                var regTmc = new TmcRegister()
                {
                    TypeDoc = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(s => s.Id == 25)!,
                    Tmc = position.Tmc,
                    Quantity = position.Quantity,
                    UnitOkei = position.UnitOkei,
                    Amount = position.AccountingMethodNds!.Id == 2 ? position.TotalAmount : position.Amount,
                    Price = position.Price,
                    AmountNds = position.AmountNds,
                    Credit = position.ComingTmc.ComingTmcCalculations.AccountingPlan,
                    Debit = position.AccountingAccount,
                    StorageLocation = position.StorageLocation,
                    DateRegister = position.ComingTmc.RegDate,
                    Description = $"Поступление по док.№ {position.ComingTmc.RegNumber} " +
                                  $"от {position.ComingTmc.RegDate.ToShortDateString()}, " +
                                  $"поставщик {position.ComingTmc.Counterparty.Name} " +
                                  $"ИНН {position.ComingTmc.Counterparty.Inn}"
                };
                registrsTmc.Add(regTmc);

                registrAccounting.Add(new AccountingPlanRegister()
                {
                    DateReg = position.ComingTmc.RegDate,
                    Debit = position.AccountingAccount,
                    Credit = position.ComingTmc.ComingTmcCalculations.AccountingPlan,
                    Amount = position.Amount,
                    ContaAction = $"Поступление ТМЦ вх. док.№ {position.ComingTmc.RegNumber} " +
                                  $"от {position.ComingTmc.RegDate.ToShortDateString()}, ",
                    ContaObject = position.Tmc.Name,
                    ContaParty = position.ComingTmc.Counterparty.Name,
                    ContaDoc = $"Накладная (УПД) № {position.ComingTmc.NumberDoc} от {position.ComingTmc.DateDoc.ToShortDateString()}"
                   

                });
                if (position.AmountNds > 0)
                {
                    registrAccounting.Add(new AccountingPlanRegister()
                    {
                        DateReg = position.ComingTmc.RegDate,
                        Debit = position.AccountingAccountNds!,
                        Credit = position.ComingTmc.ComingTmcCalculations.AccountingPlan,
                        Amount = position.AmountNds,
                        ContaAction = $"Поступление НДС по док.№ {position.ComingTmc.RegNumber} " +
                                      $"от {position.ComingTmc.RegDate.ToShortDateString()}, ",
                        ContaObject = position.Tmc.Name,
                        ContaParty = position.ComingTmc.Counterparty.Name,
                        ContaDoc = $"Накладная (УПД) № {position.ComingTmc.NumberDoc} от {position.ComingTmc.DateDoc.ToShortDateString()}"
                    });
                    if (position.AccountingMethodNds.Id == 2)
                    {
                        registrAccounting.Add(new AccountingPlanRegister()
                        {
                            DateReg = position.ComingTmc.RegDate,
                            Debit = position.AccountingAccount,
                            Credit = position.AccountingAccountNds!,
                            Amount = position.AmountNds,
                            ContaAction = "НДС в ключен в стоимость ТМЦ",
                            ContaObject = position.Tmc.Name,
                            ContaParty = position.ComingTmc.Counterparty.Name,
                            ContaDoc = $"Накладная (УПД) № {position.ComingTmc.NumberDoc} от {position.ComingTmc.DateDoc.ToShortDateString()}"
                        });
                    }
                }
            }

            coming.TmcRegisters = registrsTmc;
            coming.AccountingPlanRegisters = registrAccounting;
            coming.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 23);
            if (coming.History == null!) coming.History = new();
            coming.History!.Add(new History()
            {
                EventDate = DateTime.Now,
                User = (Application.Current.Properties["CurrentUser"] as User)!,
                EventHistory = "Регистрация документа"
            });
            var newComing = await _comingTmcRepository.SaveAsync(coming);
            SelectedComingTmc.Status = newComing.Status;
            _notificationManager.Show("Логер",
                $"Статус документа успешно изменен на {SelectedComingTmc.Status!.Name}",
                NotificationType.Information);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер",
                $"При изменении статуса произошла ошибка {e.Message}",
                NotificationType.Error);
        }


    }

    #endregion

    #region CancellationRegistration Отмена регистрации

    private ICommand? _cancellationRegistrationCommand;

    public ICommand CancellationRegistrationCommand => _cancellationRegistrationCommand
        ??= new RelayCommand(OnCancellationRegistrationExecuted, CancellationRegistrationCan);

    private bool CancellationRegistrationCan(object arg)
    {
        return SelectedComingTmc!=null! && SelectedComingTmc.Status!.Id==23;
    }

    private async void OnCancellationRegistrationExecuted(object obj)
    {
        try
        {
            var coming = await _comingTmcRepository.GetByIdAsync(SelectedComingTmc.Id);
            //foreach (var tmcRegister in coming!.TmcRegisters!)
            //{
            //   await _comingTmcRepository.DeleteTmcRegister(tmcRegister.Id);
            //    coming!.TmcRegisters!.Remove(tmcRegister);
            //}

            //foreach (var planRegister in coming!.AccountingPlanRegisters!)
            //{
            //   await _comingTmcRepository.DeleteAccountingRegister(planRegister.Id);
            //    coming!.AccountingPlanRegisters!.Remove(planRegister);
            //}
            if (coming!.TmcRegisters != null)
            {
                coming.TmcRegisters.Clear();
            }

            if (coming.AccountingPlanRegisters != null)
            {
                coming.AccountingPlanRegisters.Clear();
            }
            
            coming.Status=(Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1);
            var newComing = await _comingTmcRepository.SaveAsync(coming);
            SelectedComingTmc.Status = newComing.Status;
            _notificationManager.Show("Логер",
                $"Статус документа успешно изменен на {SelectedComingTmc.Status!.Name}", 
                NotificationType.Information);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер",
                $"При отмене регистрации документа произошла ошибка: {e.Message}", 
                NotificationType.Error);
        }
    }

    #endregion

    #region Refresh

    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object obj)
    {
        LoadData();
    }
    #endregion

    #region Copy

    private ICommand? _copyCommand;

    public ICommand CopyCommand => _copyCommand
        ??= new RelayCommand(OnCopyExecuted, CopyCan);

    private bool CopyCan(object arg)
    {
        return SelectedComingTmc != null!;
    }

    private async void OnCopyExecuted(object obj)
    {
        try
        {
            var coming = new ComingTmc();
            var copyComing = await _comingTmcRepository.GetByIdAsync(SelectedComingTmc.Id);
            coming.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1);
            coming.DateDoc = copyComing!.DateDoc;
            coming.NumberDoc = copyComing.NumberDoc;
            coming.Counterparty = copyComing.Counterparty;
            coming.ComingTmcCalculations = copyComing.ComingTmcCalculations;
            coming.Positions = copyComing.Positions;
            coming.Amount=copyComing.Amount;
            coming.AmountNds=copyComing.AmountNds;
            coming.TotalAmount=copyComing.TotalAmount;
            var page = new ComingTmcPage();
            var model = page.DataContext as ComingTmcViewModel;
            model!.SenderModel = this;
            model.ComingTmc = coming;
            model.TabItem = _helperNavigation.OpenPage(page, "Новый документ поступления (копия)");
            _notificationManager.Show("Логер",
                "Успешно создана копия документа поступления",
                NotificationType.Information);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер",
                $"При копировании документа получена ошибка: {e.Message}",
                NotificationType.Error);
        }
    }

    #endregion

    #region Delete

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        return SelectedComingTmc != null! && SelectedComingTmc.Status!.Id == 1;
    }

    private async void OnDeleteExecuted(object obj)
    {
        var result = MessageBox.Show(
            $"Вы действительно хотите удалить докумет {SelectedComingTmc.NumberDoc} от {SelectedComingTmc.DateDoc}?",
            "Редактор документов",
            MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            try
            {
                var coming = await _comingTmcRepository.GetByIdAsync(SelectedComingTmc.Id);
                coming!.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 6);
                if (coming.History == null!) coming.History = new();
                coming.History!.Add(new History()
                {
                    EventDate = DateTime.Now,
                    User = (Application.Current.Properties["CurrentUser"] as User)!,
                    EventHistory = "Удаление документа"
                });
                var deleteComing = await _comingTmcRepository.SaveAsync(coming);
                SelectedComingTmc.Status= deleteComing.Status;
                _notificationManager.Show("Логер",
                    $"Статус документа успешно изменен на {SelectedComingTmc.Status!.Name}", 
                    NotificationType.Information);
            }
            catch (Exception e)
            {
                _notificationManager.Show("Логер",
                    $"При удалении документа произошла ошибка: {e.Message}", 
                    NotificationType.Error);
            }

        }
    }

    #endregion

    #region DoubleClickRow

    private ICommand? _doubleClickRowCommand;

    public ICommand DoubleClickRowCommand => _doubleClickRowCommand
        ??= new RelayCommand(OnDoubleClickRowExecuted, DoubleClickRowCan);

    private bool DoubleClickRowCan(object arg)
    {
        return SelectedComingTmc != null!;
    }

    private async void OnDoubleClickRowExecuted(object obj)
    {
        try
        {
            var page = new ComingTmcPage();
            var model = page.DataContext as ComingTmcViewModel;
            model!.ComingTmc = (await _comingTmcRepository.GetByIdAsync(SelectedComingTmc.Id))!;
            model.SenderModel = this;
            model.IsLock=true;
            model.TabItem = _helperNavigation.OpenPage(page, $"Документ поступления № " +
                                                              $"{SelectedComingTmc.RegNumber} от " +
                                                              $"{SelectedComingTmc.RegDate.ToShortDateString()}");
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"При открытии страницы возникла ошибка: {e.Message}", NotificationType.Error);
        }
    }

    #endregion

    #endregion
}
