using System.Windows;
using Agro.WPF.Views.Windows;

namespace Agro.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CustomerBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new ContractorsView();
        }
    }
}
