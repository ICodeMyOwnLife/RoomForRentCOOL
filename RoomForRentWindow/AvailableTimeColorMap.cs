namespace RoomForRentWindow
{
    public class AvailableTimeColorMap
    {
        #region  Properties & Indexers
        public DaysColor[] DaysColors { get; set; }
        public string DefaultColor1 { get; set; }
        public string DefaultColor2 { get; set; }
        #endregion
    }

    public class DaysColor
    {
        #region  Properties & Indexers
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public int Days { get; set; }
        #endregion
    }
}