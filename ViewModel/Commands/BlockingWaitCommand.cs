using System;
using System.Threading;
using System.Windows.Input;

namespace WpfExample.ViewModel
{
    public class BlockingWaitCommand : BaseSyncCommand
    {
        private ViewModelRoot viewModelRoot;

        public BlockingWaitCommand(ViewModelRoot viewModel) : base(viewModel)
        {
            viewModelRoot = viewModel;    
        }

        public override void DoExecute(object parameter)
        {
            Thread.Sleep(1000);
            viewModelRoot.Message = "I waited for 1000 milliseconds";
        }
    }
}