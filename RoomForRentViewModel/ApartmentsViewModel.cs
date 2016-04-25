using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class ApartmentsViewModel: IdModelViewModelBase<Apartment>
    {
        #region Fields
        private Building[] _buildings;
        private Owner[] _owners;
        private readonly IRoomForRentDataAccess _roomForRentDataAccess;

        private Building _selectedBuilding;

        private Owner _selectedOwner;
        #endregion


        #region  Constructors & Destructor
        public ApartmentsViewModel()
        {
            _roomForRentDataAccess = RoomForRentViewModelConfig.GetDataAccess();
            Buildings = _roomForRentDataAccess.GetBuildings();
            Owners = _roomForRentDataAccess.GetOwners();
            ReloadAppartments();
        }
        #endregion


        #region  Properties & Indexers
        public Building[] Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        public Owner[] Owners
        {
            get { return _owners; }
            set { SetProperty(ref _owners, value); }
        }

        public Building SelectedBuilding
        {
            get { return _selectedBuilding; }
            set { SetProperty(ref _selectedBuilding, value); }
        }

        public Owner SelectedOwner
        {
            get { return _selectedOwner; }
            set { SetProperty(ref _selectedOwner, value); }
        }
        #endregion


        #region Override
        protected override bool CanSaveItem(Apartment item)
        {
            return item?.Code != null;
        }

        protected override void DeleteItem(int id)
        {
            _roomForRentDataAccess.DeleteApartment(id);
        }

        protected override Apartment[] LoadItems()
        {
            return _roomForRentDataAccess.GetApartments();
        }

        protected override Apartment SaveItem(Apartment item)
        {
            //UNDONE: Set selected Building, selected Owner
            return _roomForRentDataAccess.SaveApartment(item);
        }
        #endregion
    }
}