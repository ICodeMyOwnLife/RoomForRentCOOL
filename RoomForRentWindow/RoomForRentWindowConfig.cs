using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using CB.Model.Serialization;


namespace RoomForRentWindow
{
    public class RoomForRentWindowConfig
    {
        #region Methods
        public static AvailableTimeBrushMap GetAvailableTimeBrushMap()
            => SerializationHelpers.Load<AvailableTimeBrushMap>(GetMapFile());

        public static AvailableTimeColorMap GetAvailableTimeColorMap()
        {
            using (var reader = new StreamReader(GetMapFile()))
            {
                var ser = new XmlSerializer(typeof(AvailableTimeColorMap));
                return ser.Deserialize(reader) as AvailableTimeColorMap;
            }
        }
        #endregion


        #region Implementation
        private static string GetMapFile()
            => ConfigurationManager.AppSettings["colorMapFile"];
        #endregion
    }
}