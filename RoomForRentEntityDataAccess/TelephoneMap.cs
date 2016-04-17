using System.Data.Entity.ModelConfiguration;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class TelephoneMap: EntityTypeConfiguration<Telephone>
    {
        public TelephoneMap()
        {
            Property(t => t.Id).HasColumnOrder(50);
            Property(t => t.Number).HasColumnOrder(70).HasMaxLength(16).IsRequired().IsUnicode(false);

            HasRequired(t => t.Owner).WithMany(o => o.Telephones).HasForeignKey(t => t.OwnerId);

            /*MapToStoredProcedures(s =>
            {
                s.Insert(i => i.HasName("Telephone_Insert", "dbo"));
                s.Update(u => u.HasName("Telephone_Update", "dbo"));
                s.Delete(d => d.HasName("Telephone_Delete", "dbo"));
            });*/
        }
    }
}