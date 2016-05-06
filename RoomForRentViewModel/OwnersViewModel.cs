using System.Diagnostics.CodeAnalysis;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class OwnersViewModel: IdNameEntityViewModelBase<Owner>
    {
        #region Fields
        private readonly IRoomForRentDataAccess _roomForRentDataAccess;
        #endregion


        #region  Constructors & Destructor
        [SuppressMessage("ReSharper", "VirtualMemberCallInContructor")]
        public OwnersViewModel()
        {
            _roomForRentDataAccess = RoomForRentViewModelConfig.GetDataAccess();
            ModelDeleter(i => _roomForRentDataAccess.DeleteOwner(i));
            ModelsLoader(() => _roomForRentDataAccess.GetOwners());
            ModelSaver(o => _roomForRentDataAccess.SaveOwner(o));
        }
        #endregion
    }
}