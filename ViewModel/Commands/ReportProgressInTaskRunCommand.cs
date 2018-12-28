using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WpfExample.ViewModel;

namespace WpfExample
{

    public class ReportProgressInTaskRunCommand : BaseAsyncCommand
    {
        private ViewModelRoot viewModelRoot;

        public ReportProgressInTaskRunCommand(ViewModelRoot viewModel) : base(viewModel)
        {
            viewModelRoot = viewModel;
        }

        public override Task DoExecuteAsync(object parameter)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(1500);
                viewModelRoot.Message = "Halfway there (" + SynchronizationContext.Current + ")";
                Thread.Sleep(1500);
                viewModelRoot.Message = "Finished!";
            });
        }

    }

}