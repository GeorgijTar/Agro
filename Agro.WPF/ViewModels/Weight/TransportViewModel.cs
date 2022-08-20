

using System.Linq;
using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.Weight;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Agronomy;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows.Interop;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using System.Windows;
using System;

namespace Agro.WPF.ViewModels.Weight;

public class TransportViewModel : ViewModel
{
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IBaseRepository<Transport> _transportRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }
    

    private Transport _transport = new();
    public Transport Transport { get => _transport; set => Set(ref _transport, value); }

    public object SenderModel { get; set; }

    public TransportViewModel(IBaseRepository<Status> statusRepository, IBaseRepository<Transport> transportRepository)
    {
        _statusRepository = statusRepository;
        _transportRepository = transportRepository;
    }
    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return Transport.CarBrand !=null! && Transport.RegNumber != null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        Transport.Status = await _statusRepository.GetByIdAsync(5);
        var transport = await _transportRepository.SaveAsync(Transport);
        if (SenderModel is TransportsViewModel viewModel)
        {
            var tr = viewModel.Transports.FirstOrDefault(t => t.Id == transport.Id);
            if (tr != null!)
            {
                tr = transport;
            }
            else
            {
                viewModel.Transports.Add(transport);
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
