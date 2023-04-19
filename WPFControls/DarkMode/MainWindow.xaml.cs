using DarkMode.Managers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DarkMode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDarkMode = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LightModeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                // 在UI线程上执行更改主题的操作
                ThemeManager.SetTheme(false);
            });
            isDarkMode = false;
        }

        private void DarkModeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                // 在UI线程上执行更改主题的操作
                ThemeManager.SetTheme(true);
            });
            isDarkMode = true;
        }

        private bool IsDarkModeEnabled()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string valueName = "AppsUseLightTheme";

            int value = (int)Registry.GetValue(keyName, valueName, 1);

            return value == 0;
        }

        private void CheckThemeMod_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window();
            CheckDarkModeControl checkDarkModeControl = new CheckDarkModeControl(isDarkMode);
            window.Title = "Check";
            window.Height = 200;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Width = 400;
            window.ResizeMode = ResizeMode.NoResize;
            window.Content = checkDarkModeControl;
            window.WindowStyle = WindowStyle.None;
            window.Owner = this;
            window.ShowInTaskbar = false;
            window.ShowDialog();
        }

        private void DefaultModeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (IsDarkModeEnabled())
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // 在UI线程上执行更改主题的操作
                    ThemeManager.SetTheme(true);
                });
                isDarkMode = false;
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // 在UI线程上执行更改主题的操作
                    ThemeManager.SetTheme(false);
                });
                isDarkMode = true;

            }
        }
    }
}
