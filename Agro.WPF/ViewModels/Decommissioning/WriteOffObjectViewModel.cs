using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Warehouse;
using Castle.Components.DictionaryAdapter.Xml;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Decommissioning;
public class WriteOffObjectViewModel : ViewModel
{
    private readonly IBaseRepository<WriteOffObject> _writeOffObjectRepository;
    private readonly INotificationManager _notificationManager;

    private WriteOffObject _writeOffObject = new();
    public WriteOffObject WriteOffObject { get => _writeOffObject; set => Set(ref _writeOffObject, value); }


    private IEnumerable<TypeObject> _typeObjects = null!;
    public IEnumerable<TypeObject> TypeObjects { get => _typeObjects; set => Set(ref _typeObjects, value); }


    private IEnumerable<GroupObject> _groupObjects = null!;
    public IEnumerable<GroupObject> GroupObjects { get => _groupObjects; set => Set(ref _groupObjects, value); }

    public WriteOffObjectViewModel(
        IBaseRepository<WriteOffObject> writeOffObjectRepository,
        INotificationManager notificationManager)
    {
        _writeOffObjectRepository = writeOffObjectRepository;
        _notificationManager = notificationManager;
        LoadData();
    }

    private void LoadData()
    {
        TypeObjects = (Application.Current.Properties["TypeObjects"] as IEnumerable<TypeObject>)!
            .Where(t => t.Status.Id != 6).OrderBy(t => t.Name);
        GroupObjects = (Application.Current.Properties["GroupObjects"] as IEnumerable<GroupObject>)!
            .Where(g => g.Status.Id != 6).OrderBy(g => g.Name);
    }


    #region Commands

    #region Add

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var view = new TypeSubTypeGroupObjectView();
        var model = view.DataContext as TypeSubTypeGroupObjectViewModel;
        model!.SenderModel = this;
        if ((string)obj == "TypeObject")
        {
            model.TypeObject = new();
            model.Type = "TypeObject";
            model.Title = "Добпаление нового типа объекта списания";
        }

        if ((string)obj == "GroupObject")
        {
            model.GroupObject = new();
            model.Type = "GroupObject";
            model.Title = "Добпаление новой группы объекта списания";
        }

        view.ShowDialog();
    }

    #endregion

    #region Edit

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        if ((string)arg == "TypeObject")
        {
            return WriteOffObject.TypeObject != null!;
        }

        if ((string)arg == "GroupObject")
        {
            return WriteOffObject.GroupObject != null!;
        }

        return false;
    }

    private void OnEditExecuted(object obj)
    {
        var view = new TypeSubTypeGroupObjectView();
        var model = view.DataContext as TypeSubTypeGroupObjectViewModel;
        if ((string)obj == "TypeObject")
        {
            model!.TypeObject = WriteOffObject.TypeObject;
            model.Type = "TypeObject";
            model.Title = "Редактирование типа объекта списания";
        }

        if ((string)obj == "GroupObject")
        {
            model!.GroupObject = WriteOffObject.GroupObject;
            model.Type = "GroupObject";
            model.Title = "Редактирование группы объекта списания";
        }

        view.ShowDialog();
    }

    #endregion

    #region Close

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

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return WriteOffObject.TypeObject != null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {
            WriteOffObject.Status =
                (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(t => t.Id == 5)!;
            var writeOffObject = await _writeOffObjectRepository.SaveAsync(WriteOffObject);
        if (SenderModel != null!)
        {
            if (SenderModel is WriteOffObjectsViewModel wmModel)
            {
                var woo= wmModel.WriteOffObjects.FirstOrDefault(t=>t.Id== writeOffObject.Id);
                if (woo != null!)
                {
                    var ind = wmModel.WriteOffObjects.IndexOf(woo);
                    wmModel.WriteOffObjects[ind]= writeOffObject;
                }
                else
                {
                    wmModel.WriteOffObjects.Add(writeOffObject);
                }
            }
        }
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
        _notificationManager.Show("Редактор документов",
            "Объект успешно сохранен", NotificationType.Information);
        }
        catch (Exception e)
        {
            var message = e.InnerException != null! ? e.InnerException.Message : e.Message;
            _notificationManager.Show("Редактор документов",
                $"При сохранении документа в БД произошла ошибка: {message}", NotificationType.Error);
        }

    }

    #endregion

    #region ClearGroup

    private ICommand? _clearGroupCommand;

    public ICommand ClearGroupCommand => _clearGroupCommand
        ??= new RelayCommand(OnClearGroupExecuted, ClearGroupCan);

    private bool ClearGroupCan(object arg)
    {
        return WriteOffObject.GroupObject != null!;
    }

    private void OnClearGroupExecuted(object obj)
    {
        WriteOffObject.GroupObject = null!;
    }

    #endregion
    #endregion
}
