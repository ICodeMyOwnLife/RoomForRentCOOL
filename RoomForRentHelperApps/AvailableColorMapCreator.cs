using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using RoomForRentWindow;


namespace RoomForRentHelperApps
{
    class AvailableColorMapCreator
    {
        #region Implementation
        static void Main(string[] args)
        {
            var map = new AvailableTimeColorMap
            {
                DaysColors = new[]
                {
                    new DaysColor { Color1 = "Red", Color2 = "White", Days = 0 },
                    new DaysColor { Color1 = "Orange", Color2 = "White", Days = 90 },
                    new DaysColor { Color1 = "Yellow", Color2 = "White", Days = 180 },
                    new DaysColor { Color1 = "Green", Color2 = "White", Days = 270 }
                },
                DefaultColor1 = "Blue",
                DefaultColor2 = "White"
            };
            const string FILE = "colors.map";
            using (var writer = new StreamWriter(FILE))
            {
                var ser = new XmlSerializer(typeof(AvailableTimeColorMap));
                ser.Serialize(writer, map);
            }
            Process.Start("explorer.exe", $"/select, {Path.GetFullPath(FILE)}");
        }
        #endregion
    }
}