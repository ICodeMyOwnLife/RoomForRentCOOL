using System;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Telephone: ObservableObject
    {
        #region Fields
        private int? _id;
        private string _number;

        [NonSerialized]
        private Owner _owner;

        private int _ownerId;
        #endregion


        #region  Properties & Indexers
        public int? Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
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