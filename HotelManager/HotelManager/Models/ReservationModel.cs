using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class ReservationModel : ObservableObject
    {
        private long _id;
        private string _dateStart;
        private string _dateEnd;
        private string _status;
        private long _room_id;
        private long _client_id;
        private long _service_id;
        private double _price;
        private string _roomType;

        public long Id
        {
            get { return _id; }
            set { OnPropertyChanged(ref _id, value); }
        }

        public string RoomType
        {
            get { return _roomType; }
            set { OnPropertyChanged(ref _roomType, value); }
        }

        public string DateStart
        {
            get { return _dateStart; }
            set { OnPropertyChanged(ref _dateStart, value); }
        }

        public string DateEnd
        {
            get { return _dateEnd; }
            set { OnPropertyChanged(ref _dateEnd, value); }

        }

        public string Status
        {
            get { return _status; }
            set { OnPropertyChanged(ref _status, value); }

        }

        public long Room_id
        {
            get { return _room_id; }

            set { OnPropertyChanged(ref _room_id, value); }
        }

        public long Service_id
        {
            get {  return _service_id; }
            set { OnPropertyChanged(ref _service_id, value); }
        }

        public long Client_id
        {
            get { return _client_id; }
            set {  OnPropertyChanged(ref _client_id, value); }
        }

        public double Price
        {
            get { return _price; }
            set { OnPropertyChanged(ref _price, value); }
        }

    }
}
