using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class BuildingsViewModel: IdNameEntityViewModelBase<Building>
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
        protected override void LoadCollections()
        {
            AddressesViewModel.Load();
            base.LoadCollections();
        }
        
        protected override void OnSelectedItemChanged(Building selectedItem)
        {
            base.OnSelectedItemChanged(selectedItem);
            SetSelectedProvince(selectedItem?.ProvinceId);
            SetSelectedDistrict(selectedItem?.DistrictId);
            SetSelectedWard(selectedItem?.WardId);
        }
        
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