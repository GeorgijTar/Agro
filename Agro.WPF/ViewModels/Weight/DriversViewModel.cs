
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Weight;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Weight;
using System;

namespace Agro.WPF.ViewModels.Weight;

public class DriversViewModel : ViewModel
{
    private readonly IBaseRepository<Driver> _driveRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<Driver> _drivers = new();
    public ObservableCollection<Driver> Drivers{ get => _drivers; set => Set(ref _drivers, value); }


    private Driver _driver = null!;
    public Driver Driver { get => _driver;set => Set(ref _driver, value); }

    public object SenderModel = null!;

    public DriversViewModel(IBaseRepository<Driver> driveRepository, IBaseRepository<Status> statusRepository)
    {
        _driveRepository = driveRepository;
        _statusRepository = statusRepository;
        LoadData();
    }

    private async void LoadData()
    {
        var drivers = await _driveRepository.GetAllAsync();
        drivers = drivers!.Where(d => d.Status!.Id == 5).ToArray();
        foreach (var driver in drivers)
        {
            Drivers.Add(driver);
        }
    }

    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        DriverView view = new();
        var model = view.DataContext as DriverViewModel;
        model!.SenderModel = this;
        model.Title = "Добавление нового водителя";
        view.DataContext = model;
        view.ShowDialog();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return Driver != null!;
    }

    private void OnEditExecuted(object obj)
    {
        DriverView view = new();
        var model = view.DataContext as DriverViewModel;
        model!.SenderModel = this;
        model.Title = "Редактирование нового водителя";
        model.Driver=Driver;
        view.DataContext = model;
        view.ShowDialog();
    }

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanEditExecuted);

    private async void OnDeleteExecuted(object obj)
    {
       
        var result = MessageBox.Show($"Вы действительно хотите удалить водителя: {Environment.NewLine}" +
                                     $"{Driver.Surname} {Driver.Name} {Driver.Patronymic}", "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Driver.Status = await _statusRepository.GetByIdAsync(6);
            await _driveRepository.UpdateAsync(Driver);
            Drivers.Remove(Driver);
        }
    }

    #endregion
}
