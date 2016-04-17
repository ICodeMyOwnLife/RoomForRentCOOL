using System.Data.Entity;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class RoomForRentEntityContext: DbContext
    {
        #region  Constructors & Destructor
        public RoomForRentEntityContext(): base("name=RoomForRentContext") { }
        #endregion


        #region  Properties & Indexers
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
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