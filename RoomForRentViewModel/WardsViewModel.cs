using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class WardsViewModel: IdNameEntityViewModelBase<Ward>
    {
        #region Fields
        private readonly IAddressDataAccess _addressDataAccess;
        private District _selectedDistrict;
        #endregion


        #region  Constructors & Destructor
        public WardsViewModel(IAddressDataAccess addressDataAccess)
        {
            _addressDataAccess = addressDataAccess;
            ModelDeleter(i => _addressDataAccess.DeleteWard(i));
            ModelSaver(w =>
            {
                if (SelectedDistrict?.Id == null) return null;

                w.DistrictId = SelectedDistrict.Id;
                return _addressDataAccess.SaveWard(w);
            });
            ModelsLoader(
                () => SelectedDistrict?.Id == null ? new Ward[0] : _addressDataAccess.GetWards(SelectedDistrict.Id));
        }
        #endregion


        #region  Properties & Indexers
        public District SelectedDistrict
        {
            get { return _selectedDistrict; }
            set
            {
                _selectedDistrict = value;
                Load();
            }
        }
        #endregion
    }
}