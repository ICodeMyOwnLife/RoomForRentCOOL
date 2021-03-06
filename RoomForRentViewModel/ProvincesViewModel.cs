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
            ModelDeleter(i => _addressDataAccess.DeleteProvince(i));
            ModelSaver(p => _addressDataAccess.SaveProvince(p));
            ModelsLoader(() => _addressDataAccess.GetProvinces());
        }
        #endregion


        /*protected override void DeleteItem(int id)
        {
            _addressDataAccess.DeleteProvince(id);
        }

        protected override IEnumerable<Province> LoadItems()
        {
            return _addressDataAccess.GetProvinces();
        }

        protected override Province SaveItem(Province item)
        {
            return _addressDataAccess.SaveProvince(item);
        }*/
    }
}