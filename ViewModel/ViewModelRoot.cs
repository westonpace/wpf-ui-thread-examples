using System;
using System.ComponentModel;

namespace WpfExample.ViewModel
{
    public class ViewModelRoot : INotifyPropertyChanged, ICommandStatusModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string message = "No message yet";
        private bool isBusy = false;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        public BlockingWaitCommand BlockingWait { get; private set; }
        public AsyncWaitCommand AsyncWait { get; private set; }
        public BlockingWriteFileCommand BlockingWrite { get; private set; }
        public AsyncWriteFileCommand AsyncWrite { get; private set; }
        public TaskRunWriteFileCommand TaskRunWrite { get; private set; }
        public ReportProgressInTaskRunCommand ReportProgressInTaskRun { get; private set; }
        public ReportProgressAsyncAwaitCommand ReportProgressAsyncAwait { get; private set; }

        public void ReportError(Exception ex)
        {
            Message = "Unexpected exception: " + ex.Message;
        }

        public ViewModelRoot()
        {
            BlockingWait = new BlockingWaitCommand(this);
            AsyncWait = new AsyncWaitCommand(this);
            BlockingWrite = new BlockingWriteFileCommand(this);
            AsyncWrite = new AsyncWriteFileCommand(this);
            TaskRunWrite = new TaskRunWriteFileCommand(this);
            ReportProgressInTaskRun = new ReportProgressInTaskRunCommand(this);
            ReportProgressAsyncAwait = new ReportProgressAsyncAwaitCommand(this);
        }

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}