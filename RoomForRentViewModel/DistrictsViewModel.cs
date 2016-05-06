using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class DistrictsViewModel: IdNameEntityViewModelBase<District>
    {
        #region Fields
        private readonly IAddressDataAccess _addressDataAccess;
        private Province _selectedProvince;
        #endregion


        #region  Constructors & Destructor
        public DistrictsViewModel(IAddressDataAccess addressDataAccess)
        {
            _addressDataAccess = addressDataAccess;
            ModelDeleter(i => _addressDataAccess.DeleteDistrict(i));
            ModelSaver(d =>
            {
                if (SelectedProvince?.Id == null) return null;

                d.ProvinceId = SelectedProvince.Id;
                return _addressDataAccess.SaveDistrict(d);
            });
            ModelsLoader(() =>
                         SelectedProvince?.Id == null
                             ? new District[0] : _addressDataAccess.GetDistricts(SelectedProvince.Id));
        }
        #endregion


        #region  Properties & Indexers
        public Province SelectedProvince
        {
            get { return _selectedProvince; }
            set
            {
                _selectedProvince = value;
                Load();
            }
        }
        #endregion
    }
}