namespace RoomForRentModels
{
    public interface IRoomForRentDataAccess
        : IRoomForRentDataAccessSync, IRoomForRentDataAccessAsync, IAddressDataAccess, IApartmentDataAccess,
          IBuildingDataAccess, IOwnerDataAccess { }
}