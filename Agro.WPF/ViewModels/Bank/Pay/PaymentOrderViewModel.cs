using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Bank.Pay;
using Agro.DAL.Entities.Base;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.InvoiceVM;
using Agro.WPF.Views.Windows;
using Notification.Wpf;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace Agro.WPF.ViewModels.Bank.Pay;
public class PaymentOrderViewModel : ViewModel
{
    private readonly IPaymentOrderRepository<PaymentOrder> _repository;
    private readonly INotificationManager _notificationManager;
    private readonly IHelperNavigation _helperNavigation;
    private PaymentOrder? _paymentOrder = new();
    public PaymentOrder? PaymentOrder { get => _paymentOrder; set => Set(ref _paymentOrder, value); }

    public int IdPaymentOrder { get; set; }

    private Visibility _isVisibilityInvoice = Visibility.Collapsed;
    public Visibility IsVisibilityInvoice { get => _isVisibilityInvoice; set => Set(ref _isVisibilityInvoice, value); }


    private ICollection<BankDetails> _bankDetailsCounterparty = null!;
    public ICollection<BankDetails> BankDetailsCounterparty
    {
        get => _bankDetailsCounterparty;
        set
        {
            Set(ref _bankDetailsCounterparty, value);
            if (value != null! && value.Count == 1)
            {
                PaymentOrder!.BankDetailsCounterparty = value.First();
            }
        }
    }

    private string _fullNameBankOrg = null!;

    public string FullNameBankOrg
    {
        get => _fullNameBankOrg;
        set => Set(ref _fullNameBankOrg, value);
    }

    private string _fullNameBankCoynter = null!;

    public string FullNameBankCoynter
    {
        get => _fullNameBankCoynter;
        set => Set(ref _fullNameBankCoynter, value);
    }

    private IEnumerable<BankDetails>? _bankDetailsOrg;
    public IEnumerable<BankDetails>? BankDetailsOrg
    {
        get => _bankDetailsOrg;
        set
        {
            Set(ref _bankDetailsOrg, value);
            PaymentOrder!.BankDetailsOrganization = value!.FirstOrDefault(b => b.IsMain)!;
        }
    }

    private IEnumerable<TypeOperationPay>? _typeOperationsPay;
    public IEnumerable<TypeOperationPay>? TypeOperationsPay { get => _typeOperationsPay; set => Set(ref _typeOperationsPay, value); }

    private IEnumerable<TypePayment>? _typePayments;
    public IEnumerable<TypePayment>? TypePayments { get => _typePayments; set => Set(ref _typePayments, value); }

    private IEnumerable<Nds>? _nds;
    public IEnumerable<Nds>? Nds { get => _nds; set => Set(ref _nds, value); }

    private IEnumerable<BasisPayment>? _basisPayments;
    public IEnumerable<BasisPayment>? BasisPayments { get => _basisPayments; set => Set(ref _basisPayments, value); }

    private IEnumerable<PayerStatus>? _payerStatus = null!;
    public IEnumerable<PayerStatus>? PayerStatus { get => _payerStatus; set => Set(ref _payerStatus, value); }

    private IEnumerable<OrderPayment>? _orderPayment;
    public IEnumerable<OrderPayment>? OrderPayment { get => _orderPayment; set => Set(ref _orderPayment, value); }

    private IEnumerable<TypeTransactions>? _typeTransactions = null!;
    public IEnumerable<TypeTransactions>? TypeTransactions { get => _typeTransactions; set => Set(ref _typeTransactions, value); }

    private bool _isEnabletNds = true;

    public bool IsEnabletNds
    {
        get => _isEnabletNds;
        set => Set(ref _isEnabletNds, value);
    }

    private string _invoiceName = null!;
    public string InvoiceName { get => _invoiceName; set => Set(ref _invoiceName, value); }

    public PaymentOrderViewModel(IPaymentOrderRepository<PaymentOrder> repository,
        INotificationManager notificationManager,
        IHelperNavigation helperNavigation)
    {
        _repository = repository;
        _notificationManager = notificationManager;
        _helperNavigation = helperNavigation;
        Title = "Платежное поручение";

        this.PropertyChanged += ModelChanged;
        PaymentOrder!.PropertyChanged += PaymentOrderChanged;

        LoadData();
    }

    private void ModelChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "PaymentOrder":
                TypeOperationChanged();
                if (PaymentOrder != null!)
                {
                    PaymentOrder!.PropertyChanged += PaymentOrderChanged;
                    LoadData();
                }
                break;
        }
    }

    private void TypeOperationChanged()
    {
        if (PaymentOrder! == null! || PaymentOrder.TypeOperation == null!) return;
        if (PaymentOrder!.TypeOperation.Id == 1)
        {
            IsVisibilityInvoice = Visibility.Visible;
            if (PaymentOrder.Invoice != null!)
            {
                PaymentOrder.PurposePayment = $"Оплата согласно сч. № {PaymentOrder.Invoice.Number}" +
                                              $" от {PaymentOrder.Invoice.DateInvoice.ToShortDateString()}";
                PaymentOrder.Nds = PaymentOrder.Invoice.Nds;
                PaymentOrder.Amount = PaymentOrder.Invoice.TotalAmount;
                PaymentOrder.AmountNds = PaymentOrder.Invoice.AmountNds;
                PaymentOrder.Counterparty = PaymentOrder.Invoice.Counterparty;
                PaymentOrder.BankDetailsCounterparty = PaymentOrder.Invoice.BankDetails;

                InvoiceName = $"Счет № {PaymentOrder.Invoice.Number} от " +
                              $"{PaymentOrder.Invoice.DateInvoice.ToShortDateString()} " +
                              $"на сумму {PaymentOrder.Invoice.TotalAmount.ToString("N2", CultureInfo.GetCultureInfo("ru-RU"))}";
                IsEnabletNds = false;
            }
            else
            {
                PaymentOrder.Nds = null!;
                PaymentOrder.Amount = 0;
                PaymentOrder.AmountNds = 0;
                PaymentOrder.Counterparty = null!;
                PaymentOrder.BankDetailsCounterparty = null!;
                InvoiceName = null!;
                IsEnabletNds = true;
            }
        }
        else
        {
            IsVisibilityInvoice = Visibility.Collapsed;
            PaymentOrder.Invoice = null!;
        }

        if (PaymentOrder!.TypeOperation.Id == 2)
        {
            PaymentOrder.Kbk = "18201061201010000510";
            PaymentOrder.PayerStatus = (Application.Current.Properties["PayerStatus"] as IEnumerable<PayerStatus>)!.FirstOrDefault(s => s.Id == 1);
            PaymentOrder.Oktmo = "0";
            PaymentOrder.BasisPayment = (Application.Current.Properties["BasisPayments"] as IEnumerable<BasisPayment>)!.FirstOrDefault(b => b.Id == 1);
            PaymentOrder.TaxPeriod = new TaxPeriod() { Tax1 = "0" };
            PaymentOrder.NumberDoc = "0";
            PaymentOrder.DateDoc = "0";
            PaymentOrder.Nds = (Application.Current.Properties["Nds"] as IEnumerable<Nds>)!.FirstOrDefault(b => b.Id == 1)!;
            IsEnabletNds = false;
            PaymentOrder.AmountNds = 0;
            PaymentOrder.PurposePayment = "Единый налоговый платеж. НДС не облагается";

        }
        else
        {
            PaymentOrder.Kbk = null!;
            PaymentOrder.PayerStatus = null!;
            PaymentOrder.Oktmo = null!;
            PaymentOrder.BasisPayment = null!;
            PaymentOrder.TaxPeriod = null!;
            PaymentOrder.NumberDoc = null!;
            PaymentOrder.DateDoc = null!;
            PaymentOrder.Nds = null!;
            IsEnabletNds = true;
            PaymentOrder.PurposePayment = null!;
        }
    }
    private void PaymentOrderChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "TypeOperation":
                TypeOperationChanged();
                break;
            case "BankDetailsOrganization":
                FullNameBankOrg = $"{PaymentOrder!.BankDetailsOrganization.NameBank} {PaymentOrder!.BankDetailsOrganization.City}";
                break;
            case "BankDetailsCounterparty":
                if (PaymentOrder!.BankDetailsCounterparty != null!)
                {
                    FullNameBankCoynter = $"{PaymentOrder!.BankDetailsCounterparty.NameBank} {PaymentOrder!.BankDetailsCounterparty.City}";
                }
                else
                {
                    FullNameBankCoynter = null!;
                }
                break;

            case "Invoice":
                if (PaymentOrder != null!)
                {
                    if (PaymentOrder.Invoice != null!)
                    {
                        PaymentOrder.PurposePayment = $"Оплата согласно сч. № {PaymentOrder.Invoice.Number}" +
                                                      $" от {PaymentOrder.Invoice.DateInvoice.ToShortDateString()}";
                        PaymentOrder.Nds = PaymentOrder.Invoice.Nds;
                        PaymentOrder.Amount = PaymentOrder.Invoice.TotalAmount;
                        PaymentOrder.AmountNds = PaymentOrder.Invoice.AmountNds;
                        PaymentOrder.Counterparty = PaymentOrder.Invoice.Counterparty;
                        PaymentOrder.BankDetailsCounterparty = PaymentOrder.Invoice.BankDetails;

                        InvoiceName = $"Счет № {PaymentOrder.Invoice.Number} от " +
                                      $"{PaymentOrder.Invoice.DateInvoice.ToShortDateString()} " +
                                      $"на сумму {PaymentOrder.Invoice.TotalAmount.ToString("N2", CultureInfo.GetCultureInfo("ru-RU"))}";
                        IsEnabletNds = false;
                    }
                    else
                    {
                        PaymentOrder.Nds = null!;
                        PaymentOrder.Amount = 0;
                        PaymentOrder.AmountNds = 0;
                        PaymentOrder.Counterparty = null!;
                        PaymentOrder.BankDetailsCounterparty = null!;
                        InvoiceName = null!;
                        IsEnabletNds = true;
                    }
                }
                break;

            case "Nds":
                CalculationNds();
                break;

            case "Amount":
                CalculationNds();
                break;

        }
    }

    private void CalculationNds()
    {
        if (PaymentOrder!.Nds != null!)
        {
            string textNds = "";
            if (PaymentOrder!.Nds.Id == 1 || PaymentOrder!.Nds.Id == 2)
            {
                PaymentOrder!.AmountNds = 0;
                textNds = ", НДС не облагается";
            }
            else
            {
                PaymentOrder!.AmountNds = PaymentOrder.Amount / PaymentOrder.Nds.OverPercent *
                    PaymentOrder.Nds.Percent / 100;
                textNds =
                    $", НДС {PaymentOrder.Nds.Name} {PaymentOrder.AmountNds.ToString("N2", CultureInfo.GetCultureInfo("ru-RU"))}";
            }

            if (!string.IsNullOrEmpty(PaymentOrder!.PurposePayment))
            {
                var purArr = PaymentOrder.PurposePayment.Split(", НДС");

                PaymentOrder.PurposePayment = purArr[0] + textNds;
            }
            else
            {
                PaymentOrder.PurposePayment = textNds;
            }

        }
    }

    private async void LoadData()
    {
        BankDetailsOrg = Application.Current.Properties["BankDetailsOrg"] as IEnumerable<BankDetails>;
        TypeOperationsPay = Application.Current.Properties["TypeOperation"] as IEnumerable<TypeOperationPay>;
        TypePayments = Application.Current.Properties["TypePayments"] as IEnumerable<TypePayment>;
        Nds = Application.Current.Properties["Nds"] as IEnumerable<Nds>;
        BasisPayments = Application.Current.Properties["BasisPayments"] as IEnumerable<BasisPayment>;
        PayerStatus = Application.Current.Properties["PayerStatus"] as IEnumerable<PayerStatus>;
        TypeTransactions = Application.Current.Properties["TypeTransactions"] as IEnumerable<TypeTransactions>;
        OrderPayment = Application.Current.Properties["OrderPayment"] as IEnumerable<OrderPayment>;
        if (PaymentOrder != null! && PaymentOrder.OrderPayment == null!)
        {
            PaymentOrder.OrderPayment = (OrderPayment!.FirstOrDefault(o => o.Code == "5"))!;
        }

        if (PaymentOrder!.Status! == null!)
        {
            PaymentOrder.Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1);
        }

        PaymentOrder!.Uip = "0";
        PaymentOrder.TaxPeriod = new();
        PaymentOrder.TypeTransactions = (Application.Current.Properties["TypeTransactions"] as IEnumerable<TypeTransactions>)!.FirstOrDefault(t => t.Code == "01")!;
        PaymentOrder.Organization = (Application.Current.Properties["Organization"] as DAL.Entities.Organization.Organization)!;
        //FullNameBankOrg = $"{PaymentOrder!.BankDetailsOrganization.NameBank} {PaymentOrder!.BankDetailsOrganization.City}";
    }


    #region Commands

    #region ShowCounterpartyes

    private ICommand? _showCounterpartyesCommand;

    public ICommand ShowCounterpartyesCommand => _showCounterpartyesCommand
        ??= new RelayCommand(OnShowCounterpartyesExecuted);

    private void OnShowCounterpartyesExecuted(object obj)
    {
        var view = new CoynterpartiesView();
        var model = view.DataContext as ContractorsViewModel;
        model!.SenderModel = this;
        view.ShowDialog();
    }
    #endregion

    #region RemovalCounterparty

    private ICommand? _removalCounterpartyCommand;

    public ICommand RemovalCounterpartyCommand => _removalCounterpartyCommand
        ??= new RelayCommand(OnRemovalCounterpartyExecuted, RemovalCounterpartyCan);

    private bool RemovalCounterpartyCan(object arg)
    {
        return PaymentOrder != null! && PaymentOrder.Counterparty != null!;
    }

    private void OnRemovalCounterpartyExecuted(object obj)
    {
        PaymentOrder!.Counterparty = null!;
    }

    #endregion

    #region ShowInvoice

    private ICommand? _showInvoiceCommand;

    public ICommand ShowInvoiceCommand => _showInvoiceCommand
        ??= new RelayCommand(OnShowInvoiceExecuted, ShowInvoiceCan);

    private bool ShowInvoiceCan(object arg)
    {
        return PaymentOrder!.TypeOperation != null! && PaymentOrder!.TypeOperation.Id == 1;
    }

    private void OnShowInvoiceExecuted(object obj)
    {
        var view = new InvoicesView();
        //view.ShowInTaskbar = false;
        var model = view.DataContext as InvoicesViewModel;
        model!.TypeInvoice = (System.Windows.Application.Current.Properties["Types"]
            as IEnumerable<TypeDoc>)!.FirstOrDefault(t => t.Id == 9)!;
        model.StatusFilter = (System.Windows.Application.Current.Properties["Status"]
            as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 9);
        model.SenderModel = this;
        view.ShowDialog();
    }

    #endregion

    #region RemovalInvoice

    private ICommand? _removalInvoiceCommand;

    public ICommand RemovalInvoiceCommand => _removalInvoiceCommand
        ??= new RelayCommand(OnRemovalInvoiceExecuted, RemovalInvoiceCan);

    private bool RemovalInvoiceCan(object arg)
    {
        return PaymentOrder != null! && PaymentOrder.Invoice != null!;
    }

    private void OnRemovalInvoiceExecuted(object obj)
    {
        PaymentOrder!.Invoice = null!;
    }

    #endregion

    #region SavePaymentOrder

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return true;
    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {
            if (PaymentOrder!.UserCreator == null!)
            {
                PaymentOrder!.UserCreator = (Application.Current.Properties["CurrentUser"] as User)!;
            }
            var po = await _repository.SaveAsync(PaymentOrder!);
            if (SenderModel != null!)
            {
                if (SenderModel is PaymentOrdersViewModel payments)
                {
                    var ind = payments.PaymentOrders.FirstOrDefault(p => p.Id == po.Id);
                    if (ind! == null!)
                    {
                        payments.PaymentOrders.Add(po);
                    }
                    else
                    {
                        int i = payments.PaymentOrders.IndexOf(ind);
                        payments.PaymentOrders[i] = po;
                    }
                }
            }

            _helperNavigation.ClosePage(TabItem);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"Во время сохранения возникла ошибка: {e.Message}", NotificationType.Error);
        }
    }

    #endregion

    #region ClosePage

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        _helperNavigation.ClosePage(TabItem);
    }

    #endregion

    #endregion
}