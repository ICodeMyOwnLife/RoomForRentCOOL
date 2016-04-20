namespace RoomForRentModels
{
    public interface IRoomForRentDataAccessSync: IApartmentDataAccessSync, IBuildingDataAccessSync, IOwnerDataAccessSync, IAddressDataAccessSync { }
}