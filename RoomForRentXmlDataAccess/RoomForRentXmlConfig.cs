using System.Configuration;


namespace RoomForRentXmlDataAccess
{
    internal class RoomForRentXmlConfig
    {
        #region Methods
        public static string GetFilePath(string modelName)
        {
            return ConfigurationManager.AppSettings[modelName];
        }
        #endregion
    }
}