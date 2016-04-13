using CB.Model.Common;


namespace RoomForRentModels
{
    public class Room: ObservableObject
    {
        #region Fields
        private string _address;
        private string _district;
        private int? _id;
        private decimal _price;
        private string _province;
        private int _roomCount;
        private int? _roomNumber;
        private string _ward;
        #endregion


        #region  Properties & Indexers
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
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

        public decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        public string Province
        {
            get { return _province; }
            set { SetProperty(ref _province, value); }
        }

        public int RoomCount
        {
            get { return _roomCount; }
            set { SetProperty(ref _roomCount, value); }
        }

        public int? RoomNumber
        {
            get { return _roomNumber; }
            set { SetProperty(ref _roomNumber, value); }
        }

        public string Ward
        {
            get { return _ward; }
            set { SetProperty(ref _ward, value); }
        }
        #endregion
    }
}