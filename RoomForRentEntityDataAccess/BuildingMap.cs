using System.Data.Entity.ModelConfiguration;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class BuildingMap: EntityTypeConfiguration<Building>
    {
        public BuildingMap()
        {
            Property(b => b.Id).HasColumnOrder(50);
            Property(b => b.Name).HasColumnOrder(70).HasMaxLength(32).IsRequired().IsUnicode();
            Property(b => b.Number).HasColumnOrder(90);
            Property(b => b.Street).HasColumnOrder(110).HasMaxLength(32).IsRequired().IsUnicode();
            Property(b => b.Ward).HasColumnOrder(130).HasMaxLength(16).IsUnicode();
            Property(b => b.District).HasColumnOrder(150).HasMaxLength(16).IsRequired().IsUnicode();
            Property(b => b.Province).HasColumnOrder(170).HasMaxLength(32).IsRequired().IsUnicode();

            /*MapToStoredProcedures(s =>
            {
                s.Insert(i => i.HasName("Building_Insert", "dbo"));
                s.Update(u => u.HasName("Building_Update", "dbo"));
                s.Delete(d => d.HasName("Building_Delete", "dbo"));
            });*/
        }
    }
}