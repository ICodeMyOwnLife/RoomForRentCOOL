using System;
using CB.Model.Common;


namespace RoomForRentModels
{
    public class Contract: ObservableObject
    {
        #region Fields
        private Client _client;
        private TimeSpan _duration;
        private int? _id;
        private Room _room;
        private DateTime _startDate;
        #endregion


        #region  Properties & Indexers
        public Client Client
        {
            get { return _client; }
            set { SetProperty(ref _client, value); }
        }

        public TimeSpan Duration
        {
            get { return _duration; }
            set { SetProperty(ref _duration, value); }
        }

        public int? Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public Room Room
        {
            get { return _room; }
            set { SetProperty(ref _room, value); }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }
        #endregion
    }
}