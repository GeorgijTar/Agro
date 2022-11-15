using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Invoice;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Agro.WPF.ViewModels.InvoiceVM;
public class RegistryInvoiceViewModel : ViewModel
{
    private readonly IRegistryInvoiceRepository<RegistryInvoice> _registryInvoiceRepository;

    private RegistryInvoice _registryInvoice = new(){Invoices = new ObservableCollection<Invoice>()};
    public RegistryInvoice RegistryInvoice { get => _registryInvoice; set => Set(ref _registryInvoice, value); }

    private Invoice _invoice = null!;
    public Invoice Invoice { get => _invoice; set => Set(ref _invoice, value); }
    
    private decimal _amountInvoice;
    public decimal AmountInvoice { get => _amountInvoice; set => Set(ref _amountInvoice, value); }

    public RegistryInvoiceViewModel(IRegistryInvoiceRepository<RegistryInvoice> registryInvoiceRepository)
    {
        _registryInvoiceRepository = registryInvoiceRepository;
        LoadData();
        RegistryInvoice.Invoices.CollectionChanged += ChangedInvoises;
    }

    private void ChangedInvoises(object? sender, NotifyCollectionChangedEventArgs e)
    {
        AmountInvoice = RegistryInvoice.Invoices.Sum(s => s.TotalAmount);
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
        return RegistryInvoice.Invoices.Any() && RegistryInvoice.Number>0 && AmountInvoice>0;
    }

    private async void OnSaveExecuted(object obj)
    {
        foreach (var registryInvoiceInvoice in RegistryInvoice.Invoices)
        {
            registryInvoiceInvoice.Status = await _registryInvoiceRepository.GetStatusAsync(15);
        }
        var reg = await _registryInvoiceRepository.SaveAsync(RegistryInvoice);
        var registry = await _registryInvoiceRepository.SetStatusAsync(17, reg);
       
        RegistryInvoice = registry;
        if (Application.Current.Windows.OfType<RegistryInvoicesView>().Any())
        {
          var r=  Application.Current.Windows.OfType<RegistryInvoicesView>().ToArray();
            //r[0].Window.Visibility = Visibility.Visible;
            //r[0].Window.Focusable= true;
            r[0].Window.Activate();
        }
        else
        {
            var view = new RegistryInvoicesView();
            view.Show();
        }
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    #endregion

    #endregion


}