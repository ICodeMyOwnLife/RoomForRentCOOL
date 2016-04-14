using System;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Apartment: IdModelBase
    {
        #region Fields
        private DateTime _availableFrom;
        private int _bedRoomCount;

        [NonSerialized]
        private Building _building;

        private int _buildingId;
        private string _code;
        private string _commission;
        private bool _hasFurniture;
        private string _note;

        [NonSerialized]
        private Owner _owner;

        private int _ownerId;
        private decimal _price;
        private DateTime _updatedOn = DateTime.Now;
        #endregion


        #region  Properties & Indexers
        public DateTime AvailableFrom
        {
            get { return _availableFrom; }
            set { if (SetProperty(ref _availableFrom, value)) SetUpdatedOn(); }
        }

        public int BedRoomCount
        {
            get { return _bedRoomCount; }
            set { if (SetProperty(ref _bedRoomCount, value)) SetUpdatedOn(); }
        }

        [XmlIgnore]
        public Building Building
        {
            get { return _building; }
            set { if (SetProperty(ref _building, value)) SetUpdatedOn(); }
        }

        public int BuildingId
        {
            get { return _buildingId; }
            set { if (SetProperty(ref _buildingId, value)) SetUpdatedOn(); }
        }

        public string Code
        {
            get { return _code; }
            set { if (SetProperty(ref _code, value)) SetUpdatedOn(); }
        }

        public string Commission
        {
            get { return _commission; }
            set { if (SetProperty(ref _commission, value)) SetUpdatedOn(); }
        }

        public bool HasFurniture
        {
            get { return _hasFurniture; }
            set { if (SetProperty(ref _hasFurniture, value)) SetUpdatedOn(); }
        }
        
        public string Note
        {
            get { return _note; }
            set { if (SetProperty(ref _note, value)) SetUpdatedOn(); }
        }

        [XmlIgnore]
        public Owner Owner
        {
            get { return _owner; }
            set { if (SetProperty(ref _owner, value)) SetUpdatedOn(); }
        }

        public int OwnerId
        {
            get { return _ownerId; }
            set { if (SetProperty(ref _ownerId, value)) SetUpdatedOn(); }
        }

        public decimal Price
        {
            get { return _price; }
            set { if (SetProperty(ref _price, value)) SetUpdatedOn(); }
        }

        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { SetProperty(ref _updatedOn, value); }
        }
        #endregion


        #region Methods
        public override void CopyFrom(IdModelBase obj, bool copyId)
        {
            var apartment = obj as Apartment;
            if(apartment==null) return;
            AvailableFrom = apartment.AvailableFrom;
            BedRoomCount = apartment.BedRoomCount;
            Building = apartment.Building;
            BuildingId = apartment.BuildingId;
            Code = apartment.Code;
            Commission = apartment.Commission;
            HasFurniture = apartment.HasFurniture;
            Note = apartment.Note;
            Owner = apartment.Owner;
            OwnerId = apartment.OwnerId;
            Price = apartment.Price;
            base.CopyFrom(obj, copyId);
        }
        #endregion


        #region Implementation
        private void SetUpdatedOn()
        {
            UpdatedOn = DateTime.Now;
        }
        #endregion
    }
}