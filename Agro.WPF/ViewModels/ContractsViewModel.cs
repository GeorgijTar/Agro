using System.Collections.ObjectModel;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels;

public class ContractsViewModel : ViewModel
{
    private readonly IContractRepository<Contract> _contractRepository;

    public ContractsViewModel(IContractRepository<Contract> contractRepository)
    {
        _contractRepository = contractRepository;
        Title = "Реестр контрактов";
        LoadData();
    }

    private async void LoadData()
    {
        var contracts = await _contractRepository.GetAllAsync();
        foreach (var contract in contracts!)
        {
            Contracts.Add(contract);
        }
    }

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<Contract> _contracts = null!;
    public ObservableCollection<Contract> Contracts { get => _contracts; set => Set(ref _contracts, value); }


    private Contract _selectedContract = null!;
    public Contract SelectedContract { get => _selectedContract; set => Set(ref _selectedContract, value); } 


}