using System;
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
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.InvoiceVM;
using Agro.WPF.Views.Windows.Contract;
using Microsoft.Extensions.Logging;

namespace Agro.WPF.ViewModels.Contract;

public class ContractsViewModel : ViewModel
{
    private readonly IContractRepository<DAL.Entities.Counter.Contract> _contractRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly ILogger<ContractsViewModel> _logger;
    
    public int GroupId { get; set; }
    public ContractsViewModel(IContractRepository<DAL.Entities.Counter.Contract> contractRepository, 
        IBaseRepository<Status> statusRepository, ILogger<ContractsViewModel> logger)
    {
        _contractRepository = contractRepository;
        _statusRepository = statusRepository;
        _logger = logger;
        Title = "Реестр контрактов";
        LoadData();
        this.PropertyChanged += ModelChanged;
    }

    private async void LoadData()
    {
        Contracts.Clear();
        var contracts = await _contractRepository.GetAllByNoIdStatusAsync(6);
        if (GroupId != 0)
        {
            contracts = contracts!.Where(c => c.Group.Id == GroupId).ToList();
        }
        
        foreach (var contract in contracts!)
        {
            Contracts.Add(contract);
        }
        CollectionView = CollectionViewSource.GetDefaultView(Contracts);
       
    }

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<DAL.Entities.Counter.Contract> _contracts = new();
    public ObservableCollection<DAL.Entities.Counter.Contract> Contracts { get => _contracts; set => Set(ref _contracts, value); }


    private DAL.Entities.Counter.Contract _selectedContract = null!;
    public DAL.Entities.Counter.Contract SelectedContract { get => _selectedContract; set => Set(ref _selectedContract, value); }

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView 
    { 
        get => _collectionView; set
    {
        Set(ref _collectionView, value);
        if (value != null!)
        {
            if (!string.IsNullOrEmpty(InnFilter))
            {
                CollectionView.Filter = FilterByInn;
            }

        }
    }
    }

    private string _namefilter = null!;
    public string NameFilter { get => _namefilter; set => Set(ref _namefilter, value); }


    private string _innFilter = null!;
    public string InnFilter { get => _innFilter; set=> Set(ref _innFilter, value); }


    private string _numberFilter = null!;
    public string NumberFilter { get => _numberFilter; set => Set(ref _numberFilter, value); }
    public object SenderModel { get; set; } = null!;

    public void ModelChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (CollectionView != null!)
        {
            switch (e.PropertyName)
            {
                case "NameFilter":
                    CollectionView.Filter = FilterByName;
                    break;
                case "InnFilter":
                    CollectionView.Filter = FilterByInn;
                    break;
                case "NumberFilter":
                    CollectionView.Filter = FilterByNumber;
                    break;
            }
        }
    }

    #region Filter

    private bool FilterByName(object count)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            DAL.Entities.Counter.Contract? dto = count as DAL.Entities.Counter.Contract;
            return dto!.Counterparty.Name.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByInn(object count)
    {
        if (!string.IsNullOrEmpty(InnFilter))
        {
            DAL.Entities.Counter.Contract? dto = count as DAL.Entities.Counter.Contract;
            return dto!.Counterparty.Inn.ToUpper().Contains(InnFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByNumber(object count)
    {
        if (!string.IsNullOrEmpty(NumberFilter))
        {
            DAL.Entities.Counter.Contract? dto = count as DAL.Entities.Counter.Contract;
            return dto!.Number.ToUpper().Contains(NumberFilter.ToUpper());
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
        var view = new ContractView();
        var model = view.DataContext as ContractViewModel;
        model!.SenderModel=this;
        model.Title = "Добавление нового договора";
        model.Contract = new DAL.Entities.Counter.Contract();
        view.Show();
        
    }
    
    #endregion

    #region Edet

    private ICommand? _edetCommand;

    public ICommand EdetCommand => _edetCommand
        ??= new RelayCommand(OnEdetExecuted, CanEdetExecuted);

    private bool CanEdetExecuted(object arg)
    {
        return SelectedContract != null!;
    }

    private void OnEdetExecuted(object obj)
    {
        var view = new ContractView();
        var model = view.DataContext as ContractViewModel;
        model!.SenderModel = this;
        model.IsEdete = true;
        model.Title = "Редактирование договора";
        model.Contract = SelectedContract;
        view.Show();
    }

    #endregion

    #region Delete

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanDeleteExecuted);

    private bool CanDeleteExecuted(object arg)
    {
        return SelectedContract != null!;
    }

    private async void OnDeleteExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить " +
                                     $"{SelectedContract.Type.Name} № {SelectedContract.Number} от {SelectedContract.Date.ToShortDateString()}",
            "Редактор документов", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            SelectedContract.Status = await _statusRepository.GetByIdAsync(6);
            await _contractRepository.UpdateAsync(SelectedContract);
            Contracts.Remove(SelectedContract);
        }

        
        
    }

    #endregion

    #region SelectRow

    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowExecuted, CanSelectRowExecuted);

    private bool CanSelectRowExecuted(object arg)
    {
        return SelectedContract != null!;
    }

    private void OnSelectRowExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is InvoiceViewModel invoice)
            {
                invoice.Invoice.Contract=SelectedContract;
                if (SelectedContract.Specification!=null! && SelectedContract.Specification!.Count == 1)
                {
                    invoice.Invoice.Specification = SelectedContract.Specification![0];
                }
                if (invoice.Invoice.Counterparty == null!)
                {
                    invoice.Invoice.Counterparty = SelectedContract.Counterparty;
                    invoice.Invoice.BankDetails = SelectedContract.BankDetails;
                    invoice.Invoice.BankDetailsOrg = SelectedContract.BankDetailsOrg;
                }

            }
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }

    #endregion
    #endregion
}