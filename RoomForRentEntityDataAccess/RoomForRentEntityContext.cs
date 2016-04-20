using System.Data.Entity;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class RoomForRentEntityContext: DbContext
    {
        #region Fields
        internal readonly string _connectionString;
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
        public DbSet<Building> Buildings { get; set; }
        internal string ConnectionString => _connectionString;
        public DbSet<District> Districts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Ward> Wards { get; set; }
        #endregion


        #region Override
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
    }
}


// TODO: Add SQL Server Compact Backup