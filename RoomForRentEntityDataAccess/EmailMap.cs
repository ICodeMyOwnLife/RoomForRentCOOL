using System.Data.Entity.ModelConfiguration;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class EmailMap: EntityTypeConfiguration<Email>
    {
        public EmailMap()
        {
            Property(e => e.Id).HasColumnOrder(50);
            Property(e => e.Address).HasColumnOrder(70). HasMaxLength(64).IsRequired();

            HasRequired(e => e.Owner).WithMany(o => o.Emails).HasForeignKey(e => e.OwnerId);

            /*MapToStoredProcedures(s =>
            {
                s.Insert(i => i.HasName("Email_Insert", "dbo"));
                s.Update(u => u.HasName("Email_Update", "dbo"));
                s.Delete(d => d.HasName("Email_Delete"));
            });*/
        }
    }
}