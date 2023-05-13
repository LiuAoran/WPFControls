using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MefExample.Core;


namespace MefExample.PluginTwo
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PluginExampleControl : UserControl, INotifyPropertyChanged, PluginService.IPluginService
    {


        private string _pluginHeadLine;
        public string PluginHeadLine
        {
            get { return _pluginHeadLine; }
            set
            {
                if (value != PluginHeadLine)
                {
                    _pluginHeadLine = value;
                    OnPropertyChanged("PluginHeadLine");
                };
            }
        }

        public PluginExampleControl()
        {
            InitializeComponent();
            this.DataContext = this;
            PluginHeadLine = "Plugin two";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string InitPlugin()
        {
            return "Plugin two is loaded.";
        }

        private void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    }
}