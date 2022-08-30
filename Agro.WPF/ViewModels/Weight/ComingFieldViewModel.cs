using Agro.DAL.Entities.Weight;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Agro.DAL.Entities.Storage;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.ViewModels.Agronomy;
using Agro.WPF.Views.Windows.Agronomy;
using Agro.WPF.Views.Windows.Weight;

namespace Agro.WPF.ViewModels.Weight;

public class ComingFieldViewModel : ViewModel
{
    private readonly IComingFieldRepository<ComingField> _comingFieldRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ComingField _comingField = new();
    public ComingField ComingField { get => _comingField; set => Set(ref _comingField, value); }


    private IEnumerable<DAL.Entities.Weight.Weight>? _weights;
    public IEnumerable<DAL.Entities.Weight.Weight>? Weights { get => _weights; set => Set(ref _weights, value); }


    private IEnumerable<StorageLocation>? _storageLocations;
    public IEnumerable<StorageLocation>? StorageLocations { get => _storageLocations; set => Set(ref _storageLocations, value); }


    public object SenderModel { get; set; } = null!;

    public ComingFieldViewModel(IComingFieldRepository<ComingField> comingFieldRepository)
    {
        _comingFieldRepository = comingFieldRepository;
        LoadData();
    }

    private async void LoadData()
    {
        Weights = await _comingFieldRepository.GetAllWeight();
        StorageLocations = await _comingFieldRepository.GetAllStorageLocation();
    }


    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return ComingField.Driver != null! && ComingField.Transport != null! && ComingField.Field != null!
               && ComingField.Culture != null! && ComingField.VesNetto >= 0 && ComingField.VesBrutto >= 0
               && ComingField.VesTara >= 0 && ComingField.StorageLocation != null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        ComingField.Status = await _comingFieldRepository.GetStatusById(1);
        if (ComingField.Number==0) ComingField.Number = await _comingFieldRepository.GetNumber(ComingField) + 1;
        var com = await _comingFieldRepository.SaveAsync(ComingField);
        if (SenderModel is ComingFieldsViewModel comingFieldsViewModel)
        {
            var cl = comingFieldsViewModel.ComingFields.FirstOrDefault(x => x.Id == com.Id);
            if (cl! == null!)
            {
                comingFieldsViewModel.ComingFields.Add(com);
            }
        }

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
        view.DataContext = mod;
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
        ComingField.Field = null!;
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



    private ICommand? _clearDriverCommand;

    public ICommand ClearDriverCommand => _clearDriverCommand
        ??= new RelayCommand(OnClearDriverExecuted, CanClearDriverExecuted);

    private bool CanClearDriverExecuted(object arg)
    {
        return ComingField.Driver != null!;
    }

    private void OnClearDriverExecuted(object obj)
    {
        ComingField.Driver = null!;
    }




    private ICommand? _clearTransportCommand;

    public ICommand ClearTransportCommand => _clearTransportCommand
        ??= new RelayCommand(OnClearTransportExecuted, CanClearTransportExecuted);

    private bool CanClearTransportExecuted(object arg)
    {
        return ComingField.Transport != null!;
    }

    private void OnClearTransportExecuted(object obj)
    {
        ComingField.Transport = null!;
    }


    private ICommand? _copyVesCommand;

    public ICommand CopyVesCommand => _copyVesCommand
        ??= new RelayCommand(OnCopyVesExecuted, CanCopyVesExecuted);

    private bool CanCopyVesExecuted(object arg)
    {
        return ComingField.VesNetto != 0;
    }

    private void OnCopyVesExecuted(object obj)
    {
        if (obj is TextBox tb)
        {
            if (tb.Name == "Acros")
            {
                ComingField.VesNettoAcros = ComingField.VesNetto;
            }

            if (tb.Name == "Claas")
            {
                ComingField.VesNettoTucano = ComingField.VesNetto;
            }

            if (tb.Name == "Don")
            {
                ComingField.VesNettoDon = ComingField.VesNetto;
            }
        }
    }
    #endregion
}
