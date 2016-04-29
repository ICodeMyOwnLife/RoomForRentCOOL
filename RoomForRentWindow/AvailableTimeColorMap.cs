using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;


namespace RoomForRentWindow
{
    [Serializable]
    [XmlRoot("AvailableTimeColorMap")]
    public class AvailableTimeColorMap
    {
        #region Fields
        private DaysColor[] _daysColors;
        #endregion


        #region  Properties & Indexers
        public DaysColor[] DaysColors
        {
            get { return _daysColors; }
            set { _daysColors = value.OrderBy(dc => dc.Days).ToArray(); }
        }

        public string DefaultColor1 { get; set; }

        public string DefaultColor2 { get; set; }
        #endregion


        #region Methods
        public Brush GetBrush(double waitingDays)
        {
            var daysColor = DaysColors.FirstOrDefault(dc => dc.Days >= waitingDays);
            return daysColor == null
                       ? GetBrush(DefaultColor1, DefaultColor2) : GetBrush(daysColor.Color1, daysColor.Color2);
        }
        #endregion


        #region Implementation
        private static Brush GetBrush(string color1, string color2)
            => new LinearGradientBrush((Color)ColorConverter.ConvertFromString(color1),
                (Color)ColorConverter.ConvertFromString(color2), new Point(0, 0), new Point(0, 1));
        #endregion
    }
}