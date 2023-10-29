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

namespace ImageDisplayer
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

        private async void LoadImageBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = HelperTools.FileHelper.GetFilePathOrEmpty(HelperTools.FileDialogType.Open, "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png");
            if (filePath != string.Empty)
            {
                await ImageDisplayerControl.LoadImageAsync(filePath);
            }
        }


        private void AddSubStk_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement? sourceFrameworkElement = e.Source as FrameworkElement;
            if (sourceFrameworkElement != null)
            {
                if(sourceFrameworkElement.Name == "AddBtn")
                {
                    ImageDisplayerControl.Scale += 0.1;
                }
                else
                {
                    ImageDisplayerControl.Scale -= 0.1;
                }
            }
        }
    }
}
