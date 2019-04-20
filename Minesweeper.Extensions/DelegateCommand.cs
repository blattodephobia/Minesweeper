using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace System.Windows.Input
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeCallback;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged(EventArgs args = null) => CanExecuteChanged?.Invoke(this, args ?? EventArgs.Empty);

        public bool CanExecute(object parameter) => _canExecute.Invoke(parameter);

        public void Execute(object parameter) =>_executeCallback.Invoke(parameter);

        public DelegateCommand(Action<object> executeCallback, Func<object, bool> canExecute = null)
        {
            _executeCallback = executeCallback;
            _canExecute = canExecute ?? ((object payload) => true);
        }
    }
}
