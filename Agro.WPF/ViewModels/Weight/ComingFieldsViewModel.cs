using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Weight;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Agronomy;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Agronomy;
using Agro.WPF.Views.Windows.Weight;

namespace Agro.WPF.ViewModels.Weight;

public class ComingFieldsViewModel: ViewModel
{
    private readonly IComingFieldRepository<ComingField> _comingFieldRepository;
    private string _title = "Реестр прихода с поля";
    public string Title { get => _title; set => Set(ref _title, value); }

    
    private ObservableCollection<ComingField> _comingFields = new();
    public ObservableCollection<ComingField> ComingFields { get => _comingFields; set => Set(ref _comingFields, value); }

    
    private ComingField _comingField = null!;
    public ComingField ComingField { get => _comingField; set => Set(ref _comingField, value); }

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }


    private IEnumerable<DAL.Entities.Weight.Weight>? _weights;
    public IEnumerable<DAL.Entities.Weight.Weight>? Weights { get => _weights; set => Set(ref _weights, value); }

    
    private IEnumerable<Status>? _statuses;
    public IEnumerable<Status>? Statuses { get => _statuses; set => Set(ref _statuses, value); } 



    private DAL.Entities.Weight.Weight _weightFilter = null!;
    public DAL.Entities.Weight.Weight WeightFilter { get => _weightFilter; set => Set(ref _weightFilter, value); }

    
    private Field _fieldFilter = null!;
    public Field FieldFilter { get => _fieldFilter; set => Set(ref _fieldFilter, value); }

    
    private Status _statusFilter = null!;
    public Status StatusFilter { get => _statusFilter; set => Set(ref _statusFilter, value); } 


    private string _cultureFilter = null!;
    public string CultureFilter { get => _cultureFilter; set => Set(ref _cultureFilter, value); }


    private string _driverFilter = null!;
    public string DriverFilter { get => _driverFilter; set => Set(ref _driverFilter, value); }


    private string _transportFilter = null!;
    public string TransportFilter { get => _transportFilter; set => Set(ref _transportFilter, value); } 


    public ComingFieldsViewModel(IComingFieldRepository<ComingField> comingFieldRepository)
    {
        _comingFieldRepository = comingFieldRepository;
        CollectionView = CollectionViewSource.GetDefaultView(ComingFields);
        LoadData();
    }

    private async void LoadData()
    { 
        ComingFields.Clear();
        var cfs = await _comingFieldRepository.GetAllAsync();
        cfs = cfs!.Where(c => c.Status!.Id != 6).ToArray();
        foreach (var comingField in cfs)
        {
            ComingFields.Add(comingField);
        }

        Statuses=cfs.Where(c=>c.Status!.Id!=6).Select(c=>c.Status).Distinct().ToArray()!;
        Weights = await _comingFieldRepository.GetAllWeight();
    }


    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var view = new ComingFieldView();
        var model = view.DataContext as ComingFieldViewModel;
        model!.Title = "Создание нового прихода с поля";
        model.SenderModel = this;
        model.ComingField = new();
        view.DataContext = model;
        view.Show();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return ComingField != null! && ComingField.Status?.Id==1;
    }

    private void OnEditExecuted(object obj)
    {
        var view = new ComingFieldView();
        var model = view.DataContext as ComingFieldViewModel;
        model!.Title = "Редактирование прихода с поля";
        model.SenderModel = this;
        model.ComingField = ComingField;
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
                $"Вы действительно хотите удалит приход с поля:{Environment.NewLine} " +
                $"№ {ComingField.Number} от {ComingField.Date}",
                "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            ComingField.Status = await _comingFieldRepository.GetStatusById(6);
            await _comingFieldRepository.UpdateAsync(ComingField);
            ComingFields.Remove(ComingField);
            ComingField = null!;
        }
    }

    
    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object obj)
    {
      LoadData();
    }


    //private ICommand? _selectRowCommand;

    //public ICommand SelectRowCommand => _selectRowCommand
    //    ??= new RelayCommand(OnSelectRowExecuted, CanEditExecuted);

    //private async void OnSelectRowExecuted(object obj)
    //{
    //    if (SenderModel != null!)
    //    {
    //        if (SenderModel is DriverViewModel driverViewModel)
    //        {
    //            driverViewModel.Driver.Transports!.Add(Transport);
    //            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
    //            if (window != null!)
    //                window.Close();
    //        }
    //    }
    //}

    private ICommand? _showFieldsCommand;

    public ICommand ShowFieldsCommand => _showFieldsCommand
        ??= new RelayCommand(OnShowFieldsExecuted);

    private void OnShowFieldsExecuted(object obj)
    {
        var view = new FieldsView();
        var mod = view.DataContext as FieldsViewModel;
        mod!.Title = "Выбирите поле";
        mod.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }


    private ICommand? _clearFieldCommand;

    public ICommand ClearFieldCommand => _clearFieldCommand
        ??= new RelayCommand(OnClearFieldExecuted, CanClearFieldExecuted);

    private bool CanClearFieldExecuted(object arg)
    {
        return FieldFilter != null!;
    }

    private void OnClearFieldExecuted(object obj)
    {
        FieldFilter = null!;
    }
    #endregion

}
