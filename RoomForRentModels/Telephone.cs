using System;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Telephone: IdModelBase
    {
        #region Fields
        private string _number;

        [NonSerialized]
        private Owner _owner;

        private int _ownerId;
        #endregion


        #region  Properties & Indexers
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


        #region Override
        public override void CopyFrom(IdModelBase obj, bool copyId)
        {
            var telephone = obj as Telephone;
            if (telephone == null) return;
            Number = telephone.Number;
            Owner = telephone.Owner;
            OwnerId = telephone.OwnerId;
            base.CopyFrom(obj, copyId);
        }
        #endregion
    }
}