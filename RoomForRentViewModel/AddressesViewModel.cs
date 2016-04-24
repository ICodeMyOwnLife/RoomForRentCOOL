using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentViewModel
{
    /*public class AddressesViewModel: ViewModelBase
    {
        #region Fields
        private ICommand _addNewDistrictCommand;
        private ICommand _addNewProvinceCommand;
        private ICommand _addNewWardCommand;
        private District[] _districts;
        private District _newDistrict = new District();
        private Province _newProvince = new Province();
        private Ward _newWard = new Ward();
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
        public ICommand AddNewDistrictCommand
            => GetCommand(ref _addNewDistrictCommand, _ => AddNewDistrict(), _ =>
            {
                Debug.WriteLine($"New district name: {NewDistrict.Name}");
                return !string.IsNullOrEmpty(NewDistrict?.Name);
            });

        public ICommand AddNewProvinceCommand
            => GetCommand(ref _addNewProvinceCommand, _ => AddNewProvince(), _ =>
            {
                Debug.WriteLine($"New province name: {NewProvince.Name}");
                return !string.IsNullOrEmpty(NewProvince?.Name);
            });

        public ICommand AddNewWardCommand
            => GetCommand(ref _addNewWardCommand, _ => AddNewWard(), _ =>
            {
                Debug.WriteLine($"New ward name: {NewWard.Name}");
                return !string.IsNullOrEmpty(NewWard?.Name);
            });

        public District[] Districts
        {
            get { return _districts; }
            set
            {
                if (SetProperty(ref _districts, value) && value.Length > 1)
                {
                    SelectedDistrict = value[1];
                }
            }
        }

        public District NewDistrict
        {
            get { return _newDistrict; }
            set { SetProperty(ref _newDistrict, value); }
        }

        public Province NewProvince
        {
            get { return _newProvince; }
            set { SetProperty(ref _newProvince, value); }
        }

        public Ward NewWard
        {
            get { return _newWard; }
            set { SetProperty(ref _newWard, value); }
        }

        public Province[] Provinces
        {
            get { return _provinces; }
            set
            {
                if (SetProperty(ref _provinces, value))
                {
                    if (value.Length > 1)
                    {
                        SelectedProvince = Provinces[1];
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
                if (SetProperty(ref _wards, value) && value.Length > 1)
                {
                    SelectedWard = value[1];
                }
            }
        }
        #endregion


        #region Methods
        public void AddNewDistrict()
        {
            if (!string.IsNullOrEmpty(NewDistrict?.Name))
            {
                if (SelectedProvince.Id != null) NewDistrict.ProvinceId = SelectedProvince.Id.Value;
                _roomForRentDataAccess.SaveDistrict(NewDistrict);
                ReloadDistricts();
                SelectedDistrict = NewDistrict;
                NewDistrict = new District();
            }
        }

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

        public void AddNewWard()
        {
            if (string.IsNullOrEmpty(NewWard?.Name)) return;

            if (SelectedDistrict.Id != null) NewWard.DistrictId = SelectedDistrict.Id.Value;
            _roomForRentDataAccess.SaveWard(NewWard);
            ReloadWards();
            SelectedWard = NewWard;
            NewWard = new Ward();
        }

        public void Load()
        {
            ReloadProvinces();
            ReloadDistricts();
        }
        #endregion


        #region Implementation
        private void ReloadDistricts()
        {
            Districts = SelectedProvince.Id != null
                            ? _roomForRentDataAccess.GetDistricts(SelectedProvince.Id.Value) : new District[0];
        }

        private void ReloadProvinces()
        {
            Provinces = _roomForRentDataAccess.GetProvinces();
        }

        private void ReloadWards()
        {
            Wards = SelectedDistrict.Id != null
                        ? _roomForRentDataAccess.GetWards(SelectedDistrict.Id.Value) : new Ward[0];
        }
        #endregion
    }*/
}