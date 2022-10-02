using System;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Personnel;
using Agro.WPF.Views.Windows;
using Agro.WPF.Views.Windows.Personnel;
using FNS.Api;

namespace Agro.WPF.ViewModels.Organization;

public class OrganizationViewModel : ViewModel
{
    private readonly IBaseRepository<DAL.Entities.Organization.Organization> _organizationRepository;
    private readonly IBaseRepository<BankDetails> _bankDetailsRepository;

    private DAL.Entities.Organization.Organization _organization = new ();
    public DAL.Entities.Organization.Organization Organization { get=>_organization; set=>Set(ref _organization, value); }

    private string _title = "Настройки организации";
    public string Title { get => _title; set => Set(ref _title, value); }

    private BankDetails _selectedBankDetails=null!;

    public BankDetails SelectedBankDetails {get=>_selectedBankDetails; set=>Set(ref _selectedBankDetails, value);}

    public OrganizationViewModel(
        IBaseRepository<DAL.Entities.Organization.Organization> organizationRepository, 
        IBaseRepository<BankDetails> bankDetailsRepository)
    {
        _organizationRepository = organizationRepository;
        _bankDetailsRepository = bankDetailsRepository;
        LoadData();
    }

    private async void LoadData()
    {
        var org = await _organizationRepository.GetByIdAsync(1);
        if (org!=null!)
            Organization = org;
    }


    #region Commands
    private ICommand? _getOrgCommand;

    public ICommand GetOrgCommand => _getOrgCommand
        ??= new RelayCommand(OnGetOrgCommandExecuted, GetOrgCan);

    private bool GetOrgCan(object arg)
    {
        if (Organization.Inn == null!) return false;
        return Organization.Inn.Length == 10 || Organization.Inn.Length == 12;
    }

    private async void OnGetOrgCommandExecuted(object obj)
    {
        if (Organization.Inn.Length == 10)
        {
         var org =  await CheckoApi.GetOrgUl(Organization.Inn);
         Organization.AddressUr=org.AddressUr;
         Organization.AbbreviatedName=org.AbbreviatedName;
         Organization.Name=org.Name;
         Organization.Kpp=org.Kpp;
         Organization.Okato=org.Okato;
         Organization.Okfs=org.Okfs;
         Organization.Okogy=org.Okogy;
         Organization.Okopf=org.Okopf;
         Organization.Oktmo=org.Oktmo;
         Organization.Ogrn=org.Ogrn;
         Organization.Okpo=org.Okpo;
         Organization.Okved=org.Okved;
         Organization.RegFns=org.RegFns;
         Organization.RegPfr=org.RegPfr;
         Organization.RegFss=org.RegFss;
        }
    }


    private ICommand? _showBankDetailsCommand;

    public ICommand ShowBankDetailsCommand => _showBankDetailsCommand
        ??= new RelayCommand(OnShowBankDetailsCommandExecuted);

    private void OnShowBankDetailsCommandExecuted(object obj)
    {
        BankDetailsView view = new();
        BankDetailsViewModel? viewModel = view.DataContext as BankDetailsViewModel;
        viewModel!.ViewSender = this;
        viewModel.BankDetails.Guid=Guid.NewGuid();
        view.ShowDialog();
    }


    private ICommand? _showEditBankDetailsCommand;

    public ICommand ShowEditBankDetailsCommand => _showEditBankDetailsCommand
        ??= new RelayCommand(OnShowEditBankDetailsCommandExecuted, ShowEditBankDetailsCommandCan);

    private bool ShowEditBankDetailsCommandCan(object arg)
    {
        return SelectedBankDetails != null!;
    }

    private void OnShowEditBankDetailsCommandExecuted(object obj)
    {
        BankDetailsView view = new();
        BankDetailsViewModel? viewModel = view.DataContext as BankDetailsViewModel;
        viewModel!.ViewSender = this;
        viewModel.BankDetails = SelectedBankDetails;
        view.ShowDialog();
    }

    private ICommand? _deleteBankDetailsCommand;

    public ICommand DeleteBankDetailsCommand => _deleteBankDetailsCommand
        ??= new RelayCommand(OnDeleteBankDetailsCommandExecuted, DeleteBankDetailsCommandCan);

    private async void OnDeleteBankDetailsCommandExecuted(object obj)
    {
        var mess = MessageBox.Show($"Вы действительно хотите удалить банковский счет {SelectedBankDetails.Bs}", 
            "Редактор банковских счетов", MessageBoxButton.YesNo);

        if (mess != MessageBoxResult.Yes) return;
        if (SelectedBankDetails.Id != 0)
        {
            await _bankDetailsRepository.DeleteAsync(SelectedBankDetails);
        }
        Organization.BankDetails.Remove(SelectedBankDetails);

    }

    private bool DeleteBankDetailsCommandCan(object arg)
    {
        return SelectedBankDetails != null!;
    }



    private ICommand? _saveBankDetailsCommand;

    public ICommand SaveBankDetailsCommand => _saveBankDetailsCommand
        ??= new RelayCommand(OnSaveBankDetailsCommandExecuted, SaveBankDetailsCommandCan);

    private bool SaveBankDetailsCommandCan(object arg)
    {
        return Organization.Inn != null!;
    }

    private async void OnSaveBankDetailsCommandExecuted(object obj)
    {
        Organization= await _organizationRepository.SaveAsync(Organization);
    }


    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseCommandExecuted);

    private void OnCloseCommandExecuted(object? obj)
    {
        if (obj is Window window)
        {
            window.Close();
        }
        else
        {
            throw new InvalidOperationException("Нет окна для закрытия");
        }
        
    }

    #region ShowEmployeeDirector

    private ICommand? _showEmployeeDirectorCommand;

    public ICommand ShowEmployeeDirectorCommand => _showEmployeeDirectorCommand
        ??= new RelayCommand(OnShowEmployeeDirectorExecuted);

    private void OnShowEmployeeDirectorExecuted(object obj)
    {
        var view = new EmployeesView();
        var model = view.DataContext as EmployeesViewModel;
        model!.SenderModel = this;
        model.SenderModelPole = "Director";
        model.Title = "Выбирете сотрудника - Руководителя";
        view.ShowDialog();
    }

    #endregion

    #region ShowEmployeeGlavByx

    private ICommand? _showEmployeeGlavByxCommand;

    public ICommand ShowEmployeeGlavByxCommand => _showEmployeeGlavByxCommand
        ??= new RelayCommand(OnShowEmployeeGlavByxExecuted);

    private void OnShowEmployeeGlavByxExecuted(object obj)
    {
        var view = new EmployeesView();
        var model = view.DataContext as EmployeesViewModel;
        model!.SenderModel = this;
        model.SenderModelPole = "GeneralAccountant";
        model.Title = "Выбирете сотрудника - Главного бухгалтера";
        view.ShowDialog();
    }

    #endregion

    #region ShowEmployeeCashier

    private ICommand? _showEmployeeCashierCommand;

    public ICommand ShowEmployeeCashierCommand => _showEmployeeCashierCommand
        ??= new RelayCommand(OnShowEmployeeCashierExecuted);

    private void OnShowEmployeeCashierExecuted(object obj)
    {
        var view = new EmployeesView();
        var model = view.DataContext as EmployeesViewModel;
        model!.SenderModel = this;
        model.SenderModelPole = "Cashier";
        model.Title = "Выбирете сотрудника - Кассира";
        view.ShowDialog();
    }

    #endregion

    #region ShowEmployeeHr

    private ICommand? _showEmployeeHrCommand;

    public ICommand ShowEmployeeHrCommand => _showEmployeeHrCommand
        ??= new RelayCommand(OnShowEmployeeHrExecuted);

    private void OnShowEmployeeHrExecuted(object obj)
    {
        var view = new EmployeesView();
        var model = view.DataContext as EmployeesViewModel;
        model!.SenderModel = this;
        model.SenderModelPole = "Hr";
        model.Title = "Выбирете сотрудника - Кадровика";
        view.ShowDialog();
    }

    #endregion

    #endregion
}