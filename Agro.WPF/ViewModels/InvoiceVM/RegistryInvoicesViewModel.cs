
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Agro.DAL.Entities;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels.InvoiceVM;

public class RegistryInvoicesViewModel : ViewModel
{
    private readonly IRegistryInvoiceRepository<RegistryInvoice> _registryInvoiceRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<RegistryInvoice> _registryInvoices = new();
    public ObservableCollection<RegistryInvoice> RegistryInvoices { get => _registryInvoices; set => Set(ref _registryInvoices, value); }

    private RegistryInvoice _registryInvoice = null!;
    public RegistryInvoice RegistryInvoice { get => _registryInvoice; set => Set(ref _registryInvoice, value); }

    private IEnumerable<Status> _statusEnumerable = null!;
    public IEnumerable<Status> StatusEnumerable { get => _statusEnumerable; set => Set(ref _statusEnumerable, value); } 


    public RegistryInvoicesViewModel(IRegistryInvoiceRepository<RegistryInvoice> registryInvoiceRepository)
    {
        _registryInvoiceRepository = registryInvoiceRepository;
        Title = "Список реестров на оплату";
        LoadData();
    }

    private async void LoadData()
    {
        RegistryInvoices.Clear();
        var reg = await _registryInvoiceRepository.GetAllByIdNoAsync(6);
        StatusEnumerable = reg.Select(r => r.Status).Distinct().ToArray();
        foreach (var registry in reg)
        {
            RegistryInvoices.Add(registry);
        }
    }
}

