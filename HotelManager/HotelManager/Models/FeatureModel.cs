using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class FeatureModel : ObservableObject
    {
        private string _name;
        private string _price;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { OnPropertyChanged(ref _id, value); }
        }

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
