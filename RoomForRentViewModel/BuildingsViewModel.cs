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
            ModelDeleter(i => _roomForRentDataAccess.DeleteBuilding(i));
            ModelsLoader(() => _roomForRentDataAccess.GetBuildings());
            ModelSaver(b => _roomForRentDataAccess.SaveBuilding(b));
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
        /*protected override void DeleteItem(int id)
        {
            _roomForRentDataAccess.DeleteBuilding(id);
        }*/

        protected override void LoadCollections()
        {
            AddressesViewModel.Load();
            base.LoadCollections();
        }

        /*protected override IEnumerable<Building> LoadItems()
        {
            var buildings = _roomForRentDataAccess.GetBuildings();
            return buildings;
        }*/

        protected override void OnSelectedItemChanged(Building selectedItem)
        {
            base.OnSelectedItemChanged(selectedItem);
            SetSelectedProvince(selectedItem?.ProvinceId);
            SetSelectedDistrict(selectedItem?.DistrictId);
            SetSelectedWard(selectedItem?.WardId);
        }

        /*protected override Building SaveItem(Building item)
        {
            SetBuildingAddressId(item);
            var result = _roomForRentDataAccess.SaveBuilding(item);
            item.CopyFrom(result, true);
            return result;
        }*/

        protected override void SetModelAfterSaving(Building model)
        {
            model.Province = AddressesViewModel.SelectedProvince;
            model.District = AddressesViewModel.SelectedDistrict;
            model.Ward = AddressesViewModel.SelectedWard;
            base.SetModelAfterSaving(model);
        }

        protected override void SetModelBeforeSaving(Building model)
        {
            model.Province = null;
            model.District = null;
            model.Ward = null;
            model.ProvinceId = AddressesViewModel.SelectedProvince?.Id;
            model.DistrictId = AddressesViewModel.SelectedDistrict?.Id;
            model.WardId = AddressesViewModel.SelectedWard?.Id;
            base.SetModelBeforeSaving(model);
        }
        #endregion


        #region Implementation
        /*private void SetBuildingAddressId(Building item)
        {
            item.Province = null;
            item.District = null;
            item.Ward = null;
            item.ProvinceId = AddressesViewModel.SelectedProvince?.Id;
            item.DistrictId = AddressesViewModel.SelectedDistrict?.Id;
            item.WardId = AddressesViewModel.SelectedWard?.Id;
        }*/

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


// TODO: Test Set references after saving