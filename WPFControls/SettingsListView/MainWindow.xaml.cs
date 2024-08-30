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

namespace SettingsListView
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

        private void AddFileBtn_Click(object sender, RoutedEventArgs e)
        {
            FileInfo fileInfo = new FileInfo();
            fileInfo.FilePath =  HelperTools.FileHelper.GetFilePathOrEmpty(HelperTools.FileDialogType.Open);
            fileInfo.FileSize = HelperTools.FileHelper.GetFileSize(fileInfo.FilePath);
            fileInfo.OpenDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            FileHistoryManager<FileInfo>.Instance.AddToHistory(fileInfo);
            FileHistoryManager<FileInfo>.Instance.SaveHistory();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileHistoryManager<FileInfo>.Instance.LoadHistory();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            FileHistoryManager<FileInfo>.Instance.SaveHistory();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            FileHistoryManager<FileInfo>.Instance.ClearHistory();
            FileHistoryManager<FileInfo>.Instance.SaveHistory();
        }
    }
}
