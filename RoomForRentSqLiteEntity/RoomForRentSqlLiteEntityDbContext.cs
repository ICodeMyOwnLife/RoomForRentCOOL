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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(
                new SqliteCreateDatabaseIfNotExists<RoomForRentSqlLiteEntityDbContext>(modelBuilder));
            base.OnModelCreating(modelBuilder);
        }

    }
}