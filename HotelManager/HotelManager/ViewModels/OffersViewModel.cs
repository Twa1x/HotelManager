using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class OffersViewModel
    {
        public OffersModel offersModel { get; private set; }
        public ICommand AddCommand { get; }
        public OffersViewModel()
        {
            offersModel  = new OffersModel();
            AddCommand = new RelayCommand(Add);
        }

        private void Add()
        {
            Console.WriteLine(offersModel.Name);
            Console.WriteLine(offersModel.Description);
            Console.WriteLine(offersModel.Price);
            Console.WriteLine(offersModel.DateStart);
            Console.WriteLine(offersModel.DateEnd);
            Console.WriteLine(offersModel.RoomId);
        }
    }
}
