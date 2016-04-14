namespace RoomForRentModels
{
    public interface IAppartmentDataAccessSync
    {
        #region Abstract
        void DeleteApartment(int apartmentId);
        Apartment GetApartment(int id);
        Apartment[] GetApartments();
        Apartment[] GetApartments(int buildingId);
        Apartment SaveApartment(Apartment apartment);
        #endregion
    }
}