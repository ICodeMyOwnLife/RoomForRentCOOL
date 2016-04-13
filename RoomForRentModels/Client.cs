using CB.Model.Common;


namespace RoomForRentModels
{
    public class Client: ObservableObject
    {
        #region Fields
        private int? _id;
        private string _identification;
        private string _name;
        private string _nationality;
        #endregion


        #region  Properties & Indexers
        public int? Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string Identification
        {
            get { return _identification; }
            set { SetProperty(ref _identification, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Nationality
        {
            get { return _nationality; }
            set { SetProperty(ref _nationality, value); }
        }
        #endregion
    }
}