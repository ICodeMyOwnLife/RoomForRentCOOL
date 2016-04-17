using System.Data.Entity.ModelConfiguration;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class OwnerMap: EntityTypeConfiguration<Owner>
    {
        public OwnerMap()
        {
            Property(o => o.Id).HasColumnOrder(50);
            Property(o => o.Name).HasColumnOrder(70).HasMaxLength(64).IsRequired();

            /*MapToStoredProcedures(s =>
            {
                s.Insert(i => i.HasName("Owner_Insert", "dbo"));
                s.Update(u => u.HasName("Owner_Update", "dbo"));
                s.Delete(d => d.HasName("Owner_Delete", "dbo"));
            });*/
        }
    }
}