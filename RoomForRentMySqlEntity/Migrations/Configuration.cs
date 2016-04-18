using System.Data.Entity.Migrations;
using MySql.Data.Entity;


namespace RoomForRentMySqlEntity.Migrations
{
    internal sealed class Configuration: DbMigrationsConfiguration<RoomForRentMySqlEntityDbContext>
    {
        #region  Constructors & Destructor
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }
        #endregion


        #region Override
        protected override void Seed(RoomForRentMySqlEntityDbContext context)
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