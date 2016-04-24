using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class ProvincesViewModel: IdNameModelViewModelBase<Province>
    {
        #region Fields
        private readonly IAddressDataAccess _addressDataAccess;
        #endregion


        #region  Constructors & Destructor
        public ProvincesViewModel(IAddressDataAccess addressDataAccess)
        {
            _addressDataAccess = addressDataAccess;
        }
        #endregion


        #region Override
        protected override void DeleteItem(int id)
        {
            _addressDataAccess.DeleteProvince(id);
        }

        protected override Province[] LoadItems()
        {
            return _addressDataAccess.GetProvinces();
        }

        protected override Province SaveItem(Province item)
        {
            return _addressDataAccess.SaveProvince(item);
        }
        #endregion
    }
}