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

namespace MultiPageWrapListBox
{
    /// <summary>
    /// MultiPageWrapListBoxControl.xaml 的交互逻辑
    /// </summary>
    public partial class MultiPageWrapListBoxControl : UserControl, INotifyPropertyChanged
    {
        public event EventHandler<CustomItem> SelectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _currentIndex = 1;
        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                if(UpdateProper(ref _currentIndex, value))
                {
                    RefreshCurrentItems();
                }
            }
        } 

        private int _totalIndex = 1;
        public int TotalIndex
        {
            get => _totalIndex; set
            {
                UpdateProper(ref _totalIndex, value);
            }
        }

        private int _horizontalItemNumber = 0;
        public int HorizontalItemNumber
        {
            get => _horizontalItemNumber;
            set
            {
                if (UpdateProper(ref _horizontalItemNumber, value))
                {
                    ResetTotalIndex();
                }
            }
        }

        private int _verticalItemNumber = 0;
        public int VerticalItemNumber
        {
            get => _verticalItemNumber;
            set
            {
                if (UpdateProper(ref _verticalItemNumber, value))
                {
                    ResetTotalIndex();
                }
            }
        }

        public static readonly DependencyProperty ItemsProperty =
           DependencyProperty.Register("Items", typeof(ObservableCollection<CustomItem>), typeof(MultiPageWrapListBoxControl), new PropertyMetadata(null));

        public ObservableCollection<CustomItem> Items
        {
            get { return (ObservableCollection<CustomItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        private ObservableCollection<CustomItem> _pageItems = new ObservableCollection<CustomItem>();
        public ObservableCollection<CustomItem> PageItems
        {
            get => _pageItems;
            set
            {
                UpdateProper(ref _pageItems, value);
            }
        }

        public MultiPageWrapListBoxControl()
        {
            this.DataContext = this;
            InitializeComponent();
            Items = new ObservableCollection<CustomItem>();
        }

        private void ListGd_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (MultiPageWrapListBox != null && CustomItem.ItemWidth > 0 && CustomItem.ItemHeight > 0)
            {
                HorizontalItemNumber = (int)((MultiPageWrapListBox.ActualWidth) / (CustomItem.ItemWidth + 2 * CustomItem.ItemMargin));
                VerticalItemNumber = (int)((MultiPageWrapListBox.ActualHeight) / (CustomItem.ItemHeight + 2 * CustomItem.ItemMargin));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MultiPageWrapListBox.SelectionChanged += MultiPageWrapListBox_SelectionChanged;
        }


        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            MultiPageWrapListBox.SelectionChanged -= MultiPageWrapListBox_SelectionChanged;
        }

        private void MultiPageWrapListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null && listBox.SelectedIndex != -1)
            {
                SelectionChanged?.Invoke(sender, Items[listBox.SelectedIndex + HorizontalItemNumber*VerticalItemNumber*(CurrentIndex-1)]);
                listBox.SelectedIndex = -1;
            }
        }

        private void ResetTotalIndex()
        {
            if (MultiPageWrapListBox != null && HorizontalItemNumber != 0 && VerticalItemNumber != 0)
            {
                int totalIndex = Items.Count / (HorizontalItemNumber * VerticalItemNumber);
                if (Items.Count % (HorizontalItemNumber * VerticalItemNumber) != 0)
                {
                    TotalIndex = totalIndex + 1;
                }
                else
                {
                    TotalIndex = totalIndex;
                }
                if(CurrentIndex > TotalIndex)
                {
                    CurrentIndex = TotalIndex;
                }
                RefreshCurrentItems(); 
            }
        }

        private void RefreshCurrentItems()
        {
            PageItems.Clear();
            int baseItemIndex = (CurrentIndex - 1) * HorizontalItemNumber * VerticalItemNumber;
            for (int ItemIndex = baseItemIndex;
                ItemIndex < baseItemIndex + HorizontalItemNumber * VerticalItemNumber && ItemIndex < Items.Count;
                ItemIndex++)
            {
                PageItems.Add(Items[ItemIndex]);
            }
        }

        protected bool UpdateProper<T>(ref T properValue,
                            T newValue,
                            [CallerMemberName] string properName = "")
        {
            if (object.Equals(properValue, newValue))
                return false;

            properValue = newValue;
            OnPropertyChanged(properName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentIndex < TotalIndex)
            {
                CurrentIndex++;
            }
        }

        private void PrePageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentIndex > 1)
            {
                CurrentIndex--;
            }
        }
    }

    public class CustomItem : Control, INotifyPropertyChanged
    {

        static public double ItemWidth { get; set; } = 200;
        static public double ItemHeight { get; set; } = 100;

        static public int ItemMargin { get; set; } = 10;

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
