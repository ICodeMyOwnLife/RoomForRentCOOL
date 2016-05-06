using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Ward: IdNameEntityBase
    {
        #region Fields
        [NonSerialized]
        private ICollection<Building> _buildings;

        [NonSerialized]
        private District _district;

        private int _districtId;
        #endregion


        #region  Properties & Indexers
        [XmlIgnore]
        public virtual ICollection<Building> Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        [XmlIgnore]
        public virtual District District
        {
            get { return _district; }
            set { SetProperty(ref _district, value); }
        }

        public int DistrictId
        {
            get { return _districtId; }
            set { SetProperty(ref _districtId, value); }
        }
        #endregion


        #region Override
        public override void CopyFrom(IdEntityBase other, bool copyId = false)
        {
            var ward = other as Ward;
            if (ward == null) return;

            Buildings = ward.Buildings;
            District = ward.District;
            DistrictId = ward.DistrictId;
            base.CopyFrom(other, copyId);
        }
        #endregion
    }
}