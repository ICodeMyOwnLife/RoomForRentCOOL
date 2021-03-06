﻿using System.Threading.Tasks;


namespace RoomForRentModels
{
    public interface IApartmentDataAccessAsync
    {
        #region Abstract
        Task DeleteApartmentAsync(int apartmentId);
        Task<Apartment> GetApartmentAsync(int id);
        Task<Apartment[]> GetApartmentsAsync();
        Task<Apartment[]> GetApartmentsAsync(int buildingId);
        Task<Apartment> SaveApartmentAsync(Apartment apartment);
        #endregion
    }
}