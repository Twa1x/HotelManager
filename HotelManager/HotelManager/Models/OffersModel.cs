using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class OffersModel : ObservableObject
    {
        private int _id;
        private string _name;
        private string _description;
        private string _price;
        private string _dateStart;
        private string _dateEnd;
        private int _roomId;
        private string _roomType;


        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }

        public string RoomType
        {
            get { return _roomType; }
            set { OnPropertyChanged(ref _roomType, value); }
        }
        public int Id
        {
            get { return _id; }
            set { OnPropertyChanged(ref _id, value); }
        }

        public string Description
        {
            get { return _description; }
            set { OnPropertyChanged(ref _description, value); }
        }

        public string Price
        {
            get { return _price; }
            set { OnPropertyChanged(ref _price, value); }
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

        public int RoomId
        {
            get { return _roomId; }
            set { OnPropertyChanged(ref _roomId, value); }
        }


    }
}
