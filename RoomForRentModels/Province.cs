﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CB.Model.Common;


namespace RoomForRentModels
{
    [Serializable]
    public class Province: IdNameModelBase
    {
        #region Fields
        [NonSerialized]
        private ICollection<Building> _buildings;

        [NonSerialized]
        private ICollection<District> _districts;
        #endregion


        #region  Properties & Indexers
        [XmlIgnore]
        public ICollection<Building> Buildings
        {
            get { return _buildings; }
            set { SetProperty(ref _buildings, value); }
        }

        [XmlIgnore]
        public ICollection<District> Districts
        {
            get { return _districts; }
            set { SetProperty(ref _districts, value); }
        }
        #endregion
    }
}