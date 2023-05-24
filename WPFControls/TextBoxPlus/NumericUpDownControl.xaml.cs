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

namespace TextBoxPlus
{
    /// <summary>
    /// NumericUpDownControl.xaml 的交互逻辑
    /// </summary>
    public partial class NumericUpDownControl : UserControl
    {
        private string regexString = "[^0-9]+";

        // The dependency property which will be accessible on the UserControl
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(NumericUpDownControl), new UIPropertyMetadata());

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        public static readonly DependencyProperty MaxiumProperty =
           DependencyProperty.Register("Maxium", typeof(int), typeof(NumericUpDownControl), new UIPropertyMetadata());
        public int Maxium
        {
            get { return (int)GetValue(MaxiumProperty); }
            set { SetValue(MaxiumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
    DependencyProperty.Register("Minimum", typeof(int), typeof(NumericUpDownControl), new UIPropertyMetadata());
        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public NumericUpDownControl()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex(regexString).IsMatch(e.Text);
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

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBox.Text, out int num))
            {
                TextBox.Text = (++num).ToString();
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBox.Text, out int num))
            {
                TextBox.Text = (--num).ToString();
            }
        }
    }
}
