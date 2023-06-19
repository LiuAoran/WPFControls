using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace NumberBoxPlus
{
    /// <summary>
    /// NumberBoxDropDownControl.xaml 的交互逻辑
    /// </summary>
    public partial class NumberBoxDropDownControl : UserControl
    {
        private string regixString = "[^0-9]+";

        // The dependency property which will be accessible on the UserControl
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(NumberBoxDropDownControl), new UIPropertyMetadata());

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        public static readonly DependencyProperty MaxiumProperty =
            DependencyProperty.Register("Maxium", typeof(int), typeof(NumberBoxDropDownControl), new UIPropertyMetadata());

        public int Maxium
        {
            get { return (int)GetValue(MaxiumProperty); }
            set { SetValue(MaxiumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
    DependencyProperty.Register("Minimum", typeof(int), typeof(NumberBoxDropDownControl), new UIPropertyMetadata());

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public NumberBoxDropDownControl()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex(regixString).IsMatch(e.Text);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyStates == Keyboard.GetKeyStates(Key.LeftCtrl) || e.KeyStates == Keyboard.GetKeyStates(Key.RightCtrl)) && e.KeyStates == Keyboard.GetKeyStates(Key.V))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox.Text))
            {
                if (int.Parse(TextBox.Text) > Maxium)
                {
                    TextBox.Text = Maxium.ToString();
                }

                if (int.Parse(TextBox.Text) < Minimum)
                {
                    TextBox.Text = Minimum.ToString();
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox.SelectedIndex != -1)
            {
                TextBox.Text = ((sender as ComboBox)?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? string.Empty;
                ComboBox.SelectedIndex = -1;
            } 
        }
    }
}
