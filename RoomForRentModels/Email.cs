using System;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Email: IdModelBase
    {
        #region Fields
        private string _address;

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


        #region Override
        public override void CopyFrom(IdModelBase obj, bool copyId)
        {
            var email = obj as Email;
            if (email == null) return;
            Address = email.Address;
            Owner = email.Owner;
            OwnerId = email.OwnerId;
            base.CopyFrom(obj, copyId);
        }
        #endregion
    }
}