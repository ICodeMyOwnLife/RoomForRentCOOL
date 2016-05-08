using System.Windows;
using System.Windows.Media;


namespace RoomForRentWindow
{
    public class DayBrush
    {
        #region  Properties & Indexers
        public Brush Background { get; set; }
        public Brush BorderBrush { get; set; }
        public Thickness BorderThickness { get; set; }
        public Brush Foreground { get; set; }
        public int? Days { get; set; }
        #endregion
    }
}