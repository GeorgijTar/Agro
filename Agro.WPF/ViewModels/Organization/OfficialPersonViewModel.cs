
using System;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Organization;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Personnel;
using Agro.WPF.ViewModels.Storage;
using Agro.WPF.Views.Windows.Personnel;

namespace Agro.WPF.ViewModels.Organization;

public class OfficialPersonViewModel : ViewModel
{
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    public object SenderModel { get; set; } = null!;

    
    private OfficialPerson _officialPerson = new();
    public OfficialPerson OfficialPerson { get => _officialPerson;set => Set(ref _officialPerson, value); }

    public OfficialPersonViewModel(IBaseRepository<Status> statusRepository)
    {
        _statusRepository = statusRepository;
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveCommandExecuted, CanSaveCommandExecuted);

    private bool CanSaveCommandExecuted(object arg)
    {
        return OfficialPerson.Employee!= null!;
    }

    private async void OnSaveCommandExecuted(object obj)
    {
        OfficialPerson.Status = await _statusRepository.GetByIdAsync(5);
        if (SenderModel != null!)
        {
            if (SenderModel is StorageLocationViewModel locationViewModel)
            {
                if (locationViewModel.StorageLocation.Storekeepers.Count > 0)
                {
                    MessageBox.Show("Все предыдущие записи о кладовщиках будут переведены в архивный статус", "", MessageBoxButton.OK);
                    foreach (var storageLocationStorekeeper in locationViewModel.StorageLocation.Storekeepers)
                    {
                        storageLocationStorekeeper.Status= await _statusRepository.GetByIdAsync(7);
                    }
                }

                locationViewModel.StorageLocation.Storekeepers.Add(OfficialPerson);
                locationViewModel.StorageLocation.ActualStorekeeper=OfficialPerson;
                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
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



    private ICommand? _showEmployeeCommand;

    public ICommand ShowEmployeeCommand => _showEmployeeCommand
        ??= new RelayCommand(OnShowEmployeeExecuted);

    private void OnShowEmployeeExecuted(object obj)
    {
        var view = new EmployeesView();
        var mod = view.DataContext as EmployeesViewModel;
        mod!.Title = "Выбирите сотрудника";
        mod.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }

    #endregion

}

