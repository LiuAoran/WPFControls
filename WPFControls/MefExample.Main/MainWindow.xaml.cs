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
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MefExample.Core;
using System.Diagnostics;

namespace MefExample.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        const string PLUGIN_DIR = "\\Plugins";

        private PluginRepository? PluginRepository { get; set; }

        private PluginService.IPluginService? _pluginView;
        public PluginService.IPluginService? PluginView
        {
            get=> _pluginView;
            set
            {
                _pluginView = value;
                OnPropertyChanged("PluginView");
            }
        }

        private string? _pluginMsg;
        public string? PluginMsg
        {
            get => _pluginMsg;
            set
            {
                if(value != PluginMsg)
                {
                    _pluginMsg = value;
                    OnPropertyChanged("PluginMsg");
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadPlugins();
        }

        private void PluginFirst_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PluginView = PluginRepository.PluginServiceList.Find(v => v.ToString() == "MefExample.PluginOne.PluginExampleControl");
                PluginMsg = PluginView.InitPlugin();
            }
            catch 
            {
                PluginMsg = "Plugin not found";
            }
        }

        private void PluginSecond_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PluginView = PluginRepository.PluginServiceList.Find(v => v.ToString() == "MefExample.PluginTwo.PluginExampleControl");
                PluginMsg = PluginView.InitPlugin();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                PluginMsg = "Plugin not found";
            }
        }

        private void LoadPlugins()
        {
            try
            {
                // We set the Plugin-Directory under the directory where the application is located
                string pluginDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + PLUGIN_DIR;
                var catalog = new DirectoryCatalog(pluginDir);
                var container = new CompositionContainer(catalog);
                PluginRepository = new PluginRepository(container.GetExportedValues<MefExample.Core.PluginService.IPluginService>());

                foreach (var pluginService in PluginRepository.PluginServiceList)
                {
                    string Msg = pluginService.InitPlugin(); // <-- call the special plugin method
                    Debug.WriteLine("Load Plugin " + pluginService.ToString() + ", Msg: " + Msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    }
}
