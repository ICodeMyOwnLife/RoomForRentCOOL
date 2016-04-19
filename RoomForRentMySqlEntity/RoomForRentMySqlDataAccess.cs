using RoomForRentEntityDataAccess;


namespace RoomForRentMySqlEntity
{
    public class RoomForRentMySqlDataAccess: RoomForRentEntityCommonDataAccess
    {
        #region Override
        protected override RoomForRentEntityContext CreateContext()
        {
            return new RoomForRentMySqlEntityDbContext();
        }
        #endregion
    }
}