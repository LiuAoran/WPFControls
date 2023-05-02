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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RadioButton = System.Windows.Controls.RadioButton;
using UserControl = System.Windows.Controls.UserControl;

namespace ColorPicker
{
    /// <summary>
    /// ColorSelectorControl.xaml 的交互逻辑
    /// </summary>
    public partial class ColorSelectorControl : UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private Brush _brush = Brushes.Black;

        public Brush Brush
        {
            get => _brush;
            set
            {
                _brush = value;
                OnPropertyChanged(nameof(Brush));
            }
        }

        public ColorSelectorControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Brush GetBrush()
        {
            return Brush;
        }

        private void CustomColorRadioButton_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));
                Brush = brush;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ColorRadioButton_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                if (radioButton.Tag.ToString() == "Red")
                {
                    Brush = Brushes.Red;
                }
                else if (radioButton.Tag.ToString() == "Black")
                {
                    Brush = Brushes.Black;
                }
                else if (radioButton.Tag.ToString() == "Green")
                {
                    Brush = Brushes.Green;
                }
                else if (radioButton.Tag.ToString() == "Blue")
                {
                    Brush = Brushes.Blue;
                }
            }
        }
    }
}
