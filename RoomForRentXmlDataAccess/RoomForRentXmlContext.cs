using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using CB.Model.Common;
using RoomForRentModels;


namespace RoomForRentXmlDataAccess
{
    public class RoomForRentXmlContext: IApartmentDataAccessSync, IBuildingDataAccessSync, IOwnerDataAccessSync
    {
        #region Fields
        private static IList<Apartment> _apartments;
        private static IList<Building> _buildings;
        private static IList<Email> _emails;
        private static IList<ModelId> _ids;
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

        private static IList<ModelId> Ids
        {
            get { return _ids; }
            set { _ids = value; }
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
            Delete(apartmentId, Apartments, nameof(Apartments), null);
        }

        public void DeleteBuilding(int buildingId)
        {
            if (!Delete(buildingId, Buildings, nameof(Buildings), null, building => building.Apartments))
                MessageBox.Show("Cannot delete this building.");
        }

        public void DeleteOwner(int ownerId)
        {
            if (!Delete(ownerId, Owners, nameof(Owners), null, owner => owner.Apartments))
                MessageBox.Show("Cannot delete this owner.");
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
                Load(ref _ids, nameof(Ids));
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
            Save(Ids, nameof(Ids));
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
        /*private static void Delete<TModel>(int id, ICollection<TModel> models, string nameOfModelCollection)
            where TModel: IdEntityBase
        {
            var model = Get(models, id);
            if (model == null) return;

            models.Remove(model);
            Save(models, nameOfModelCollection);
        }*/

        /*private static void Delete<TModel>(int id, ICollection<TModel> models, string nameOfModelCollection,
            Func<TModel, bool> deleteCascadedAction = null)
            where TModel: IdEntityBase
        {
            var model = Get(models, id);
            if (model == null || deleteCascadedAction?.Invoke(model) != true) return;
            models.Remove(model);
            Save(models, nameOfModelCollection);
        }*/

        private static bool Delete<TModel>(int id, ICollection<TModel> models, string nameOfModelCollection,
            Action<TModel> success = null,
            params Func<TModel, IEnumerable>[] dependenceCollections)
            where TModel: IdEntityBase
        {
            var model = Get(models, id);
            if (model == null ||
                dependenceCollections.Any(dependenceCollection => dependenceCollection(model).Cast<object>().Any()))
            {
                return false;
            }
            models.Remove(model);
            Save(models, nameOfModelCollection);
            success?.Invoke(model);
            return true;
        }

        private static void Delete<TModel>(IEnumerable<TModel> deletedModels, ICollection<TModel> models,
            string nameOfModelCollection)
        {
            foreach (var model in deletedModels)
            {
                models.Remove(model);
            }
            Save(models, nameOfModelCollection);
        }

        private static TModel Get<TModel>(IEnumerable<TModel> models, int id) where TModel: IdEntityBase
        {
            return models?.FirstOrDefault(m => m.Id == id);
        }

        private static int GetNextId(string modelName)
        {
            /*var idModels = models.Where(m => m.Id.HasValue).ToArray();

            // ReSharper disable once PossibleInvalidOperationException
            return idModels.Any() ? idModels.Max(m => m.Id) + 1 : 1;*/

            var modelId = Ids?.FirstOrDefault(mi => mi.ModelName == modelName);
            int id;
            if (modelId == null)
            {
                id = 1;
                modelId = new ModelId { ModelName = modelName, Id = 1 };
                Ids?.Add(modelId);
            }
            else
            {
                id = modelId.Id;
            }
            modelId.Id += 1;
            Save(Ids, nameof(Ids));
            return id;
        }

        // ReSharper disable once RedundantAssignment
        private static void Load<TModel>(ref IList<TModel> models, string nameOfModelCollection)
        {
            var loadResult = XmlDataAccess.Load<TModel[]>(RoomForRentXmlConfig.GetFilePath(nameOfModelCollection));
            models = loadResult?.ToList() ?? new List<TModel>();
        }

        private static TModel Save<TModel>(TModel model, ICollection<TModel> models, string nameOfModelCollection)
            where TModel: IdEntityBase
        {
            var current = Get(models, model.Id);

            // If not existing
            if (current == null)
            {
                model.Id = GetNextId(nameOfModelCollection);
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
            SetRelationalProperties();
        }

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        private static void SetRelationalProperties()
        {
            foreach (var owner in Owners)
            {
                owner.Apartments = Apartments.Where(a =>
                {
                    if (a.OwnerId != owner.Id) return false;

                    a.Owner = owner;
                    a.OwnerId = owner.Id;
                    return true;
                }).ToArray();
            }

            foreach (var building in Buildings)
            {
                building.Apartments = Apartments.Where(a =>
                {
                    if (a.BuildingId != building.Id) return false;

                    a.Building = building;
                    a.BuildingId = building.Id;
                    return true;
                }).ToArray();
            }
        }
        #endregion
    }
}