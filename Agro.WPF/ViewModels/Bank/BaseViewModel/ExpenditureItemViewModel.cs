using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.Bank.Base;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Bank.BaseViewModel;
public class ExpenditureItemViewModel : ViewModel
{
    private readonly IExpenditureItemRepository<ExpenditureItem> _repository;
    private readonly INotificationManager _notificationManager;

    private ExpenditureItem? _expenditureItem = new();
    public ExpenditureItem? ExpenditureItem { get => _expenditureItem; set => Set(ref _expenditureItem, value); }

    private IEnumerable<TypeCashFlow>? _typeCashFlows;
    public IEnumerable<TypeCashFlow>? TypeCashFlows { get => _typeCashFlows; set => Set(ref _typeCashFlows, value); }


    public ExpenditureItemViewModel(
        IExpenditureItemRepository<ExpenditureItem> repository, 
        INotificationManager notificationManager)
    {
        _repository = repository;
        _notificationManager = notificationManager;
        Title = "Статья доходов/расходов";
        LoadData();
    }

    private async void LoadData()
    {
        
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return ExpenditureItem != null! && ExpenditureItem.Name != null! &&
               !string.IsNullOrEmpty(ExpenditureItem!.Name.Trim()) && 
               ExpenditureItem.TypeCashFlow != null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {
            ExpenditureItem!.Status = await _repository.GetStatusByIdAsync(5);
            ExpenditureItem.Direction=ExpenditureItem.TypeCashFlow.Direction;

            var resultDb = await _repository.SaveAsync(ExpenditureItem);
            if (SenderModel != null!)
            {
                if (SenderModel is ExpenditureItemsViewModel expenditure)
                {
                    var result = expenditure.ExpenditureItems
                        .FirstOrDefault(s => s.Id == resultDb.Id);
                    if (result != null!)
                    {
                        int i = expenditure.ExpenditureItems.IndexOf(result);
                        if (i != -1)
                        {
                            expenditure.ExpenditureItems[i]= resultDb;
                        }
                    }
                    else
                    {
                        expenditure.ExpenditureItems.Add(resultDb);
                    }
                }
            }
            _notificationManager.Show("Результат обработки запроса к базе данных",
                "Данные успешно сохранены в БД", NotificationType.Information);
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
        catch (Exception e)
        {
            _notificationManager.Show("Результат обработки запроса к базе данных",
                "Произошла ошибка: " + e.Message, NotificationType.Error);
        }
    }


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

}
