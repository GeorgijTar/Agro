using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System;
using System.Drawing;
using System.Windows;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Helpers;
using System.Reflection;
using System.Windows.Media;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;

namespace Agro.WPF.ViewModels;

public class LoginViewModel : ViewModel
{

    private readonly ILoginRepository<User> _loginRepository;

    private string _login = null!;
    public string Login { get => _login; set => Set(ref _login, value); }

    private string _password = null!;
    public string Password { get => _password; set => Set(ref _password, value); }

    private string _currentVersion = null!;
    public string CurrentVersion { get => _currentVersion; set => Set(ref _currentVersion, value); }

    private SolidColorBrush _ellipseColor = new SolidColorBrush(Colors.Red); 
    public SolidColorBrush EllipseColor { get => _ellipseColor; set => Set(ref _ellipseColor, value); }

    private string _ellipseLabel ="Сервер не доступен!";
    public string EllipseLabel { get => _ellipseLabel; set => Set(ref _ellipseLabel, value); }
   
    public LoginViewModel(ILoginRepository<User> loginRepository)
    {
        _loginRepository = loginRepository;
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
        var user = await _loginRepository.GetUserAsync(Login, AgroHelper.CalculateHash(Password, Login))!;

        if (user != null!)
        {
            Application.Current.Properties["User"] = user;

            var view = new MainWindow();
            view.Show();

            var window = p as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль!", "Авторизация");
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

    #endregion
}

