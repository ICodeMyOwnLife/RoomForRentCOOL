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
        private District[] _districts;
        private Building _newBuilding = new Building();
        private Province[] _provinces;
        private readonly IRoomForRentDataAccess _roomForRentDataAccess;
        private ICommand _saveBuildingCommand;
        private District _selectedDistrict;
        private Province _selectedProvince;
        private Ward _selectedWard;
        private Ward[] _wards;
        #endregion


        #region  Constructors & Destructor
        public BuildingsViewModel()
        {
            _roomForRentDataAccess = RoomForRentViewModelConfig.GetDataAccess();
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

        public District[] Districts
        {
            get { return _districts; }
            set
            {
                if (SetProperty(ref _districts, value) && value.Length > 0)
                {
                    SelectedDistrict = value[0];
                }
            }
        }

        public Building NewBuilding
        {
            get { return _newBuilding; }
            set { SetProperty(ref _newBuilding, value); }
        }

        public Province[] Provinces
        {
            get { return _provinces; }
            set
            {
                if (SetProperty(ref _provinces, value))
                {
                    if (value.Length > 0)
                    {
                        SelectedProvince = Provinces[0];
                    }
                }
            }
        }

        public ICommand SaveBuildingCommand
            => GetCommand(ref _saveBuildingCommand, obj => SaveBuilding(obj as Building), obj => obj is Building);

        public District SelectedDistrict
        {
            get { return _selectedDistrict; }
            set
            {
                if (!SetProperty(ref _selectedDistrict, value)) return;

                NewBuilding.District = value;
                if (value?.Id != null)
                {
                    Wards = _roomForRentDataAccess.GetWards(value.Id.Value);
                }
            }
        }

        public Province SelectedProvince
        {
            get { return _selectedProvince; }
            set
            {
                if (!SetProperty(ref _selectedProvince, value)) return;

                NewBuilding.Province = value;
                if (value?.Id != null)
                {
                    Districts = _roomForRentDataAccess.GetDistricts(value.Id.Value);
                }
            }
        }

        public Ward SelectedWard
        {
            get { return _selectedWard; }
            set
            {
                if (!SetProperty(ref _selectedWard, value)) return;
                NewBuilding.Ward = value;
            }
        }

        public Ward[] Wards
        {
            get { return _wards; }
            set
            {
                if (SetProperty(ref _wards, value) && value.Length > 0)
                {
                    SelectedWard = value[0];
                }
            }
        }
        #endregion


        #region Methods
        public void AddNewBuilding()
        {
            var b = _roomForRentDataAccess.SaveBuilding(NewBuilding);
            NewBuilding = new Building();
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
            Provinces = _roomForRentDataAccess.GetProvinces();
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