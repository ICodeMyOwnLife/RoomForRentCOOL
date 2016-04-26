using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class OwnersViewModel: IdNameModelViewModelBase<Owner>
    {
        #region Fields
        private readonly IRoomForRentDataAccess _roomForRentDataAccess;
        #endregion


        #region  Constructors & Destructor
        [SuppressMessage("ReSharper", "VirtualMemberCallInContructor")]
        public OwnersViewModel()
        {
            _roomForRentDataAccess = RoomForRentViewModelConfig.GetDataAccess();
        }
        #endregion


        #region Override
        protected override void DeleteItem(int id)
        {
            _roomForRentDataAccess.DeleteOwner(id);
        }

        protected override IEnumerable<Owner> LoadItems()
        {
            return _roomForRentDataAccess.GetOwners();
        }

        protected override Owner SaveItem(Owner item)
        {
            return _roomForRentDataAccess.SaveOwner(item);
        }
        #endregion
    }
}