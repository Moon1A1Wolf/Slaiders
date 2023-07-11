using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Slaiders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class ColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int alpha = (int)values[0];
            int red = (int)values[1];
            int green = (int)values[2];
            int blue = (int)values[3];

            return Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SliderAlpha_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int num = 0;
            Slider s = sender as Slider;
            num = (int)s.Value;
            Alpha.Content = num.ToString();
        }

        private void SliderRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int num = 0;
            Slider s = sender as Slider;
            num = (int)s.Value;
            Red.Content = num.ToString();
        }

        private void SliderGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int num = 0;
            Slider s = sender as Slider;
            num = (int)s.Value;
            Green.Content = num.ToString();
        }

        private void SliderBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int num = 0;
            Slider s = sender as Slider;
            num = (int)s.Value;
            Blue.Content = num.ToString();
        }

        private void UpdateLabelAndColor(Slider slider, Label label)
        {
            int value = (int)slider.Value;
            label.Content = value.ToString();
            UpdateColor();
        }

        private void UpdateColor()
        {
            int alpha = (int)SliderAlpha.Value;
            int red = (int)SliderRed.Value;
            int green = (int)SliderGreen.Value;
            int blue = (int)SliderBlue.Value;

            SolidColorBrush brush = (SolidColorBrush)FindResource("ColorConverter");
            brush.Color = Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);
        }
    }
}
