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

namespace RountedEventExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void YesNoCancelButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement sourceFrameworkElement = e.Source as FrameworkElement;
            switch (sourceFrameworkElement.Name)
            {
                case "YesButton":
                    // YesButton logic.
                    break;
                case "NoButton":
                    // NoButton logic.
                    break;
                case "CancelButton":
                    // CancelButton logic.
                    break;
            }
            e.Handled = true;
        }
    }
}
