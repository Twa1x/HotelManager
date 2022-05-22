using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            HotelEntities hotelEntities = new HotelEntities();
            hotelEntities.sp_insert_offer(offersModel.Name, offersModel.Description, Convert.ToDouble(offersModel.Price),
                Convert.ToDateTime(offersModel.DateStart), Convert.ToDateTime(offersModel.DateEnd), offersModel.RoomId, 0);
            MessageBox.Show("Offer added succesfully!");
        }
    }
}
