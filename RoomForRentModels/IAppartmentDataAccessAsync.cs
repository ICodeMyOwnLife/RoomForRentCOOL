using System.Threading.Tasks;


namespace RoomForRentModels
{
    public interface IAppartmentDataAccessAsync
    {
        #region Abstract
        Task DeleteApartmentAsync(Apartment apartment);
        Task<Apartment> GetApartmentAsync(int id);
        Task<Apartment[]> GetApartmentsAsync();
        Task<Apartment[]> GetApartmentsAsync(int buildingId);
        Task<Apartment> SaveApartmentAsync(Apartment apartment);
        #endregion
    }
}