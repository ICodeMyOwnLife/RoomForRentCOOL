using System.Collections.Generic;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class DistrictsViewModel: IdNameModelViewModelBase<District>
    {
        #region Fields
        private readonly IAddressDataAccess _addressDataAccess;
        private Province _selectedProvince;
        #endregion


        #region  Constructors & Destructor
        public DistrictsViewModel(IAddressDataAccess addressDataAccess)
        {
            _addressDataAccess = addressDataAccess;
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


        #region Override
        protected override void DeleteItem(int id)
        {
            _addressDataAccess.DeleteDistrict(id);
        }

        protected override IEnumerable<District> LoadItems()
        {
            return SelectedProvince?.Id != null
                       ? _addressDataAccess.GetDistricts(SelectedProvince.Id.Value) : new District[0];
        }

        protected override District SaveItem(District item)
        {
            if (SelectedProvince?.Id == null) return null;

            item.ProvinceId = SelectedProvince.Id.Value;
            return _addressDataAccess.SaveDistrict(item);
        }
        #endregion
    }
}