using System;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using RoomForRentEntityDataAccess;


namespace RoomForRentSqLiteEntity
{
    public class RoomForRentSqLiteDataAccess: RoomForRentEntityCommonDataAccess
    {
        #region Fields
        private readonly CultureInfo _usCultureInfo = new CultureInfo("en-US");
        #endregion


        #region  Constructors & Destructor
        public RoomForRentSqLiteDataAccess()
        {
            AutoBackup = true;
        }
        #endregion


        #region Override
        protected override void Backup()
        {
            PrepareBackup();
            using (var source = OpenConnection(_connectionString))
            {
                var backupTime = DateTime.Now;
                var backupFile = Path.Combine(_backupFolder, $"{backupTime.ToString("yyyyMMdd_HHmmss")}.sqlite");
                var desConStr = $"DataSource={backupFile}";
                using (var destination = OpenConnection(desConStr))
                {
                    source.BackupDatabase(destination, "main", "main", -1, null, 0);
                }
                File.WriteAllText(_backupLogFile, backupTime.ToString(_usCultureInfo));
            }
        }

        protected override RoomForRentEntityContext CreateContext() => new RoomForRentSqlLiteEntityDbContext();

        protected override bool ShouldBackup()
            => !Directory.Exists(_backupFolder) || !File.Exists(_backupLogFile) || IsTimeToBackup();
        #endregion


        #region Implementation
        private bool IsTimeToBackup()
        {
            var logString = File.ReadAllText(_backupLogFile);
            DateTime lastBackup;
            return string.IsNullOrEmpty(logString) ||
                   !DateTime.TryParse(logString, _usCultureInfo, DateTimeStyles.None, out lastBackup) ||
                   (DateTime.Now - lastBackup).TotalHours > _backupInterval;
        }

        private static SQLiteConnection OpenConnection(string connectionString)
        {
            var con = new SQLiteConnection(connectionString);
            con.Open();
            return con;
        }

        private void PrepareBackup()
        {
            if (!Directory.Exists(_backupFolder)) Directory.CreateDirectory(_backupFolder);
            var backupLogFolder = Path.GetDirectoryName(_backupLogFile);
            if (backupLogFolder != null && !Directory.Exists(backupLogFolder))
                Directory.CreateDirectory(backupLogFolder);
        }
        #endregion
    }
}