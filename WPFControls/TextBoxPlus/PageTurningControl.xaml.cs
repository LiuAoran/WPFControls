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
    /// PageTurningControl.xaml 的交互逻辑
    /// </summary>
    public partial class PageTurningControl : UserControl
    {
        private string regexString = "[^0-9]+";

        public static readonly DependencyProperty MaxiumProperty =
           DependencyProperty.Register("Maxium", typeof(int), typeof(PageTurningControl), new UIPropertyMetadata());
        public int Maxium
        {
            get { return (int)GetValue(MaxiumProperty); }
            set { SetValue(MaxiumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
    DependencyProperty.Register("Minimum", typeof(int), typeof(PageTurningControl), new UIPropertyMetadata());
        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        private int PageNumber = 1;

        public PageTurningControl()
        {
            InitializeComponent();
        }

        private void EditPageBtn_Click(object sender, RoutedEventArgs e)
        {
            EditPageTbx.Visibility = Visibility.Visible;
            EditPageBtn.Visibility = Visibility.Collapsed;
            EditPageTbx.Focus();
        }

        private void EditPageTbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex(regexString).IsMatch(e.Text);
        }

        private void EditPageTbx_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyStates == Keyboard.GetKeyStates(Key.LeftCtrl) || e.KeyStates == Keyboard.GetKeyStates(Key.RightCtrl)) && e.KeyStates == Keyboard.GetKeyStates(Key.V) || e.KeyStates == Keyboard.GetKeyStates(Key.Space))
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                if(EditPageTbx.Text == string.Empty)
                {
                    EditPageTbx.Text = PageNumber.ToString();
                }
                else
                {
                    PageNumber = int.Parse(EditPageTbx.Text);
                }
            }
            else
                e.Handled = false;
        }

        private void EditPageTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(EditPageTbx.Text))
            {
                int value = 1;
                if (int.TryParse(EditPageTbx.Text, out value))
                {
                    if (value > Maxium)
                    {
                        EditPageTbx.Text = Maxium.ToString();
                    }

                    if (value < Minimum)
                    {
                        EditPageTbx.Text = Minimum.ToString();
                    }
                }
            }
        }

        private void EditPageTbx_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PrePageBtn_Click(object sender, RoutedEventArgs e)
        {
            Maxium--;
        }

        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
