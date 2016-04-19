using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using RoomForRentEntityDataAccess;
using SQLite.CodeFirst;


namespace RoomForRentSqLiteEntity
{
    public class RoomForRentSqlLiteEntityDbContext: RoomForRentEntityContext
    {
        #region  Constructors & Destructor
        public RoomForRentSqlLiteEntityDbContext()
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
                var backupFile = Path.Combine(_backupFolder, $"{DateTime.Now.ToString("YYYYMMdd HHmmss")}.sqlite");
                var desConStr = $"DataSource={backupFile}";
                using (var destination = OpenConnection(desConStr))
                {
                    source.BackupDatabase(destination, "main", "main", -1, null, 0);
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(
                new SqliteCreateDatabaseIfNotExists<RoomForRentSqlLiteEntityDbContext>(modelBuilder));
            base.OnModelCreating(modelBuilder);
        }

        protected override bool ShouldBackup()
        {
            return !Directory.Exists(_backupFolder) || !File.Exists(_backupLogFile) || IsTimeToBackup();
        }
        #endregion


        #region Implementation
        private bool IsTimeToBackup()
        {
            var logString = File.ReadAllText(_backupLogFile);
            DateTime lastBackup;
            return string.IsNullOrEmpty(logString) ||
                   !DateTime.TryParse(logString, new CultureInfo("en-US"), DateTimeStyles.None, out lastBackup) ||
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