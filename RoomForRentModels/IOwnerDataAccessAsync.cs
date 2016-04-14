using System.Threading.Tasks;


namespace RoomForRentModels
{
    public interface IOwnerDataAccessAsync
    {
        #region Abstract
        Task DeleteOwnerAsync(int ownerId);
        Task<Owner> GetOwnerAsync(int id);
        Task<Owner[]> GetOwnersAsync();
        Task<Owner> SaveOwnerAsync(Owner owner);
        #endregion
    }
}