using System.Windows;
using System;
using System.Windows.Input;
using Agro.Helpers;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels.UserSettings;

public class RegistryInvoiceSettingsViewModel : ViewModel
{
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private Interfaces.UserSettings _userSettings = null!;
    public Interfaces.UserSettings UserSettings { get => _userSettings; set => Set(ref _userSettings, value); }

    public RegistryInvoiceSettingsViewModel()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        UserSettings = UserSettingsHelper.GetUserSettings();
    }

    #region Commands

    

  
    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }


    private ICommand? _saveSettingsCommand;

    public ICommand SaveCommand => _saveSettingsCommand
        ??= new RelayCommand(OnSaveExecuted);

    private void OnSaveExecuted(object obj)
    {
        if (UserSettingsHelper.SetUserSettings(UserSettings))
        {
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }

    #endregion

}
