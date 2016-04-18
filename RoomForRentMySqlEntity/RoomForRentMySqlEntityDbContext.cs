using RoomForRentEntityDataAccess;


namespace RoomForRentMySqlEntity
{
    public class RoomForRentMySqlEntityDbContext: RoomForRentEntityContext
    {
        #region  Constructors & Destructor
        public RoomForRentMySqlEntityDbContext(): base("name=RoomForRentMySqlContext") { }
        #endregion
    }
}