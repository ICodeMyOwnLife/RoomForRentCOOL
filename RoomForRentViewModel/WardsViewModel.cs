using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class WardsViewModel: IdNameModelViewModelBase<Ward>
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

                w.DistrictId = SelectedDistrict.Id.Value;
                return _addressDataAccess.SaveWard(w);
            });
            ModelsLoader(
                () => SelectedDistrict?.Id == null ? new Ward[0] : _addressDataAccess.GetWards(SelectedDistrict.Id.Value));
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


        /*protected override void DeleteItem(int id)
        {
            _addressDataAccess.DeleteWard(id);
        }

        protected override IEnumerable<Ward> LoadItems()
        {
            return SelectedDistrict?.Id != null ? _addressDataAccess.GetWards(SelectedDistrict.Id.Value) : new Ward[0];
        }

        protected override Ward SaveItem(Ward item)
        {
            if (SelectedDistrict?.Id == null) return null;

            item.DistrictId = SelectedDistrict.Id.Value;
            return _addressDataAccess.SaveWard(item);
        }*/
    }
}