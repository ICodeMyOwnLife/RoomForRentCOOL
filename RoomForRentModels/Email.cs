using System;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Email: IdEntityBase
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
        public virtual Owner Owner
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
        public override void CopyFrom(IdEntityBase other, bool copyId = false)
        {
            var email = other as Email;
            if (email == null) return;

            Address = email.Address;
            Owner = email.Owner;
            OwnerId = email.OwnerId;
            base.CopyFrom(other, copyId);
        }
        #endregion
    }
}