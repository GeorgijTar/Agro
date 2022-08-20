using System.Linq;
using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System;
using Agro.DAL.Entities;

namespace Agro.WPF.ViewModels.Agronomy;
public class DepartmentViewModel : ViewModel
{
    private readonly IBaseRepository<Department> _departmentRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    private object? _senderModel = null!;

    public object? SenderModel { get => _senderModel; set => Set(ref _senderModel, value); } 

    public DepartmentViewModel(IBaseRepository<Department> departmentRepository, IBaseRepository<Status> statusRepository)
    {
        _departmentRepository = departmentRepository;
        _statusRepository = statusRepository;
        Department = new();
    }
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private Department _department = null!;

    public Department Department { get => _department; set => Set(ref _department, value); }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
       return Department.Name!=null! && Department.AbbreviatedName!=null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        Department.Status = await _statusRepository.GetByIdAsync(5);
      var dep= await _departmentRepository.SaveAsync(Department);

        var window = obj as Window;
       if (window != null!)
           window.Close();

       if (SenderModel is DepartmentsViewModel viewModel)
       {
           var depart = viewModel.Departments!.FirstOrDefault(x => x.Id == dep.Id);
           if (depart! == null!)
           {
               viewModel.Departments!.Add(dep!);
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

    #endregion

}