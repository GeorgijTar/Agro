
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
using Agro.Interfaces.Base.Repositories.Base;
using Agro.Services.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Warehouse.Decommissioning;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Decommissioning;

public class PurposeExpendituresViewModel : ViewModel
{
    private readonly IBaseRepository<PurposeExpenditure> _pupposeRepository;
    private readonly INotificationManager _notificationManager;
    private ObservableCollection<PurposeExpenditure> _purposeExpenditures = new();

    public ObservableCollection<PurposeExpenditure> PurposeExpenditures
    {
        get => _purposeExpenditures;
        set => Set(ref _purposeExpenditures, value);
    }

    private PurposeExpenditure _purposeExpenditureSelect = null!;

    public PurposeExpenditure PurposeExpenditureSelect
    {
        get => _purposeExpenditureSelect;
        set => Set(ref _purposeExpenditureSelect, value);
    }

    public PurposeExpendituresViewModel(
        IBaseRepository<PurposeExpenditure> pupposeRepository,
        INotificationManager notificationManager)
    {
        _pupposeRepository = pupposeRepository;
        _notificationManager = notificationManager;
        LoadData();
        PropertyChanged += ViewChanged;
    }

    private async void LoadData()
    {
        var pur = await _pupposeRepository.GetAllAsync();
        foreach (var expenditure in pur!)
        {
            if (expenditure.Status.Id != 6)
            {
                PurposeExpenditures.Add(expenditure);
            }
        }

        CollectionView = CollectionViewSource.GetDefaultView(PurposeExpenditures);
    }

    private void ViewChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "NameFilter":
                CollectionView.Filter = FilterByName;
                break;
        }
    }

    #region Filter



    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }


    private string _nameFilter = null!;
    public string NameFilter { get => _nameFilter; set => Set(ref _nameFilter, value); }

    private bool FilterByName(object obj)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            var dto = obj as PurposeExpenditure;
            return dto!.Name.ToUpper().Contains(NameFilter.ToUpper());
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
        var view = new PurposeExpenditureView();
        var model = view.DataContext as PurposeExpenditureViewModel;
        model!.SenderModel = this;
        view.ShowDialog();
    }

    #endregion

    #region Edit

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        return PurposeExpenditureSelect != null!;
    }

    private void OnEditExecuted(object obj)
    {
        var view = new PurposeExpenditureView();
        var model = view.DataContext as PurposeExpenditureViewModel;
        model!.SenderModel = this;
        model.PurposeExpenditure = PurposeExpenditureSelect;
        view.ShowDialog();
    }

    #endregion

    #region Delete

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        return PurposeExpenditureSelect!=null!;
    }

    private void OnDeleteExecuted(object obj)
    {

        _notificationManager.ShowButtonWindow($"Вы действительно хотите удалить цель расходования: {PurposeExpenditureSelect.Name}?",
            "Редактор документов",
            LeftButtonAction, "Да",
            RightButtonAction, "Отмена", TimeSpan.MaxValue, "", null, null, false);
    }

    private void RightButtonAction()
    {
    }

    private async void LeftButtonAction()
    {
        try
        {
            PurposeExpenditureSelect.Status =
                (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 6)!;
            await _pupposeRepository.SaveAsync(PurposeExpenditureSelect);
            PurposeExpenditures.Remove(PurposeExpenditureSelect);
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
        return PurposeExpenditureSelect != null! && SenderModel != null!;
    }

    private void OnSelectRowExecuted(object obj)
    {
        if (SenderModel is DecommissioningTmcViewModel model)
        {
            model.DecommissioningTmc.PurposeExpenditure = PurposeExpenditureSelect;
            model.DecommissioningTmc.AccountingPlan=PurposeExpenditureSelect.AccountingPlan;
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }

    #endregion
    #endregion
}
