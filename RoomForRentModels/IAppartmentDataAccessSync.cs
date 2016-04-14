namespace RoomForRentModels
{
    public interface IAppartmentDataAccessSync
    {
        #region Abstract
        void DeleteApartment(Apartment apartment);
        Apartment GetApartment(int id);
        Apartment[] GetApartments();
        Apartment[] GetApartments(int buildingId);
        Apartment SaveApartment(Apartment apartment);
        #endregion
    }
}