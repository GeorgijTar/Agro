

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Storage;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Storage;

namespace Agro.WPF.ViewModels.Storage;

public class StorageLocationsViewModel : ViewModel
{
    private readonly IBaseRepository<StorageLocation> _storageLocationRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<StorageLocation> _storageLocations = new();
    public ObservableCollection<StorageLocation> StorageLocations { get => _storageLocations; set => Set(ref _storageLocations, value); }

    
    private StorageLocation _storageLocation = null!;
    public StorageLocation StorageLocation { get => _storageLocation; set => Set(ref _storageLocation, value); } 

    public object SenderModel { get; set; } = null!;

    public StorageLocationsViewModel(
        IBaseRepository<StorageLocation> storageLocationRepository, 
        IBaseRepository<Status> statusRepository)
    {
        _storageLocationRepository = storageLocationRepository;
        _statusRepository = statusRepository;
        LoadData();
    }

    private async void LoadData()
    {
        StorageLocations.Clear();
       var sls=await _storageLocationRepository.GetAllAsync();
       sls = sls!.Where(s => s.Status!.Id == 5).ToArray();
       foreach (var storageLocation in sls)
       {
           StorageLocations.Add(storageLocation);
       }
    }

    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var view = new StorageLocationView();
        var model = view.DataContext as StorageLocationViewModel;
        model!.Title = "Создание нового места хранения";
        model.SenderModel = this;
        model.StorageLocation = new();
        view.DataContext = model;
        view.Show();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return StorageLocation != null!;
    }

    private void OnEditExecuted(object obj)
    {
        var view = new StorageLocationView();
        var model = view.DataContext as StorageLocationViewModel;
        model!.Title = "Создание нового места хранения";
        model.SenderModel = this;
        model.StorageLocation = StorageLocation;
        view.DataContext = model;
        view.Show();
    }

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanEditExecuted);

    private async void OnDeleteExecuted(object obj)
    {
        var result =
            MessageBox.Show(
                $"Вы действительно хотите удалит место хранения:{Environment.NewLine} " +
                $"{StorageLocation.Name}",
                "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            StorageLocation.Status = await _statusRepository.GetByIdAsync(6);
            await _storageLocationRepository.UpdateAsync(StorageLocation);
            StorageLocations.Remove(StorageLocation);
            StorageLocation = null!;
        }
    }


    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object obj)
    {
        LoadData();
    }


    //private ICommand? _selectRowCommand;

    //public ICommand SelectRowCommand => _selectRowCommand
    //    ??= new RelayCommand(OnSelectRowExecuted, CanEditExecuted);

    //private async void OnSelectRowExecuted(object obj)
    //{
    //    if (SenderModel != null!)
    //    {
    //        if (SenderModel is DriverViewModel driverViewModel)
    //        {
    //            driverViewModel.Driver.Transports!.Add(Transport);
    //            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
    //            if (window != null!)
    //                window.Close();
    //        }
    //    }
    //}

    #endregion
}
