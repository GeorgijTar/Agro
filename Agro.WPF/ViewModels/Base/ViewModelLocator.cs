using Microsoft.Extensions.DependencyInjection;

namespace Agro.WPF.ViewModels.Base;

public class ViewModelLocator
{
    public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    public ContractorsViewModel ContractorsModel => App.Services.GetRequiredService<ContractorsViewModel>();

    public CounterpartyViewModel CounterpartyModel => App.Services.GetRequiredService<CounterpartyViewModel>();

    public BankDetailsViewModel BankDetailsModel => App.Services.GetRequiredService<BankDetailsViewModel>();

    public ProductsViewModel ProductsModel => App.Services.GetRequiredService<ProductsViewModel>();

    public ProductViewModel ProductModel => App.Services.GetRequiredService<ProductViewModel>();

    public AccountingPlansViewModel AccountingPlansModel => App.Services.GetRequiredService<AccountingPlansViewModel>();

    public AccountingPlanViewModel AccountingPlanModel => App.Services.GetRequiredService<AccountingPlanViewModel>();

    public InvoicesViewModel InvoicesModel => App.Services.GetRequiredService<InvoicesViewModel>();

    public InvoiceViewModel InvoiceModel => App.Services.GetRequiredService<InvoiceViewModel>();

    public OrganizationViewModel OrganizationModel => App.Services.GetRequiredService<OrganizationViewModel>();

    public ProductInvoiceViewModel ProductInvoiceModel => App.Services.GetRequiredService<ProductInvoiceViewModel>();

    public ReestrInvoiceViewModel ReestrInvoiceModel => App.Services.GetRequiredService<ReestrInvoiceViewModel>();
}