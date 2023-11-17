using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Personnel;
using System.Windows;
using System;
using System.Windows.Input;
using Agro.DAL.Entities.Personnel;
using System.Linq;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.DAL.Entities.Base;

namespace Agro.WPF.ViewModels.Personnel;
public class EmployeeViewModel : ViewModel
{
    private readonly IBaseRepository<Employee> _employeeRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private Employee _employee = new();
    public Employee Employee { get => _employee; set => Set(ref _employee, value); }

    public object SenderModel { get; set; } = null!;

    public EmployeeViewModel(IBaseRepository<Employee> employeeRepository, IBaseRepository<Status> statusRepository)
    {
        _employeeRepository = employeeRepository;
        _statusRepository = statusRepository;
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveCommandExecuted, CanSaveCommandExecuted);

    private bool CanSaveCommandExecuted(object arg)
    {
        return Employee.People != null! && Employee.Division != null! && Employee.Post != null!;
    }

    private async void OnSaveCommandExecuted(object obj)
    {
        Employee.Status = await _statusRepository.GetByIdAsync(5);
        var eml = await _employeeRepository.SaveAsync(Employee);
        if (SenderModel is EmployeesViewModel employeesViewModel)
        {
            var pld = employeesViewModel.Employees.FirstOrDefault(x => x.Id == eml.Id);
            if (pld! == null!)
            {
                employeesViewModel.Employees.Add(eml);
            }
        }
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }



    private ICommand? _clearPeopleCommand;

    public ICommand ClearPeopleCommand => _clearPeopleCommand
        ??= new RelayCommand(OnClearPeopleCommandExecuted);

    private void OnClearPeopleCommandExecuted(object obj)
    {
        Employee.People = null!;
    }



    private ICommand? _clearPostCommand;

    public ICommand ClearPostCommand => _clearPostCommand
        ??= new RelayCommand(OnClearPostCommandExecuted);

    private void OnClearPostCommandExecuted(object obj)
    {
        Employee.Post = null!;
        Employee.Division = null!;

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



    private ICommand? _showPeoplesCommand;

    public ICommand ShowPeoplesCommand => _showPeoplesCommand
        ??= new RelayCommand(OnShowPeoplesExecuted);

    private void OnShowPeoplesExecuted(object obj)
    {
        var view = new PeoplsView();
        var mod = view.DataContext as PeoplsViewModel;
        mod!.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }


    private ICommand? _showStaffListCommand;

    public ICommand ShowStaffListCommand => _showStaffListCommand
        ??= new RelayCommand(OnShowStaffListExecuted);

    private void OnShowStaffListExecuted(object obj)
    {
        var view = new StafListSprView();
        var mod = view.DataContext as StafListSprViewModel;
        mod!.Title = "Выбирите должность";
        mod.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }

    #endregion
}