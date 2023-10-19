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

namespace WrapListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateItem();
        }
         

        private void CreateItem()
        {
            if (WrapListBoxControl != null)
            {
                WrapListBoxControl.Items.Add(new CustomItem
                {
                    TitleText = "A1",
                    DescriptionText = "A1 is a1"
                });

                WrapListBoxControl.Items.Add(new CustomItem
                {
                    TitleText = "A2",
                    DescriptionText = "A2 is a2"
                });

                WrapListBoxControl.Items.Add(new CustomItem
                {
                    TitleText = "A3",
                    DescriptionText = "A2 is a2"
                });

                WrapListBoxControl.Items.Add(new CustomItem
                {
                    TitleText = "A4",
                    DescriptionText = "A4 is a4"
                });

                WrapListBoxControl.Items.Add(new CustomItem
                {
                    TitleText = "A5",
                    DescriptionText = "A5 is a5"
                });
                WrapListBoxControl.SelectionChanged += WrapListBoxControl_SelectionChanged; ;
            }
        }

        private void WrapListBoxControl_SelectionChanged(object? sender, CustomItem e)
        {
            MessageBox.Show(e.TitleText);
        }
    }
}
