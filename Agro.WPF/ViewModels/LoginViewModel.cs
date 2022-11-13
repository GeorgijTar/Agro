
using Agro.DAL.Entities.Counter;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using FNS.Api;
using System.Windows.Input;
using System;
using System.Windows;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories;
using Helpers;

namespace Agro.WPF.ViewModels;

public class LoginViewModel : ViewModel
{
    private readonly ILoginRepository<User> _loginRepository;

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private string _login = null!;
    public string Login { get => _login; set => Set(ref _login, value); }

    private string _password = null!;
    public string Password { get => _password; set => Set(ref _password, value); }



    public LoginViewModel(ILoginRepository<User> loginRepository)
    {
        _loginRepository = loginRepository;
    }

    #region Commands

    

   
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
}

