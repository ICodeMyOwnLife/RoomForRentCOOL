using System.Data.Entity.Migrations;


namespace RoomForRentSqlServerCompactEntity.Migrations
{
    internal sealed class Configuration: DbMigrationsConfiguration<RoomForRentSqlServerConpactEntityDbContext>
    {
        #region  Constructors & Destructor
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        #endregion


        #region Override
        protected override void Seed(RoomForRentSqlServerConpactEntityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
        #endregion
    }
}