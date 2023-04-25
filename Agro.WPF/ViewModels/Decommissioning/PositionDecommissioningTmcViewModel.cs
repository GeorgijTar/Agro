using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.Warehouse;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.Dto.Warehouse;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.TMC;
using Agro.WPF.Views.Windows.Warehouse;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Decommissioning;
public class PositionDecommissioningTmcViewModel : ViewModel
{
    private readonly ITmcSprRepository<Tmc> _tmcSprRepository;
    private readonly INotificationManager _notificationManager;
    private PositionDecommissioningTmc _position = new();
    public PositionDecommissioningTmc Position
    {
        get => _position;
        set
        {
            Set(ref _position, value);
            Quantity = Position.Quantity;
        }
    }

    private IEnumerable<StorageLocation> _storageLocations = null!;
    public IEnumerable<StorageLocation> StorageLocations { get => _storageLocations; set => Set(ref _storageLocations, value); }

    private TmcSprDto? _tmcSprDto;
    public TmcSprDto? TmcSprDto { get => _tmcSprDto; set => Set(ref _tmcSprDto, value); }

    private decimal _quantity;
    public decimal Quantity
    {
        get => _quantity;
        set
        {
            Set(ref _quantity, value);
            if (TmcSprDto != null!)
            {
                if (value > TmcSprDto!.Quantity)
                {
                    _notificationManager.Show("Регистратор",
                        "Введенное количество привышает количество допустимое для списания", NotificationType.Error);
                    Quantity = 0;
                }
            }

            Position.Quantity = value;
            Position.Amount = value * Position.Price;
        }
    }

    public bool IsEdit { get; set; }

    public PositionDecommissioningTmcViewModel(ITmcSprRepository<Tmc> tmcSprRepository, INotificationManager notificationManager)
    {
        _tmcSprRepository = tmcSprRepository;
        _notificationManager = notificationManager;
        Position.PropertyChanged += PositionPropertyChanged;

        StorageLocations = (Application.Current.Properties["StorageLocations"] as IEnumerable<StorageLocation>)!.OrderBy(s => s.Name);
    }

    private async void PositionPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Tmc))
        {
            TmcSprDto = await _tmcSprRepository.GetRemainsTmcByIdLsApAsync(Position.Tmc.Id, Position.StorageLocation.Id, Position.AccountingPlan.Id);

        }
    }

    #region Commands

    #region ShowTmcSpr

    private ICommand? _showTmcSprCommand;

    public ICommand ShowTmcSprCommand => _showTmcSprCommand
        ??= new RelayCommand(OnShowTmcSprExecuted);

    private void OnShowTmcSprExecuted(object obj)
    {
        var view = new TmcSprView();
        var model = view.DataContext as TmcSprViewModel;
        model!.SenderModel = this;
        view.ShowDialog();
    }
    #endregion

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return true;
    }

    private void OnSaveExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is DecommissioningTmcViewModel model)
            {
                if (IsEdit == false)
                {
                    if (model.DecommissioningTmc.Positions.Any(p => p.Tmc == Position.Tmc))
                    {
                        _notificationManager.Show("Редактор документов",
                            $"В документе уже присутствует позиция с {Position.Tmc.Name}", NotificationType.Error);
                        return;
                    }
                    else
                    {
                        model.DecommissioningTmc.Positions.Add(Position);
                    }
                }
                else
                {
                    var pos = model.DecommissioningTmc.Positions.FirstOrDefault(p => p.Guid == Position.Guid);

                }

                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }

        }
    }

    #endregion

    #endregion
}
