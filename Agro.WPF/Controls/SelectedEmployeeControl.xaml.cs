using System.Windows;
using System.Windows.Controls;

namespace Agro.WPF.Controls
{
    public partial class SelectedEmployeeControl
    {

        /// <summary>Выбранный элемент</summary>
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(SelectedEmployeeControl),
                new PropertyMetadata(default(object)));

        /// <summary>Выбранный элемент</summary>
        public object SelectedItem { get => (object)GetValue(SelectedItemProperty); set => SetValue(SelectedItemProperty, value); }

        public SelectedEmployeeControl()
        {
            InitializeComponent();
        }
    }
}
