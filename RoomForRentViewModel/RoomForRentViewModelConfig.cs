using System;
using System.Configuration;
using RoomForRentModels;
using RoomForRentMySqlEntity;
using RoomForRentSqlServerCompactEntity;
using RoomForRentSqLiteEntity;


namespace RoomForRentViewModel
{
    public class RoomForRentViewModelConfig
    {
        #region Methods
        /*public static TDataAccess GetDataAccess<TDataAccess>() where TDataAccess: class
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
        }*/

        public static IRoomForRentDataAccess GetDataAccess()
        {
            switch (GetDataAccessConfig())
            {
                case "xml":
                    throw new NotSupportedException();
                case "mySql":
                    return new RoomForRentMySqlDataAccess();
                case "sqLite":
                    return new RoomForRentSqLiteDataAccess();
                case "sqlServer":
                    throw new NotSupportedException();
                case "sqlServerCompact":
                    return new RoomForRentSqlServerCompactDataAccess();
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


// TODO: XAML serializer