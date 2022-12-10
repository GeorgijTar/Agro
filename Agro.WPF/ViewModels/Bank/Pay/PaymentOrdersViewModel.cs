using System.Collections.ObjectModel;
using Agro.DAL.Entities.Bank.Pay;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels.Bank.Pay;

public class PaymentOrdersViewModel : ViewModel
{
    private ObservableCollection<PaymentOrder> _paymentOrders = new ();
    public ObservableCollection<PaymentOrder> PaymentOrders 
    { get => _paymentOrders; set => Set(ref _paymentOrders, value); }


    private PaymentOrder _selectedPaymentOrder = null!;
    public PaymentOrder SelectedPaymentOrder {
        get => _selectedPaymentOrder; set => Set(ref _selectedPaymentOrder, value); }

    public PaymentOrdersViewModel()
    {
        Title = "Реестр платежных поручений";
    }
}

