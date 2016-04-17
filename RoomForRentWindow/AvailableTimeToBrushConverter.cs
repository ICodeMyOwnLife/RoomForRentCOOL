using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;


namespace RoomForRentWindow
{
    [ValueConversion(typeof(DateTime), typeof(Brush))]
    public class AvailableTimeToBrushConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime)) return DependencyProperty.UnsetValue;
            var availableFrom = (DateTime)value;

            /*var waitingTime = availableFrom - DateTime.Now;
            TimeSpan.Parse()*/
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}