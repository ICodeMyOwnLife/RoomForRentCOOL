using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class ProvincesViewModel: IdNameEntityViewModelBase<Province>
    {
        #region Fields
        private readonly IAddressDataAccess _addressDataAccess;
        #endregion


        #region  Constructors & Destructor
        public ProvincesViewModel(IAddressDataAccess addressDataAccess)
        {
            _addressDataAccess = addressDataAccess;
            ModelDeleter(i => _addressDataAccess.DeleteProvince(i));
            ModelSaver(p => _addressDataAccess.SaveProvince(p));
            ModelsLoader(() => _addressDataAccess.GetProvinces());
        }
        #endregion
    }
}