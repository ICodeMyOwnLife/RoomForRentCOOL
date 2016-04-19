using System.Data.Entity;
using RoomForRentEntityDataAccess;


namespace RoomForRentMySqlEntity
{
    public class RoomForRentMySqlEntityDbContext: RoomForRentEntityContext
    {
        #region Override
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RoomForRentMySqlEntityDbContext>());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}