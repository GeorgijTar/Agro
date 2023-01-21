﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Bank.Pay;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Pages.Invoice;
using Agro.WPF.Views.Windows.Invoice;
using Microsoft.Win32;
using Notification.Wpf;
using ReportExcelLib;

namespace Agro.WPF.ViewModels.InvoiceVM;

public class InvoicesViewModel : ViewModel
{
    private readonly IInvoiceRepository<DAL.Entities.InvoiceEntity.Invoice> _repository;
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IHelperNavigation _helperNavigation;
    private readonly INotificationManager _notificationManager;

    private ObservableCollection<DAL.Entities.InvoiceEntity.Invoice> _invoices = new();

    public ObservableCollection<DAL.Entities.InvoiceEntity.Invoice> Invoices { get => _invoices; set => Set(ref _invoices, value); }

    private DAL.Entities.InvoiceEntity.Invoice _selectedInvoice = null!;

    public DAL.Entities.InvoiceEntity.Invoice SelectedInvoice { get => _selectedInvoice; set => Set(ref _selectedInvoice, value); }

    private TypeDoc _typeInvoice = new();
    public TypeDoc TypeInvoice
    {
        get => _typeInvoice;
        set
        {
            Set(ref _typeInvoice, value);
            if (TypeInvoice.Id == 9)
                VisibilityReestr = Visibility.Visible;
        }
    }

    private Visibility _visibilityButton = Visibility.Hidden;
    public Visibility VisibilityButton { get => _visibilityButton; set => Set(ref _visibilityButton, value); }

    private Visibility _visibilityReestr = Visibility.Hidden;
    public Visibility VisibilityReestr { get => _visibilityReestr; set => Set(ref _visibilityReestr, value); }


    private IEnumerable<Nds>? _nds = new HashSet<Nds>();
    public IEnumerable<Nds>? Nds { get => _nds; set => Set(ref _nds, value); }


    private string _numberFilter = null!;
    public string NumberFilter { get => _numberFilter; set => Set(ref _numberFilter, value); }


    private DateTime? _dateOnFilter;
    public DateTime? DateOnFilter { get => _dateOnFilter; set => Set(ref _dateOnFilter, value); }


    private DateTime? _dateOffFilter;
    public DateTime? DateOffFilter { get => _dateOffFilter; set => Set(ref _dateOffFilter, value); }


    private string _innFilter = null!;
    public string InnFilter { get => _innFilter; set => Set(ref _innFilter, value); }


    private string _nameFilter = null!;
    public string NameFilter { get => _nameFilter; set => Set(ref _nameFilter, value); }

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    private ObservableCollection<Status> _statusColl = new();
    public ObservableCollection<Status> StatusColl { get => _statusColl; set => Set(ref _statusColl, value); }

    private Status? _statusFilter;

    public Status? StatusFilter
    {
        get => _statusFilter;
        set => Set(ref _statusFilter, value);
    }

    private decimal _limit;

    public InvoicesViewModel(
        IInvoiceRepository<DAL.Entities.InvoiceEntity.Invoice> repository,
        IBaseRepository<Status> statusRepository,
        IHelperNavigation helperNavigation,
        INotificationManager notificationManager)
    {
        _repository = repository;
        _statusRepository = statusRepository;
        _helperNavigation = helperNavigation;
        _notificationManager = notificationManager;
        Title = "Реестр счетов";
        LoadData();
        CollectionView = CollectionViewSource.GetDefaultView(Invoices);
        PropertyChanged += ViewChanged;
    }

    private void ViewChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {

            case "NumberFilter":
                CollectionView.Filter = FilterByNumber;
                break;
            case "DateOnFilter":
                CollectionView.Filter = FilterByDate;
                break;
            case "DateOffFilter":
                CollectionView.Filter = FilterByDate;
                break;
            case "InnFilter":
                CollectionView.Filter = FilterByInn;
                break;
            case "NameFilter":
                CollectionView.Filter = FilterByName;
                break;
            case "StatusFilter":
                CollectionView.Filter = FilterByStatus;
                break;
        }
    }
    private async void LoadData()
    {
        _limit = await _repository.GetLimit()!;
        Invoices.Clear();
        var invoices = await _repository.GetAllNoTrackingAsync();
        invoices = invoices!.Where(x => x.Status!.Id != 6).Where(x => x.Type.Id == TypeInvoice.Id);
        foreach (var invoice in invoices)
        {
            Invoices.Add(invoice);
        }
        var statusTmp = StatusFilter;
        StatusColl.Clear();
        StatusColl.Add(new Status() { Id = 0, Name = "Все" });
        var statuses = invoices.Select(i => i.Status).Distinct().ToArray();
        foreach (var status in statuses)
        {
            StatusColl.Add(status!);
        }

        if (statusTmp! == null!)
        {
            StatusFilter = StatusColl[0];
        }
        else
        {
            StatusFilter = statusTmp;
        }


        Nds = await _repository.GetAllNds();
    }

    #region Filters

    private bool FilterByStatus(object obj)
    {
        if (StatusFilter != null! && StatusFilter.Id != 0)
        {
            DAL.Entities.InvoiceEntity.Invoice? dto = obj as DAL.Entities.InvoiceEntity.Invoice;
            return dto!.Status!.Name.ToUpper().Contains(StatusFilter.Name.ToUpper());
        }
        return true;
    }

    private bool FilterByName(object obj)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            DAL.Entities.InvoiceEntity.Invoice? dto = obj as DAL.Entities.InvoiceEntity.Invoice;
            return dto!.Counterparty.Name.ToUpper().Contains(NameFilter.ToUpper()) |
                   dto.Counterparty.PayName.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByInn(object obj)
    {
        if (!string.IsNullOrEmpty(InnFilter))
        {
            DAL.Entities.InvoiceEntity.Invoice? dto = obj as DAL.Entities.InvoiceEntity.Invoice;
            return dto!.Counterparty.Inn.ToUpper().Contains(InnFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByDate(object obj)
    {
        if (DateOnFilter <= DateOffFilter)
        {
            DAL.Entities.InvoiceEntity.Invoice? dto = obj as DAL.Entities.InvoiceEntity.Invoice;
            return dto!.DateInvoice.Date >= DateOnFilter!.Value.Date & dto.DateInvoice.Date <= DateOffFilter!.Value.Date;
        }

        return true;
    }

    private bool FilterByNumber(object obj)
    {
        if (!string.IsNullOrEmpty(NumberFilter))
        {
            DAL.Entities.InvoiceEntity.Invoice? dto = obj as DAL.Entities.InvoiceEntity.Invoice;
            return dto!.Number.ToUpper().Contains(NumberFilter.ToUpper());
        }
        return true;
    }

    #endregion



    #region Commands

    #region Add

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted);

    private async void OnAddCommandExecuted(object obj)
    {
        var page = new InvoicePage();
        var model = page.DataContext as InvoiceViewModel;

        model!.Nds = Nds;
        model.SenderModel = this;
        model.Invoice!.Type = TypeInvoice;
        if (TypeInvoice.Id == 8)
        {
            model.VisibilityNumeric = Visibility.Visible;
            model.VisibilityBankOrg = Visibility.Visible;
        }

        model.TabItem = _helperNavigation.OpenPage(page, $"Новый счет на оплату ({TypeInvoice.Name})");
    }

    #endregion

    #region Edit

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditCommandExecuted, EditCommandExecut);

    private bool EditCommandExecut(object arg)
    {
        return SelectedInvoice != null! && SelectedInvoice.Status!.Id == 1;
    }

    private async void OnEditCommandExecuted(object obj)
    {
        var page = new InvoicePage();
        var model = page.DataContext as InvoiceViewModel;
        model!.Nds = Nds;
        model.Invoice = await _repository.GetByIdAsync(SelectedInvoice.Id);
        model.IsEdit = true;
        model.SenderModel = this;
        if (TypeInvoice.Id == 8)
        {
            model.VisibilityNumeric = Visibility.Visible;
            model.VisibilityBankOrg = Visibility.Visible;
        }
        model.TabItem = _helperNavigation.OpenPage(page, $"Редактирование счета на оплату ({TypeInvoice.Name}) № {SelectedInvoice.Number} от {SelectedInvoice.DateInvoice.ToShortDateString()}");
    }

    #endregion

    #region Delete

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanDeleteExecuted);

    private bool CanDeleteExecuted(object arg)
    {
        return SelectedInvoice != null! && SelectedInvoice.Status!.Id == 1;
    }

    private async void OnDeleteExecuted(object obj)
    {
        try
        {
            SelectedInvoice = await _repository.SetStatusAsync(6, SelectedInvoice);
            _notificationManager.Show("Логер", "Счет успешно удален!", NotificationType.Information);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"При удалении счета возникла ошибка: {e.Message}", NotificationType.Error);
        }

    }

    #endregion

    #region Print

    private ICommand? _printCommand;

    public ICommand PrintCommand => _printCommand
        ??= new RelayCommand(OnPrintCommandExecuted, PrintCommandCanExecut);

    private bool PrintCommandCanExecut(object arg)
    {
        return SelectedInvoice != null! && SelectedInvoice.Type.Id == 8;
    }

    private async void OnPrintCommandExecuted(object obj)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.DefaultExt = "*.xlsx";
        saveFileDialog.FileName = $"Счет на оплату № {SelectedInvoice.Number} от {SelectedInvoice.DateInvoice.ToShortDateString()}";
        saveFileDialog.Filter = "Microsoft Excel (*.xlsx)|*.xlsx";
        if (saveFileDialog.ShowDialog() == true)
        {
            InvoiceReportExcel.Print(saveFileDialog.FileName, await _repository.GetByIdAsync(SelectedInvoice.Id));
        }
    }

    #endregion

    #region SelectRow

    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowExecuted, CanSelectRowExecuted);

    private bool CanSelectRowExecuted(object arg)
    {
        return SelectedInvoice != null!;
    }

    private async void OnSelectRowExecuted(object obj)
    {


        if (SenderModel != null!)
        {
            if (SenderModel is PaymentOrderViewModel paymentOrderViewModel)
            {
                try
                {
                    paymentOrderViewModel.PaymentOrder!.Invoice = (await _repository.GetByIdAsync(SelectedInvoice.Id))!;
                    var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                    if (window != null!)
                        window.Close();
                }
                catch (Exception e)
                {
                    _notificationManager.Show("Логер", $"При вставке счета №{SelectedInvoice.Number} от {SelectedInvoice.DateInvoice.ToShortDateString()} возникла ошибка: {e.Message}", NotificationType.Error);
                }

            }
        }
        else
        {
            try
            {
                var page = new InvoicePage();
                var model = page.DataContext as InvoiceViewModel;
                model!.Nds = Nds;
                model.BankDetailsOrg = await _repository.GetAllBankDetailsOrg();
                model.Invoice = await _repository.GetByIdAsync(SelectedInvoice.Id);
                model.ButtonActivity = false;
                model.IsEdit = true;
                model.SenderModel = this;
                if (TypeInvoice.Id == 8)
                {
                    model.VisibilityNumeric = Visibility.Visible;
                    model.VisibilityBankOrg = Visibility.Visible;
                }
                model.TabItem = _helperNavigation.OpenPage(page, $"Счет на оплату ({TypeInvoice.Name}) № {SelectedInvoice.Number} от {SelectedInvoice.DateInvoice.ToShortDateString()}");
            }
            catch (Exception e)
            {
                _notificationManager.Show("Логер", $"При открытии счета №{SelectedInvoice.Number} от {SelectedInvoice.DateInvoice.ToShortDateString()} возникла ошибка: {e.Message}", NotificationType.Error);
            }

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

    #region RegistryInvoceForm

    private ICommand? _registryInvoceFormCommand;

    public ICommand RegistryInvoceFormCommand => _registryInvoceFormCommand
        ??= new RelayCommand(OnRegistryInvoceFormExecuted, CanRegistryInvoceFormExecuted);

    private bool CanRegistryInvoceFormExecuted(object arg)
    {
        return Invoices.Any(i => i.Status!.Id == 8);
    }

    private void OnRegistryInvoceFormExecuted(object obj)
    {
        var view = new RegistryInvoiceView();
        view.ShowDialog();
    }

    #endregion

    #region ContecstMenu

    #region billing 
    /// <summary>
    /// Выставление счета
    /// </summary>

    private ICommand? _billingCommand;

    public ICommand BillingCommand => _billingCommand
        ??= new RelayCommand(OnBillingExecuted, CanBillingExecuted);

    private bool CanBillingExecuted(object arg)
    {
        return SelectedInvoice != null! && SelectedInvoice!.Type.Id == 8 && SelectedInvoice.Status!.Id == 1;
    }

    private async void OnBillingExecuted(object obj)
    {
        try
        {
            SelectedInvoice.Status = (await _repository.SetStatusAsync(11, SelectedInvoice)).Status;
            
            _notificationManager.Show("Логер",
                $"Статус счета успешно изменен на \"{SelectedInvoice.Status!.Name}\"",
                NotificationType.Information);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер",
                $"При изменении статуса счета произошла ошибка: {e.Message}",
                NotificationType.Error);
        }
    }

    #endregion

    #region acceptance
    /// <summary>
    /// Принятие счета
    /// </summary>
    private ICommand? _acceptanceCommand;

    public ICommand AcceptanceCommand => _acceptanceCommand
        ??= new RelayCommand(OnAcceptanceExecuted, CanAcceptanceExecuted);

    private bool CanAcceptanceExecuted(object arg)
    {

        return SelectedInvoice != null! && SelectedInvoice.Type.Id == 9 && SelectedInvoice.Status!.Id == 1;



    }

    private async void OnAcceptanceExecuted(object obj)
    {
        try
        {

            if (SelectedInvoice.TotalAmount > _limit)
            {
              SelectedInvoice.Status =  (await _repository.SetStatusAsync(8, SelectedInvoice)).Status;
            }
            else
            {
                SelectedInvoice.Status = (await _repository.SetStatusAsync(9, SelectedInvoice)).Status;
            }
           
            _notificationManager.Show("Логер",
                $"Статус счета успешно изменен на \"{SelectedInvoice.Status!.Name}\"",
                NotificationType.Information);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер",
                $"При изменении статуса счета произошла ошибка: {e.Message}",
                NotificationType.Error);
        }


    }

    #endregion

    #region Return

    private ICommand? _returnCommand;

    public ICommand ReturnCommand => _returnCommand
        ??= new RelayCommand(OnReturnExecuted, CanReturnExecuted);

    private bool CanReturnExecuted(object arg)
    {
        return SelectedInvoice != null! && SelectedInvoice.Status!.Id != 1 && SelectedInvoice.Status!.Id != 15;
    }

    private async void OnReturnExecuted(object obj)
    {
        try
        {
            SelectedInvoice.Status =(await _repository.SetStatusAsync(1, SelectedInvoice)).Status;
            _notificationManager.Show("Логер",
                $"Статус счета успешно изменен на \"{SelectedInvoice.Status!.Name}\"",
                NotificationType.Information);
        }
        catch (Exception e)
        {

            _notificationManager.Show("Логер", $"При изменении статуса возникла ошибка: {e.Message}", NotificationType.Error);
        }

    }

    #endregion

    #endregion

    #endregion
}