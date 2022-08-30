

using System;
using System.Linq;
using System.Windows;
using Agro.DAL.Entities.Weight;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.WPF.Views.Windows.Weight;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.WPF.ViewModels.Weight;

public class DriverViewModel : ViewModel
{
    private readonly IBaseRepository<Driver> _driveRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private Driver _driver = new();
    public Driver Driver { get => _driver; set => Set(ref _driver, value); } 


    public object SenderModel=null!;


    private Transport _transport = null!;
    public Transport Transport { get => _transport; set => Set(ref _transport, value); }

    public DriverViewModel(IBaseRepository<Driver> driveRepository, IBaseRepository<Status> statusRepository)
    {
        _driveRepository = driveRepository;
        _statusRepository = statusRepository;
    }

    #region Commands

    private ICommand? _addTransportCommand;

    public ICommand AddTransportCommand => _addTransportCommand
        ??= new RelayCommand(OnAddTransportExecuted);

    private void OnAddTransportExecuted(object obj)
    {
        TransportsView view = new();
        var model = view.DataContext as TransportsViewModel;
        model!.SenderModel = this;
        model.Title = "Выбирите транспортное средство";
        view.DataContext=model;
        view.ShowDialog();
    }

    private ICommand? _deleteTransportCommand;

    public ICommand DeleteTransportCommand => _deleteTransportCommand
        ??= new RelayCommand(OnDeleteTransportExecuted, CanDeleteTransportExecuted);

    private bool CanDeleteTransportExecuted(object arg)
    {
        return Transport != null!;
    }

    private void OnDeleteTransportExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите открепить автомобиль{Environment.NewLine}" +
                                     $"{Transport.CarBrand} {Transport.RegNumber} от водителя " +
                                     $"{Driver.Surname} {Driver.Name, 1}. {Driver.Patronymic, 1}.", "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Driver.Transports!.Remove(Transport);
        }
    }


    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return Driver.Surname!=null! && Driver.Surname.Length > 2 && Driver.Name!=null! && Driver.Name.Length>2 &&
               Driver.Patronymic!=null! && Driver.Patronymic.Length>2;
    }

    private async void OnSaveExecuted(object obj)
    {
        Driver.Status = await _statusRepository.GetByIdAsync(5);
        var dr = await _driveRepository.SaveAsync(Driver);
      
        if (SenderModel is DriversViewModel driversViewModel)
        {
            var cl = driversViewModel.Drivers.FirstOrDefault(x => x.Id == dr.Id);
            if (cl != null!)
            {
                cl = dr;
            }
            else
            {
                driversViewModel.Drivers.Add(dr);
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

    #endregion
}