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

        private Building _newBuilding = new Building();
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

        public Building NewBuilding
        {
            get { return _newBuilding; }
            set { SetProperty(ref _newBuilding, value); }
        }
        #endregion


        #region Methods
        public void AddNewBuilding()
        {
            _buildingDataAccess.SaveBuilding(NewBuilding);
            NewBuilding = new Building();
            Buildings = _buildingDataAccess.GetBuildings();
        }
        #endregion
    }
}