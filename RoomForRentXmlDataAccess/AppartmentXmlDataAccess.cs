using System.Linq;
using RoomForRentModels;


namespace RoomForRentXmlDataAccess
{
    public class AppartmentXmlDataAccess: IAppartmentDataAccessSync
    {
        public AppartmentXmlDataAccess()
        {
            RoomForRentXmlContext.Load();
        }
        public void DeleteApartment(Apartment apartment)
        {
            RoomForRentXmlContext.Apartments.Remove(apartment);
            RoomForRentXmlContext.SaveApartments();
        }

        public Apartment GetApartment(int id)
        {
            return RoomForRentXmlContext.Apartments.FirstOrDefault(a => a.Id == id);
        }

        public Apartment[] GetApartments()
        {
            return RoomForRentXmlContext.Apartments.ToArray();
        }

        public Apartment[] GetApartments(int buildingId)
        {
            return RoomForRentXmlContext.Apartments.Where(a => a.BuildingId == buildingId).ToArray();
        }

        public Apartment SaveApartment(Apartment apartment)
        {
            RoomForRentXmlContext.Apartments.Add(apartment);
            RoomForRentXmlContext.SaveApartments();
        }
    }
}