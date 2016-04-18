using System.Data.Entity.ModelConfiguration;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class DistrictMap: EntityTypeConfiguration<District>
    {
        public DistrictMap()
        {
            Property(d => d.Id).HasColumnOrder(50);
            Property(d => d.Name).HasColumnOrder(70).HasMaxLength(16).IsRequired();

            HasMany(d => d.Wards).WithRequired(w => w.District).HasForeignKey(w => w.DistrictId);
            HasMany(d => d.Buildings).WithOptional(b => b.District).HasForeignKey(b => b.DistrictId);
        }
    }
}