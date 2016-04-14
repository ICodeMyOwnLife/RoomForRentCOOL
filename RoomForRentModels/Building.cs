using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Building: ObservableObject
    {
        #region Fields
        [NonSerialized]
        private ICollection<Apartment> _apartments;

        private string _district;
        private int? _id;
        private string _name;
        private int _number;
        private string _province;
        private string _street;
        private string _ward;
        #endregion


        #region  Properties & Indexers
        [XmlIgnore]
        public ICollection<Apartment> Apartments
        {
            get { return _apartments; }
            set { SetProperty(ref _apartments, value); }
        }

        public string District
        {
            get { return _district; }
            set { SetProperty(ref _district, value); }
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

        public int Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }

        public string Province
        {
            get { return _province; }
            set { SetProperty(ref _province, value); }
        }

        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }

        public string Ward
        {
            get { return _ward; }
            set { SetProperty(ref _ward, value); }
        }
        #endregion
    }
}