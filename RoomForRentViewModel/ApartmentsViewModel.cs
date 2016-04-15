using System.Windows.Input;
using CB.Model.Common;
using RoomForRentModels;
using RoomForRentXmlDataAccess;


namespace RoomForRentViewModel
{
    public class ApartmentsViewModel: ViewModelBase
    {
        #region Fields
        private Apartment[] _apartments;
        private readonly IAppartmentDataAccessSync _appartmentDataAccess;
        private Building[] _buildings;
        private Apartment _newApartment = new Apartment();
        private Owner[] _owners;
        #endregion


        #region  Constructors & Destructor
        public ApartmentsViewModel()
        {
            var context = new RoomForRentXmlContext();
            context.Load();
            _appartmentDataAccess = context;
            Buildings = context.GetBuildings();
            Owners = context.GetOwners();
            ReloadAppartments();
        }
        #endregion


        #region  Properties & Indexers
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
            _appartmentDataAccess.SaveApartment(NewApartment);
            NewApartment = new Apartment();
            ReloadAppartments();
        }
        #endregion


        private ICommand _addNewApartmentCommand;
        public ICommand AddNewApartmentCommand => GetCommand(ref _addNewApartmentCommand, _ => AddNewApartment());
        
        #region Implementation
        private void ReloadAppartments()
        {
            Apartments = _appartmentDataAccess.GetApartments();
        }
        #endregion
    }
}


//TODO: IdModelBase: IComparable