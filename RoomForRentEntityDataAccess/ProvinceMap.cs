using System.Data.Entity.ModelConfiguration;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class ProvinceMap: EntityTypeConfiguration<Province>
    {
        public ProvinceMap()
        {
            Property(p => p.Id).HasColumnOrder(50);
            Property(p => p.Name).HasColumnOrder(70).HasMaxLength(32).IsRequired();

            HasMany(p => p.Districts).WithRequired(d => d.Province).HasForeignKey(d => d.ProvinceId);
            HasMany(p => p.Buildings).WithOptional(d => d.Province).HasForeignKey(d => d.ProvinceId);
        }
    }
}