using RoomForRentEntityDataAccess;


namespace RoomForRentSqLiteEntity
{
    public class RoomForRentSqLiteDataAccess: RoomForRentEntityCommonDataAccess
    {
        #region Override
        protected override RoomForRentEntityContext CreateContext()
        {
            return new RoomForRentSqlLiteEntityDbContext();
        }
        #endregion
    }
}