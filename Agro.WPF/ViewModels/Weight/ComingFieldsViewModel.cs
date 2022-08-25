﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Weight;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Weight;

namespace Agro.WPF.ViewModels.Weight;

public class ComingFieldsViewModel: ViewModel
{
    private readonly IBaseRepository<ComingField> _comingFieldRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = "Реестр прихода с поля";
    public string Title { get => _title; set => Set(ref _title, value); }

    
    private ObservableCollection<ComingField> _comingFields = null!;
    public ObservableCollection<ComingField> ComingFields { get => _comingFields; set => Set(ref _comingFields, value); }

    
    private ComingField _comingField = null!;
    public ComingField ComingField { get => _comingField; set => Set(ref _comingField, value); }

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    public ComingFieldsViewModel(IBaseRepository<ComingField> comingFieldRepository, IBaseRepository<Status> statusRepository)
    {
        _comingFieldRepository = comingFieldRepository;
        _statusRepository = statusRepository;
        CollectionView = CollectionViewSource.GetDefaultView(ComingFields);
        LoadData();
    }

    private async void LoadData()
    {
        var cfs = await _comingFieldRepository.GetAllAsync();
        cfs = cfs!.Where(c => c.Status!.Id != 6).ToArray();
        foreach (var comingField in cfs)
        {
            ComingFields.Add(comingField);
        }
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
        model.ComingField = new();
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
            ComingField.Status = await _statusRepository.GetByIdAsync(6);
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

    #endregion

}
