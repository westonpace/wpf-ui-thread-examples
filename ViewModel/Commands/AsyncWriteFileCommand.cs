using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using WpfExample.ViewModel;

namespace WpfExample
{

    public class AsyncWriteFileCommand : BaseAsyncCommand
    {
        private const int BlockSize = 1000;
        private const int NumIterations = 400000;

        private byte[] buffer;
        private ViewModelRoot viewModelRoot;

        public AsyncWriteFileCommand(ViewModelRoot viewModel) : base(viewModel)
        {
            buffer = new byte[BlockSize];
            viewModelRoot = viewModel;
        }

        public override async Task DoExecuteAsync(object parameter)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await DoSomeIoOperationsAsync();
            viewModelRoot.Message = "I Wrote a File (async) in " + stopwatch.ElapsedMilliseconds + "ms";
        }

        private async Task DoSomeIoOperationsAsync()
        {
            // Simulates some busy I/O work by writing ~400MB to a temp file and then deleting the file
            var path = Path.GetTempFileName();
            using (FileStream stream = File.OpenWrite(path))
            {
                for (var i = 0; i < NumIterations; i++)
                {
                    await stream.WriteAsync(buffer, 0, BlockSize);
                }
            }
            File.Delete(path);
        }
    }

}