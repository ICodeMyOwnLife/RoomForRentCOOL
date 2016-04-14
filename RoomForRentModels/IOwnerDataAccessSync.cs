namespace RoomForRentModels
{
    public interface IOwnerDataAccessSync
    {
        #region Abstract
        void DeleteOwner(int ownerId);
        Owner GetOwner(int id);
        Owner[] GetOwners();
        Owner SaveOwner(Owner owner);
        #endregion
    }
}