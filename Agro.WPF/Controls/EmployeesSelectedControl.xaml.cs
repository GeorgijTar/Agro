using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Agro.DAL.Entities.Personnel;

namespace Agro.WPF.Controls;

public partial class EmployeesSelectedControl
{

    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
        "ItemsSource", typeof(IEnumerable<Employee>), typeof(EmployeesSelectedControl));
    public IEnumerable<Employee> ItemsSource
    {
        get { return (IEnumerable<Employee>)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public static readonly DependencyProperty MyItemsProperty = DependencyProperty.Register(
        "MyItems", typeof(IEnumerable<Employee>), typeof(EmployeesSelectedControl));

    public IEnumerable<Employee> MyItems
    {
        get { return (IEnumerable<Employee>)GetValue(MyItemsProperty); }
        set { SetValue(MyItemsProperty, value); }
    }

    public EmployeesSelectedControl()
    {
        InitializeComponent();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        listBox.SelectedIndex = -1;
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (listBox.SelectedItem != null)
        {
            textBox.Text = listBox.SelectedItem.ToString();
            listBox.Visibility = Visibility.Collapsed;
        }
    }

    private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Down)
        {
            listBox.SelectedIndex = 0;
            listBox.Focus();
            e.Handled = true;
        }
    }
    private void TextBox_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Up || e.Key == Key.Down)
            return;

        string filterText = textBox.Text.ToLower();
        listBox.Items.Clear();

        foreach (var item in ItemsSource)
        {
            if (item.ToString().ToLower().Contains(filterText))
            {
                listBox.Items.Add(item);
            }
        }

        if (listBox.Items.Count > 0)
        {
            listBox.Visibility = Visibility.Visible;
            popup.IsOpen = true; // Открываем Popup
        }
        else
        {
            listBox.Visibility = Visibility.Collapsed;
            popup.IsOpen = false; // Закрываем Popup
        }
    }

}