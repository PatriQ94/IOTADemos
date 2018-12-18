using System;
using System.Windows;

namespace IOTADemos.BO
{
    class DelegateCommand<T> : System.Windows.Input.ICommand where T : class
    {
        private readonly string _name;
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {

        }

        public DelegateCommand(CommandEnum command, Action<T> execute)
        {
            this._name = command.ToString();
            this._execute = execute;
        }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            if ((dynamic) parameter is System.Windows.Controls.Button)
            {
                parameter = ((System.Windows.Controls.Button) parameter).Tag;
            }

            return _canExecute((T) parameter);
        }

        public void Execute(object parameter)
        {
            string parameterName = string.Empty;

            if (parameter != null && (dynamic) parameter is System.Windows.Controls.Button)
            {
                try
                {
                    parameterName = ((dynamic) parameter).Name;
                }
                catch
                {
                    // ignored
                }

                parameter = ((System.Windows.Controls.Button) parameter).Tag;
            }

            if ((parameterName == "LoginButton" || parameterName == "LogoutButton" || parameterName == "keyboard"))
            {
                _execute((T) parameter);
                return;
            }

            _execute((T) parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged(object sender, EventArgs args)
        {
            //if application is exiting, abort to avoid exception
            if (Application.Current == null)
            {
                return;
            }

            Application.Current?.Dispatcher?.Invoke(new Action(() =>
            {
                this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }));

        }
    }
}
