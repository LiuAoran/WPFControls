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

namespace ComboBoxPlus
{
    /// <summary>
    /// WritableSelectionComboBoxControl.xaml 的交互逻辑
    /// </summary>
    public partial class WritableSelectionComboBoxControl : UserControl
    {
        public string SelectedIndex
        {
            get { return (string)GetValue(SelectedIndexProperty); }
            set {
                SetValue(SelectedIndexProperty, value); 
            }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(string), typeof(WritableSelectionComboBoxControl), new PropertyMetadata("0"));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WritableSelectionComboBoxControl), new PropertyMetadata(""));


        public WritableSelectionComboBoxControl()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if(comboBox.SelectedIndex == comboBox.Items.Count - 1)
            {
                TextBox.Visibility = Visibility.Visible;
            }
            else
            {
                TextBox.Visibility = Visibility.Hidden;
            }
        }
    }
}
