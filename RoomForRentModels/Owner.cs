using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Owner: IdNameModelBase
    {
        #region Fields
        [NonSerialized]
        private ICollection<Apartment> _apartments;

        private string _emails;
        private string _telephones;
        #endregion


        #region  Properties & Indexers
        [XmlIgnore]
        public ICollection<Apartment> Apartments
        {
            get { return _apartments; }
            set { SetProperty(ref _apartments, value); }
        }

        public string Emails
        {
            get { return _emails; }
            set { SetProperty(ref _emails, value); }
        }

        public string Telephones
        {
            get { return _telephones; }
            set { SetProperty(ref _telephones, value); }
        }
        #endregion


        #region Override
        public override void CopyFrom(IdModelBase obj, bool copyId)
        {
            var owner = obj as Owner;
            if (owner == null) return;
            Apartments = owner.Apartments;
            Emails = owner.Emails;
            Name = owner.Name;
            Telephones = owner.Telephones;
            base.CopyFrom(obj, copyId);
        }
        #endregion
    }
}