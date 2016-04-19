using RoomForRentEntityDataAccess;


namespace RoomForRentSqlServerCompactEntity
{
    public class RoomForRentSqlServerCompactDataAccess: RoomForRentEntityCommonDataAccess
    {
        #region Override
        protected override RoomForRentEntityContext CreateContext()
        {
            return new RoomForRentSqlServerConpactEntityDbContext();
        }
        #endregion
    }
}