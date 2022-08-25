using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Weight;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Personnel;
using System.Windows.Input;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Storage;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.ViewModels.Agronomy;
using Agro.WPF.Views.Windows.Agronomy;
using Agro.WPF.Views.Windows.Weight;

namespace Agro.WPF.ViewModels.Weight;

public class ComingFieldViewModel: ViewModel
{
    private readonly IBaseRepository<ComingField> _comingFieldRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IBaseRepository<DAL.Entities.Weight.Weight> _weightRepository;
    private readonly IBaseRepository<StorageLocation> _storageLocationRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    
    private ComingField _comingField = new();
    public ComingField ComingField { get => _comingField; set => Set(ref _comingField, value); }

    
    private IEnumerable<DAL.Entities.Weight.Weight> _weights = null!;
    public IEnumerable<DAL.Entities.Weight.Weight> Weights { get => _weights; set => Set(ref _weights, value); }


    private IEnumerable<StorageLocation>? _storageLocations = null!;
    public IEnumerable<StorageLocation>? StorageLocations { get => _storageLocations; set => Set(ref _storageLocations, value); } 


    public object SenderModel { get; set; } = null!;

    public ComingFieldViewModel(
        IBaseRepository<ComingField> comingFieldRepository, 
        IBaseRepository<Status> statusRepository,
        IBaseRepository<DAL.Entities.Weight.Weight> weightRepository,
        IBaseRepository<StorageLocation> storageLocationRepository)
    {
        _comingFieldRepository = comingFieldRepository;
        _statusRepository = statusRepository;
        _weightRepository = weightRepository;
        _storageLocationRepository = storageLocationRepository;
        LoadData();
    }

    private async void LoadData()
    {
        var wes = await _weightRepository.GetAllAsync();
        wes = wes?.Where(w => w.Status?.Id == 5);
        Weights = wes!;

        var strLocs = await _storageLocationRepository.GetAllAsync();
        StorageLocations = strLocs?.Where(str => str.Status?.Id == 5).ToArray();

    }


    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return ComingField != null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        ComingField.Status = await _statusRepository.GetByIdAsync(1);
        var cult = await _comingFieldRepository.SaveAsync(ComingField);
        //if (SenderModel is DivisionsViewModel divisionsViewModel)
        //{
        //    var cl = divisionsViewModel.Divisions.FirstOrDefault(x => x.Id == cult.Id);
        //    if (cl != null!)
        //    {
        //        cl = cult;
        //    }
        //    else
        //    {
        //        divisionsViewModel.Divisions.Add(cult);
        //    }
        //}

        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }


    private ICommand? _showFieldsCommand;

    public ICommand ShowFieldsCommand => _showFieldsCommand
        ??= new RelayCommand(OnShowFieldsExecuted);

    private void OnShowFieldsExecuted(object obj)
    {
        var view = new FieldsView();
        var mod = view.DataContext as FieldsViewModel;
        mod!.Title = "Выбирите поле";
        mod.SenderModel = this;
        view.DataContext= mod;
        view.ShowDialog();
    }
    
    private ICommand? _showCulturesCommand;

    public ICommand ShowCulturesCommand => _showCulturesCommand
        ??= new RelayCommand(OnShowCulturesExecuted);

    private void OnShowCulturesExecuted(object obj)
    {
        var view = new CulturesView();
        var mod = view.DataContext as CulturesViewModel;
        mod!.Title = "Выбирите культуру";
        mod.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }
    
    private ICommand? _showDriversCommand;

    public ICommand ShowDriversCommand => _showDriversCommand
        ??= new RelayCommand(OnShowDriversExecuted);

    private void OnShowDriversExecuted(object obj)
    {
        var view = new DriversView();
        var mod = view.DataContext as DriversViewModel;
        mod!.Title = "Выбирите водителя";
        mod.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }

    
    private ICommand? _showTransportCommand;

    public ICommand ShowTransportCommand => _showTransportCommand
        ??= new RelayCommand(OnShowTransportExecuted);

    private void OnShowTransportExecuted(object obj)
    {
        var view = new TransportsView();
        var mod = view.DataContext as TransportsViewModel;
        mod!.Title = "Выбирите автомобиль";
        mod.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }


    private ICommand? _clearFieldsCommand;

    public ICommand ClearFieldCommand => _clearFieldsCommand
        ??= new RelayCommand(OnClearFieldsExecuted, CanClearFieldsExecuted);

    private bool CanClearFieldsExecuted(object arg)
    {
        return ComingField.Field != null!;
    }

    private void OnClearFieldsExecuted(object obj)
    {
        ComingField.Field= null!;
    }


    private ICommand? _clearCultureCommand;

    public ICommand ClearCultureCommand => _clearCultureCommand
        ??= new RelayCommand(OnClearCultureExecuted, CanClearCultureExecuted);

    private bool CanClearCultureExecuted(object arg)
    {
        return ComingField.Culture != null!;
    }

    private void OnClearCultureExecuted(object obj)
    {
        ComingField.Culture = null!;
    }
    


    #endregion
}
