using System.Data.Entity;
using System.Timers;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class RoomForRentEntityContext: DbContext, IAutoBackup
    {
        #region Fields
        private const double FIVE_MINUTE = 1000 * 5;
        private bool _autoBackup;
        protected readonly string _connectionString;
        protected readonly string _backupFolder = RoomForRentEntityConfig.GetBackupFolder();
        protected readonly int _backupInterval = RoomForRentEntityConfig.GetBackupInterval();
        protected readonly string _backupLogFile = RoomForRentEntityConfig.GetBackupLogFile();
        private Timer _timer;
        #endregion


        #region  Constructors & Destructor
        public RoomForRentEntityContext(): this("name=RoomForRentContext") { }

        public RoomForRentEntityContext(string nameOrConnectionString): base(nameOrConnectionString)
        {
            _connectionString = RoomForRentEntityConfig.GetConnectionString(nameOrConnectionString);
        }
        #endregion


        #region  Properties & Indexers
        public DbSet<Apartment> Apartments { get; set; }

        public bool AutoBackup
        {
            get { return _autoBackup; }
            set
            {
                _autoBackup = value;
                EnableTimer(value);
            }
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        #endregion


        #region Override
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            EnableTimer(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ApartmentMap());
            modelBuilder.Configurations.Add(new BuildingMap());
            modelBuilder.Configurations.Add(new EmailMap());
            modelBuilder.Configurations.Add(new OwnerMap());
            modelBuilder.Configurations.Add(new TelephoneMap());
        }
        #endregion


        #region Event Handlers
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (ShouldBackup()) { Backup(); }
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

// Bring Backup Implementation to DataAccess classes