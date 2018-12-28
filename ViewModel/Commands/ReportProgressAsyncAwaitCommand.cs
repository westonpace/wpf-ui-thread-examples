using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WpfExample.ViewModel;

namespace WpfExample
{

    public class ReportProgressAsyncAwaitCommand : BaseAsyncCommand
    {
        private ViewModelRoot viewModelRoot;

        public ReportProgressAsyncAwaitCommand(ViewModelRoot viewModel) : base(viewModel)
        {
            viewModelRoot = viewModel;
        }

        public override async Task DoExecuteAsync(object parameter)
        {
            await Task.Delay(1500);
            viewModelRoot.Message = "Halfway there (" + SynchronizationContext.Current + ")";
            await Task.Delay(1500);
            viewModelRoot.Message = "Finished";
        }

    }

}