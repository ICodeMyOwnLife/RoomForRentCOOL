namespace RoomForRentModels
{
    public interface IRoomForRentDataAccessAsync: IApartmentDataAccessAsync, IBuildingDataAccessAsync, IOwnerDataAccessAsync, IAddressDataAccessAsync { }
}