using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Shortcut
{
    internal class MainWindowViewModel : ObservableObject
    {
        private bool _isKMod = false;
        public bool IsKMod
        {
            get => _isKMod;
            set => SetProperty(ref _isKMod, value);
        }

        private SolidColorBrush _backgroundColor = new();
        public SolidColorBrush BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        private Dictionary<string, SolidColorBrush> keyValuePairs = new Dictionary<string, SolidColorBrush>()
        {
            {"Success", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#20a162")) },
            {"Pass", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#158bb8")) },
            {"Joy", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#eb261a")) },
            {"Warning", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f4a83a")) },
            {"Danger", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ac1f18")) },
            {"Common", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#808080")) },
            {"Unknow", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#525288")) },
            {"Default", new SolidColorBrush((Color)ColorConverter.ConvertFromString("#131824")) }
        };

        public ICommand SetColorCommand { get; }
        public ICommand KModCommand { get; }
        public ICommand KModSetColorCommand { get; }

        private readonly KeyboardHook keyboardHook = new KeyboardHook();

        public MainWindowViewModel()
        {
            SetColorCommand = new RelayCommand<string>((e) =>
            {
                if (!IsKMod)
                {
                    BackgroundColor = (e != null) ? keyValuePairs[e] : new SolidColorBrush(Colors.White);
                }
            });

            KModCommand = new RelayCommand(() =>
            {
                IsKMod = true;
                keyboardHook.KeyPressed += OnKeyPressed;
            });

            KModSetColorCommand = new RelayCommand<string>((e) =>
            {
                if (IsKMod)
                {
                    BackgroundColor = (e != null) ? keyValuePairs[e] : new SolidColorBrush(Colors.White);
                    IsKMod = false;
                }
            });
        }

        private void OnKeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (IsKMod)
            {
                IsKMod = !IsKMod;
                keyboardHook.KeyPressed -= OnKeyPressed;
            } 
        }
    }
}
