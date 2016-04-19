using System.Data.Entity;
using RoomForRentEntityDataAccess;
using SQLite.CodeFirst;


namespace RoomForRentSqLiteEntity
{
    public class RoomForRentSqlLiteEntityDbContext: RoomForRentEntityContext
    {
        #region Override
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(
                new SqliteDropCreateDatabaseWhenModelChanges<RoomForRentSqlLiteEntityDbContext>(modelBuilder));
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}