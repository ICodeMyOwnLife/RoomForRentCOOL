using System;
using System.Configuration;


namespace RoomForRentEntityDataAccess
{
    public class RoomForRentEntityConfig
    {
        #region Fields
        private const string BACKUP_FOLDER = "backupFolder";
        private const string BACKUP_INTERVAL = "backupInterval";
        private const string BACKUP_LOG = "backupLogFile";
        #endregion


        #region Methods
        public static string GetBackupFolder()
        {
            return ConfigurationManager.AppSettings[BACKUP_FOLDER];
        }

        public static int GetBackupInterval()
        {
            return Convert.ToInt32(GetBackupIntervalString());
        }

        public static string GetBackupLogFile()
        {
            return ConfigurationManager.AppSettings[BACKUP_LOG];
        }
        #endregion


        #region Implementation
        private static string GetBackupIntervalString()
        {
            return ConfigurationManager.AppSettings[BACKUP_INTERVAL];
        }
        #endregion


        public static string GetConnectionString(string nameOrConnectionString)
        {
            return nameOrConnectionString.StartsWith("name=")
                       ? ConfigurationManager.ConnectionStrings[nameOrConnectionString.Substring(5)].ConnectionString
                       : nameOrConnectionString;
        }
    }
}