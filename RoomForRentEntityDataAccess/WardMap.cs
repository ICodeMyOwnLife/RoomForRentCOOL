using System.Data.Entity.ModelConfiguration;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class WardMap: EntityTypeConfiguration<Ward>
    {
        public WardMap()
        {
            Property(w => w.Id).HasColumnOrder(50);
            Property(w => w.Name).HasColumnOrder(70).HasMaxLength(16).IsRequired();

            HasMany(w => w.Buildings).WithOptional(b => b.Ward).HasForeignKey(b => b.WardId);
        }
    }
}