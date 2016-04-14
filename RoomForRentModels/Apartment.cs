using System;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Apartment: ObservableObject
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
        private int? _id;
        private string _note;

        [NonSerialized]
        private Owner _owner;

        private int _ownerId;
        private decimal _price;
        private DateTime _updatedOn;
        #endregion


        #region  Properties & Indexers
        public DateTime AvailableFrom
        {
            get { return _availableFrom; }
            set { SetProperty(ref _availableFrom, value); }
        }

        public int BedRoomCount
        {
            get { return _bedRoomCount; }
            set { SetProperty(ref _bedRoomCount, value); }
        }

        [XmlIgnore]
        public Building Building
        {
            get { return _building; }
            set { SetProperty(ref _building, value); }
        }

        public int BuildingId
        {
            get { return _buildingId; }
            set { SetProperty(ref _buildingId, value); }
        }

        public string Code
        {
            get { return _code; }
            set { SetProperty(ref _code, value); }
        }

        public string Commission
        {
            get { return _commission; }
            set { SetProperty(ref _commission, value); }
        }

        public bool HasFurniture
        {
            get { return _hasFurniture; }
            set { SetProperty(ref _hasFurniture, value); }
        }

        public int? Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string Note
        {
            get { return _note; }
            set { SetProperty(ref _note, value); }
        }

        [XmlIgnore]
        public Owner Owner
        {
            get { return _owner; }
            set { SetProperty(ref _owner, value); }
        }

        public int OwnerId
        {
            get { return _ownerId; }
            set { SetProperty(ref _ownerId, value); }
        }

        public decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { SetProperty(ref _updatedOn, value); }
        }
        #endregion
    }
}