using System;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;


namespace RoomForRentWindow
{
    [ContentProperty(nameof(BrushMap))]
    public class AvailableTimeBrushMap
    {
        #region  Properties & Indexers
        public DayBrushCollection BrushMap { get; } = new DayBrushCollection();
        public DayBrush DefaultBrush { get; set; }
        #endregion


        #region Methods
        public Brush GetBackground(DateTime availableFrom)
            => GetDayBrush(availableFrom).Background;

        public Brush GetBorderBrush(DateTime availableFrom)
            => GetDayBrush(availableFrom).BorderBrush;

        public Thickness GetBorderThickness(DateTime availableFrom)
            => GetDayBrush(availableFrom).BorderThickness;

        public DayBrush GetDayBrush(DateTime availableFrom)
        {
            var now = DateTime.Now;
            return BrushMap.FirstOrDefault(db => db.Days.HasValue && availableFrom < now.AddDays(db.Days.Value)) ??
                   DefaultBrush;
        }

        public Brush GetForeground(DateTime availableFrom)
            => GetDayBrush(availableFrom).Foreground;
        #endregion
    }
}