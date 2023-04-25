using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.WPF.ViewModels.Base;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.Views.Windows.Warehouse;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Decommissioning;

public class WriteOffObjectsViewModel : ViewModel
{
    private readonly IBaseRepository<WriteOffObject> _writeOffObjectRepository;
    private readonly INotificationManager _notificationManager;

    private ObservableCollection<WriteOffObject> _writeOffObjects = new();
    public ObservableCollection<WriteOffObject> WriteOffObjects { get => _writeOffObjects; set => Set(ref _writeOffObjects, value); }

    private WriteOffObject _writeOffObjectSelected = null!;
    public WriteOffObject WriteOffObjectSelected { get => _writeOffObjectSelected; set => Set(ref _writeOffObjectSelected, value); }

    private ObservableCollection<TypeObject> _typeObjects = new();
    public ObservableCollection<TypeObject> TypeObjects { get => _typeObjects; set => Set(ref _typeObjects, value); }

    private ObservableCollection<GroupObject> _groupObjects = new();
    public ObservableCollection<GroupObject> GroupObjects { get => _groupObjects; set => Set(ref _groupObjects, value); }

    private bool _isExpanded = true ;
    public bool IsExpanded { get => _isExpanded; set => Set(ref _isExpanded, value); }
   
    public WriteOffObjectsViewModel(
        IBaseRepository<WriteOffObject> writeOffObjectRepository,
        INotificationManager notificationManager)
    {
        _writeOffObjectRepository = writeOffObjectRepository;
        _notificationManager = notificationManager;
        LoadData();
    }

    private async void LoadData()
    {
        var wfo = await _writeOffObjectRepository.GetAllAsync();
        foreach (var writeOffObject in wfo!)
        {
            if (writeOffObject.Status.Id != 6)
            {
                WriteOffObjects.Add(writeOffObject);
            }
        }
        TypeObjects.Add(new TypeObject() { Id = 0, Name = "Все" });
        GroupObjects.Add(new GroupObject() { Id = 0, Name = "Все" });
        var typeObjects = (Application.Current.Properties["TypeObjects"] as IEnumerable<TypeObject>)!.Where(t => t.Status.Id != 6);

        foreach (var typeObject in typeObjects)
        {
            TypeObjects.Add(typeObject);
        }

        var groupObjects = (Application.Current.Properties["GroupObjects"] as IEnumerable<GroupObject>)!.Where(t => t.Status.Id != 6);
        foreach (var groupObject in groupObjects)
        {
            GroupObjects.Add(groupObject);
        }

        CollectionView = CollectionViewSource.GetDefaultView(WriteOffObjects);
        if (CollectionView != null)
        {
            CollectionView.GroupDescriptions.Clear();
            CollectionView.GroupDescriptions.Add(new PropertyGroupDescription("TypeObject"));
            CollectionView.GroupDescriptions.Add(new PropertyGroupDescription("GroupObject"));
        }
        PropertyChanged += ViewChanged;
    }

    private void ViewChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "RegNamber":
                CollectionView.Filter = FilterByRegNamber;
                IsExpanded = false;
                break;
            case "InvNumber":
                CollectionView.Filter = FilterByInvNumber;
                IsExpanded = false;
                break;

            case "NameFilter":
                CollectionView.Filter = FilterByName;
                IsExpanded = false;
                break;
            case "TypeObjectFilter":
                CollectionView.Filter = FilterByType;
                IsExpanded = false;
                break;
            case "GroupObjectFilter":
                CollectionView.Filter = FilterByGroup;
                IsExpanded = false;
                break;
        }
    }


    #region Filters

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    private string _regNumber = null!;
    public string RegNamber { get => _regNumber; set => Set(ref _regNumber, value); }

    private string _invNumber = null!;
    public string InvNumber { get => _invNumber; set => Set(ref _invNumber, value); }


    private string _nameFilter = null!;
    public string NameFilter { get => _nameFilter; set => Set(ref _nameFilter, value); }

    private TypeObject _typeObjectFilter = null!;
    public TypeObject TypeObjectFilter { get => _typeObjectFilter; set => Set(ref _typeObjectFilter, value); }

    private GroupObject _groupObjectFilter = null!;
    public GroupObject GroupObjectFilter { get => _groupObjectFilter; set => Set(ref _groupObjectFilter, value); }

    private bool FilterByRegNamber(object obj)
    {
        if (!string.IsNullOrEmpty(RegNamber))
        {
            var dto = obj as WriteOffObject;
            if (dto!.RegNumber == null!)
            {
                return false;
            }
            return dto.RegNumber!.ToUpper().Contains(RegNamber.ToUpper());
            

        }
        return true;
    }

    private bool FilterByInvNumber(object obj)
    {
        if (!string.IsNullOrEmpty(InvNumber))
        {
            var dto = obj as WriteOffObject;
            return dto!.InvNumber!.ToUpper().Contains(InvNumber.ToUpper());
        }
        return true;
    }

    private bool FilterByName(object obj)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            var dto = obj as WriteOffObject;
            return dto!.Name.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByType(object obj)
    {
        if (TypeObjectFilter != null!)
        {
            if (TypeObjectFilter.Id == 0) return true;
            var dto = obj as WriteOffObject;
            return dto!.TypeObject == TypeObjectFilter;
        }

        return true;
    }

    private bool FilterByGroup(object obj)
    {
        if (GroupObjectFilter != null!)
        {
            if (GroupObjectFilter.Id == 0) return true;
            var dto = obj as WriteOffObject;
            return dto!.GroupObject == GroupObjectFilter;
        }

        return true;
    }

    #endregion


    #region Commands

    #region Add

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var view = new WriteOffObjectView();
        var model = view.DataContext as WriteOffObjectViewModel;
        model!.SenderModel = this;
        model.Title = "Добавление нового объекта списания";
        view.ShowDialog();
    }

    #endregion

    #region Edit

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        return WriteOffObjectSelected != null!;
    }

    private void OnEditExecuted(object obj)
    {
        var view = new WriteOffObjectView();
        var model = view.DataContext as WriteOffObjectViewModel;
        model!.SenderModel = this;
        model.Title = "Редактирование объекта списания";
        model.WriteOffObject = WriteOffObjectSelected;
        view.ShowDialog();
    }

    #endregion

    #region Delete

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        return WriteOffObjectSelected != null!;
    }

    private void OnDeleteExecuted(object obj)
    {
        
        _notificationManager.ShowButtonWindow($"Вы действительно хотите удалить объект списания: {WriteOffObjectSelected.Name}?",
            "Редактор документов", 
            LeftButtonAction,"Да", 
            RightButtonAction, "Отмена", TimeSpan.MaxValue,"",null, null, false);
    }

    private void RightButtonAction()
    {
    }

    private async void LeftButtonAction()
    {
        try
        {
            WriteOffObjectSelected.Status =
                (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 6)!;
            await _writeOffObjectRepository.SaveAsync(WriteOffObjectSelected);
            WriteOffObjects.Remove(WriteOffObjectSelected);
            _notificationManager.Show("Регистратор",
                "Объект успешно удален из БД",
                NotificationType.Information);

        }
        catch (Exception e)
        {
            _notificationManager.Show("Регистратор",
                $"При удалении объекта произошла ошибка: {e.Message}",
                NotificationType.Error);
        }
    }

    #endregion

    #region SelectRow

    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowExecuted, SelectRowCan);

    private bool SelectRowCan(object arg)
    {
        return WriteOffObjectSelected != null! && SenderModel != null!;
    }

    private void OnSelectRowExecuted(object obj)
    {
        if (SenderModel is DecommissioningTmcViewModel model)
        {
            model.DecommissioningTmc.WriteOffObject = WriteOffObjectSelected;
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }

    #endregion

    #endregion

}
