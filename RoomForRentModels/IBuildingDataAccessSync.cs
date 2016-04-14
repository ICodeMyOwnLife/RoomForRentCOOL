namespace RoomForRentModels
{
    public interface IBuildingDataAccessSync
    {
        #region Abstract
        void DeleteBuilding(int buildingId);
        Building GetBuilding(int id);
        Building[] GetBuildings();
        Building SaveBuilding(Building building);
        #endregion
    }
}