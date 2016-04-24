using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class District: IdNameModelBase
    {
        #region Fields
        [NonSerialized]
        private ICollection<Building> _buildings;

        [NonSerialized]
        private Province _province;

        private int _provinceId;

        [NonSerialized]
        private ICollection<Ward> _wards;
        #endregion


        #region  Properties & Indexers
        [XmlIgnore]
        public ICollection<Building> Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        [XmlIgnore]
        public Province Province
        {
            get { return _province; }
            set { SetProperty(ref _province, value); }
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