using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.Base;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Agronomy;

namespace Agro.WPF.ViewModels.Agronomy;
public class DepartmentsViewModel : ViewModel
{
    private readonly IBaseRepository<Department> _departmentRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    public DepartmentsViewModel(IBaseRepository<Department> departmentRepository, IBaseRepository<Status> statusRepository)
    {
        _departmentRepository = departmentRepository;
        _statusRepository = statusRepository;
        LoadData();
    }

    private async void LoadData()
    {
        Departments = new();
        var dep = await _departmentRepository.GetAllAsync();
        dep = dep!.Where(d => d.Status!.Id != 6).ToArray();
        foreach (var d in dep)
        {
            Departments!.Add(d);
        }
    }

    private string _title = "Отделения";
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<Department>? _departments;

    public ObservableCollection<Department>? Departments { get => _departments; set => Set(ref _departments, value); }

    private Department _department = null!;

    public Department Department { get => _department; set => Set(ref _department, value); }

    #region Commands

    #region AddComand

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        DepartmentView view = new();
        var model = view.DataContext as DepartmentViewModel;
        model!.SenderModel = this;
        model.Title = "Добавление нового отделения";
        view.DataContext= model;
        view.ShowDialog();

    }

    #endregion

    #region EditComand

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return Department != null!;
    }

    private void OnEditExecuted(object obj)
    {
        DepartmentView view = new();
        var model = view.DataContext as DepartmentViewModel;
        model!.SenderModel = this;
        model.Department = Department;
        model.Title = $"Редактирование отделения: {Department.Name}";
        view.DataContext = model;
        view.ShowDialog();
    }

    #endregion


    #region DeleteComand

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanDeleteExecuted);

    private bool CanDeleteExecuted(object arg)
    {
        return Department != null!;
    }

    private async void OnDeleteExecuted(object obj)
    {
        var rezalt = MessageBox.Show($"Вы действительно хотите удалить запись {Department.Name}", "Редактор", MessageBoxButton.YesNo);
        if (rezalt == MessageBoxResult.Yes)
        {
            Department.Status = await _statusRepository.GetByIdAsync(6);
            Department = await _departmentRepository.UpdateAsync(Department);
                Departments!.Remove(Department);
                Department = null!;
        }
    }

    #endregion

    #endregion

}
