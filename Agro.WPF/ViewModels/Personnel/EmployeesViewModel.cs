

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Personnel;

namespace Agro.WPF.ViewModels.Personnel;

public class EmployeesViewModel : ViewModel
{
    private readonly IBaseRepository<Employee> _employeeRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    private string _title = "Сотрудники организации";
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<Employee> _employees = new();
    public ObservableCollection<Employee> Employees { get => _employees; set => Set(ref _employees, value); }


    private IEnumerable<Status>? _statuses;
    public IEnumerable<Status>? Statuses { get => _statuses; set => Set(ref _statuses, value); }


    private IEnumerable<Division>? _divisions;
    public IEnumerable<Division>? Divisions { get => _divisions; set => Set(ref _divisions, value); }


    private IEnumerable<Post>? _posts;
    public IEnumerable<Post>? Posts { get => _posts; set => Set(ref _posts, value); }


    private Employee _employee = null!;
    public Employee Employee { get => _employee; set => Set(ref _employee, value); }


    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }


    private string _nameFilter = null!;
    public string NameFilter { get => _nameFilter; set => Set(ref _nameFilter, value); }


    private Division _divisionFilter = null!;
    public Division DivisionFilter { get => _divisionFilter; set => Set(ref _divisionFilter, value); }


    private Status _statusFilter = null!;
    public Status StatusFilter { get => _statusFilter; set => Set(ref _statusFilter, value); }


    private Post _postFilter = null!;
    public Post PostFilter { get => _postFilter; set => Set(ref _postFilter, value); }


    private string _tabNumberFilter = null!;
    public string TabNumberFilter { get => _tabNumberFilter; set => Set(ref _tabNumberFilter, value); }


    public EmployeesViewModel(IBaseRepository<Employee> employeeRepository, IBaseRepository<Status> statusRepository)
    {
        _employeeRepository = employeeRepository;
        _statusRepository = statusRepository;
        LoadData();
        Employees.CollectionChanged += RefreshFilter;
        CollectionView = CollectionViewSource.GetDefaultView(Employees);
        this.PropertyChanged += Filter;
    }

    private void Filter(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "NameFilter")
        {
            CollectionView.Filter = FilterByName;
        }
        if (e.PropertyName == "TabNumberFilter")
        {
            CollectionView.Filter = FilterByTabNumber;
        }
        if (e.PropertyName == "StatusFilter")
        {
            CollectionView.Filter = FilterByStatus;
        }
        if (e.PropertyName == "DivisionFilter")
        {
            CollectionView.Filter = FilterByDivision;
        }

        if (e.PropertyName == "PostFilter")
        {
            CollectionView.Filter = FilterByPost;
        }
    }

    private bool FilterByPost(object obj)
    {
        if (PostFilter != null!)
        {
            Employee? dto = obj as Employee;
            return dto!.Post.Name.ToUpper().Contains(PostFilter.Name.ToUpper());
        }
        return true;
    }

    private bool FilterByDivision(object obj)
    {
        if (DivisionFilter != null!)
        {
            Employee? dto = obj as Employee;
            return dto!.Division.Name.ToUpper().Contains(DivisionFilter.Name.ToUpper());
        }
        return true;
    }

    private bool FilterByStatus(object obj)
    {
        if (StatusFilter != null!)
        {
            Employee? dto = obj as Employee;
            return dto!.Status!.Name.ToUpper().Contains(StatusFilter.Name.ToUpper());
        }
        return true;
    }

    private bool FilterByTabNumber(object obj)
    {
        if (!String.IsNullOrEmpty(TabNumberFilter))
        {
            Employee? dto = obj as Employee;
            return dto!.TabNumber.ToUpper().Contains(TabNumberFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByName(object obj)
    {
        if (!String.IsNullOrEmpty(NameFilter))
        {
            Employee? dto = obj as Employee;
            return dto!.People.Name.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }

    private void RefreshFilter(object? sender, NotifyCollectionChangedEventArgs e)
    {
        LoadFilter();
    }

    private async void LoadData()
    {
        var employees = await _employeeRepository.GetAllAsync();
        employees = employees!.Where(e => e.Status!.Id != 6).ToArray();

        foreach (var employee in employees)
        {
            Employees.Add(employee);
        }
    }

    private async void LoadFilter()
    {
        var employees = await _employeeRepository.GetAllAsync();
        employees = employees!.Where(e => e.Status!.Id != 6).ToArray();
        Statuses = employees.Select(s => s.Status!).Distinct();
        Divisions = employees.Select(s => s.Division).Distinct();
        Posts = employees.Select(s => s.Post).Distinct();
    }


    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted);

    private void OnAddCommandExecuted(object obj)
    {
        EmployeeView view = new();
        var mod = view.DataContext as EmployeeViewModel;
        mod!.Title = "Добавление нового сотрудника";
        mod.Employee = new();
        mod.SenderModel = this;
        view.DataContext = mod;
        view.Show();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditCommandExecuted, CanEditCommandExecuted);

    private bool CanEditCommandExecuted(object arg)
    {
        return Employee != null!;
    }

    private void OnEditCommandExecuted(object obj)
    {
        EmployeeView view = new();
        var mod = view.DataContext as EmployeeViewModel;
        mod!.Title = "Редактирование сотрудника";
        mod.Employee = Employee;
        mod.SenderModel = this;
        view.DataContext = mod;
        view.Show();
    }


    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteCommandExecuted, CanEditCommandExecuted);

    private async void OnDeleteCommandExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить сотрудника: {Environment.NewLine}" +
                                     $"{Employee.Post} {Employee.People.Surname} {Employee.People.Name} {Employee.People.Patronymic}",
            "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Employee.Status = await _statusRepository.GetByIdAsync(6);
            await _employeeRepository.UpdateAsync(Employee);
            Employees.Remove(Employee);
        }
    }

    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshCommandExecuted);

    private void OnRefreshCommandExecuted(object obj)
    {
        LoadData();
    }

    #endregion
}
