using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Agro.DAL;
using Agro.DAL.Entities.Bank.Base;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Bank.BaseView;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Bank.BaseViewModel;

public class ExpenditureItemsViewModel : ViewModel
{
    private readonly IExpenditureItemRepository<ExpenditureItem> _repository;
    private readonly INotificationManager _notificationManager;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<ExpenditureItem> _expenditureItems = new();
    public ObservableCollection<ExpenditureItem> ExpenditureItems { get => _expenditureItems; set => Set(ref _expenditureItems, value); }

    private ExpenditureItem _selectedExpenditureItem = null!;
    public ExpenditureItem SelectedExpenditureItem { get => _selectedExpenditureItem; set => Set(ref _selectedExpenditureItem, value); }

    public bool IsDirection;

    public ExpenditureItemsViewModel(
        IExpenditureItemRepository<ExpenditureItem> repository,
        INotificationManager notificationManager)
    {
        _repository = repository;
        _notificationManager = notificationManager;
        Title = "Справочник статей расходов/доходов";
        LoadData();
    }

    /// <summary>
    /// Загрузка данных для отображения в гриде
    /// </summary>
    private async void LoadData()
    {
        try
        {
            ExpenditureItems.Clear();
            var result = await _repository.GetAllByDirectionNoTrackingAsync();
            foreach (var expenditureItem in result!)
            {
                ExpenditureItems.Add(expenditureItem);
            }
        }
        catch (Exception e)
        {
            _notificationManager.Show("Результат обработки запроса к базе данных",
                "Произошла ошибка: " + e.Message, NotificationType.Error);
        }
    }
    #region Commands

    #region AddCommand

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private async void OnAddExecuted(object obj)
    {
        var view = new ExpenditureItemView();
        var model = view.DataContext as ExpenditureItemViewModel;
        model!.SenderModel = this;
        model.TypeCashFlows = await _repository.GetAllTypeCashFlowNoTrackingAsync();
        model.ExpenditureItem = new();
        view.Show();
    }

    #endregion

    #region Edit

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        return SelectedExpenditureItem != null! && SelectedExpenditureItem.Status!.Id==5;
    }

    private async void OnEditExecuted(object obj)
    {
        var view = new ExpenditureItemView();
        var model = view.DataContext as ExpenditureItemViewModel;
        model!.SenderModel = this;
        model.TypeCashFlows = await _repository.GetAllTypeCashFlowNoTrackingAsync();
        model.ExpenditureItem = await _repository.GetByIdAsync(SelectedExpenditureItem.Id);
        view.Show();
    }
    #endregion

    #region Delete

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        return SelectedExpenditureItem != null!;
    }

    private async void OnDeleteExecuted(object obj)
    {
        try
        {
            var result = MessageBox.Show("Вы действительно хотите удалить статью доходов/расходов: " +
                                         SelectedExpenditureItem.Name, "Редактор статей", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                SelectedExpenditureItem.Status = await _repository.GetStatusByIdAsync(7);
                await _repository.SaveAsync(SelectedExpenditureItem);
                _notificationManager.Show("Результат обработки запроса к базе данных",
                    "Данные успешно сохранены в БД", NotificationType.Information);
            }
        }
        catch (Exception e)
        {
            _notificationManager.Show("Результат обработки запроса к базе данных",
                "Произошла ошибка: " + e.Message, NotificationType.Error);
        }

    }

    #endregion

    #endregion
}
