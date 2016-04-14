namespace RoomForRentModels
{
    public interface IOwnerDataAccessSync
    {
        #region Abstract
        void DeleteOwner(Owner owner);
        Owner GetOwner(int id);
        Owner[] GetOwners();
        Owner SaveOwner(Owner owner);
        #endregion
    }
}