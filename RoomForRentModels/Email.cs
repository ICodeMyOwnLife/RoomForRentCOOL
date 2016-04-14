using System;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Email: ObservableObject
    {
        #region Fields
        private string _address;
        private int? _id;

        [NonSerialized]
        private Owner _owner;

        private int _ownerId;
        #endregion


        #region  Properties & Indexers
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        public int? Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
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
        #endregion
    }
}