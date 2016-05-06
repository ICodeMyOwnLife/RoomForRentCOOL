using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Province: IdNameEntityBase
    {
        #region Fields
        [NonSerialized]
        private ICollection<Building> _buildings;

        [NonSerialized]
        private ICollection<District> _districts;
        #endregion


        #region  Properties & Indexers
        [XmlIgnore]
        public virtual ICollection<Building> Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        [XmlIgnore]
        public virtual ICollection<District> Districts
        {
            get { return _districts; }
            set { SetProperty(ref _districts, value); }
        }
        #endregion


        #region Override
        public override void CopyFrom(IdEntityBase other, bool copyId = false)
        {
            var province = other as Province;
            if (province == null) return;

            Buildings = province.Buildings;
            Districts = province.Districts;
            base.CopyFrom(other, copyId);
        }
        #endregion
    }
}