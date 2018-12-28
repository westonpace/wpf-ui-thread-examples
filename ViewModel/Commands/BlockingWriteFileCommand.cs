using System;
using System.Diagnostics;
using System.IO;
using WpfExample.ViewModel;

namespace WpfExample
{

    public class BlockingWriteFileCommand : BaseSyncCommand
    {
        private const int BlockSize = 1000;
        private const int NumIterations = 400000;

        private byte[] buffer;
        private ViewModelRoot viewModelRoot;

        public BlockingWriteFileCommand(ViewModelRoot viewModel) : base(viewModel)
        {
            buffer = new byte[BlockSize];
            viewModelRoot = viewModel;
        }

        public override void DoExecute(object parameter)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            DoSomeIoOperations();
            viewModelRoot.Message = "I Wrote a File in " + stopwatch.ElapsedMilliseconds + "ms";
        }

        private void DoSomeIoOperations()
        {
            // Simulates some busy I/O work by writing ~400MB to a temp file and then deleting the file
            var path = Path.GetTempFileName();
            using (FileStream stream = File.OpenWrite(path))
            {
                for (var i = 0; i < NumIterations; i++)
                {
                    stream.Write(buffer, 0, BlockSize);
                }
            }
            File.Delete(path);
        }
    }

}