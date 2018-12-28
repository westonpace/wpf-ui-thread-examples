using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample.ViewModel
{
    public abstract class BaseAsyncCommand : BaseCommand
    {
        public BaseAsyncCommand(ICommandStatusModel busyModel) : base(busyModel)
        {

        }

        public override async void Execute(object parameter)
        {
            this.commandStatusModel.IsBusy = true;
            try
            {
                await this.DoExecuteAsync(parameter);
            }
            catch (Exception ex)
            {
                this.commandStatusModel.ReportError(ex);
            }
            this.commandStatusModel.IsBusy = false;
        }

        public abstract Task DoExecuteAsync(object parameter);

    }
}