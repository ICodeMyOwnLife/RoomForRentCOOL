using System.Linq;
using System.Windows.Input;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    public class AddressesViewModel: ViewModelBase
    {
        #region Fields
        private ICommand _addNewProvinceCommand;
        private District[] _districts;

        private Province _newProvince = new Province();
        private Province[] _provinces;
        private readonly IRoomForRentDataAccess _roomForRentDataAccess;
        private District _selectedDistrict;
        private Province _selectedProvince;
        private Ward _selectedWard;
        private Ward[] _wards;
        #endregion


        #region  Constructors & Destructor
        public AddressesViewModel(IRoomForRentDataAccess roomForRentDataAccess)
        {
            _roomForRentDataAccess = roomForRentDataAccess;
            Load();
        }
        #endregion


        #region  Properties & Indexers
        public ICommand AddNewProvinceCommand
            => GetCommand(ref _addNewProvinceCommand, _ => AddNewProvince(), _ => NewProvince?.Name != null);

        public District[] Districts
        {
            get { return _districts; }
            set
            {
                if (SetProperty(ref _districts, value) && value.Length > 0)
                {
                    SelectedDistrict = value[0];
                }
            }
        }

        public Province NewProvince
        {
            get { return _newProvince; }
            set { SetProperty(ref _newProvince, value); }
        }

        public Province[] Provinces
        {
            get { return _provinces; }
            set
            {
                if (SetProperty(ref _provinces, value))
                {
                    if (value.Length > 0)
                    {
                        SelectedProvince = Provinces[0];
                    }
                }
            }
        }

        public District SelectedDistrict
        {
            get { return _selectedDistrict; }
            set
            {
                if (!SetProperty(ref _selectedDistrict, value)) return;

                if (value?.Id != null)
                {
                    Wards = new Ward[] { null }.Concat(_roomForRentDataAccess.GetWards(value.Id.Value)).ToArray();
                }
            }
        }

        public Province SelectedProvince
        {
            get { return _selectedProvince; }
            set
            {
                if (!SetProperty(ref _selectedProvince, value)) return;

                if (value?.Id != null)
                {
                    Districts =
                        new District[] { null }.Concat(_roomForRentDataAccess.GetDistricts(value.Id.Value)).ToArray();
                }
            }
        }

        public Ward SelectedWard
        {
            get { return _selectedWard; }
            set { SetProperty(ref _selectedWard, value); }
        }

        public Ward[] Wards
        {
            get { return _wards; }
            set
            {
                if (SetProperty(ref _wards, value) && value.Length > 0)
                {
                    SelectedWard = value[0];
                }
            }
        }
        #endregion


        #region Methods
        public void AddNewProvince()
        {
            if (!string.IsNullOrEmpty(NewProvince?.Name))
            {
                _roomForRentDataAccess.SaveProvince(NewProvince);
                ReloadProvinces();
                SelectedProvince = NewProvince;
                NewProvince = new Province();
            }
        }

        public void Load()
        {
            ReloadProvinces();
        }
        #endregion


        #region Implementation
        private void ReloadProvinces()
        {
            Provinces = _roomForRentDataAccess.GetProvinces();
        }
        #endregion
    }
}