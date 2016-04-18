using System.Threading.Tasks;
using CB.Database.EntityFramework;
using RoomForRentModels;


namespace RoomForRentEntityDataAccess
{
    public class RoomForRentEntityCommonDataAccess
        : ModelDbContextBase<RoomForRentEntityContext>, IApartmentDataAccess, IBuildingDataAccess, IOwnerDataAccess
    {
        #region Methods
        public void DeleteApartment(int apartmentId)
            => DeleteModel<Apartment>(apartmentId);

        public async Task DeleteApartmentAsync(int apartmentId)
            => await DeleteModelAsync<Apartment>(apartmentId);

        public void DeleteBuilding(int buildingId)
            => DeleteModel<Building>(buildingId);

        public async Task DeleteBuildingAsync(int buildingId)
            => await DeleteModelAsync<Building>(buildingId);

        public void DeleteOwner(int ownerId)
            => DeleteModel<Owner>(ownerId);

        public async Task DeleteOwnerAsync(int ownerId)
            => await DeleteModelAsync<Owner>(ownerId);

        public Apartment GetApartment(int id)
            => GetModel<Apartment>(id);

        public async Task<Apartment> GetApartmentAsync(int id)
            => await GetModelAsync<Apartment>(id);

        public Apartment[] GetApartments()
            => GetModels<Apartment>();

        public Apartment[] GetApartments(int buildingId)
            => GetModels<Apartment>(apartment => apartment.BuildingId == buildingId);

        public async Task<Apartment[]> GetApartmentsAsync()
            => await GetModelsAsync<Apartment>();

        public async Task<Apartment[]> GetApartmentsAsync(int buildingId)
            => await GetModelsAsync<Apartment>(apartment => apartment.BuildingId == buildingId);

        public async Task<Building[]> GetBuidingsAsync()
            => await GetModelsAsync<Building>();

        public Building GetBuilding(int id)
            => GetModel<Building>(id);

        public async Task<Building> GetBuildingAsync(int id)
            => await GetModelAsync<Building>(id);

        public Building[] GetBuildings()
            => GetModels<Building>();

        public Owner GetOwner(int id)
            => GetModel<Owner>(id);

        public async Task<Owner> GetOwnerAsync(int id)
            => await GetModelAsync<Owner>(id);

        public Owner[] GetOwners()
            => GetModels<Owner>();

        public async Task<Owner[]> GetOwnersAsync()
            => await GetModelsAsync<Owner>();

        public Apartment SaveApartment(Apartment apartment)
            => SaveModel(apartment);

        public async Task<Apartment> SaveApartmentAsync(Apartment apartment)
            => await SaveModelAsync(apartment);

        public Building SaveBuilding(Building building)
            => SaveModel(building);

        public async Task<Building> SaveBuildingAsync(Building building)
            => await SaveModelAsync(building);

        public Owner SaveOwner(Owner owner)
            => SaveModel(owner);

        public async Task<Owner> SaveOwnerAsync(Owner owner)
            => await SaveModelAsync(owner);
        #endregion
    }
}