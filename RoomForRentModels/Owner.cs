using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Owner: ObservableObject
    {
        #region Fields
        [NonSerialized]
        private ICollection<Apartment> _apartments;

        [NonSerialized]
        private ICollection<Email> _emails;

        private int? _id;
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

        public int? Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
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
    }
}