using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Contract;
using Agro.WPF.Views.Pages.Invoice;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.InvoiceVM;
public class RegistryInvoiceViewModel : ViewModel
{
    private readonly IRegistryInvoiceRepository<RegistryInvoice> _registryInvoiceRepository;
    private readonly IHelperNavigation _helperNavigation;
    private readonly INotificationManager _notificationManager;

    private RegistryInvoice _registryInvoice = new() { Invoices = new ObservableCollection<Invoice>() };
    public RegistryInvoice RegistryInvoice { get => _registryInvoice; set => Set(ref _registryInvoice, value); }

    private Invoice _invoice = null!;
    public Invoice Invoice { get => _invoice; set => Set(ref _invoice, value); }

    private decimal _amountInvoice;
    public decimal AmountInvoice { get => _amountInvoice; set => Set(ref _amountInvoice, value); }

    public RegistryInvoiceViewModel(
        IRegistryInvoiceRepository<RegistryInvoice> registryInvoiceRepository,
        IHelperNavigation helperNavigation,
        INotificationManager notificationManager)
    {
        _registryInvoiceRepository = registryInvoiceRepository;
        _helperNavigation = helperNavigation;
        _notificationManager = notificationManager;
        LoadData();
        RegistryInvoice.Invoices!.CollectionChanged += ChangedInvoises;
    }

    private void ChangedInvoises(object? sender, NotifyCollectionChangedEventArgs e)
    {
        AmountInvoice = RegistryInvoice.Invoices!.Sum(s => s.TotalAmount);
    }

    private async void LoadData()
    {
        RegistryInvoice.Status = await _registryInvoiceRepository.GetStatusAsync(1);
        RegistryInvoice.Number = await _registryInvoiceRepository.GetNumberRegisterAsync();
        RegistryInvoice.Invoices = new();
        var invoices = await _registryInvoiceRepository.GetRegisterAcceptAsync();

        foreach (var invoice in invoices!)
        {
            RegistryInvoice.Invoices.Add(invoice);
        }
        AmountInvoice = RegistryInvoice.Invoices.Sum(s => s.TotalAmount);
    }



    #region Commands

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return RegistryInvoice.Invoices != null && RegistryInvoice.Invoices.Any() && RegistryInvoice.Number > 0 && AmountInvoice > 0;
    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {
            foreach (var registryInvoiceInvoice in RegistryInvoice.Invoices!)
            {
                registryInvoiceInvoice.Status = await _registryInvoiceRepository.GetStatusAsync(15);
            }
            var reg = await _registryInvoiceRepository.SaveAsync(RegistryInvoice);
            var registry = await _registryInvoiceRepository.SetStatusAsync(17, reg);

            RegistryInvoice = registry;

            var page = new RegistryInvoicesPage();
            var model = page.DataContext as RegistryInvoicesViewModel;
            model!.TabItem = _helperNavigation.OpenPage(page, "Реестр счетов на оплату");

            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
            _notificationManager.Show("Логер","Реестр счетов на оплату успешно добавлен!", NotificationType.Information);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"Произошла ошибка при добавлении реестра: {e.Message}", NotificationType.Error);
        }
    }

    #endregion

    #endregion


}