using System.Collections.Generic;
using System.Windows.Input;
using CB.Model.Common;
using RoomForRentModels;
using RoomForRentXmlDataAccess;


namespace RoomForRentViewModel
{
    public class BuildingsViewModel: ViewModelBase
    {
        #region Fields
        private ICommand _addNewBuildingCommand;
        private readonly IBuildingDataAccessSync _buildingDataAccess;
        private IList<Building> _buildings;

        private ICommand _deleteBuildingCommand;
        private Building _newBuilding = new Building();

        private ICommand _saveBuildingCommand;
        #endregion


        #region  Constructors & Destructor
        public BuildingsViewModel()
        {
            var context = new RoomForRentXmlContext();
            context.Load();
            _buildingDataAccess = context;
            Buildings = _buildingDataAccess.GetBuildings();
        }
        #endregion


        #region  Properties & Indexers
        public ICommand AddNewBuildingCommand => GetCommand(ref _addNewBuildingCommand, _ => AddNewBuilding());

        public IList<Building> Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        public ICommand DeleteBuildingCommand
            => GetCommand(ref _deleteBuildingCommand, obj => DeleteBuilding(obj as Building), obj => obj is Building);

        public Building NewBuilding
        {
            get { return _newBuilding; }
            set { SetProperty(ref _newBuilding, value); }
        }

        public ICommand SaveBuildingCommand
            => GetCommand(ref _saveBuildingCommand, obj => SaveBuilding(obj as Building), obj => obj is Building);
        #endregion


        #region Methods
        public void AddNewBuilding()
        {
            _buildingDataAccess.SaveBuilding(NewBuilding);
            NewBuilding = new Building();
            ReloadBuildings();
        }

        private void ReloadBuildings()
        {
            Buildings = _buildingDataAccess.GetBuildings();
        }

        public void DeleteBuilding(Building building)
        {
            if (building?.Id != null)
            {
                _buildingDataAccess.DeleteBuilding(building.Id.Value);
                ReloadBuildings();
            }
        }

        public void SaveBuilding(Building building)
        {
            _buildingDataAccess.SaveBuilding(building);
        }
        #endregion
    }
}