using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class District: IdModelBase
    {
        #region Fields
        private string _name;

        [NonSerialized]
        private Province _province;

        private int _provinceId;

        [NonSerialized]
        private ICollection<Ward> _wards;
        #endregion


        #region  Properties & Indexers
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [XmlIgnore]
        public Province Province
        {
            get { return _province; }
            set { SetProperty(ref _province, value); }
        }
        [NonSerialized]
        private ICollection<Building> _buildings;
        [XmlIgnore]
        public ICollection<Building> Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        

        public int ProvinceId
        {
            get { return _provinceId; }
            set { SetProperty(ref _provinceId, value); }
        }

        [XmlIgnore]
        public ICollection<Ward> Wards
        {
            get { return _wards; }
            set { SetProperty(ref _wards, value); }
        }
        #endregion
    }
}