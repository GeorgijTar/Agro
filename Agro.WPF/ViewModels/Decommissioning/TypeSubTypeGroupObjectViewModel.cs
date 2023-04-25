
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Decommissioning;

public class TypeSubTypeGroupObjectViewModel : ViewModel
{
    private readonly IBaseRepository<TypeObject> _typeRepository;
    private readonly IBaseRepository<GroupObject> _groupRepository;
    private readonly INotificationManager _notificationManager;
    private string _name = null!;
    public string Name
    {
        get => _name;
        set
        {
            Set(ref _name, value);
            switch (Type)
            {
                case "TypeObject":
                    TypeObject.Name = value;
                    return;

                case "GroupObject":
                    GroupObject.Name = value;
                    return;

            }
        }
    }

    private string _status = null!;
    public string Status { get => _status; set => Set(ref _status, value); }

    private int _id;
    public int Id { get => _id; set => Set(ref _id, value); }


    private TypeObject _typeObject = new();
    public TypeObject TypeObject
    {
        get => _typeObject;
        set
        {
            Set(ref _typeObject, value);
            if (Type == "TypeObject")
            {
                Name = value.Name;
                Status = value.Status.Name;
                Id = value.Id;
            }
        }
    }


    private GroupObject _groupObject = null!;
    public GroupObject GroupObject
    {
        get => _groupObject;
        set
        {
            Set(ref _groupObject, value);
            if (Type == "GroupObject")
            {
                Name = value.Name;
                Status = value.Status.Name;
                Id = value.Id;
            }
        }
    }

    public string Type { get; set; } = null!;

    public TypeSubTypeGroupObjectViewModel(
        IBaseRepository<TypeObject> typeRepository,
       IBaseRepository<GroupObject> groupRepository,
        INotificationManager notificationManager)
    {
        _typeRepository = typeRepository;
        _groupRepository = groupRepository;
        _notificationManager = notificationManager;
    }

    #region Commands

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return TypeObject != null! || TypeObject!.Name != null! | GroupObject != null! || GroupObject!.Name != null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {

            if (Type == "TypeObject")
            {
                TypeObject.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(t =>
                    t.Id == 5)!;
                var type = await _typeRepository.SaveAsync(TypeObject);
                Application.Current.Properties["TypeObjects"] = await _typeRepository.GetAllAsync();
                (SenderModel as WriteOffObjectViewModel)!.TypeObjects =
                    (Application.Current.Properties["TypeObjects"] as IEnumerable<TypeObject>)!
                    .Where(t => t.Status.Id != 6).OrderBy(t => t.Name);
                (SenderModel as WriteOffObjectViewModel)!.WriteOffObject.TypeObject = type;
            }

            if (Type == "GroupObject")
            {
                GroupObject.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(t =>
                    t.Id == 5)!;
                var group = await _groupRepository.SaveAsync(GroupObject);
                Application.Current.Properties["GroupObjects"] = await _groupRepository.GetAllAsync();
                (SenderModel as WriteOffObjectViewModel)!.GroupObjects =
                    (Application.Current.Properties["GroupObjects"] as IEnumerable<GroupObject>)!
                    .Where(g => g.Status.Id != 6).OrderBy(g => g.Name);
                (SenderModel as WriteOffObjectViewModel)!.WriteOffObject.GroupObject = group;
            }
            _notificationManager.Show("Регистратор", "Документ успешно добавлен в БД", NotificationType.Information);

            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
        catch (Exception e)
        {
            _notificationManager.Show("Регистратор", $"При сохранении документа возникла ошибка: {e.Message}", NotificationType.Error);
        }
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

    #endregion
}
