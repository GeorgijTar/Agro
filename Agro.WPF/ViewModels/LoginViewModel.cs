using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System;
using System.Windows;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Helpers;
using System.Reflection;
using System.Windows.Media;
using Notification.Wpf;

namespace Agro.WPF.ViewModels;

public class LoginViewModel : ViewModel
{

    private readonly ILoginRepository<User> _loginRepository;
    private readonly INotificationManager _notificationManager;
    private readonly IReferencesRepository _referencesRepository;

    private string _login = null!;
    public string Login { get => _login; set => Set(ref _login, value); }

    private string _password = null!;
    public string Password { get => _password; set => Set(ref _password, value); }

    private string _currentVersion = null!;
    public string CurrentVersion { get => _currentVersion; set => Set(ref _currentVersion, value); }

    private SolidColorBrush _ellipseColor = new SolidColorBrush(Colors.Red);
    public SolidColorBrush EllipseColor { get => _ellipseColor; set => Set(ref _ellipseColor, value); }

    private string _ellipseLabel = "Сервер не доступен!";
    public string EllipseLabel { get => _ellipseLabel; set => Set(ref _ellipseLabel, value); }

    private User? _user;

    public LoginViewModel(
        ILoginRepository<User> loginRepository,
        INotificationManager notificationManager,
        IReferencesRepository referencesRepository)
    {
        _loginRepository = loginRepository;
        _notificationManager = notificationManager;
        _referencesRepository = referencesRepository;
        CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version!.ToString();
        AvailableServer();
    }

    private async void AvailableServer()
    {
        if (await _loginRepository.ExistsDb())
        {
            EllipseColor = new SolidColorBrush(Colors.Green);
            EllipseLabel = "Сервер доступен!";
        }
    }

    #region Commands

    #region Login

    private ICommand? _loginCommand;

    public ICommand LoginCommand => _loginCommand
        ??= new RelayCommand(OnLoginCommandExecuted, LoginCan);

    private bool LoginCan(object arg)
    {
        return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
    }

    private async void OnLoginCommandExecuted(object p)
    {
        try
        {
            _user = await _loginRepository.GetUserAsync(Login, AgroHelper.CalculateHash(Password, Login));

            if (_user != null!)
            {
                LoadStaticData();
                var window = p as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
            else
            {
                _notificationManager.Show("Логер", "Неверный логин или пароль!", NotificationType.Error);
                // MessageBox.Show("Неверный логин или пароль!", "Авторизация");
            }
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"Ошибка: {e}", NotificationType.Error);
        }

    }

    #endregion

    #region Exit

    private ICommand? _exitCommand;

    public ICommand ExitCommand => _exitCommand
        ??= new RelayCommand(OnExitExecuted);

    private void OnExitExecuted(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    #endregion

    private async void LoadStaticData()
    {
        using var progress = _notificationManager.ShowProgressBar("Загрузка статических данных");

        progress.Report((100, "Получение информации о пользователе", "Загрузка статических данных", false));
        Application.Current.Properties["CurrentUser"] = _user;

        progress.Report((100, "Загрузка справочника типов документов", "Загрузка статических данных", false));
        Application.Current.Properties["Types"] = await _referencesRepository.GetAllTypeDocAsync().ConfigureAwait(true);

        progress.Report((100, "Загрузка справочника статусов документов", "Загрузка статических данных", false));
        Application.Current.Properties["Status"] = await _referencesRepository.GetAllStatusAsync();

        progress.Report((100, "Загрузка справочника групп документов", "Загрузка статических данных", false));
        Application.Current.Properties["Groups"] = await _referencesRepository.GetAllGroupDocAsync();

        progress.Report((100, "Загрузка справочника типов операций", "Загрузка статических данных", false));
        Application.Current.Properties["TypeOperation"] = await _referencesRepository.GetAllTypeOperationPayAsync();

        progress.Report((100, "Загрузка справочника банковских реквизитов организации", "Загрузка статических данных", false));
        Application.Current.Properties["BankDetailsOrg"] = await _referencesRepository.GetAllBankDetailsOrgAsync();

        progress.Report((100, "Загрузка данных организации", "Загрузка статических данных", false));
        Application.Current.Properties["Organization"] = await _referencesRepository.GetOrganizationAsync();

        progress.Report((100, "Загрузка справочника видов платежа", "Загрузка статических данных", false));
        Application.Current.Properties["TypePayments"] = await _referencesRepository.GetAllTypesPaymentAsync();

        progress.Report((100, "Загрузка ставок НДС", "Загрузка статических данных", false));
        Application.Current.Properties["Nds"] = await _referencesRepository.GetAllNdsAsync();

        progress.Report((100, "Загрузка справочника оснований платежа", "Загрузка статических данных", false));
        Application.Current.Properties["BasisPayments"] = await _referencesRepository.GetAllBasisPaymentAsync();

        progress.Report((100, "Загрузка справочника статусов плательщика", "Загрузка статических данных", false));
        Application.Current.Properties["PayerStatus"] = await _referencesRepository.GetAllPayerStatusAsync();

        progress.Report((100, "Загрузка справочника очередности платежа", "Загрузка статических данных", false));
        Application.Current.Properties["OrderPayment"] = await _referencesRepository.GetAllOrderPaymentAsync();

        progress.Report((100, "Загрузка справочника тиаов платежных документов", "Загрузка статических данных", false));
        Application.Current.Properties["TypeTransactions"] = await _referencesRepository.GetAllTypeTransactionsAsync();

        progress.Report((100, "Загрузка плана счетов", "Загрузка статических данных", false));
        Application.Current.Properties["AccountingPlans"] = await _referencesRepository.GetAllAccountingPlanAsync();

        progress.Report((100, "Загрузка справочника мест хранения", "Загрузка статических данных", false));
        Application.Current.Properties["StorageLocations"] = await _referencesRepository.GetAllStorageLocationAsync();

        progress.Report((100, "Загрузка справочника мест хранения", "Загрузка статических данных", false));
        Application.Current.Properties["Currency"] = await _referencesRepository.GetAllCurrencyAsync();

        progress.Report((100, "Загрузка справочника мест хранения", "Загрузка статических данных", false));
        Application.Current.Properties["AccountingMethodNds"] = await _referencesRepository.GetAllAccountingMethodNdsAsync();

        var view = new MainWindow();
        view.Show();


    }

    #endregion
}

