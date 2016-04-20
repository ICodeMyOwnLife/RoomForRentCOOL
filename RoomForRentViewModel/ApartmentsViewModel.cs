using System.Windows.Input;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class ApartmentsViewModel: ViewModelBase
    {
        #region Fields
        private ICommand _addNewApartmentCommand;
        private Apartment[] _apartments;
        private Building[] _buildings;
        private Apartment _newApartment = new Apartment();
        private Owner[] _owners;
        private readonly IRoomForRentDataAccess _roomForRentDataAccess;
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
        public ICommand AddNewApartmentCommand => GetCommand(ref _addNewApartmentCommand, _ => AddNewApartment());

        public Apartment[] Apartments
        {
            get { return _apartments; }
            set { SetProperty(ref _apartments, value); }
        }

        public Building[] Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        public Apartment NewApartment
        {
            get { return _newApartment; }
            set { SetProperty(ref _newApartment, value); }
        }

        public Owner[] Owners
        {
            get { return _owners; }
            set { SetProperty(ref _owners, value); }
        }
        #endregion


        #region Methods
        public void AddNewApartment()
        {
            _roomForRentDataAccess.SaveApartment(NewApartment);
            NewApartment = new Apartment();
            ReloadAppartments();
        }
        #endregion


        #region Implementation
        private void ReloadAppartments()
        {
            Apartments = _roomForRentDataAccess.GetApartments();
        }
        #endregion
    }
}