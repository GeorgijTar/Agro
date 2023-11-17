using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Registers;
using Agro.DAL.Entities.Warehouse;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.Dto;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Pages.Decommissioning;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Decommissioning;
public class DecommissioningTmcsViewModel : ViewModel
{
    #region Property
    
    private readonly IDecommissioningTmcRepository<DecommissioningTmc> _decommissioningTmcRepository;
    private readonly IHelperNavigation _helperNavigation;
    private readonly INotificationManager _notificationManager;
    private readonly ITmcSprRepository<Tmc> _tmcSprRepository;
    private ObservableCollection<DecommissioningTmcDto> _decommissioningTmcCollection = new();
    public ObservableCollection<DecommissioningTmcDto> DecommissioningTmcCollection { get => _decommissioningTmcCollection; set => Set(ref _decommissioningTmcCollection, value); }

    private DecommissioningTmcDto _selectionDecommissioningTmc = null!;
    public DecommissioningTmcDto SelectionDecommissioningTmc { get => _selectionDecommissioningTmc; set => Set(ref _selectionDecommissioningTmc, value); }

    private PositionDecommissioningTmcDto _selectedPositionDecommissioningTmcDto = null!;
    public PositionDecommissioningTmcDto SelectedPositionDecommissioningTmcDto { get => _selectedPositionDecommissioningTmcDto; set => Set(ref _selectedPositionDecommissioningTmcDto, value); }

    #endregion

    public DecommissioningTmcsViewModel(
        IDecommissioningTmcRepository<DecommissioningTmc> decommissioningTmcRepository,
        IHelperNavigation helperNavigation,
        INotificationManager notificationManager,
        ITmcSprRepository<Tmc> tmcSprRepository)
    {
        _decommissioningTmcRepository = decommissioningTmcRepository;
        _helperNavigation = helperNavigation;
        _notificationManager = notificationManager;
        _tmcSprRepository = tmcSprRepository;
        Title = "Реестр документов списания ТМЦ";
        LoadData();
        PropertyChanged += ModelChanged;
    }

    private async void LoadData()
    {
        try
        {
            Statuses = new ObservableCollection<string>();
            Statuses.Add("Любой");
            Status = "Любой";
            Types = new ObservableCollection<string>();
            Types.Add("Любой");
            Type = "Любой";
            PurposeExpenditures = new ObservableCollection<string>();
            PurposeExpenditures.Add("Все");
            PurposeExpenditure = "Все";

            var coll = await _decommissioningTmcRepository.GetAllDecommissioningTmcDtoAsync();
            foreach (var tmcDto in coll)
            {
                DecommissioningTmcCollection.Add(tmcDto);
                if (Statuses.FirstOrDefault(s => s == tmcDto.Status) == null!)
                {
                    Statuses.Add(tmcDto.Status);
                }

                if (Types.FirstOrDefault(t => t == tmcDto.TypeDoc) == null!)
                {
                    Types.Add(tmcDto.TypeDoc);
                }

                if (PurposeExpenditures.FirstOrDefault(p => p == tmcDto.PurposeExpenditure) == null)
                {
                    PurposeExpenditures.Add(tmcDto.PurposeExpenditure);
                }
            }
            CollectionView = CollectionViewSource.GetDefaultView(DecommissioningTmcCollection);
        }
        catch (Exception e)
        {
            var message = e.InnerException != null! ? e.InnerException.Message : e.Message;
            _notificationManager.Show("Регистратор",
                $"При загрузке данных произошла ошибка: {message}",
                NotificationType.Error);
        }
    }

    private void ModelChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "DateOn":
                if (CollectionView != null!) CollectionView.Filter += FilterByDate;
                break;
            case "DateOff":
                if (CollectionView != null!) CollectionView.Filter += FilterByDate;
                break;
            case "InitAmount":
                if (CollectionView != null!) CollectionView.Filter += FilterByAmount;
                break;
            case "FinalAmount":
                if (CollectionView != null!) CollectionView.Filter += FilterByAmount;
                break;
            case "NameFilter":
                if (CollectionView != null!) CollectionView.Filter += FilterByName;
                break;
            case "InvNumber":
                if (CollectionView != null!) CollectionView.Filter += FilterByInvNumber;
                break;
            case "RegNumber":
                if (CollectionView != null!) CollectionView.Filter += FilterByRegNumber;
                break;
            case "NumberDoc":
                if (CollectionView != null!) CollectionView.Filter += FilterByNumberDoc;
                break;
            case "Status":
                if (CollectionView != null!) CollectionView.Filter += FilterByStatus;
                break;
            case "Type":
                if (CollectionView != null!) CollectionView.Filter += FilterByType;
                break;
            case "PurposeExpenditure":
                if (CollectionView != null!) CollectionView.Filter += FilterByPurposeExpenditure;
                break;
        }
    }


    #region Filter

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    private DateTime? _dateOn;
    public DateTime? DateOn { get => _dateOn; set => Set(ref _dateOn, value); }


    private DateTime? _dateOff;
    public DateTime? DateOff { get => _dateOff; set => Set(ref _dateOff, value); }


    private decimal? _initAmount;
    public decimal? InitAmount { get => _initAmount; set => Set(ref _initAmount, value); }


    private decimal? _finalAmount;
    public decimal? FinalAmount { get => _finalAmount; set => Set(ref _finalAmount, value); }


    private string? _nameFilter;
    public string? NameFilter { get => _nameFilter; set => Set(ref _nameFilter, value); }


    private string? _invNumber;
    public string? InvNumber { get => _invNumber; set => Set(ref _invNumber, value); }


    private string? _regNumber;
    public string? RegNumber { get => _regNumber; set => Set(ref _regNumber, value); }


    private string? _numberDoc;
    public string? NumberDoc { get => _numberDoc; set => Set(ref _numberDoc, value); }


    private ObservableCollection<string>? _statuses;
    public ObservableCollection<string>? Statuses { get => _statuses; set => Set(ref _statuses, value); }


    private string? _status;
    public string? Status { get => _status; set => Set(ref _status, value); }


    private ObservableCollection<string>? _types;
    public ObservableCollection<string>? Types { get => _types; set => Set(ref _types, value); }


    private string? _type;
    public string? Type { get => _type; set => Set(ref _type, value); }


    private ObservableCollection<string>? _purposeExpenditures;
    public ObservableCollection<string>? PurposeExpenditures { get => _purposeExpenditures; set => Set(ref _purposeExpenditures, value); }


    private string? _purposeExpenditure;
    public string? PurposeExpenditure { get => _purposeExpenditure; set => Set(ref _purposeExpenditure, value); }


    private bool FilterByDate(object obj)
    {
        if (DateOn != null && DateOff != null)
        {
            if (DateOn <= DateOff)
            {
                var dto = obj as DecommissioningTmcDto;
                return dto!.Date.Date >= DateOn!.Value.Date &
                       dto.Date.Date <= DateOff!.Value.Date;
            }
        }
        return true;
    }

    private bool FilterByAmount(object obj)
    {
        if (InitAmount != 0 || FinalAmount != 0)
        {
            if (InitAmount <= FinalAmount)
            {
                var dto = obj as DecommissioningTmcDto;
                return dto!.Amount >= InitAmount &
                       dto.Amount <= FinalAmount;
            }
        }
        return true;
    }

    private bool FilterByName(object obj)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            var dto = obj as DecommissioningTmcDto;
            return dto!.WriteOffObject.ToUpper().Contains(NameFilter!.ToUpper());
        }
        return true;
    }

    private bool FilterByInvNumber(object obj)
    {
        if (!string.IsNullOrEmpty(InvNumber))
        {
            var dto = obj as DecommissioningTmcDto;
            return dto!.WriteOffObjectInvNumber.ToUpper().Contains(InvNumber!.ToUpper());
        }
        return true;
    }

    private bool FilterByRegNumber(object obj)
    {
        if (!string.IsNullOrEmpty(RegNumber))
        {
            var dto = obj as DecommissioningTmcDto;
            return dto!.WriteOffObjectRegNumber.ToUpper().Contains(RegNumber!.ToUpper());
        }
        return true;
    }

    private bool FilterByNumberDoc(object obj)
    {
        if (!string.IsNullOrEmpty(NumberDoc))
        {
            var dto = obj as DecommissioningTmcDto;
            return dto!.Number.ToUpper().Contains(NumberDoc!.ToUpper());
        }
        return true;
    }

    private bool FilterByStatus(object obj)
    {
        if (!string.IsNullOrEmpty(Status))
        {
            if (Status == "Любой") return true;
            var dto = obj as DecommissioningTmcDto;
            return dto!.Status.ToUpper().Contains(Status!.ToUpper());
        }
        return true;
    }

    private bool FilterByType(object obj)
    {
        if (!string.IsNullOrEmpty(Type))
        {
            if (Type == "Любой") return true;
            var dto = obj as DecommissioningTmcDto;
            return dto!.TypeDoc.ToUpper().Contains(Type!.ToUpper());
        }
        return true;
    }

    private bool FilterByPurposeExpenditure(object obj)
    {
        if (!string.IsNullOrEmpty(PurposeExpenditure))
        {
            if (PurposeExpenditure == "Все")
                return true;
            var dto = obj as DecommissioningTmcDto;
            return dto!.PurposeExpenditure.ToUpper().Contains(PurposeExpenditure!.ToUpper());
        }
        return true;
    }
    #endregion

    #region Commands

    #region Add

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var page = new DecommissioningTmcPage();
        var model = page.DataContext as DecommissioningTmcViewModel;
        model!.SenderModel = this;
        model.TabItem = _helperNavigation.OpenPage(page, "Создание документа: Требованиe-накладная");
    }

    #endregion

    #region Edit

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        return SelectionDecommissioningTmc != null! && SelectionDecommissioningTmc.StatusId == 1;
    }

    private async void OnEditExecuted(object obj)
    {
        var page = new DecommissioningTmcPage();
        var model = page.DataContext as DecommissioningTmcViewModel;
        model!.SenderModel = this;
        model.DecommissioningTmc = (await _decommissioningTmcRepository.GetByIdAsync(SelectionDecommissioningTmc.Id))!;
        model.TabItem = _helperNavigation.OpenPage(page, "Создание документа: Требованиe-накладная");
    }

    #endregion

    #region Delete

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        return SelectionDecommissioningTmc != null! && SelectionDecommissioningTmc.StatusId == 1;
    }

    private void OnDeleteExecuted(object obj)
    {
        _notificationManager.ShowButtonWindow(
            $"Вы действительно хотите удалить требование накладная: {SelectionDecommissioningTmc.Number} " +
            $"от {SelectionDecommissioningTmc.Date.ToLongDateString()}?",
            "Редактор документов",
            LeftButtonAction, "Да",
            RightButtonAction, "Отмена", TimeSpan.MaxValue, "", null, null, false);
    }

    private void RightButtonAction()
    {
    }

    private async void LeftButtonAction()
    {
        try
        {
            var dec = await _decommissioningTmcRepository.GetByIdAsync(SelectionDecommissioningTmc.Id);

            dec!.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 6)!;
            if (dec.History == null!) dec.History = new();
            dec.History.Add(new History()
            {
                EventDate = DateTime.Now,
                User = (Application.Current.Properties["CurrentUser"] as User)!,
                EventHistory = "Удаление документа"
            });
            await _decommissioningTmcRepository.SaveAsync(dec);
            DecommissioningTmcCollection.Remove(SelectionDecommissioningTmc);
            _notificationManager.Show("Регистратор",
                "Документ успешно удален из БД",
                NotificationType.Information);

        }
        catch (Exception e)
        {
            var message = e.InnerException != null! ? e.InnerException.Message : e.Message;
            _notificationManager.Show("Регистратор",
                $"При удалении объекта произошла ошибка: {message}",
                NotificationType.Error);
        }
    }

    #endregion

    #region Spend
    /// <summary>
    /// Команда проведения документа
    /// </summary>

    private ICommand? _spendCommand;

    public ICommand SpendCommand => _spendCommand
        ??= new RelayCommand(OnSpendExecuted, SpendCan);

    private bool SpendCan(object arg)
    {
        return SelectionDecommissioningTmc!=null! &&  SelectionDecommissioningTmc.StatusId == 1;
    }

    private async void OnSpendExecuted(object obj)
    {
        try
        {
            var decommissioningTmc = await _decommissioningTmcRepository.GetByIdAsync(SelectionDecommissioningTmc.Id);
            if (decommissioningTmc! == null!)
            {
                _notificationManager.Show("Регистратор",
                    $"Запрашиваемый документ № {SelectionDecommissioningTmc.Number} " +
                    $"от {SelectionDecommissioningTmc.Date.ToShortDateString()} не найден в бд",
                    NotificationType.Error);

            }
            else
            {
                var registersTmc = new ObservableCollection<TmcRegister>();
                var registerAccounting = new ObservableCollection<AccountingPlanRegister>();
                foreach (var position in decommissioningTmc.Positions)
                {
                    var tОst = await _tmcSprRepository.GetRemainsTmcByIdLsApAsync(position.Tmc.Id, position.StorageLocation.Id, position.AccountingPlan.Id);
                    if (tОst == null!)
                    {
                        _notificationManager.Show("Регистратор",
                            $"Запрашиваемый ТМЦ {position.Tmc.Name} не найден в бд",
                            NotificationType.Error);
                        return;
                    }

                    if (position.Quantity > tОst.Quantity)
                    {
                        _notificationManager.Show("Регистратор",
                            $"Текущего остатка по позиции {position.Tmc.Name} не достаточно " +
                            $"для списания запрашиваемого количества, операция проведения будет отменена!",
                            NotificationType.Error);
                        return;
                    }

                    var regTmc = new TmcRegister()
                    {
                        TypeDoc = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(s => s.Id == 26)!,
                        Tmc = position.Tmc,
                        Quantity = position.Quantity,
                        UnitOkei = position.UnitOkei,
                        Amount = position.Amount,
                        Price = position.Price,
                        Credit = position.AccountingPlan,
                        Debit = decommissioningTmc.AccountingPlan,
                        StorageLocation = position.StorageLocation,
                        DateRegister = decommissioningTmc.Date,
                        Description = $"Расход по док. требование накладная.№ {decommissioningTmc.Number} " +
                                      $"от {decommissioningTmc.Date.ToShortDateString()}, " +
                                      $"МОЛ: {decommissioningTmc.Mol.People}, " +
                                      $"Цель расходования: {decommissioningTmc.PurposeExpenditure.Name}, " +
                                      $"объект списания {decommissioningTmc.WriteOffObject.Name}"
                    };
                    registersTmc.Add(regTmc);

                    registerAccounting.Add(new AccountingPlanRegister()
                    {
                        DateReg = decommissioningTmc.Date,
                        Debit = decommissioningTmc.AccountingPlan,
                        Credit = position.AccountingPlan,
                        Amount = position.Amount,
                        ContaAction = $"Расход ТМЦ по док.№ {decommissioningTmc.Number} " +
                                      $"от {decommissioningTmc.Date.ToShortDateString()}, ",
                        ContaObject = position.Tmc.Name,
                        ContaParty = $"{decommissioningTmc.Mol.People} для {decommissioningTmc.WriteOffObject.Name}",
                        ContaDoc = $"Требование накладная № {decommissioningTmc.Number} от {decommissioningTmc.Date.ToShortDateString()}"


                    });
                }
                decommissioningTmc.TmcRegisters = registersTmc;
                decommissioningTmc.AccountingPlanRegisters = registerAccounting;
                decommissioningTmc.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 23);
                if (decommissioningTmc.History == null!) decommissioningTmc.History = new();
                decommissioningTmc.History.Add(new History()
                {
                    EventDate = DateTime.Now,
                    User = (Application.Current.Properties["CurrentUser"] as User)!,
                    EventHistory = "Регистрация документа"
                });
                var newDec = await _decommissioningTmcRepository.SaveAsync(decommissioningTmc);
                SelectionDecommissioningTmc.Status = newDec.Status!.Name;
                SelectionDecommissioningTmc.StatusId = newDec.Status.Id;
                _notificationManager.Show("Логер",
                    $"Операция успешно выполнена! Статус документа изменен на {SelectionDecommissioningTmc.Status}",
                    NotificationType.Information);
            }
        }
        catch (Exception e)
        {

            var message = e.InnerException != null! ? e.InnerException.Message : e.Message;
            _notificationManager.Show("Регистратор",
                $"При проведении документа произошла ошибка {message}",
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
        return SelectionDecommissioningTmc != null! && SelectionDecommissioningTmc.StatusId == 23;
    }

    private async void OnCancellationRegistrationExecuted(object obj)
    {
        try
        {
            var dec = await _decommissioningTmcRepository.GetByIdAsync(SelectionDecommissioningTmc.Id);

            if (dec!.TmcRegisters != null)
            {
                await _decommissioningTmcRepository.DeleteTmcRegisterRangePlanAsync(dec.TmcRegisters);
            }

            if (dec.AccountingPlanRegisters != null)
            {
                await _decommissioningTmcRepository.DeleteAccountingRegisterRangePlanAsync(dec.AccountingPlanRegisters);
            }

            dec.Status =
                (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1);
            if (dec.History == null!) { dec.History = new ObservableCollection<History>(); }
            dec.History.Add(new History()
            {
                EventDate = DateTime.Now,
                EventHistory = "Отмена регистрации документа",
                User = (Application.Current.Properties["CurrentUser"] as User)!
            });
            var newDec = await _decommissioningTmcRepository.SaveAsync(dec);
            SelectionDecommissioningTmc.Status = newDec.Status!.Name;
            SelectionDecommissioningTmc.StatusId = newDec.Status.Id;
            _notificationManager.Show("Регистратор",
                $"Статус документа успешно изменен на {SelectionDecommissioningTmc.Status}",
                NotificationType.Information);
        }
        catch (Exception e)
        {
            var message = e.InnerException != null! ? e.InnerException.Message : e.Message;
            _notificationManager.Show("Регистратор",
                $"При отмене проведения документа произошла ошибка {message}",
                NotificationType.Error);
        }
    }

    #endregion

    #region ClearFilter

    private ICommand? _clearFilterCommand;

    public ICommand ClearFilterCommand => _clearFilterCommand
        ??= new RelayCommand(OnClearFilterExecuted, ClearFilterCan);

    private bool ClearFilterCan(object arg)
    {
        return DateOn != null | DateOff != null | InitAmount != 0 | FinalAmount != 0 |
               !string.IsNullOrEmpty(NameFilter) |
               !string.IsNullOrEmpty(InvNumber) | !string.IsNullOrEmpty(RegNumber) | !string.IsNullOrEmpty(NumberDoc) |
               !string.IsNullOrEmpty(Status) & Status != "Любой" | !string.IsNullOrEmpty(Type) &
               Type != "Любой" | !string.IsNullOrEmpty(PurposeExpenditure) & PurposeExpenditure != "Все";
    }

    private void OnClearFilterExecuted(object obj)
    {
        CollectionView.Filter = null;
        DateOn = null;
        DateOff = null;
        InitAmount = 0;
        FinalAmount = 0;
        NameFilter = null;
        InvNumber = null;
        RegNumber = null;
        NumberDoc = null;
        Status = "Любой";
        Type = "Любой";
        PurposeExpenditure = "Все";

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

    #endregion
}