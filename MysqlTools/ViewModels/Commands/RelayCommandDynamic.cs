using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MysqlTools.ViewModels.Commands
{
    public class RelayCommandDynamic<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;

        public RelayCommandDynamic(Action<T> execute, Func<T, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is T tParameter)
            {
                return _canExecute == null || _canExecute(tParameter);
            }
            return _canExecute == null;
        }

        public void Execute(object? parameter)
        {
            T convertedParameter = parameter is T tParameter ? tParameter : default!;
            _execute(convertedParameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
