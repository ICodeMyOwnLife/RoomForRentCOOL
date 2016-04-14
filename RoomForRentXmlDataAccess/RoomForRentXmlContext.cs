using System.Collections.Generic;
using System.Linq;
using RoomForRentModels;


namespace RoomForRentXmlDataAccess
{
    public static class RoomForRentXmlContext
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
        public static void Load()
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

        public static void Save()
        {
            SaveTelephones();
            SaveEmails();
            SaveBuildings();
            SaveOwners();
            SaveApartments();
        }

        public static void SaveApartments()
        {
            SaveItems(Apartments, RoomForRentXmlConfig.GetFilePath(nameof(Apartments)));
        }

        public static void SaveBuildings()
        {
            SaveItems(Buildings, RoomForRentXmlConfig.GetFilePath(nameof(Buildings)));
        }

        public static void SaveEmails()
        {
            SaveItems(Emails, RoomForRentXmlConfig.GetFilePath(nameof(Emails)));
        }

        public static void SaveOwners()
        {
            SaveItems(Owners, RoomForRentXmlConfig.GetFilePath(nameof(Owners)));
        }

        public static void SaveTelephones()
        {
            SaveItems(Telephones, RoomForRentXmlConfig.GetFilePath(nameof(Telephones)));
        }
        #endregion


        #region Implementation
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

        private static void SaveItems<TItem>(IEnumerable<TItem> telephones, string filePath)
        {
            XmlDataAccess.Save(telephones.ToArray(), filePath);
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