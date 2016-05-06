using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Building: IdNameEntityBase
    {
        #region Fields
        [NonSerialized]
        private ICollection<Apartment> _apartments = new List<Apartment>();

        [NonSerialized]
        private District _district;

        private int? _districtId;
        private string _number = "123";

        [NonSerialized]
        private Province _province;

        private int? _provinceId;
        private string _street = "My Street";

        [NonSerialized]
        private Ward _ward;

        private int? _wardId;
        #endregion


        #region  Properties & Indexers
        [XmlIgnore]
        public virtual ICollection<Apartment> Apartments
        {
            get { return _apartments; }
            set { SetProperty(ref _apartments, value); }
        }

        [XmlIgnore]
        public virtual District District
        {
            get { return _district; }
            set { SetProperty(ref _district, value); }
        }

        public int? DistrictId
        {
            get { return _districtId; }
            set { SetProperty(ref _districtId, value); }
        }
        
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }

        [XmlIgnore]
        public virtual Province Province
        {
            get { return _province; }
            set { SetProperty(ref _province, value); }
        }

        public int? ProvinceId
        {
            get { return _provinceId; }
            set { SetProperty(ref _provinceId, value); }
        }

        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }

        [XmlIgnore]
        public virtual Ward Ward
        {
            get { return _ward; }
            set { SetProperty(ref _ward, value); }
        }

        public int? WardId
        {
            get { return _wardId; }
            set { SetProperty(ref _wardId, value); }
        }
        #endregion


        #region Override
        public override void CopyFrom(IdEntityBase other, bool copyId = false)
        {
            var building = other as Building;
            if (building == null) return;

            Apartments = building.Apartments;
            District = building.District;
            Name = building.Name;
            Number = building.Number;
            Province = building.Province;
            Street = building.Street;
            Ward = building.Ward;
            base.CopyFrom(other, copyId);
        }
        #endregion
    }
}