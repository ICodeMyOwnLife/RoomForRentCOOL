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
        #region Fields
        private static readonly AvailableTimeColorMap _map = RoomForRentWindowConfig.GetAvailableTimeColorMap();
        #endregion


        #region Methods
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime)) return DependencyProperty.UnsetValue;
            var availableFrom = (DateTime)value;

            var waitingDays = (availableFrom - DateTime.Now).TotalDays;
            return _map.GetBrush(waitingDays);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
        #endregion
    }

    [ValueConversion(typeof(DateTime), typeof(Brush))]
    public class AvailableTimeToBackgroundConverter: IValueConverter
    {
        #region Fields
        private static readonly AvailableTimeBrushMap _map = RoomForRentWindowConfig.GetAvailableTimeBrushMap();
        #endregion


        #region Methods
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime)) return DependencyProperty.UnsetValue;
            var availableFrom = (DateTime)value;
            return _map.GetBackground(availableFrom);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
        #endregion
    }
}