using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class District: IdNameEntityBase
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
        public virtual ICollection<Building> Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        [XmlIgnore]
        public virtual Province Province
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
        public virtual ICollection<Ward> Wards
        {
            get { return _wards; }
            set { SetProperty(ref _wards, value); }
        }
        #endregion


        #region Override
        public override void CopyFrom(IdEntityBase other, bool copyId = false)
        {
            var district = other as District;
            if (district == null) return;

            Buildings = district.Buildings;
            Province = district.Province;
            ProvinceId = district.ProvinceId;
            Wards = district.Wards;
            base.CopyFrom(other, copyId);
        }
        #endregion
    }
}