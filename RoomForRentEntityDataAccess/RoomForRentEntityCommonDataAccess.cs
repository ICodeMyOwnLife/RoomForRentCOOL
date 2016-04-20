using System.Threading.Tasks;
using System.Timers;
using CB.Database.EntityFramework;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class RoomForRentEntityCommonDataAccess
        : ModelDbContextBase<RoomForRentEntityContext>, IRoomForRentDataAccess, IAutoBackup
    {
        #region Fields
        private const double FIVE_MINUTE = 1000 * 15;
        private bool _autoBackup;
        protected readonly string _backupFolder = RoomForRentEntityConfig.GetBackupFolder();
        protected readonly int _backupInterval = RoomForRentEntityConfig.GetBackupInterval();
        protected readonly string _backupLogFile = RoomForRentEntityConfig.GetBackupLogFile();
        protected readonly string _connectionString;
        private Timer _timer;
        #endregion


        #region  Constructors & Destructor
        public RoomForRentEntityCommonDataAccess()
        {
            // ReSharper disable once VirtualMemberCallInContructor
            _connectionString = FetchDataContext(context => context.ConnectionString);
        }
        #endregion


        #region  Properties & Indexers
        public bool AutoBackup
        {
            get { return _autoBackup; }
            set
            {
                _autoBackup = value;
                EnableTimer(value);
            }
        }
        #endregion


        #region Methods
        public void DeleteApartment(int apartmentId)
            => DeleteModel<Apartment>(apartmentId);

        public async Task DeleteApartmentAsync(int apartmentId)
            => await DeleteModelAsync<Apartment>(apartmentId);

        public void DeleteBuilding(int buildingId)
            => DeleteModel<Building>(buildingId);

        public async Task DeleteBuildingAsync(int buildingId)
            => await DeleteModelAsync<Building>(buildingId);

        public void DeleteOwner(int ownerId)
            => DeleteModel<Owner>(ownerId);

        public async Task DeleteOwnerAsync(int ownerId)
            => await DeleteModelAsync<Owner>(ownerId);

        public Apartment GetApartment(int id)
            => GetModel<Apartment>(id);

        public async Task<Apartment> GetApartmentAsync(int id)
            => await GetModelAsync<Apartment>(id);

        public Apartment[] GetApartments()
            => GetModels<Apartment>();

        public Apartment[] GetApartments(int buildingId)
            => GetModels<Apartment>(apartment => apartment.BuildingId == buildingId);

        public async Task<Apartment[]> GetApartmentsAsync()
            => await GetModelsAsync<Apartment>();

        public async Task<Apartment[]> GetApartmentsAsync(int buildingId)
            => await GetModelsAsync<Apartment>(apartment => apartment.BuildingId == buildingId);

        public async Task<Building[]> GetBuidingsAsync()
            => await GetModelsAsync<Building>();

        public Building GetBuilding(int id)
            => GetModel<Building>(id);

        public async Task<Building> GetBuildingAsync(int id)
            => await GetModelAsync<Building>(id);

        public Building[] GetBuildings()
            => GetModels<Building>();

        public District[] GetDistricts(int provinceId)
            => GetModelsWithNoTracking<District>(d => d.ProvinceId == provinceId);

        public async Task<District[]> GetDistrictsAsync(int provinceId)
            => await GetModelsWithNoTrackingAsync<District>(d => d.ProvinceId == provinceId);

        public Owner GetOwner(int id)
            => GetModel<Owner>(id);

        public async Task<Owner> GetOwnerAsync(int id)
            => await GetModelAsync<Owner>(id);

        public Owner[] GetOwners()
            => GetModels<Owner>();

        public async Task<Owner[]> GetOwnersAsync()
            => await GetModelsAsync<Owner>();

        public Province[] GetProvinces()
            => GetModelsWithNoTracking<Province>();

        public async Task<Province[]> GetProvincesAsync()
            => await GetModelsWithNoTrackingAsync<Province>();

        public Ward[] GetWards(int districtId)
            => GetModelsWithNoTracking<Ward>(w => w.DistrictId == districtId);

        public async Task<Ward[]> GetWardsAsync(int districtId)
            => await GetModelsWithNoTrackingAsync<Ward>(w => w.DistrictId == districtId);

        public Apartment SaveApartment(Apartment apartment)
            => SaveModel(apartment);

        public async Task<Apartment> SaveApartmentAsync(Apartment apartment)
            => await SaveModelAsync(apartment);

        public Building SaveBuilding(Building building)
            => SaveModel(building);

        public async Task<Building> SaveBuildingAsync(Building building)
            => await SaveModelAsync(building);

        public Owner SaveOwner(Owner owner)
            => SaveModel(owner);

        public async Task<Owner> SaveOwnerAsync(Owner owner)
            => await SaveModelAsync(owner);
        #endregion


        #region Event Handlers
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            if (ShouldBackup())
            {
                Backup();
            }
            _timer.Start();
        }
        #endregion


        #region Implementation
        protected virtual void Backup() { }

        private void EnableTimer(bool isEnabled)
        {
            if (isEnabled)
            {
                _timer = new Timer(FIVE_MINUTE) { AutoReset = true, Enabled = true };
                _timer.Elapsed += Timer_Elapsed;
            }
            else if (_timer != null)
            {
                _timer.Elapsed -= Timer_Elapsed;
                _timer.Dispose();
            }
        }

        protected virtual bool ShouldBackup()
        {
            return false;
        }
        #endregion
    }
}


// TODO: GetWithNoTracking