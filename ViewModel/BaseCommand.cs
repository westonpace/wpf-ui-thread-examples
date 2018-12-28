using System;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfExample.ViewModel
{
    public abstract class BaseCommand : ICommand
    {
        protected ICommandStatusModel commandStatusModel;

        public BaseCommand(ICommandStatusModel commandStatusModel)
        {
            this.commandStatusModel = commandStatusModel;
            commandStatusModel.PropertyChanged += this.OnBusyPropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !commandStatusModel.IsBusy;
        }

        public abstract void Execute(object parameter);

        private void OnBusyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsBusy")
            {
                var handler = CanExecuteChanged;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
        }
    }
}