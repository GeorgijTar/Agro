
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Kassa;
using Agro.DAL.Entities.Kassa.Base;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Shared;
using Agro.WPF.Views.Pages.Kassa;
using Agro.WPF.Views.Windows.Shared;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Kassa;

public class DocsCashViewModel : ViewModel
{
    #region Fields

    private readonly ICashDocRepository<DocCash> _docCashRepository;
    private readonly INotificationManager _notificationManager;
    private readonly IHelperNavigation _helperNavigation;
    private readonly ITransactionRepository _transactionRepository;

    #endregion
   

    #region Property

    /// <summary>
    /// Коллекция кассовых документов
    /// </summary>
    private FullyObservableCollection<DocCash> _docsCash = new();
    public FullyObservableCollection<DocCash> DocsCash { get => _docsCash; set => Set(ref _docsCash, value); }

    private ObservableCollection<DocCash> _allDocsCash = new();
    public ObservableCollection<DocCash> AllDocsCash { get => _allDocsCash; set => Set(ref _allDocsCash, value); }

    /// <summary>
    /// Выбранный элемент коллекции
    /// </summary>
    private DocCash? _selectedDocCash;
    public DocCash? SelecteDocCash { get => _selectedDocCash; set => Set(ref _selectedDocCash, value); }

    /// <summary>
    /// Коллекция статусов документа
    /// </summary>
    private ObservableCollection<Status> _statusCollection = new();
    public ObservableCollection<Status> StatusCollection { get => _statusCollection; set => Set(ref _statusCollection, value); }

    /// <summary>
    /// Тип документа
    /// </summary>
    private ObservableCollection<TypeDoc> _typeDocCollection = new();
    public ObservableCollection<TypeDoc> TypeDocCollection { get => _typeDocCollection; set => Set(ref _typeDocCollection, value); }

    /// <summary>
    /// Вид операции
    /// </summary>
    private ObservableCollection<TypeOperationCash> _typeOperationCashCollection = new();
    public ObservableCollection<TypeOperationCash> TypeOperationCashCollection { get => _typeOperationCashCollection; set => Set(ref _typeOperationCashCollection, value); }

    /// <summary>
    /// Текущий остаток в кассе
    /// </summary>
    private decimal _currentBalance;
    public decimal CurrentBalance { get => _currentBalance; set => Set(ref _currentBalance, value); }
    #region Filters
    /// <summary>
    /// Коллекция представления
    /// </summary>
    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    /// <summary>
    /// Начальная дата отбора
    /// </summary>
    private DateTime? _dateOn;
    public DateTime? DateOn { get => _dateOn; set => Set(ref _dateOn, value); }

    /// <summary>
    /// Конечная дата отбора
    /// </summary>
    private DateTime? _dateOff;
    public DateTime? DateOff { get => _dateOff; set => Set(ref _dateOff, value); }

    /// <summary>
    /// Номер документа
    /// </summary>
    private string? _number;
    public string? Number { get => _number; set => Set(ref _number, value); }

    /// <summary>
    /// Начальная сумма отбора
    /// </summary>
    private decimal _amountOn;
    public decimal AmountOn { get => _amountOn; set => Set(ref _amountOn, value); }

    /// <summary>
    /// Конечная сумма отбора
    /// </summary>
    private decimal _amountOff;
    public decimal AmountOff { get => _amountOff; set => Set(ref _amountOff, value); }

    /// <summary>
    /// ФИО
    /// </summary>
    private string? _fio;
    public string? Fio { get => _fio; set => Set(ref _fio, value); }

    /// <summary>
    /// Выбранный статус документа
    /// </summary>
    private Status? _status;
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>
    /// Выбранный тип документа
    /// </summary>
    private TypeDoc? _typeDoc ;
    public TypeDoc? TypeDoc { get => _typeDoc; set => Set(ref _typeDoc, value); }

    /// <summary>
    /// Выбранный вид операции
    /// </summary>
    private TypeOperationCash _typeOperationCash = null!;
    public TypeOperationCash TypeOperationCash
    {
        get => _typeOperationCash;
        set { Set(ref _typeOperationCash, value); }
    }

    #endregion

    #endregion

    #region Methods

    #region Constructor

    public DocsCashViewModel(
        ICashDocRepository<DocCash> docCashRepository,
        INotificationManager notificationManager, 
        IHelperNavigation helperNavigation,
        ITransactionRepository transactionRepository)
    {
        _docCashRepository = docCashRepository;
        _notificationManager = notificationManager;
        _helperNavigation = helperNavigation;
        _transactionRepository = transactionRepository;
        Title = "Кассовые документы";
        LoadData();
        DocsCash.ItemPropertyChanged += ItemChanged;
        DocsCash.CollectionChanged += CollectionChanged;
       
    }

    private void ItemChanged(object? sender, ItemPropertyChangedEventArgs e)
    {
        DocsCashChanged();
    }

    private void CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        DocsCashChanged();
    }

    private void DocsCashChanged()
    {
        if (DocsCash.Count > 0)
        {
            LoadFilters(DocsCash);
            try
            {
                decimal prixod = AllDocsCash.Where(d => d.Status.Id == 26)
                    .Where(d => d.TypeDoc.Id == 31)
                    .Sum(d => d.Amount);
                decimal rasxod = AllDocsCash.Where(d => d.Status.Id == 26)
                    .Where(d => d.TypeDoc.Id == 32)
                    .Sum(d => d.Amount);
                CurrentBalance = prixod - rasxod;
            }
            catch (Exception e)
            {
                var mass = e.Message;
                if (e.InnerException != null)
                {
                    mass = mass + e.InnerException.Message;
                }

                _notificationManager.Show("Системные уведомления",
                    $"В процессе получения текущего остатка в кассе, произошла ошибка: {mass}",
                    NotificationType.Error);
            }
        }

    }

    private async void LoadData()
    {
        DocsCash.Clear();
        AllDocsCash.Clear();
        AllDocsCash = (await _docCashRepository.GetAllNoTrecAsync())!;
        foreach (var doc in AllDocsCash!)
        {
            DocsCash.Add(doc);
        }
        CollectionView = CollectionViewSource.GetDefaultView(DocsCash);
        //LoadFilters(DocsCash);
    }

    private void LoadFilters(ObservableCollection<DocCash>? collection)
    {
        Status st = new Status() { Id = 0, Name = "Все" };
        TypeDoc td = new TypeDoc() { Id = 0, Name = "Все" };
        TypeOperationCash to = new TypeOperationCash() { Id = 0, Name = "Все" };
        Status stat;
        TypeDoc typeD;
        TypeOperationCash typeO;
        if (Status != null!)
        {
            stat = Status;
        }
        else
        {
            stat = st;
        }

        if (TypeDoc != null!)
        {
            typeD=TypeDoc;
        }
        else
        {
            typeD = td;
        }

        if (TypeOperationCash != null!)
        {
            typeO=TypeOperationCash;
        }
        else
        {
            typeO = to;
        }

        StatusCollection.Clear();
        TypeDocCollection.Clear();
        TypeOperationCashCollection.Clear();
        
        StatusCollection.Add(st);
        TypeDocCollection.Add(td);
        TypeOperationCashCollection.Add(to);
        if (collection != null)
        {
            var statusCollDb = collection.Select(d => d.Status).Distinct();
            foreach (var status in statusCollDb)
            {
                StatusCollection.Add(status);
            }

            var typeCollDb = collection.Select(d => d.TypeDoc).Distinct();
            foreach (var typeDoc in typeCollDb)
            {
                TypeDocCollection.Add(typeDoc);
            }

            var typeOperDb = collection.Select(d=>d.TypeOperationCash).Distinct();
            foreach (var typeOp in typeOperDb)
            {
                TypeOperationCashCollection.Add(typeOp!);
            }
        }

        Status = stat;
        TypeDoc = typeD;
        TypeOperationCash = typeO;


    }

    #endregion


    #endregion

    #region Commands

    #region AddPko
    
    private ICommand? _showPkoCommand;

    public ICommand AddPkoCommand => _showPkoCommand
        ??= new RelayCommand(OnAddPkoExecuted);

    private void OnAddPkoExecuted(object obj)
    {
        var page = new DocCashPkoPage();
        var model = page.DataContext as DocCashViewModel;
        model!.SenderModel = this;
        model.DocCash.TypeDoc = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(s =>
            s.Id == 31)!;
        model.DocCash.Debit = ((Application.Current.Properties["AccountingPlans"] as IEnumerable<AccountingPlan>)!.FirstOrDefault(a => a.Id == 138))!;
        var type = (Application.Current.Properties["TypesOperationCash"] as IEnumerable<TypeOperationCash>)!.Where(t => t.TypeDoc == model.DocCash.TypeDoc);
        var typeOperationCash = type as TypeOperationCash[] ?? type.ToArray();
        var exp = typeOperationCash.Select(t=>t.ItemExpenditureOrIncome).Distinct();
        foreach (var typeOperation in typeOperationCash)
        {
            model.TypeOperations.Add(typeOperation);
        }

        foreach (var itemExpenditureOrIncome in exp)
        {
            model.ItemExpenditureOrIncomes.Add(itemExpenditureOrIncome!);
        }

        model.TabItem = _helperNavigation.OpenPage(page, "Добавление нового документа поступления в кассу (ПКО)");
    }


    #endregion

    #region AddRko

    private ICommand? _showRkoCommand;

    public ICommand AddRkoCommand => _showRkoCommand
        ??= new RelayCommand(OnAddRkoExecuted);

    private void OnAddRkoExecuted(object obj)
    {
        var page = new DocCashRkoPage();
        var model = page.DataContext as DocCashViewModel;
        model!.SenderModel = this;
        model.DocCash.TypeDoc = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(s =>
            s.Id == 32)!;
        model.DocCash.Credit = ((Application.Current.Properties["AccountingPlans"] as IEnumerable<AccountingPlan>)!.FirstOrDefault(a => a.Id == 138))!;
        var type = (Application.Current.Properties["TypesOperationCash"] as IEnumerable<TypeOperationCash>)!.Where(t => t.TypeDoc == model.DocCash.TypeDoc);
        var typeOperationCash = type as TypeOperationCash[] ?? type.ToArray();
        var exp = typeOperationCash.Select(t => t.ItemExpenditureOrIncome).Distinct();
        foreach (var typeOperation in typeOperationCash)
        {
            model.TypeOperations.Add(typeOperation);
        }

        foreach (var itemExpenditureOrIncome in exp)
        {
            model.ItemExpenditureOrIncomes.Add(itemExpenditureOrIncome!);
        }

        model.TabItem = _helperNavigation.OpenPage(page, "Добавление нового документа выбытия из кассы (РКО)");
    }


    #endregion


    #region EdeteDocCash

    private ICommand? _editDocCashCommand;

    public ICommand EditDocCashCommand => _editDocCashCommand
        ??= new RelayCommand(OnEditDocCashExecuted, EditDocCashCan);

    private bool EditDocCashCan(object arg)
    {
        return SelecteDocCash != null! && SelecteDocCash.Status.Id==1;
    }

    private async void OnEditDocCashExecuted(object obj)
    {
        try
        {
            if (SelecteDocCash!.TypeDoc.Id == 31)
        {
            var page = new DocCashPkoPage();
            var model = page.DataContext as DocCashViewModel;
            model!.IsEdet = true;
            model.SenderModel = this;
            model.DocCash.TypeDoc = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(s =>
                s.Id == 31)!;
            //model.DocCash.Debit = ((Application.Current.Properties["AccountingPlans"] as IEnumerable<AccountingPlan>)!.FirstOrDefault(a => a.Id == 138))!;
            var type = (Application.Current.Properties["TypesOperationCash"] as IEnumerable<TypeOperationCash>)!.Where(t => t.TypeDoc == model.DocCash.TypeDoc);
            var typeOperationCash = type as TypeOperationCash[] ?? type.ToArray();
            var exp = typeOperationCash.Select(t => t.ItemExpenditureOrIncome).Distinct();
            foreach (var typeOperation in typeOperationCash)
            {
                model.TypeOperations.Add(typeOperation);
            }

            foreach (var itemExpenditureOrIncome in exp)
            {
                model.ItemExpenditureOrIncomes.Add(itemExpenditureOrIncome!);
            }

            model.DocCash = (await _docCashRepository.GetByIdAsync(SelecteDocCash.Id))!;
            model.TabItem = _helperNavigation.OpenPage(page, $"Редактирование РКО № {SelecteDocCash.Number} от {SelecteDocCash.Date.ToShortDateString()}");

        }
        if (SelecteDocCash!.TypeDoc.Id == 32)
        {
            var page = new DocCashRkoPage();
            var model = page.DataContext as DocCashViewModel;
            model!.IsEdet = true;
            model.SenderModel = this;
            model.DocCash.TypeDoc = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(s =>
                s.Id == 32)!;
            var type = (Application.Current.Properties["TypesOperationCash"] as IEnumerable<TypeOperationCash>)!.Where(t => t.TypeDoc == model.DocCash.TypeDoc);
            var typeOperationCash = type as TypeOperationCash[] ?? type.ToArray();
            var exp = typeOperationCash.Select(t => t.ItemExpenditureOrIncome).Distinct();
            foreach (var typeOperation in typeOperationCash)
            {
                model.TypeOperations.Add(typeOperation);
            }

            foreach (var itemExpenditureOrIncome in exp)
            {
                model.ItemExpenditureOrIncomes.Add(itemExpenditureOrIncome!);
            }

            model.DocCash = (await _docCashRepository.GetByIdAsync(SelecteDocCash.Id))!;
            model.TabItem = _helperNavigation.OpenPage(page, $"Редактирование РКО № {SelecteDocCash.Number} от {SelecteDocCash.Date.ToShortDateString()}");

        }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    #endregion

    #region LookDocCash

    private ICommand? _lookDocCashCommand;

    public ICommand LookDocCashCommand => _lookDocCashCommand
        ??= new RelayCommand(OnLookDocCashExecuted, LookDocCashCan);

    private bool LookDocCashCan(object arg)
    {
        return SelecteDocCash != null!;
    }

    private async void OnLookDocCashExecuted(object obj)
    {
        if (SelecteDocCash!.TypeDoc.Id == 31)
        {
            var page = new DocCashPkoPage();
            var model = page.DataContext as DocCashViewModel;
            model!.SenderModel = this;
            model.DocCash.TypeDoc = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(s =>
                s.Id == 31)!;
            model.DocCash.Debit = ((Application.Current.Properties["AccountingPlans"] as IEnumerable<AccountingPlan>)!.FirstOrDefault(a => a.Id == 138))!;
            var type = (Application.Current.Properties["TypesOperationCash"] as IEnumerable<TypeOperationCash>)!.Where(t => t.TypeDoc == model.DocCash.TypeDoc);
            var typeOperationCash = type as TypeOperationCash[] ?? type.ToArray();
            var exp = typeOperationCash.Select(t => t.ItemExpenditureOrIncome).Distinct();
            foreach (var typeOperation in typeOperationCash)
            {
                model.TypeOperations.Add(typeOperation);
            }

            foreach (var itemExpenditureOrIncome in exp)
            {
                model.ItemExpenditureOrIncomes.Add(itemExpenditureOrIncome!);
            }

            model.DocCash = (await _docCashRepository.GetByIdAsync(SelecteDocCash.Id))!;
            model.IsEnabled = false;
            model.TabItem = _helperNavigation.OpenPage(page, "Добавление нового документа поступления в кассу");

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


    #region Spend (Провести)

    private ICommand? _spendCommand;

    public ICommand SpendCommand => _spendCommand
        ??= new RelayCommand(OnSpendExecuted, SpendCan);

    private bool SpendCan(object arg)
    {
        return SelecteDocCash != null! && SelecteDocCash!.Status.Id == 1;
    }

    private async void OnSpendExecuted(object obj)
    {
        var newStatus =
            (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 26);
        var doc = await _docCashRepository.GetByIdAsync(SelecteDocCash!.Id);
       var result= await _docCashRepository.SpendDocCashAsync(doc!, newStatus!);

       if (result) SelecteDocCash!.Status = newStatus!;

    }


    #endregion

    #region CenselSpend

    private ICommand? _cancelSpendCommand;

    public ICommand CancelSpendCommand => _cancelSpendCommand
        ??= new RelayCommand(OnCancelSpendExecuted, CancelSpendCan);

    private bool CancelSpendCan(object arg)
    {
        return SelecteDocCash!=null! && SelecteDocCash.Status.Id == 26;
    }

    private async void OnCancelSpendExecuted(object obj)
    {
        try
        {
            var newStatus =
                (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1);
            var doc = await _docCashRepository.GetByIdAsync(SelecteDocCash!.Id);
            var result = await _docCashRepository.CancelSpendDocCashAsync(doc!, newStatus!);

            if (result) SelecteDocCash!.Status = newStatus!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Delete

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        return SelecteDocCash != null! && SelecteDocCash!.Status.Id == 1;
    }

    private void OnDeleteExecuted(object obj)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region ShowTransaction

    private ICommand? _showTransactionCommand;

    public ICommand ShowTransactionCommand => _showTransactionCommand
        ??= new RelayCommand(OnShowTransactionExecuted, ShowTransactionCan);

    private bool ShowTransactionCan(object arg)
    {
        return SelecteDocCash!=null! && SelecteDocCash.Status.Id == 26 ;
    }

    private async void OnShowTransactionExecuted(object obj)
    {
        var transaction = await _transactionRepository.ConvertBaseTransactionToDtoAsync(
            (await _docCashRepository.GetByIdNoTrecAsync(SelecteDocCash!.Id))!.AccountingPlanRegisters);

        if (transaction.Count==0)
        {
            _notificationManager.Show("Редактор бухгалтерских проводок",
                "Документ не содержит бухгалтерских проводок", NotificationType.Information);
            return;
        }

        var window = new TransactionView();
        var model = window.DataContext as TransactionViewModel;
        if (SelecteDocCash!.TypeDoc.Id == 31)
        {
            model!.NameDoc =
                $"Приходный кассовый ордер № {SelecteDocCash.Number} от {SelecteDocCash.Date.ToShortDateString()}";
        }
        else
        {
            model!.NameDoc =
                $"Расходный кассовый ордер № {SelecteDocCash.Number} от {SelecteDocCash.Date.ToShortDateString()}";
        }

        model.Transactions = transaction;
           
        window.ShowDialog();
    }

    #endregion

    #region LookPrint

    private ICommand? _lookCommand;

    public ICommand LookCommand => _lookCommand
        ??= new RelayCommand(OnLookExecuted, LookCan);

    private bool LookCan(object arg)
    {
        return SelecteDocCash != null!;
    }

    private async void OnLookExecuted(object obj)
    {
        var view = new LookView();
        var model = view.DataContext as LookViewModel;
        model!.Sours = ReportExcelLib.Kassa.KassaLook.GetLook((await _docCashRepository.GetByIdNoTrecAsync(SelecteDocCash!.Id))!);
        view.ShowDialog();
    }

    #endregion

    #endregion



}