using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Agro.WPF.Commands;
using Notification.Wpf;

namespace Agro.WPF.Helpers;

public class HelperNavigation : IHelperNavigation
{
    private readonly INotificationManager _notificationManager;
    private readonly MainWindow? _window;
    public  HelperNavigation(INotificationManager notificationManager)
    {
        _notificationManager = notificationManager;
        try
        {
            _window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (_window == null)
            {
                _notificationManager.Show("Логер", "Не удолось захватить главное окно", NotificationType.Error);
            }
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"При вызове метода HelperNavigation произошла ошибка {e.Message}", NotificationType.Error);
        }
       
    }

    public TabItem OpenPage(Page page, string title)
    {
        try
        {
            var tabItem = new TabItem();
            var stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            var textBlok = new TextBlock()
            {
                Text = title,
                Margin = new Thickness(5, 0, 5, 0)
            };
            var button = new Button()
            {
                Content = "X",
                Background = Brushes.Transparent,
                Margin = new Thickness(5, 0, 5, 0),
                BorderThickness = new Thickness(0)
            };
            button.Command = CloseTabItemCommand;
            button.CommandParameter = tabItem;
            stackPanel.Children.Add(textBlok);
            stackPanel.Children.Add(button);
            tabItem.Header = stackPanel;
            var frame = new Frame();
            frame.Content = page;
            tabItem.Content = frame;
            _window!.TabControl.Items.Add(tabItem);
            _window.TabControl.SelectedItem = tabItem;
            return tabItem;
        }
        catch (Exception e)
        {
            _notificationManager.Show(
                "Логер",
                $"При вызове метода HelperNavigation.AddTabItem произошла ошибка {e.Message}",
                NotificationType.Error);
            return null!;
        }
        
    }

    private  ICommand? _closeTabItemCommand;

    public  ICommand CloseTabItemCommand => _closeTabItemCommand
        ??= new RelayCommand(OnCloseTabItemExecuted);

    private void OnCloseTabItemExecuted(object obj)
    {

        var tabItem = obj as TabItem;
        _window!.TabControl.Items.Remove(tabItem);
        
    }

    public  bool ClosePage(TabItem tabItem)
    {
        try
        {
            _window!.TabControl.Items.Remove(tabItem);
            return true;
        }
        catch (Exception e)
        {
            _notificationManager.Show(
                "Логер",
                $"При вызове метода HelperNavigation.RemoveTabItem произошла ошибка {e.Message}", 
                NotificationType.Error);
            return false;
        }
           
     
    }
}


