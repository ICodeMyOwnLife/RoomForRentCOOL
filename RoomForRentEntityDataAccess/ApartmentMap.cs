using System.Data.Entity.ModelConfiguration;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class ApartmentMap: EntityTypeConfiguration<Apartment>
    {
        #region  Constructors & Destructor
        public ApartmentMap()
        {
            Property(a => a.Id).HasColumnOrder(50);
            Property(a => a.Code).HasColumnOrder(70).HasMaxLength(16).IsRequired();
            Property(a => a.AvailableFrom).HasColumnOrder(90);
            Property(a => a.Area).HasColumnOrder(110);
            Property(a => a.BedRoomCount).HasColumnOrder(130);
            Property(a => a.HasFurniture).HasColumnOrder(150);
            Property(a => a.Price).HasColumnOrder(170);
            Property(a => a.Commission).HasColumnOrder(190).HasMaxLength(32).IsRequired();
            Property(a => a.Note).HasColumnOrder(210).HasMaxLength(128);
            Property(a => a.UpdatedOn).HasColumnOrder(230);

            HasRequired(a => a.Building).WithMany(b => b.Apartments).HasForeignKey(a => a.BuildingId);

            HasRequired(a => a.Owner).WithMany(o => o.Apartments).HasForeignKey(a => a.OwnerId);

            /*MapToStoredProcedures(s =>
            {
                s.Insert(i => i.HasName("Apartment_Insert", "dbo"));
                s.Update(u => u.HasName("Apartment_Update", "dbo"));
                s.Delete(d => d.HasName("Apartment_Delete", "dbo"));
            });*/
        }
        #endregion
    }
}