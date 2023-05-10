using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Composition;
using System.Composition.Hosting;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;

namespace MefExample
{
    public class MainWindowViewModel
    {
        private MenuItemObject _selectedPlugin;

        public MenuItemObject SelectedPlugin
        {
            get => _selectedPlugin; 
            private set => _selectedPlugin = value;
        }

        public ICommand LoadPluginCommand { get; }

        public MainWindowViewModel()
        {
            LoadPluginCommand = new RelayCommand(LoadPlugin);
        }

        private void LoadPlugin()
        {

        }
    }
}
