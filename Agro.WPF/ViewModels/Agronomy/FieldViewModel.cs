using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Agronomy;

namespace Agro.WPF.ViewModels.Agronomy;
public class FieldViewModel : ViewModel
{
    private readonly IBaseRepository<Department> _departmentRepository;
    private readonly IBaseRepository<Field> _fieldRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private Field? _field = new();
    public Field? Field { get => _field; set => Set(ref _field, value); }


    private IEnumerable<Department> _departments = null!;
    public IEnumerable<Department> Departments { get => _departments; set => Set(ref _departments, value); }


    private LandPlot _landPlot = null!;
    public LandPlot LandPlot { get => _landPlot; set => Set(ref _landPlot, value); }


    private object _senderModel = null!;
    public object SenderModel { get => _senderModel; set => Set(ref _senderModel, value); } 


    public FieldViewModel(
        IBaseRepository<Department> departmentRepository, 
        IBaseRepository<Field> fieldRepository, 
        IBaseRepository<Status> statusRepository)
    {
        _departmentRepository = departmentRepository;
        _fieldRepository = fieldRepository;
        _statusRepository = statusRepository;
        Title = "Новое поле";
        LoadData();
    }

    private async void LoadData()
    {
        var dep = await _departmentRepository.GetAllAsync();
        Departments = dep!.Where(d => d.Status!.Id == 5);
    }


    #region Commands

    private ICommand? _showFieldsCommand;

    public ICommand ShowFieldsCommand => _showFieldsCommand
        ??= new RelayCommand(OnShowFieldsExecuted);

    private void OnShowFieldsExecuted(object obj)
    {
        FieldsView view = new();
        var model = view.DataContext as FieldsViewModel;
        model!.SenderModel = this;
        model.Title = "Выбирете родительское поле";
        view.DataContext = model;
        view.ShowDialog();
    }


    private ICommand? _addLandPlotCommand;

    public ICommand AddLanPlotCommand => _addLandPlotCommand
        ??= new RelayCommand(OnAddLanPlotExecuted);

    private void OnAddLanPlotExecuted(object obj)
    {
        LandPlotsView view = new();
        var model = view.DataContext as LandPlotsViewModel;
        model!.SenderModel = this;
        model.Title = "Выбирете земельный участок";
        view.DataContext = model;
        view.ShowDialog();
    }


    private ICommand? _deleteLandPlotCommand;

    public ICommand DeleteLanPlotCommand => _deleteLandPlotCommand
        ??= new RelayCommand(OnDeleteLanPlotExecuted, CanDeleteLanPlotExecuted);

    private bool CanDeleteLanPlotExecuted(object arg)
    {
        return LandPlot != null!;
    }

    private void OnDeleteLanPlotExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить ЗУ: {LandPlot.Number}", 
            "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Field!.LandPlots!.Remove(LandPlot);
        }
    }



    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return Field!.Name != null! && Field.Areal != 0 && Field.Department != null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        Field!.Status = await _statusRepository.GetByIdAsync(5);
        var cult = await _fieldRepository.SaveAsync(Field);
        if (SenderModel is FieldsViewModel fieldsViewModel)
        {

        }

        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    #endregion
}
