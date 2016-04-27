using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        [SuppressMessage("ReSharper", "VirtualMemberCallInContructor")]
        public ApartmentsViewModel()
        {
            _roomForRentDataAccess = RoomForRentViewModelConfig.GetDataAccess();
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

        protected override IViewModelConfiguration CreateViewModelConfiguration()
        {
            var config = new ViewModelConfiguration<ApartmentsViewModel>(this);
            config.Items(vm => vm.Buildings, () => _roomForRentDataAccess.GetBuildings(), vm => vm.SelectedBuilding,
                b => b.Id);
            return config;
        }

        protected override void DeleteItem(int id)
        {
            _roomForRentDataAccess.DeleteApartment(id);
        }

        /*public override void Load()
        {
            Buildings = _roomForRentDataAccess.GetBuildings();
            Owners = _roomForRentDataAccess.GetOwners();
            base.Load();
        }*/

        protected override IEnumerable<Apartment> LoadItems()
        {
            return _roomForRentDataAccess.GetApartments();
        }

        protected override void OnSelectedItemChanged(Apartment seletedItem)
        {
            base.OnSelectedItemChanged(seletedItem);
            SetSelectedBuilding(seletedItem?.BuildingId);
            SetSelectedOwner(seletedItem?.OwnerId);
        }

        protected override Apartment SaveItem(Apartment item)
        {
            if (SelectedBuilding?.Id == null || SelectedOwner?.Id == null) return null;

            SelectedItem.Building = null;
            SelectedItem.BuildingId = SelectedBuilding.Id.Value;

            SelectedItem.Owner = null;
            SelectedItem.OwnerId = SelectedOwner.Id.Value;
            return _roomForRentDataAccess.SaveApartment(item);
        }
        #endregion


        #region Implementation
        private void SetSelectedBuilding(int? buildingId)
        {
            SelectedBuilding = buildingId == null ? null : Buildings?.FirstOrDefault(b => b.Id == buildingId);
        }

        private void SetSelectedOwner(int? ownerId)
        {
            SelectedOwner = ownerId == null ? null : Owners?.FirstOrDefault(o => o.Id == ownerId);
        }
        #endregion
    }
}