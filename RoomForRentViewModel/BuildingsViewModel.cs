using System.Windows.Input;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class BuildingsViewModel: ViewModelBase
    {
        #region Fields
        private ICommand _addNewBuildingCommand;
        private Building[] _buildings;
        private ICommand _deleteBuildingCommand;
        private Building _selectedBuilding = new Building();
        private readonly IRoomForRentDataAccess _roomForRentDataAccess;
        private ICommand _saveBuildingCommand;
        #endregion


        #region  Constructors & Destructor
        public BuildingsViewModel()
        {
            _roomForRentDataAccess = RoomForRentViewModelConfig.GetDataAccess();
            AddressesViewModel = new AddressesViewModel(_roomForRentDataAccess);
            Load();
        }
        #endregion


        #region  Properties & Indexers
        public ICommand AddNewBuildingCommand => GetCommand(ref _addNewBuildingCommand, _ => AddNewBuilding());

        public Building[] Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        public ICommand DeleteBuildingCommand
            => GetCommand(ref _deleteBuildingCommand, obj => DeleteBuilding(obj as Building), obj => obj is Building);

        public Building SelectedBuilding
        {
            get { return _selectedBuilding; }
            set { SetProperty(ref _selectedBuilding, value); }
        }

        public ICommand SaveBuildingCommand
            => GetCommand(ref _saveBuildingCommand, obj => SaveBuilding(obj as Building), obj => obj is Building);

        public AddressesViewModel AddressesViewModel { get; }
        #endregion


        #region Methods
        public void AddNewBuilding()
        {
            SelectedBuilding.Province = AddressesViewModel.SelectedProvince;
            SelectedBuilding.District = AddressesViewModel.SelectedDistrict;
            SelectedBuilding.Ward = AddressesViewModel.SelectedWard;
            var b = _roomForRentDataAccess.SaveBuilding(SelectedBuilding);
            SelectedBuilding = new Building();
            ReloadBuildings();
        }

        public void DeleteBuilding(Building building)
        {
            if (building?.Id != null)
            {
                _roomForRentDataAccess.DeleteBuilding(building.Id.Value);
                ReloadBuildings();
            }
        }

        public void Load()
        {
            Buildings = _roomForRentDataAccess.GetBuildings();
            AddressesViewModel.Load();
        }

        public void SaveBuilding(Building building)
        {
            var b = _roomForRentDataAccess.SaveBuilding(building);
        }
        #endregion


        #region Implementation
        private void ReloadBuildings()
        {
            Buildings = _roomForRentDataAccess.GetBuildings();
        }
        #endregion
    }
}