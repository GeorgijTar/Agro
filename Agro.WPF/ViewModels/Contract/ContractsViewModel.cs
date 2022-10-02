using System.Collections.ObjectModel;
using System.Windows.Input;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Contract;

namespace Agro.WPF.ViewModels.Contract;

public class ContractsViewModel : ViewModel
{
    private readonly IBaseRepository<DAL.Entities.Counter.Contract> _contractRepository;

    public ContractsViewModel(IBaseRepository<DAL.Entities.Counter.Contract> contractRepository)
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


    private ObservableCollection<DAL.Entities.Counter.Contract> _contracts = null!;
    public ObservableCollection<DAL.Entities.Counter.Contract> Contracts { get => _contracts; set => Set(ref _contracts, value); }


    private DAL.Entities.Counter.Contract _selectedContract = null!;
    public DAL.Entities.Counter.Contract SelectedContract { get => _selectedContract; set => Set(ref _selectedContract, value); }

    #region Commands

    #region Add

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var view = new ContractView();
        var model = view.DataContext as ContractViewModel;
        model!.SenderModel=this;
        model.Contract = new DAL.Entities.Counter.Contract();
        view.Show();
    }

    #endregion

    #endregion
}