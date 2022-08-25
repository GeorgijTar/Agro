using System;
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

namespace Agro.WPF.ViewModels.Weight;
public class TransportsViewModel : ViewModel
{
    private readonly IBaseRepository<Transport> _transportRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<Transport> _transports = new();
    public ObservableCollection<Transport> Transports { get => _transports; set => Set(ref _transports, value); }


    private Transport _transport = null!;
    public Transport Transport { get => _transport; set => Set(ref _transport, value); }

    public object SenderModel { get; set; }=null!;

    public TransportsViewModel(IBaseRepository<Transport> transportRepository, IBaseRepository<Status> statusRepository)
    {
        _transportRepository = transportRepository;
        _statusRepository = statusRepository;
        LoadData();
    }

    private async void LoadData()
    {
        var transports = await _transportRepository.GetAllAsync();
        transports = transports!.Where(t => t.Status.Id == 5).ToArray();
        foreach (var transport in transports)
        {
            Transports.Add(transport);
        }
    }

    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var view = new TransportView();
        var model=view.DataContext as TransportViewModel;
        model!.Title = "Добавление нового автотранспорта";
        model.SenderModel = this;
        model.Transport = new();
        view.DataContext=model;
        view.Show();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return Transport != null!;
    }

    private void OnEditExecuted(object obj)
    {
        var view = new TransportView();
        var model = view.DataContext as TransportViewModel;
        model!.Title = "Добавление нового автотранспорта";
        model.SenderModel = this;
        model.Transport = Transport;
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
                $"Вы действительно хотите удалит автотранспорт:{Environment.NewLine} {Transport.CarBrand} рег. № {Transport.RegNumber}",
                "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Transport.Status = await _statusRepository.GetByIdAsync(6);
            await _transportRepository.UpdateAsync(Transport);
            Transports.Remove(Transport);
            Transport = null!;
        }
    }

    

    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowExecuted, CanEditExecuted);

    private async void OnSelectRowExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is DriverViewModel driverViewModel)
            {
                driverViewModel.Driver.Transports!.Add(Transport);
            }

            if (SenderModel is ComingFieldViewModel model)
            {
                model.ComingField.Transport=Transport;
            }
            
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }

    #endregion
}
