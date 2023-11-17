
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Storage;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System;
using System.Linq;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.ViewModels.Organization;
using Agro.WPF.Views.Windows.Organization;
using Agro.DAL.Entities.Base;

namespace Agro.WPF.ViewModels.Storage;

public class StorageLocationViewModel : ViewModel
{
    private readonly IBaseRepository<StorageLocation> _storageLocationRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    
    private StorageLocation _storageLocation = new();
    public StorageLocation StorageLocation { get => _storageLocation; set => Set(ref _storageLocation, value); }


    private OfficialPerson _officialPerson = null!;
    public OfficialPerson OfficialPerson { get => _officialPerson; set => Set(ref _officialPerson, value); } 


    public object SenderModel { get; set; } = null!;


    public StorageLocationViewModel(
        IBaseRepository<StorageLocation> storageLocationRepository, 
        IBaseRepository<Status> statusRepository)
    {
        _storageLocationRepository = storageLocationRepository;
        _statusRepository = statusRepository;
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return StorageLocation.Name != null! && StorageLocation.Name.Trim().Length>2;
    }

    private async void OnSaveExecuted(object obj)
    {
        StorageLocation.Status = await _statusRepository.GetByIdAsync(5);
        var cult = await _storageLocationRepository.SaveAsync(StorageLocation);
        if (SenderModel is StorageLocationsViewModel locationsViewModel)
        {
            var cl = locationsViewModel.StorageLocations.FirstOrDefault(x => x.Id == cult.Id);
            if (cl != null!)
            {
                cl = cult;
            }
            else
            {
                locationsViewModel.StorageLocations.Add(cult);
            }
        }
        Application.Current.Properties["StorageLocations"] = await _storageLocationRepository.GetAllAsync();

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


    private ICommand? _addOfficialPersonCommand;

    public ICommand AddOfficialPersonCommand => _addOfficialPersonCommand
        ??= new RelayCommand(OnAddOfficialPersonExecuted);

    private void OnAddOfficialPersonExecuted(object obj)
    {
        var view = new OfficialPersonView();
        var mod = view.DataContext as OfficialPersonViewModel;
        mod!.Title = "Добавление нового кладовщика";
        mod.SenderModel = this;
        view.DataContext=mod;
        view.ShowDialog();
    }

    private ICommand? _deleteOfficialPersonCommand;

    public ICommand DeleteOfficialPersonCommand => _deleteOfficialPersonCommand
        ??= new RelayCommand(OnDeleteOfficialPersonExecuted, CanDeleteOfficialPersonExecuted);

    private bool CanDeleteOfficialPersonExecuted(object arg)
    {
        return OfficialPerson != null!;
    }

    private async void OnDeleteOfficialPersonExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить кладовщика:{Environment.NewLine}" +
                                     $"{OfficialPerson.Employee.People.Surname} {OfficialPerson.Employee.People.Name[0]}" +
                                     $"{OfficialPerson.Employee.People.Patronymic[0]}", "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            OfficialPerson.Status = await _statusRepository.GetByIdAsync(6);
            StorageLocation.Storekeepers!.Remove(OfficialPerson);
        }
    }
    

    #endregion

}