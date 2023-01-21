using System;
using Agro.WPF.Commands.Base;

namespace Agro.WPF.Commands
{
    internal class RelayCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
       
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null!)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter!) ?? true;

        public override void Execute(object? parameter)
        {
            if (CanExecute(parameter))
                _execute(parameter!);
        }
    }
}
