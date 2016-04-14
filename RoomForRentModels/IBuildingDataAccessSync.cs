namespace RoomForRentModels
{
    public interface IBuildingDataAccessSync
    {
        #region Abstract
        void DeleteBuilding(Building building);
        Building GetBuilding(int id);
        Building[] GetBuildings();
        Building SaveBuilding(Building building);
        #endregion
    }
}