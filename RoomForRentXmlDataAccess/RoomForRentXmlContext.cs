using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentXmlDataAccess
{
    public class RoomForRentXmlContext: IAppartmentDataAccessSync, IBuildingDataAccessSync, IOwnerDataAccessSync
    {
        #region Fields
        private static IList<Apartment> _apartments;
        private static IList<Building> _buildings;
        private static IList<Email> _emails;
        private static bool _isLoaded;
        private static IList<Owner> _owners;
        private static IList<Telephone> _telephones;
        #endregion


        #region  Properties & Indexers
        public static IList<Apartment> Apartments
        {
            get { return _apartments; }
            set { _apartments = value; }
        }

        public static IList<Building> Buildings
        {
            get { return _buildings; }
            set { _buildings = value; }
        }

        public static IList<Email> Emails
        {
            get { return _emails; }
            set { _emails = value; }
        }

        public static IList<Owner> Owners
        {
            get { return _owners; }
            set { _owners = value; }
        }

        public static IList<Telephone> Telephones
        {
            get { return _telephones; }
            set { _telephones = value; }
        }
        #endregion


        #region Methods
        public void DeleteApartment(int apartmentId)
        {
            Delete(apartmentId, Apartments, nameof(Apartments));
        }

        public void DeleteBuilding(int buildingId)
        {
            Delete(buildingId, Buildings, nameof(Buildings));
        }

        public void DeleteOwner(int ownerId)
        {
            Delete(ownerId, Owners, nameof(Owners));
        }

        public Apartment GetApartment(int id)
        {
            return Get(Apartments, id);
        }

        public Apartment[] GetApartments()
        {
            return Apartments?.ToArray();
        }

        public Apartment[] GetApartments(int buildingId)
        {
            var building = GetBuilding(buildingId);
            return building?.Apartments?.ToArray();
        }

        public Building GetBuilding(int id)
        {
            return Get(Buildings, id);
        }

        public Building[] GetBuildings()
        {
            return Buildings.ToArray();
        }

        public Owner GetOwner(int id)
        {
            return Get(Owners, id);
        }

        public Owner[] GetOwners()
        {
            return Owners.ToArray();
        }

        public void Load()
        {
            if (!_isLoaded)
            {
                Load(ref _apartments, nameof(Apartments));
                Load(ref _buildings, nameof(Buildings));
                Load(ref _emails, nameof(Emails));
                Load(ref _owners, nameof(Owners));
                Load(ref _telephones, nameof(Telephones));
                SetRelationalProperties();
                _isLoaded = true;
            }
        }

        public void Save()
        {
            Save(Apartments, nameof(Apartments));
            Save(Buildings, nameof(Buildings));
            Save(Emails, nameof(Emails));
            Save(Owners, nameof(Owners));
            Save(Telephones, nameof(Telephones));
        }

        public Apartment SaveApartment(Apartment apartment)
        {
            return Save(apartment, Apartments, nameof(Apartments));
        }

        public Building SaveBuilding(Building building)
        {
            return Save(building, Buildings, nameof(Buildings));
        }

        public Owner SaveOwner(Owner owner)
        {
            return Save(owner, Owners, nameof(Owners));
        }

        public Telephone SaveTelephone(Telephone telephone)
        {
            return Save(telephone, Telephones, nameof(Telephones));
        }
        #endregion


        #region Implementation
        private static void Delete<TModel>(int id, ICollection<TModel> models, string nameofModelCollection)
            where TModel: IdModelBase
        {
            var model = Get(models, id);
            if (model == null) return;

            models.Remove(model);
            Save(models, nameofModelCollection);
        }

        private static TModel Get<TModel>(IEnumerable<TModel> models, int id) where TModel: IdModelBase
        {
            return models?.FirstOrDefault(m => m.Id.HasValue && m.Id.Value == id);
        }

        private static int GetNextId<TModel>(IEnumerable<TModel> models) where TModel: IdModelBase
        {
            var idModels = models.Where(m => m.Id.HasValue).ToArray();

            // ReSharper disable once PossibleInvalidOperationException
            return idModels.Any() ? idModels.Max(m => m.Id.Value) + 1 : 1;
        }

        // ReSharper disable once RedundantAssignment
        private static void Load<TModel>(ref IList<TModel> models, string nameOfModelCollection)
        {
            var loadResult = XmlDataAccess.Load<TModel[]>(RoomForRentXmlConfig.GetFilePath(nameOfModelCollection));
            models = loadResult?.ToList() ?? new List<TModel>();
        }

        private static TModel Save<TModel>(TModel model, ICollection<TModel> models, string nameOfModelCollection)
            where TModel: IdModelBase
        {
            var current = model.Id.HasValue ? Get(models, model.Id.Value) : null;

            // If not existing
            if (current == null)
            {
                model.Id = GetNextId(models);
                models.Add(model);
                Save(models, nameOfModelCollection);
                return model;
            }

            current.CopyFrom(model, false);
            Save(models, nameOfModelCollection);
            return current;
        }

        private static void Save<TModel>(IEnumerable<TModel> models, string nameOfModelCollection)
        {
            XmlDataAccess.Save(models.ToArray(), RoomForRentXmlConfig.GetFilePath(nameOfModelCollection));
        }

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        private static void SetRelationalProperties()
        {
            foreach (var owner in Owners.Where(o => o.Id.HasValue))
            {
                owner.Telephones = Telephones.Where(t =>
                {
                    if (t.OwnerId != owner.Id.Value) return false;

                    t.Owner = owner;
                    t.OwnerId = owner.Id.Value;
                    return true;
                }).ToArray();

                owner.Emails = Emails.Where(e =>
                {
                    if (e.OwnerId != owner.Id.Value) return false;

                    e.Owner = owner;
                    e.OwnerId = owner.Id.Value;
                    return true;
                }).ToArray();

                owner.Apartments = Apartments.Where(a =>
                {
                    if (a.OwnerId != owner.Id.Value) return false;

                    a.Owner = owner;
                    a.OwnerId = owner.Id.Value;
                    return true;
                }).ToArray();
            }

            foreach (var building in Buildings.Where(b => b.Id.HasValue))
            {
                building.Apartments = Apartments.Where(a =>
                {
                    if (a.BuildingId != building.Id.Value) return false;

                    a.Building = building;
                    a.BuildingId = building.Id.Value;
                    return true;
                }).ToArray();
            }
        }
        #endregion
    }
}