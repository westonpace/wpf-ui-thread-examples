using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample.ViewModel
{
    public abstract class BaseSyncCommand : BaseCommand
    {
        public BaseSyncCommand(ICommandStatusModel commandStatusModel) : base(commandStatusModel)
        {
            
        }

        public override void Execute(object parameter)
        {
            this.commandStatusModel.IsBusy = true;
            try
            {
                this.DoExecute(parameter);
            }
            catch (Exception ex)
            {
                this.commandStatusModel.ReportError(ex);
            }
            this.commandStatusModel.IsBusy = false;
        }

        public abstract void DoExecute(object parameter);

    }
}