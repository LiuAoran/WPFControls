using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
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

namespace GlobalLanguage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LanguageCmbSelectCurrentLanguage();
        }
        
        private void LanguageCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string language = ((ComboBoxItem)LanguageCmb.SelectedItem).Tag.ToString();
            if (language.Equals(App.CurrentCulture))
            {
                return;
            }
            MessageBoxResult result = MessageBox.Show(App.LanguageManager.GetString("Tip_Restart"),
                App.LanguageManager.GetString("Caption_Warn"), 
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Properties.Settings.Default.Culture = language;
                Properties.Settings.Default.Save();
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                this.Close();
            }
            else
            {
                LanguageCmbSelectCurrentLanguage();
            }
        }
        
        private void LanguageCmbSelectCurrentLanguage()
        {
            foreach (ComboBoxItem item in LanguageCmb.Items)
            {
                if (item.Tag.ToString() == App.CurrentCulture)
                {
                    item.IsSelected = true;
                }
            }
        }
    }
}