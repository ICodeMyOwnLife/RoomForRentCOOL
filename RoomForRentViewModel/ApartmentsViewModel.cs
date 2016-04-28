using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            Collection(() => Buildings, () => SelectedBuilding, () => _roomForRentDataAccess.GetBuildings(), mdl => mdl.Building, b => b.Id);
            Collection(() => Owners, () => SelectedOwner, () => _roomForRentDataAccess.GetOwners(), a => a.Owner,
                o => o.Id);
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

        /*protected override void OnSelectedItemChanged(Apartment seletedItem)
        {
            base.OnSelectedItemChanged(seletedItem);
            SetSelectedBuilding(seletedItem?.BuildingId);
            SetSelectedOwner(seletedItem?.OwnerId);
        }*/

        protected override Apartment SaveItem(Apartment item)
        {
            if (SelectedBuilding?.Id == null || SelectedOwner?.Id == null) return null;

            item.Building = null;
            item.BuildingId = SelectedBuilding.Id.Value;

            item.Owner = null;
            item.OwnerId = SelectedOwner.Id.Value;

            var result = _roomForRentDataAccess.SaveApartment(item);

            item.Building = SelectedBuilding;
            item.Owner = SelectedOwner;
            return result;
        }
        #endregion


        /*private void SetSelectedBuilding(int? buildingId)
        {
            SelectedBuilding = buildingId == null ? null : Buildings?.FirstOrDefault(b => b.Id == buildingId);
        }

        private void SetSelectedOwner(int? ownerId)
        {
            SelectedOwner = ownerId == null ? null : Owners?.FirstOrDefault(o => o.Id == ownerId);
        }*/
    }
}