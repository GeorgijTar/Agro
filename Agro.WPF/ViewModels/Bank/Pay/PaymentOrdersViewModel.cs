using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Bank.Pay;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Pages.Bank.Pay;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Bank.Pay;

public class PaymentOrdersViewModel : ViewModel
{
    private readonly IPaymentOrderRepository<PaymentOrder> _repository;
    private readonly INotificationManager _notificationManager;
    private readonly IHelperNavigation _helperNavigation;

    private ObservableCollection<PaymentOrder> _paymentOrders = new();
    public ObservableCollection<PaymentOrder> PaymentOrders
    { get => _paymentOrders; set => Set(ref _paymentOrders, value); }


    private PaymentOrder _selectedPaymentOrder = null!;
    public PaymentOrder SelectedPaymentOrder
    {
        get => _selectedPaymentOrder; set => Set(ref _selectedPaymentOrder, value);
    }

    public PaymentOrdersViewModel(
        IPaymentOrderRepository<PaymentOrder> repository,
        INotificationManager notificationManager,
        IHelperNavigation helperNavigation)
    {
        _repository = repository;
        _notificationManager = notificationManager;
        _helperNavigation = helperNavigation;
        Title = "Реестр платежных поручений";
        LoadData();
    }

    private async void LoadData()
    {
        PaymentOrders.Clear();
        try
        {
            var po = await _repository.GetAllNoTrackingAsync();
            foreach (var paymentOrder in po!)
            {
                PaymentOrders.Add(paymentOrder);
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
        var page = new PaymentOrderPage();
        var model=page.DataContext as PaymentOrderViewModel;
        model!.SenderModel=this;
        model.PaymentOrder!.Number = await _repository.GetNumberAsync();
        model.TabItem = _helperNavigation.OpenPage(page, "Новое платежное поручение");

    }

    #endregion

    #region EditCommand

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        return SelectedPaymentOrder!=null!;
    }

    private async void OnEditExecuted(object obj)
    {
        var page = new PaymentOrderPage();
        var model = page.DataContext as PaymentOrderViewModel;
        model!.SenderModel = this;
        model.PaymentOrder = await _repository.GetByIdAsync(SelectedPaymentOrder.Id);
        model.TabItem = _helperNavigation.OpenPage(page, "Новое платежное поручение");

    }

    #endregion

    #region DeleteCommand

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        return SelectedPaymentOrder!=null! &&  SelectedPaymentOrder.Status!.Id==1;
    }

    private async void OnDeleteExecuted(object obj)
    {
        var resalt = MessageBox.Show($"Вы действительно хотите удалить платежное поручение № {SelectedPaymentOrder.Number} от {SelectedPaymentOrder.Date.ToShortDateString()}", 
            "Редактор документов", 
            MessageBoxButton.YesNo);
        if (resalt == MessageBoxResult.Yes)
        {
            try
            {
               var po = await _repository.GetByIdAsync(SelectedPaymentOrder.Id);
                po!.Status = (System.Windows.Application.Current.Properties["Status"]
                    as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 6);
                await _repository.SaveAsync(po);
                SelectedPaymentOrder.Status =po.Status;
                _notificationManager.Show("Логер", "Платежное поручение успешно удалено", NotificationType.Information);
            }
            catch (Exception e)
            {
                _notificationManager.Show("Логер",$"При удалении возникла ошибка: {e.Message}", NotificationType.Error);
            }
        }
    }

    #endregion

    #endregion
}

