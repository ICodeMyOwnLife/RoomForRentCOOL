using System.Threading.Tasks;


namespace RoomForRentModels
{
    public interface IBuildingDataAccessAsync
    {
        #region Abstract
        Task DeleteBuildingAsync(int buildingId);
        Task<Building[]> GetBuidingsAsync();
        Task<Building> GetBuildingAsync(int id);
        Task<Building> SaveBuildingAsync(Building building);
        #endregion
    }
}