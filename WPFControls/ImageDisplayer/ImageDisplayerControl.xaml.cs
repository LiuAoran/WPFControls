using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace ImageDisplayer
{
    /// <summary>
    /// ImageDisplayerControl.xaml 的交互逻辑
    /// </summary>
    public partial class ImageDisplayerControl : UserControl, INotifyPropertyChanged
    {

        private bool isDragging = false;
        private Point lastMousePosition;
        private double startVerticalOffset;
        private double startHorizontalOffset;

        private BitmapImage? _imageSource;
        public BitmapImage? ImageSource
        {
            get => _imageSource;
            set
            {
                UpdateProper(ref _imageSource, value);
            }
        }

        private double _scale = 1.0;
        public double Scale
        {
            get => _scale;
            set
            {
                if (Image.ActualHeight * value < ImageGd.ActualHeight ||
                    Image.ActualWidth * value < ImageGd.ActualWidth)
                { 
                    value = Math.Min(ImageGd.ActualHeight / Image.ActualHeight,
                                     ImageGd.ActualWidth / Image.ActualWidth);
                }

                UpdateProper(ref _scale, Math.Min((Math.Max(value, 0.1)), 10));
            }
        }

        public ImageDisplayerControl()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public async Task LoadImageAsync(string imagePath)
        {
            ImageSource = null;
            BitmapImage bitmap = await Task.Run(() => LoadImage(imagePath));

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                ImageSource = bitmap;
            }));
        }

        private BitmapImage LoadImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();
            Thread.Sleep(1000);
            return bitmap;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

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

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lastMousePosition = e.GetPosition(Image);
            startVerticalOffset = ImageSv.VerticalOffset;
            startHorizontalOffset = ImageSv.HorizontalOffset;
            Image.CaptureMouse();
            this.Cursor = Cursors.Hand;
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image.ReleaseMouseCapture();
            this.Cursor = Cursors.Arrow;

        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (ImageSv.Visibility == Visibility.Visible && Image.IsMouseCaptured)
            {
                Point currentMousePosition = e.GetPosition(Image);
                double deltaVerticalOffset = lastMousePosition.Y - currentMousePosition.Y ;
                double deltaHorizontalOffset = lastMousePosition.X - currentMousePosition.X;

                double newVerticalOffset = startVerticalOffset + deltaVerticalOffset/1.5 ;
                double newHorizontalOffset = startHorizontalOffset + deltaHorizontalOffset/1.5;
                Debug.WriteLine("--------------");
                Debug.WriteLine($"deltaVerticalOffset: {deltaVerticalOffset}, deltaHorizontalOffset: {deltaHorizontalOffset}");

                Debug.WriteLine($"newVerticalOffset: {newVerticalOffset}, newHorizontalOffset: {newHorizontalOffset}");
                Debug.WriteLine("--------------");

                ImageSv.ScrollToVerticalOffset(newVerticalOffset );
                ImageSv.ScrollToHorizontalOffset(newHorizontalOffset);
            }
        }
    }
}
