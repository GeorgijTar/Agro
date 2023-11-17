using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Kassa;
using Agro.DAL.Entities.Kassa.Base;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Contract;
using Agro.WPF.ViewModels.InvoiceVM;
using Agro.WPF.ViewModels.Personnel;
using Agro.WPF.ViewModels.Shared;
using Agro.WPF.ViewModels.Storage;
using Agro.WPF.Views.Windows;
using Agro.WPF.Views.Windows.Contract;
using Agro.WPF.Views.Windows.Personnel;
using Agro.WPF.Views.Windows.Shared;
using Agro.WPF.Views.Windows.Storage;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Kassa;

/// <summary>
/// Кассовый документ
/// </summary>
public class DocCashViewModel : ViewModel
{
    private readonly ICashDocRepository<DocCash> _cashDocRepository;
    private readonly INotificationManager _notificationManager;
    private readonly IHelperNavigation _helperNavigation;

    #region Property

    /// <summary>
    /// Кассовый документ
    /// </summary>
    private DocCash _docCash = new();
    public DocCash DocCash
    {
        get => _docCash;
        set
        {
            Set(ref _docCash, value);
        }
    }

    /// <summary>
    /// Список типов операции
    /// </summary>
    private ObservableCollection<TypeOperationCash> _typeOperations = new();
    public ObservableCollection<TypeOperationCash> TypeOperations { get => _typeOperations; set => Set(ref _typeOperations, value); }

    /// <summary>
    /// Список статей доходов или расходов
    /// </summary>
    private ObservableCollection<ItemExpenditureOrIncome> _itemExpenditureOrIncomes = new();
    public ObservableCollection<ItemExpenditureOrIncome> ItemExpenditureOrIncomes { get => _itemExpenditureOrIncomes; set => Set(ref _itemExpenditureOrIncomes, value); }

    private IEnumerable<BankDetails>? _bankDetailsOrg = new HashSet<BankDetails>();
    public IEnumerable<BankDetails>? BankDetailsOrg { get => _bankDetailsOrg; set => Set(ref _bankDetailsOrg, value); }
    /// <summary>
    /// Коллекция ставок НДС
    /// </summary>
    private IEnumerable<Nds>? _nds = new HashSet<Nds>();
    public IEnumerable<Nds>? Nds { get => _nds; set => Set(ref _nds, value); }


    private string _isVisibilityCounterparty = "Collapsed";
    public string IsVisibilityCounterparty { get => _isVisibilityCounterparty; set => Set(ref _isVisibilityCounterparty, value); }

    private string _isVisibilityPeople = "Collapsed";
    public string IsVisibilityPeople { get => _isVisibilityPeople; set => Set(ref _isVisibilityPeople, value); }

    private string _isVisibilityBankDetailsOrg = "Collapsed";
    public string IsVisibilityBankDetailsOrg { get => _isVisibilityBankDetailsOrg; set => Set(ref _isVisibilityBankDetailsOrg, value); }

    private string _isVisibilityStorageLocation = "Collapsed";
    public string IsVisibilityStorageLocation { get => _isVisibilityStorageLocation; set => Set(ref _isVisibilityStorageLocation, value); }

    private string _isVisibilityContract = "Collapsed";
    public string IsVisibilityContract { get => _isVisibilityContract; set => Set(ref _isVisibilityContract, value); }

    private string _isVisibilityInvoice = "Collapsed";
    public string IsVisibilityInvoice { get => _isVisibilityInvoice; set => Set(ref _isVisibilityInvoice, value); }

    private string _isVisibilityNds = "Collapsed";
    public string IsVisibilityNds { get => _isVisibilityNds; set => Set(ref _isVisibilityNds, value); }

    private string _namePeople = null!;
    public string NamePeople { get => _namePeople; set => Set(ref _namePeople, value); }

    private bool _isEnabled = true;
    public bool IsEnabled { get => _isEnabled; set => Set(ref _isEnabled, value); }

    private bool _isEdet;

    public bool IsEdet
    {
        get => _isEdet;
        set => Set(ref _isEdet, value);
    }

    #endregion

    public DocCashViewModel(ICashDocRepository<DocCash> cashDocRepository,
        INotificationManager notificationManager,
        IHelperNavigation helperNavigation)
    {
        _cashDocRepository = cashDocRepository;
        _notificationManager = notificationManager;
        _helperNavigation = helperNavigation;
        BankDetailsOrg = Application.Current.Properties["BankDetailsOrg"] as IEnumerable<BankDetails>;
        Nds = Application.Current.Properties["Nds"] as IEnumerable<Nds>;
        DocCash.Organization = (Application.Current.Properties["Organization"] as DAL.Entities.Organization.Organization)!;
        DocCash.Nds = (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
        DocCash.Director = (Application.Current.Properties["Organization"] as DAL.Entities.Organization.Organization)!.Director;
        DocCash.Cashier = (Application.Current.Properties["Organization"] as DAL.Entities.Organization.Organization)!.Cashier;
        DocCash.GeneralAccountant = (Application.Current.Properties["Organization"] as DAL.Entities.Organization.Organization)!.GeneralAccountant;
        DocCash.PropertyChanged += DocCashChanged;
        PropertyChanged += ViewModelChanged;
    }

    private void ViewModelChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(DocCash))
        {
            TypeOperationChanged();
            if (DocCash != null!)
            {
                DocCash.PropertyChanged += DocCashChanged;
            }
        }
    }

    private void DocCashChanged(object? sender, PropertyChangedEventArgs e)
    {
        try
        {



            if (e.PropertyName == nameof(DocCash.TypeOperationCash))
            {

                DocCash.ItemExpenditureOrIncome = DocCash.TypeOperationCash!.ItemExpenditureOrIncome;

                if (DocCash.TypeDoc.Id == 31)
                {
                    if (DocCash.Credit == null!)
                        DocCash.Credit = DocCash.TypeOperationCash.AccountingPlan!;
                }

                if (DocCash.TypeDoc.Id == 32)
                {
                    if (DocCash.Debit == null!)
                        DocCash.Debit = DocCash.TypeOperationCash.AccountingPlan!;
                }

                TypeOperationChanged();

            }

            if (e.PropertyName == nameof(DocCash.Nds))
            {

                if (DocCash.Nds != null!)
                {
                    DocCash.AmountNds = DocCash.Amount / DocCash.Nds.OverPercent * DocCash.Nds.Percent / 100;
                }
                else
                {
                    DocCash.AmountNds = 0;
                }
            }

            if (e.PropertyName == nameof(DocCash.Amount))
            {
                if (DocCash.Nds != null!)
                {
                    DocCash.AmountNds = DocCash.Amount / DocCash.Nds.OverPercent * DocCash.Nds.Percent / 100;
                }
                else
                {
                    DocCash.AmountNds = 0;
                }

            }

            if (e.PropertyName == nameof(DocCash.People))
            {
                //DocCash.FoundationDoc = String.Empty;
                //DocCash.From = String.Empty;
                if (DocCash.People != null!)
                {
                    if (DocCash.TypeDoc.Id == 31)
                    {


                        if (!string.IsNullOrEmpty(DocCash.People.SurnameRp))
                        {
                            DocCash.From = DocCash.People.SurnameRp + " " + DocCash.People.NameRp + " " +
                                           DocCash.People.PatronymicRp;
                        }
                        else
                        {
                            DocCash.From = DocCash.People.Surname + " " + DocCash.People.Name + " " +
                                         DocCash.People.Patronymic;
                        }


                    }

                    if (DocCash.TypeDoc.Id == 32)
                    {
                        var doc = DocCash.People!.Documents!.Where(d => d.TypeDoc.Id == 10).FirstOrDefault(d => d.Status!.Id == 5);
                        if (doc != null!)
                        {
                            DocCash.FoundationDoc = $"{doc.NameDocument} серия {doc.Series} " +
                                                    $"номер {doc.Number} выдан {doc.Issuing}, {doc.DateIssue.ToShortDateString()}";
                        }

                        if (!string.IsNullOrEmpty(DocCash.People.SurnameDp))
                        {
                            DocCash.From = DocCash.People.SurnameDp + " " + DocCash.People.NameDp + " " +
                                           DocCash.People.PatronymicDp;
                        }
                        else
                        {
                            DocCash.From = DocCash.People.Surname + " " + DocCash.People.Name + " " +
                                           DocCash.People.Patronymic;
                        }

                    }
                }
            }

            if (e.PropertyName == nameof(DocCash.BankDetailsOrg))
            {
                if (DocCash.BankDetailsOrg != null!)
                {
                    DocCash.From = $"{DocCash.BankDetailsOrg.NameBank} ({DocCash.BankDetailsOrg.Bs})";
                }
            }

            if (e.PropertyName == nameof(DocCash.Counterparty))
            {
                if (DocCash.Counterparty != null!)
                {
                    DocCash.From = $"{DocCash.Counterparty.PayName} ({DocCash.Counterparty.Inn})";
                }
            }
        }
        catch (Exception exception)
        {
            _notificationManager.Show(exception.Message);
        }
    }


    private void TypeOperationChanged()
    {
        try
        {
            if (DocCash.TypeOperationCash != null!)
            {

                switch (DocCash.TypeOperationCash!.Id)
                {
                    case 1: //Получение наличных в банке
                        IsVisibilityBankDetailsOrg = "true";
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "true";
                        NamePeople = "Через кого:";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed";
                       break;
                    case 2: //Оплата от покупателя
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "true";
                        IsVisibilityPeople = "true";
                        NamePeople = "Через кого:";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "true";
                        IsVisibilityInvoice = "true";
                        IsVisibilityNds = "true";
                        break;
                    case 3: //Розничная выручка
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "true";
                        NamePeople = "Через кого:";
                        IsVisibilityStorageLocation = "true";
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "true";
                        break;
                    case 4: //Возврат от подотчетного лица
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "true";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed";
                       break;
                    case 5: //Возврат займа работником
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "true";
                        NamePeople = "Работник:";
                        IsVisibilityStorageLocation = "true";
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed";
                       break;
                    case 6: //Возврат от поставщика
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "true";
                        IsVisibilityPeople = "true";
                        NamePeople = "Через кого:";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "true";
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "true";
                        break;

                    case 8: //Выдача подотчетному лицу
                        
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "true";
                        NamePeople = "Подотчетное лицо:";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed";
                      
                        break;
                    case 9: //Оплата поставщику
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "true";
                        IsVisibilityPeople = "true";
                        NamePeople = "Через кого:";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "true";
                        IsVisibilityInvoice = "true";
                        IsVisibilityNds = "true";
                        DocCash.FoundationDoc = null;
                        DocCash.Footing = null;
                        DocCash.From = null;
                        break;
                    case 10:  //Выплата заработной платы по ведомостям
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "Collapsed";
                        DocCash.People = null;
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed";
                        DocCash.Nds = null!;
                        break;
                    case 11: //Выплата заработной платы работнику
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "true";
                        NamePeople = "Получатель:";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed"; 
                        break;
                    case 12: //Выплата по договору подряда
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "true";
                        NamePeople = "Получатель:";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed";
                        break;
                    case 13: //Выдача займа работнику
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "true";
                        NamePeople = "Получатель:";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed";
                        break;
                    case 14: //Взнос наличными в банк
                        IsVisibilityBankDetailsOrg = "true";
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "true";
                        NamePeople = "Через кого:";
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed";
                        break;

                    default:
                        IsVisibilityBankDetailsOrg = "Collapsed";
                        DocCash.BankDetailsOrg = null;
                        IsVisibilityCounterparty = "Collapsed";
                        DocCash.Counterparty = null;
                        IsVisibilityPeople = "Collapsed";
                        DocCash.People = null;
                        IsVisibilityStorageLocation = "Collapsed";
                        DocCash.StorageLocation = null;
                        IsVisibilityContract = "Collapsed";
                        DocCash.Contract = null;
                        IsVisibilityInvoice = "Collapsed";
                        DocCash.Invoice = null;
                        IsVisibilityNds = "Collapsed";
                        DocCash.Nds = null!;
                        break;
                }
            }

        }
        catch (Exception e)
        {
            _notificationManager.Show(e.Message);
        }

    }

    #region Commands

    #region Close

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        _helperNavigation.ClosePage(TabItem);
    }

    #endregion

    #region ShowCounterpartySpr

    private ICommand? _showCounterpartySprCommand;

    public ICommand ShowCounterpartySprCommand => _showCounterpartySprCommand
        ??= new RelayCommand(OnShowCounterpartySprExecuted);

    private void OnShowCounterpartySprExecuted(object obj)
    {
        var view = new CoynterpartiesView();
        var model = view.DataContext as ContractorsViewModel;
        model!.SenderModel = this;
        view.ShowDialog();
    }

    #endregion

    #region ShowPeopleSpr

    private ICommand? _showPeopleSprCommand;

    public ICommand ShowPeopleSprCommand => _showPeopleSprCommand
        ??= new RelayCommand(OnShowPeopleSprExecuted);

    private void OnShowPeopleSprExecuted(object obj)
    {
        var view = new PeoplsView();
        var model = view.DataContext as PeoplsViewModel;
        model!.SenderModel = this;
        view.ShowDialog();
    }

    #endregion

    #region ShowStorageLocationsSpr

    private ICommand? _showStorageLocationsSprCommand;

    public ICommand ShowStorageLocationsSprCommand => _showStorageLocationsSprCommand
        ??= new RelayCommand(OnShowStorageLocationsSprExecuted);

    private void OnShowStorageLocationsSprExecuted(object obj)
    {
        var view = new StorageLocationsView();
        var model = view.DataContext as StorageLocationsViewModel;
        model!.SenderModel = this;
        view.ShowDialog();
    }

    #endregion

    #region ShowContractSpr

    private ICommand? _showContractSprCommand;

    public ICommand ShowContractSprCommand => _showContractSprCommand
        ??= new RelayCommand(OnShowContractSprExecuted);

    private void OnShowContractSprExecuted(object obj)
    {
        var view = new ContractsView();
        var model = view.DataContext as ContractsViewModel;
        model!.SenderModel = this;
        if (DocCash.Counterparty != null!)
        {
            model.InnFilter = DocCash.Counterparty!.Inn;
        }
        view.ShowDialog();
    }

    #endregion

    #region ShowInvoiceSpr

    private ICommand? _showInvoiceSprCommand;

    public ICommand ShowInvoiceSprCommand => _showInvoiceSprCommand
        ??= new RelayCommand(OnShowInvoiceSprExecuted);

    private void OnShowInvoiceSprExecuted(object obj)
    {
        var view = new InvoicesView();
        var model = view.DataContext as InvoicesViewModel;
        model!.SenderModel = this;
        model.TypeInvoice = (Application.Current.Properties["Types"] as IEnumerable<TypeDoc>)!.FirstOrDefault(t => t.Id == 8)!;
        if (DocCash.Counterparty != null!)
        {
            model.InnFilter = DocCash.Counterparty!.Inn;
        }
        model.Title = "Выберите выставленный счет на оплату";
        view.ShowDialog();
    }

    #endregion

    #region Команда очистки полей

    private ICommand? _clearingCommand;

    public ICommand ClearingCommand => _clearingCommand
        ??= new RelayCommand(OnClearingExecuted, ClearingCan);

    private bool ClearingCan(object arg)
    {
        switch (arg as string)
        {
            case "Counterparty":
                if (DocCash.Counterparty != null!) return true;
                break;
            case "People":
                if (DocCash.People != null!) return true;
                break;
            case "BankDetailsOrg":
                if (DocCash.BankDetailsOrg != null!) return true;
                break;
            case "StorageLocation":
                if (DocCash.StorageLocation != null!) return true;
                break;
            case "Contract":
                if (DocCash.Contract != null!) return true;
                break;
            case "Invoice":
                if (DocCash.Invoice != null!) return true;
                break;
            case "Cashier":
                if (DocCash.Cashier != null!) return true;
                break;
            case "GeneralAccountant":
                if (DocCash.GeneralAccountant != null!) return true;
                break;
            case "Director":
                if (DocCash.Director != null!) return true;
                break;
            default: return false;
        }
        return false;
    }

    private void OnClearingExecuted(object obj)
    {
        switch (obj as string)
        {
            case "Counterparty":
                DocCash.Counterparty = null!;
                break;
            case "People":
                DocCash.People = null!;
                break;
            case "BankDetailsOrg":
                DocCash.BankDetailsOrg = null!;
                break;
            case "StorageLocation":
                DocCash.StorageLocation = null!;
                break;
            case "Contract":
                DocCash.Contract = null!;
                break;
            case "Invoice":
                DocCash.Invoice = null!;
                break;
            case "Cashier":
                DocCash.Cashier = null!;
                break;
            case "GeneralAccountant":
                DocCash.GeneralAccountant = null!;
                break;
            case "Director":
                DocCash.Director = null!;
                break;
        }
    }



    #endregion

    #region SaveCommand

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        if (DocCash.TypeDoc != null! && DocCash.TypeDoc.Id == 31 && DocCash.TypeOperationCash != null!)
        {

            if (DocCash.TypeOperationCash! == null!) return false;

            if (DocCash.TypeOperationCash!.Id == 1)
            {
                return DocCash.Amount > 0 && DocCash.BankDetailsOrg != null!;
            }

            if (DocCash.TypeOperationCash!.Id == 2 | DocCash.TypeOperationCash!.Id == 6)
            {
                return DocCash.Amount > 0 && DocCash.Counterparty != null!;
            }

            if (DocCash.TypeOperationCash!.Id == 3)
            {
                return DocCash.Amount > 0 && DocCash.StorageLocation != null!;
            }

            if (DocCash.TypeOperationCash!.Id == 4 | DocCash.TypeOperationCash!.Id == 5)
            {
                return DocCash.Amount > 0 && DocCash.People != null!;
            }
            return DocCash.Amount > 0;
        }

        if (DocCash.TypeDoc != null! && DocCash.TypeDoc.Id == 32 && DocCash.TypeOperationCash != null!)
        {
            if (DocCash.TypeOperationCash!.Id == 8 | DocCash.TypeOperationCash!.Id == 11 | DocCash.TypeOperationCash!.Id == 12 | DocCash.TypeOperationCash!.Id == 13)
            {
                return DocCash.Amount > 0 && DocCash.People != null!;
            }

            if (DocCash.TypeOperationCash!.Id == 5)
            {
                return DocCash.Amount > 0 && DocCash.Counterparty != null!;
            }


            if (DocCash.TypeOperationCash!.Id == 14)
            {
                return DocCash.Amount > 0 && DocCash.BankDetailsOrg != null!;
            }

            return DocCash.Amount> 0;
        }

        return DocCash.Amount > 0;

    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {
            if (string.IsNullOrEmpty(DocCash.Number))
            {
                DocCash.Number = (await _cashDocRepository.GetNumberDocAsync(DocCash)).ToString();
            }

            DocCash.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1)!;



            DocCash = await _cashDocRepository.SaveAsync(DocCash);


            if (SenderModel is DocsCashViewModel docsCashViewModel)
            {
                var saveDocCash = await _cashDocRepository.GetByIdNoTrecAsync(DocCash.Id);
                if (saveDocCash! == null!)
                {
                    throw new ArgumentNullException();
                }

                var docColl = docsCashViewModel.DocsCash.FirstOrDefault(d => d.Id == DocCash.Id);
                if (docColl! == null!)
                {
                    docsCashViewModel.DocsCash.Add(saveDocCash);
                }
                else
                {
                    var ind = docsCashViewModel.DocsCash.IndexOf(docColl);
                    docsCashViewModel.DocsCash[ind] = saveDocCash;
                }


            }
            _notificationManager.Show("Регистратор документов", "Документ успешно сохранен", NotificationType.Information);
            _helperNavigation.ClosePage(this.TabItem);

        }
        catch (Exception e)
        {
            string ex = e.Message;
            if (e.InnerException != null)
            {
                ex = e.InnerException.Message;
            }
            _notificationManager.Show("Регистратор документов", $"В процессе сохранения ПКО произошла ошибка: {ex}", NotificationType.Error);
        }
    }



    #endregion

    #region ShowEmployees

    private ICommand? _showEmployeesCommand;

    public ICommand ShowEmployeesCommand => _showEmployeesCommand
        ??= new RelayCommand(OnShowEmployeesExecuted);

    private void OnShowEmployeesExecuted(object obj)
    {
        var pole = (string)obj;

        if (!string.IsNullOrEmpty(pole))
        {
            var view = new EmployeesView();
            var model = view.DataContext as EmployeesViewModel;
            model!.SenderModel = this;
            switch (pole)
            {
                case "Cashier":
                    model.SenderModelPole = "Cashier";
                    break;
                case "GeneralAccountant":
                    model.SenderModelPole = "GeneralAccountant";
                    break;
                case "Director":
                    model.SenderModelPole = "Director";
                    break;
            }
            view.ShowDialog();
        }
    }

    #endregion

    #region FillPrintedForm

    private ICommand? _fillPrintedFormCommand;

    public ICommand FillPrintedFormCommand => _fillPrintedFormCommand
        ??= new RelayCommand(OnFillPrintedFormExecuted);


    private void OnFillPrintedFormExecuted(object obj)
    {
        try
        {
            if (DocCash.TypeOperationCash != null!)
            {
                switch (DocCash.TypeOperationCash!.Id)
                {
                    case 1: //Получение наличных в банке
                       

                        if (DocCash.People != null! && DocCash.BankDetailsOrg != null!)
                        {
                            if (!string.IsNullOrEmpty(DocCash.People.SurnameRp))
                            {
                                DocCash.From =
                                    $"{DocCash.BankDetailsOrg.NameBank} ч/з {DocCash.People.SurnameRp} {DocCash.People.NameRp} {DocCash.People.PatronymicRp}";
                            }
                            else
                            {
                                DocCash.From =
                                    $"{DocCash.BankDetailsOrg.NameBank} ч/з {DocCash.People.Surname} {DocCash.People.Name} {DocCash.People.Patronymic}";
                            }
                        }

                        DocCash.Footing =
                            $"Получение наличных в банке по чеку №  от {DateTime.Now.Date.ToShortDateString()} г.";
                        DocCash.Nds =
                            (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
                        break;
                    case 2: //Оплата от покупателя
                        if (DocCash.People != null! && DocCash.Counterparty != null!)
                        {
                            if (!string.IsNullOrEmpty(DocCash.People.SurnameRp))
                            {
                                DocCash.From =
                                    $"{DocCash.Counterparty.PayName} ч/з {DocCash.People.SurnameRp} {DocCash.People.NameRp} {DocCash.People.PatronymicRp}";
                            }
                            else
                            {
                                DocCash.From =
                                    $"{DocCash.Counterparty.PayName} ч/з {DocCash.People.Surname} {DocCash.People.Name} {DocCash.People.Patronymic}";
                            }
                        }

                        if (DocCash.Contract != null!)
                        {
                            DocCash.Footing = $"По {DocCash}";
                        }
                        break;
                    case 3: //Розничная выручка
                        if (DocCash.People != null! && DocCash.StorageLocation != null!)
                        {
                            if (!string.IsNullOrEmpty(DocCash.People.SurnameRp))
                            {
                                DocCash.From =
                                    $"{DocCash.StorageLocation.Name} ч/з {DocCash.People.SurnameRp} {DocCash.People.NameRp} {DocCash.People.PatronymicRp}";
                            }
                            else
                            {
                                DocCash.From =
                                    $"{DocCash.StorageLocation.Name} ч/з {DocCash.People.Surname} {DocCash.People.Name} {DocCash.People.Patronymic}";
                            }
                        }
                        break;
                    case 4: //Возврат от подотчетного лица
                        if (DocCash.People != null!)
                        {
                            if (!string.IsNullOrEmpty(DocCash.People.SurnameRp))
                            {
                                DocCash.From = DocCash.People.SurnameRp + " " + DocCash.People.NameRp + " " +
                                               DocCash.People.PatronymicRp;
                            }
                            else
                            {
                                DocCash.From = DocCash.People.Surname + " " + DocCash.People.Name + " " +
                                               DocCash.People.Patronymic;
                            }
                        }

                        DocCash.Footing = "Возврат не использованных подотчетных средств";
                        DocCash.Nds =
                            (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
                        break;
                    case 5: //Возврат займа работником

                        DocCash.Footing = "Возврат займа по договру № от";
                        if (DocCash.People != null!)
                        {
                            if (!string.IsNullOrEmpty(DocCash.People.SurnameRp))
                            {
                                DocCash.From = DocCash.People.SurnameRp + " " + DocCash.People.NameRp + " " +
                                               DocCash.People.PatronymicRp;
                            }
                            else
                            {
                                DocCash.From = DocCash.People.Surname + " " + DocCash.People.Name + " " +
                                               DocCash.People.Patronymic;
                            }
                        }

                        DocCash.Nds =
                            (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
                        break;
                    case 6: //Возврат от поставщика

                        break;

                    case 8: //Выдача подотчетному лицу
                        if (DocCash.People != null!)
                        {
                            if (!string.IsNullOrEmpty(DocCash.People.SurnameDp))
                            {
                                DocCash.From = DocCash.People.SurnameDp + " " + DocCash.People.NameDp + " " +
                                               DocCash.People.PatronymicDp;
                            }
                            else
                            {
                                DocCash.From = DocCash.People.Surname + " " + DocCash.People.Name + " " +
                                               DocCash.People.Patronymic;
                            }
                        }

                        NamePeople = "Подотчетное лицо:";
                        DocCash.Footing = "В подотчет";

                        DocCash.Nds =
                            (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
                        break;
                    case 9: //Оплата поставщику

                        break;
                    case 10: //Выплата заработной платы по ведомостям
                        if (string.IsNullOrEmpty(DocCash.Footing)) DocCash.Footing = "Выдача заработной платы";
                        DocCash.FoundationDoc = "Платежная ведомость №  от";
                        DocCash.From = "Работникам организации";
                        DocCash.Nds =
                            (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
                        break;
                    case 11: //Выплата заработной платы работнику
                        if (DocCash.People != null!)
                        {
                            if (!string.IsNullOrEmpty(DocCash.People.SurnameDp))
                            {
                                DocCash.From = DocCash.People.SurnameDp + " " + DocCash.People.NameDp + " " +
                                               DocCash.People.PatronymicDp;
                            }
                            else
                            {
                                DocCash.From = DocCash.People.Surname + " " + DocCash.People.Name + " " +
                                               DocCash.People.Patronymic;
                            }
                        }
                        DocCash.Footing = "Выдача заработной платы";
                        DocCash.Nds =
                            (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
                        break;
                    case 12: //Выплата по договору подряда
                        if (DocCash.People != null!)
                        {
                            if (!string.IsNullOrEmpty(DocCash.People.SurnameDp))
                            {
                                DocCash.From = DocCash.People.SurnameDp + " " + DocCash.People.NameDp + " " +
                                               DocCash.People.PatronymicDp;
                            }
                            else
                            {
                                DocCash.From = DocCash.People.Surname + " " + DocCash.People.Name + " " +
                                               DocCash.People.Patronymic;
                            }
                        }
                        DocCash.Footing = "Вознаграждение по Договору ГПХ № от ";
                        DocCash.Nds =
                            (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
                        break;
                    case 13: //Выдача займа работнику
                        if (DocCash.People != null!)
                        {
                            if (!string.IsNullOrEmpty(DocCash.People.SurnameDp))
                            {
                                DocCash.From = DocCash.People.SurnameDp + " " + DocCash.People.NameDp + " " +
                                               DocCash.People.PatronymicDp;
                            }
                            else
                            {
                                DocCash.From = DocCash.People.Surname + " " + DocCash.People.Name + " " +
                                               DocCash.People.Patronymic;
                            }
                        }
                        DocCash.Footing = "Выдача займа работнику по договору займа № от ";
                        DocCash.Nds =
                            (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
                        break;
                    case 14: //Взнос наличными в банк
                        DocCash.Footing =
                            "Для зачисления на расчетный счет в";
                        DocCash.Nds =
                            (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(n => n.Id == 1);
                        break;

                    default:

                        break;
                }
            }
            else
            {
                _notificationManager.Show("Редактор документов",
                    "Для заполнения полей печатной формы выберите Тип операции", NotificationType.Warning);
            }
        }
        catch (Exception e)
        {
            string message = e.Message;
            if (e.InnerException != null)
                message = e.InnerException.Message;

            _notificationManager.Show("Редактор документов",
                $"При заполнении печатной формы произошла ошибка: {message}", NotificationType.Error);
        }
    }

    #endregion

    #region LookPrint

    private ICommand? _lookCommand;

    public ICommand LookCommand => _lookCommand
        ??= new RelayCommand(OnLookExecuted, LookCan);

    private bool LookCan(object arg)
    {
        return DocCash != null!;
    }

    private async void OnLookExecuted(object obj)
    {
        var view = new LookView();
        var model = view.DataContext as LookViewModel;
        model!.Sours = ReportExcelLib.Kassa.KassaLook.GetLook(DocCash);
        view.ShowDialog();
    }

    #endregion

    #endregion
}