using System.Diagnostics.CodeAnalysis;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class ApartmentsViewModel: IdEntityViewModelBase<Apartment>
    {
        #region Fields
        private Building[] _buildings;
        private Owner[] _owners;
        private readonly IRoomForRentDataAccess _roomForRentDataAccess;
        private Building _selectedBuilding;
        private Owner _selectedOwner;
        #endregion


        #region  Constructors & Destructor
        [SuppressMessage("ReSharper", "VirtualMemberCallInContructor")]
        public ApartmentsViewModel()
        {
            _roomForRentDataAccess = RoomForRentViewModelConfig.GetDataAccess();
            ModelDeleter(i => { _roomForRentDataAccess.DeleteApartment(i); });
            ModelsLoader(() => _roomForRentDataAccess.GetApartments());
            ModelSaver(a => _roomForRentDataAccess.SaveApartment(a));
            Collection(() => Buildings, () => _roomForRentDataAccess.GetBuildings(), () => SelectedBuilding,
                mdl => mdl.Building, a => a.BuildingId, b => b?.Id ?? 0);
            Collection(() => Owners, () => _roomForRentDataAccess.GetOwners(), () => SelectedOwner, a => a.Owner,
                a => a.OwnerId,
                o => o?.Id ?? 0);
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
            return SelectedBuilding?.Id != null && SelectedOwner?.Id != null && item?.Code != null;
        }
        #endregion
    }
}