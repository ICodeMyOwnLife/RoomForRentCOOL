using System;
using System.Configuration;
using RoomForRentMySqlEntity;
using RoomForRentSqlServerCompactEntity;
using RoomForRentSqLiteEntity;


namespace RoomForRentViewModel
{
    public class RoomForRentViewModelConfig
    {
        #region Methods
        public static TDataAccess GetDataAccess<TDataAccess>() where TDataAccess: class
        {
            switch (GetDataAccessConfig())
            {
                case "xml":
                    throw new NotSupportedException();
                case "mySql":
                    return new RoomForRentMySqlDataAccess() as TDataAccess;
                case "sqLite":
                    return new RoomForRentSqLiteDataAccess() as TDataAccess;
                case "sqlServer":
                    throw new NotSupportedException();
                case "sqlServerCompact":
                    return new RoomForRentSqlServerCompactDataAccess() as TDataAccess;
                default:
                    throw new NotSupportedException();
            }
        }
        #endregion


        #region Implementation
        private static string GetDataAccessConfig()
        {
            return ConfigurationManager.AppSettings["dataAccess"];
        }
        #endregion
    }
}