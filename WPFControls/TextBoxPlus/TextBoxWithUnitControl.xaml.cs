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

namespace NumberBoxPlus
{
    /// <summary>
    /// TextBoxWithUnitControl.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxWithUnitControl : UserControl
    {
        // The dependency property which will be accessible on the UserControl
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(TextBoxWithUnitControl), new UIPropertyMetadata(String.Empty));

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        public TextBoxWithUnitControl()
        {
            InitializeComponent();
        } 
    }
}
