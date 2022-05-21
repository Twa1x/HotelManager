using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class ServicesModel : ObservableObject
    {
        private string _name;
        private string _price;

        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }   
        }

        public string Price
        {
            get { return _price; }  
            set { OnPropertyChanged(ref _price, value); }
        }

    }
}
