using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample.ViewModel
{
    public class AsyncWaitCommand : BaseAsyncCommand
    {
        private ViewModelRoot viewModelRoot;

        public AsyncWaitCommand(ViewModelRoot viewModel) : base(viewModel)
        {
            viewModelRoot = viewModel;    
        }

        public override async Task DoExecuteAsync(object parameter)
        {
            await Task.Delay(1000);
            viewModelRoot.Message = "I async waited for 1000 milliseconds";
        }
    }
}