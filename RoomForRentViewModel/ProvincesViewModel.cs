using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class ProvincesViewModel: NamedModelViewModel<Province>
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

    public class DistrictsViewModel: NamedModelViewModel<District>
    {
        #region Fields
        private readonly IAddressDataAccess _addressDataAccess;
        #endregion


        #region  Constructors & Destructor
        public DistrictsViewModel(IAddressDataAccess addressDataAccess)
        {
            _addressDataAccess = addressDataAccess;
        }
        #endregion


        #region  Properties & Indexers
        public Province SelectedProvince { get; set; }
        #endregion


        #region Override
        protected override void DeleteItem(int id)
        {
            _addressDataAccess.DeleteDistrict(id);
        }

        protected override District[] LoadItems()
        {
            return SelectedProvince.Id.HasValue
                       ? _addressDataAccess.GetDistricts(SelectedProvince.Id.Value) : new District[0];
        }

        protected override District SaveItem(District item)
        {
            return _addressDataAccess.SaveDistrict(item);
        }
        #endregion
    }

    public class WardsViewModel: NamedModelViewModel<Ward>
    {
        #region Fields
        private readonly IAddressDataAccess _addressDataAccess;
        #endregion


        #region  Constructors & Destructor
        public WardsViewModel(IAddressDataAccess addressDataAccess)
        {
            _addressDataAccess = addressDataAccess;
        }
        #endregion


        #region  Properties & Indexers
        public District SeleteDistrict { get; set; }
        #endregion


        #region Override
        protected override void DeleteItem(int id)
        {
            _addressDataAccess.DeleteWard(id);
        }

        protected override Ward[] LoadItems()
        {
            return SeleteDistrict.Id.HasValue ? _addressDataAccess.GetWards(SeleteDistrict.Id.Value) : new Ward[0];
        }

        protected override Ward SaveItem(Ward item)
        {
            return _addressDataAccess.SaveWard(item);
        }
        #endregion
    }
}