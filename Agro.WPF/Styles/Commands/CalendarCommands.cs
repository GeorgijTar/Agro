using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Agro.WPF.Styles.Commands;

    public class CalendarCommands
    {

        private static readonly SelectTodayCommand _selectTodayCommand = new SelectTodayCommand();

        public static ICommand SelectToday
        {
            get { return _selectTodayCommand; }
        }

        private sealed class SelectTodayCommand : ICommand
        {
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter)
            {
                return parameter is Calendar;
            }

            public void Execute(object parameter)
            {
                var calendar = parameter as Calendar;
                if (calendar == null)
                    return;

                var today = DateTime.Today;
                calendar.SelectedDate = today;
                calendar.DisplayDate = today;
                

            }
        }
    }

    

