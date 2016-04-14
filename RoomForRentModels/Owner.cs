using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Owner: IdModelBase
    {
        #region Fields
        [NonSerialized]
        private ICollection<Apartment> _apartments;

        [NonSerialized]
        private ICollection<Email> _emails;

        private string _name;

        [NonSerialized]
        private ICollection<Telephone> _telephones;
        #endregion


        #region  Properties & Indexers
        [XmlIgnore]
        public ICollection<Apartment> Apartments
        {
            get { return _apartments; }
            set { SetProperty(ref _apartments, value); }
        }

        [XmlIgnore]
        public ICollection<Email> Emails
        {
            get { return _emails; }
            set { SetProperty(ref _emails, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [XmlIgnore]
        public ICollection<Telephone> Telephones
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