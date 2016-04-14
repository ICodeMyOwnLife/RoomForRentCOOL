using System.Collections.Generic;
using System.Linq;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentXmlDataAccess
{
    public class RoomForRentXmlContext: IAppartmentDataAccessSync
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
        public static Telephone AddTelephone(Telephone telephone)
        {
            telephone.Id = Telephones.Max(t => t.Id.Value) + 1;
            Telephones.Add(telephone);
            SaveTelephones();
            return telephone;
        }

        public void DeleteApartment(int apartmentId)
        {
            var apartment = GetApartment(apartmentId);
            if (apartment != null)
            {
                Apartments.Remove(apartment);
                SaveApartments();
            }
        }

        public Apartment GetApartment(int id)
        {
            return Apartments?.FirstOrDefault(a => a.Id.HasValue && a.Id.Value == id);
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
            return Buildings?.FirstOrDefault(b => b.Id.HasValue && b.Id.Value == id);
        }

        public void Load()
        {
            if (!_isLoaded)
            {
                LoadTelephones();
                LoadEmails();
                LoadBuildings();
                LoadOwners();
                LoadApartments();
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

        public Telephone SaveTelephone(Telephone telephone)
        {
            return Save(telephone, Telephones, nameof(Telephones));
        }
        #endregion


        #region Implementation
        private static TModel Get<TModel>(ICollection<TModel> models, int id) where TModel: IdModelBase
        {
            return models?.FirstOrDefault(m => m.Id.HasValue && m.Id.Value == id);
        }

        private static int GetNextId<TModel>(IEnumerable<TModel> models) where TModel: IdModelBase
        {
            var idModels = models.Where(m => m.Id.HasValue).ToArray();

            // ReSharper disable once PossibleInvalidOperationException
            return idModels.Any() ? idModels.Max(m => m.Id.Value) + 1 : 1;
        }

        private static void LoadApartments()
        {
            LoadItems(ref _apartments, RoomForRentXmlConfig.GetFilePath(nameof(Apartments)));
        }

        private static void LoadBuildings()
        {
            LoadItems(ref _buildings, RoomForRentXmlConfig.GetFilePath(nameof(Buildings)));
        }

        private static void LoadEmails()
        {
            LoadItems(ref _emails, RoomForRentXmlConfig.GetFilePath(nameof(Emails)));
        }

        private static void LoadItems<TItem>(ref IList<TItem> items, string filePath)
        {
            items = XmlDataAccess.Load<TItem[]>(filePath);
        }

        private static void LoadOwners()
        {
            LoadItems(ref _owners, RoomForRentXmlConfig.GetFilePath(nameof(Owners)));
        }

        private static void LoadTelephones()
        {
            LoadItems(ref _telephones, RoomForRentXmlConfig.GetFilePath(nameof(Telephones)));
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

        private static void SaveApartments()
        {
            SaveItems(Apartments, RoomForRentXmlConfig.GetFilePath(nameof(Apartments)));
        }

        private static void SaveBuildings()
        {
            SaveItems(Buildings, RoomForRentXmlConfig.GetFilePath(nameof(Buildings)));
        }

        private static void SaveEmails()
        {
            SaveItems(Emails, RoomForRentXmlConfig.GetFilePath(nameof(Emails)));
        }

        private static void SaveItems<TItem>(IEnumerable<TItem> telephones, string filePath)
        {
            XmlDataAccess.Save(telephones.ToArray(), filePath);
        }

        private static void SaveOwners()
        {
            SaveItems(Owners, RoomForRentXmlConfig.GetFilePath(nameof(Owners)));
        }

        private static void SaveTelephones()
        {
            SaveItems(Telephones, RoomForRentXmlConfig.GetFilePath(nameof(Telephones)));
        }

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