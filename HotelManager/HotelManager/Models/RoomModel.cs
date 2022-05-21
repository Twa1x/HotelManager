using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class RoomModel : ObservableObject
    {
        private int _id;
        private string _type;
        private bool _availabilty;
        private string _aditionalServices;
        private string _price;
        private string _image1;
        private string _image2;
        private string _image3;

        public int Id
        {
            get { return _id; }
            set { OnPropertyChanged(ref _id, value); }
        }


        public string Type
        {
            get { return _type; }
            set { OnPropertyChanged(ref _type, value); }
        }
        public bool Avilabilty
        {
            get { return _availabilty; }
            set { OnPropertyChanged(ref _availabilty, value); }

        }

        public string AditionalServices
        {
            get { return _aditionalServices; }
            set { OnPropertyChanged(ref _aditionalServices, value); }
        }

        public string Price
        {
            get { return _price; }
            set { OnPropertyChanged(ref _price, value); }
        }
        
        public string Image1
        {
            get { return _image1; }
            set { OnPropertyChanged(ref _image1, value); }

        }

        public string Image2
        {
            get { return _image2; }
            set { OnPropertyChanged(ref _image2, value); }
        }

        public string Image3
        {
            get { return _image3; }
            set { OnPropertyChanged(ref _image3, value); }
        }
    }
}
