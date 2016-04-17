namespace RoomForRentModels
{
    public interface IApartmentDataAccessSync
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