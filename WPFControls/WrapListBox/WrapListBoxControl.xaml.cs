using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WrapListBox
{
    /// <summary>
    /// WrapListBoxControl.xaml 的交互逻辑
    /// </summary>
    public partial class WrapListBoxControl : UserControl
    {
        public event EventHandler<CustomItem> SelectionChanged;

        public static readonly DependencyProperty ItemsProperty =
           DependencyProperty.Register("Items", typeof(ObservableCollection<CustomItem>), typeof(WrapListBoxControl), new PropertyMetadata(null));

        public ObservableCollection<CustomItem> Items
        {
            get { return (ObservableCollection<CustomItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public WrapListBoxControl()
        {
            this.DataContext = this;
            InitializeComponent();
            Items = new ObservableCollection<CustomItem>();
        }

        private void WrapListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null && listBox.SelectedIndex != -1) {
                SelectionChanged?.Invoke(sender, Items[listBox.SelectedIndex]);
                listBox.SelectedIndex= -1;
            } 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            WrapListBox.SelectionChanged += WrapListBox_SelectionChanged;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            WrapListBox.SelectionChanged -= WrapListBox_SelectionChanged;
        }
    }

    public class CustomItem : Control, INotifyPropertyChanged
    {

        private string _titleText;
        public string TitleText
        {
            get => _titleText;
            set
            {
                UpdateProper(ref _titleText, value);
            }
        }

        private string _descriptionText;
        public string DescriptionText
        {
            get => _descriptionText;
            set
            {
                UpdateProper(ref _descriptionText, value);
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void UpdateProper<T>(ref T properValue,
                            T newValue,
                            [CallerMemberName] string properName = "")
        {
            if (object.Equals(properValue, newValue))
                return;

            properValue = newValue;
            OnPropertyChanged(properName);

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
