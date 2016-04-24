using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class WardsViewModel: NamedModelViewModel<Ward>
    {
        #region Fields
        private readonly IAddressDataAccess _addressDataAccess;
        private District _seleteDistrict;
        #endregion


        #region  Constructors & Destructor
        public WardsViewModel(IAddressDataAccess addressDataAccess)
        {
            _addressDataAccess = addressDataAccess;
        }
        #endregion


        #region  Properties & Indexers
        public District SeleteDistrict
        {
            get { return _seleteDistrict; }
            set
            {
                _seleteDistrict = value; 
                Load();
            }
        }
        #endregion


        #region Override
        protected override void DeleteItem(int id)
        {
            _addressDataAccess.DeleteWard(id);
        }

        protected override Ward[] LoadItems()
        {
            return SeleteDistrict?.Id != null ? _addressDataAccess.GetWards(SeleteDistrict.Id.Value) : new Ward[0];
        }

        protected override Ward SaveItem(Ward item)
        {
            if (SeleteDistrict?.Id == null) return null;

            item.DistrictId = SeleteDistrict.Id.Value;
            return _addressDataAccess.SaveWard(item);
        }
        #endregion
    }
}