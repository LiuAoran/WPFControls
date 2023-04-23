using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TrayApp
{
    internal class MainWindowViewModel: ObservableRecipient
    {
        private bool _showInTaskbar;
        public bool ShowInTaskbar
        {
            get => _showInTaskbar;
            set => SetProperty(ref _showInTaskbar, value);
        }

        private WindowState _windowState;
        public WindowState WindowState
        {
            get => _windowState;
            set
            {
                ShowInTaskbar = true;
                SetProperty(ref _windowState, value);
                ShowInTaskbar = value != WindowState.Minimized;
            }
        }

        private NotifyIconWrapper.NotifyRequestRecord? _notifyRequest;
        public NotifyIconWrapper.NotifyRequestRecord? NotifyRequest
        {
            get => _notifyRequest;
            set => SetProperty(ref _notifyRequest, value);
        }

        public ICommand LoadedCommand { get; }
        public ICommand ClosingCommand { get; }
        public ICommand NotifyCommand { get; }
        public ICommand NotifyIconOpenCommand { get; }
        public ICommand NotifyIconExitCommand { get; }

        public MainWindowViewModel()
        {
            LoadedCommand = new RelayCommand(Loaded);
            ClosingCommand = new RelayCommand<CancelEventArgs>(Closing);
            NotifyCommand = new RelayCommand(()=>Notify("甜起来了！"));
            NotifyIconOpenCommand = new RelayCommand(()=>WindowState = WindowState.Normal);
            NotifyIconExitCommand = new RelayCommand(() => App.Current.Shutdown());
        }

        private void Notify(string message)
        {
            NotifyRequest = new NotifyIconWrapper.NotifyRequestRecord
            {
                Title = "辛苦了",
                Text = message,
                Duration = 100
            };
        }

        private void Loaded()
        {
            WindowState = WindowState.Minimized;
        }

        private void Closing(CancelEventArgs? e)
        {
            if (e == null)
                return;
            e.Cancel = true;
            WindowState = WindowState.Minimized;
        }
    }
}
