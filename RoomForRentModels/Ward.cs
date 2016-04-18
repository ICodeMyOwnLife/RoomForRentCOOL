using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Ward: IdModelBase
    {
        #region Fields
        [NonSerialized]
        private ICollection<Building> _buildings;

        [NonSerialized]
        private District _district;

        private int _districtId;
        private string _name;
        #endregion


        #region  Properties & Indexers
        [XmlIgnore]
        public ICollection<Building> Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        [XmlIgnore]
        public District District
        {
            get { return _district; }
            set { SetProperty(ref _district, value); }
        }

        public int DistrictId
        {
            get { return _districtId; }
            set { SetProperty(ref _districtId, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        #endregion
    }
}