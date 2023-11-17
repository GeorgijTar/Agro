using System.Collections.ObjectModel;
using System.Windows;
using Agro.WPF.Commands;
using System.Windows.Input;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels.Kassa
{
    public class TestUserControl: ViewModel
    {

        private ObservableCollection<string> _myItems = new();

        public ObservableCollection<string> MyItems
        {
            get => _myItems;
            set => Set(ref _myItems, value);
        }


        private ICommand? _Command1Command;
        
        public ICommand Command1 => _Command1Command
            ??= new RelayCommand(OnCommand1Executed, Command1Can);

        private bool Command1Can(object arg)
        {
            return true;
        }

        private void OnCommand1Executed(object obj)
        {
            MessageBox.Show("Сработала кнопка 1");
        }

        private ICommand? _Command2Command;

        public ICommand Command2 => _Command2Command
            ??= new RelayCommand(OnCommand2Executed, Command2Can);

        private bool Command2Can(object arg)
        {
            return true;
        }

        private void OnCommand2Executed(object obj)
        {
            MessageBox.Show("Сработала кнопка 2");
        }
        private ICommand? _Command3Command;

        public ICommand Command3 => _Command1Command
            ??= new RelayCommand(OnCommand3Executed, Command3Can);

        private bool Command3Can(object arg)
        {
            return true;
        }

        private void OnCommand3Executed(object obj)
        {
            MessageBox.Show("Сработала кнопка 3");
        }


        public TestUserControl()
        {
            MyItems.Add("Вариант 1");
            MyItems.Add("Пример 1");
            MyItems.Add("Элемент 1");
            MyItems.Add("Вариант 2");
            MyItems.Add("Пример 3");
            MyItems.Add("Элемент 4");
            MyItems.Add("Какойто текст");
        }
    }
}
