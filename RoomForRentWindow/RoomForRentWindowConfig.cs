using System.Configuration;
using System.IO;
using System.Xml.Serialization;


namespace RoomForRentWindow
{
    public class RoomForRentWindowConfig
    {

        public static AvailableTimeColorMap GetAvailableTimeColorMap()
        {
            using (var reader = new StreamReader(GetMapFile()))
            {
                var ser =new XmlSerializer(typeof(AvailableTimeColorMap));
                return ser.Deserialize(reader) as AvailableTimeColorMap;
                
            }
        }

        private static string GetMapFile()
        {
            return ConfigurationManager.AppSettings["colorMapFile"];
        }
    }
}