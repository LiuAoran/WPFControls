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
    /// CheckDarkModeControl.xaml 的交互逻辑
    /// </summary>
    public partial class CheckDarkModeControl : UserControl
    {
        private string _themeStatusMsg = string.Empty;
        public string ThemeStatusMsg
        {
            get => _themeStatusMsg;
            set => _themeStatusMsg = value;
        }

        public CheckDarkModeControl(bool isDarkMode = true)
        {
            InitializeComponent();
            this.DataContext= this;
            if (isDarkMode)
            {
                ThemeStatusMsg = "Dark Mode";
            }
            else
            {
                ThemeStatusMsg= "Light Mode";
            }
        }

        private void SureButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
