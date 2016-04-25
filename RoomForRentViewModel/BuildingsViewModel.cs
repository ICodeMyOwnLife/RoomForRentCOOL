using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    /*public class BuildingsViewModel: ViewModelBase
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
    }*/

    public class BuildingsViewModel: IdNameModelViewModelBase<Building>
    {
        #region Fields
        private AddressesViewModel _addressesViewModel;
        private readonly IRoomForRentDataAccess _roomForRentDataAccess;
        #endregion


        #region  Constructors & Destructor
        [SuppressMessage("ReSharper", "VirtualMemberCallInContructor")]
        public BuildingsViewModel()
        {
            _roomForRentDataAccess = RoomForRentViewModelConfig.GetDataAccess();
            AddressesViewModel = new AddressesViewModel(_roomForRentDataAccess);
            Load();
        }
        #endregion


        #region  Properties & Indexers
        public AddressesViewModel AddressesViewModel
        {
            get { return _addressesViewModel; }
            private set { SetProperty(ref _addressesViewModel, value); }
        }
        #endregion


        #region Override
        protected override void DeleteItem(int id)
        {
            _roomForRentDataAccess.DeleteBuilding(id);
        }

        public override void Load()
        {
            base.Load();
            AddressesViewModel.Load();
        }

        protected override Building[] LoadItems()
        {
            var buildings = _roomForRentDataAccess.GetBuildings();
            return buildings;
        }

        protected override void OnSelectedItemChanged(Building selectedItem)
        {
            base.OnSelectedItemChanged(selectedItem);
            SetSelectedProvince(selectedItem?.ProvinceId);
            SetSelectedDistrict(selectedItem?.DistrictId);
            SetSelectedWard(selectedItem?.WardId);
        }

        protected override Building SaveItem(Building item)
        {
            SetBuildingAddress(item);
            return _roomForRentDataAccess.SaveBuilding(item);
        }
        #endregion


        #region Implementation
        private void SetBuildingAddress(Building item)
        {
            item.Province = null;
            item.District = null;
            item.Ward = null;
            item.ProvinceId = AddressesViewModel.SelectedProvince?.Id;
            item.DistrictId = AddressesViewModel.SelectedDistrict?.Id;
            item.WardId = AddressesViewModel.SelectedWard?.Id;
        }

        private void SetSelectedDistrict(int? districtId)
        {
            AddressesViewModel.SelectedDistrict = districtId == null ? null :
                                                      AddressesViewModel.DistrictsViewModel.Items?.FirstOrDefault(
                                                          d => d.Id == districtId);
        }

        private void SetSelectedProvince(int? provinceId)
        {
            AddressesViewModel.SelectedProvince = provinceId == null ? null :
                                                      AddressesViewModel.ProvincesViewModel.Items?.FirstOrDefault(
                                                          p => p.Id == provinceId);
        }

        private void SetSelectedWard(int? wardId)
        {
            AddressesViewModel.SelectedWard = wardId == null ? null :
                                                  AddressesViewModel.WardsViewModel.Items?.FirstOrDefault(
                                                      w => w.Id == wardId);
        }
        #endregion
    }
}