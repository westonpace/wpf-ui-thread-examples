using System;
using System.ComponentModel;

namespace WpfExample.ViewModel
{
    public interface ICommandStatusModel : INotifyPropertyChanged
    {
        bool IsBusy { get; set; }
        void ReportError(Exception ex);
    }
}