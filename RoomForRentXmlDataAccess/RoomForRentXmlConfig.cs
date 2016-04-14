using System.Configuration;


namespace RoomForRentXmlDataAccess
{
    internal class RoomForRentXmlConfig
    {
        #region Methods
        public static string GetFilePath(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
        #endregion
    }
}