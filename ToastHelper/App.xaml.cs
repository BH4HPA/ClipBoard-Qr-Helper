using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace ToastHelper {
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e)
        {
            _taskbar = (TaskbarIcon)FindResource("Taskbar");
            base.OnStartup(e);
        }

        private TaskbarIcon _taskbar;

        private void PauseChecking(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("will pause");
        }

        private void UnPauseChecking(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("will continue");
        }
        private void GetAutoStart(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("will set auto start");
        }

        private void CancelAutoStart(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("will reset auto start");
        }
    }
    public class DelegateCommand : ICommand
    {
        public Action CommandAction { get; set; }
        public Func<bool> CanExecuteFunc { get; set; }

        public void Execute(object parameter)
        {
            CommandAction();
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc == null || CanExecuteFunc();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class NotifyIconViewModel
    {
        public ICommand ExitApplicationCommand
        {
            get
            {
                return new DelegateCommand { CommandAction = () => Application.Current.Shutdown() };
            }
        }

        private bool _isPauseChecking = false;
        public bool IsPauseChecking
        {
            get { return _isPauseChecking; }
            set
            {
                _isPauseChecking = value;
                OnPropertyChanged("IsPauseChecking");
            }
        }

        private bool _isAutoStart = false;
        public bool IsAutoStart
        {
            get { return _isAutoStart; }
            set
            {
                _isAutoStart = value;
                OnPropertyChanged("IsAutoStart");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
