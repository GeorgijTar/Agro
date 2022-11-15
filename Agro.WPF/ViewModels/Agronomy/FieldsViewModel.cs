
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Weight;
using Agro.WPF.Views.Windows.Agronomy;

namespace Agro.WPF.ViewModels.Agronomy;

public class FieldsViewModel : ViewModel
{
    private readonly IBaseRepository<Department> _departmentRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IBaseRepository<Field> _fieldRepository;

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<Department> _departments = new();
    public ObservableCollection<Department> Departments { get => _departments; set => Set(ref _departments, value); }

    private object _field = null!;
    public object Field { get => _field; set => Set(ref _field, value); }

    private object _senderModel = null!;

    public object SenderModel { get => _senderModel; set => Set(ref _senderModel, value); } 

    public FieldsViewModel(IBaseRepository<Department> departmentRepository, 
        IBaseRepository<Status> statusRepository, IBaseRepository<Field> fieldRepository)
{
        _departmentRepository = departmentRepository;
        _statusRepository = statusRepository;
        _fieldRepository = fieldRepository;
        Title = "Реестр полей";
        LoadData();
    }

    private async void LoadData()
    {
        Departments.Clear();
       var deps = await _departmentRepository.GetAllAsync();
       deps = deps!.Where(d => d.Status!.Id == 5).ToArray();
       foreach (var dep in deps)
       {
           var fl = dep.Fields!.Where(f => f.Status!.Id == 5).ToArray();
           dep.Fields!.Clear();
           foreach (var f in fl)
           {
               dep.Fields.Add(f);
           }
           Departments.Add(dep);
       }
    }

    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        FieldView view = new();
        var model = view.DataContext as FieldViewModel;
        model!.SenderModel = this;
        model.Title = "Добавление нового поля";
        view.DataContext = model;
        view.ShowDialog();
    }

    
    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return Field != null! && Field is Field;
    }

    private void OnEditExecuted(object obj)
    {
        FieldView view = new();
        var model = view.DataContext as FieldViewModel;
        model!.SenderModel = this;
        model.Field = Field as Field;
        model.Title = "Редактирование поля";
        view.DataContext = model;
        view.ShowDialog();
    }

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanEditExecuted);
    
    private async void OnDeleteExecuted(object obj)
    {
        var fl = Field as Field;
        var result = MessageBox.Show($"Вы действительно хотите удалить поле {fl!.Name}", "Редактор",
            MessageBoxButton.YesNo);
       if (result == MessageBoxResult.Yes)
       {
           Field = null!;
           var dp = fl.Department;
           fl.Status = await _statusRepository.GetByIdAsync(7);
           await _fieldRepository.UpdateAsync(fl);
           dp.Fields!.Remove(fl);
       }
    }


    private ICommand? _doubleClickCommand;

    public ICommand DoubleClickCommand => _doubleClickCommand
        ??= new RelayCommand(OnDoubleClickExecuted);

    private void OnDoubleClickExecuted(object obj)
    {
        if (Field is Field field)
        {
            if (SenderModel != null!)
            {
                if (SenderModel is FieldViewModel fieldViewModel)
                {
                    fieldViewModel.Field!.ParentField = field;
                    fieldViewModel.Field.Department = field.Department;
                }

                if (SenderModel is ComingFieldViewModel comingFieldViewModel)
                {
                    comingFieldViewModel.ComingField.Field = field;
                }

                if (SenderModel is ComingFieldsViewModel comingFieldsViewModel)
                {
                    comingFieldsViewModel.FieldFilter = field;
                }

                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }

    }

    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object obj)
    {
        LoadData();
    }




    #endregion
}