using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class OffersViewModel : ObservableObject
    {
        public OffersModel offersModel { get; private set; }

        private OffersModel currentOffer;

        public OffersModel CurrentOffer
        {
            get { return currentOffer; }
            set { OnPropertyChanged(ref currentOffer, value); }
        }

        public ObservableCollection<OffersModel> Offers { get; set; }

        private ObservableCollection<OffersModel> LoadOffers()
        {
            var tempOffers = new ObservableCollection<OffersModel>();
            HotelEntities hotelEntities = new HotelEntities();
            List<Offer> listOffers = hotelEntities.Offers.ToList();
            foreach (var offer in listOffers)
            {
                OffersModel tempOfferModel = new OffersModel();
                tempOfferModel.Name = offer.name;
                tempOfferModel.Description = offer.description;
                tempOfferModel.Price = Convert.ToString(offer.price);
                tempOfferModel.DateStart = Convert.ToString(offer.date_start);
                tempOfferModel.DateEnd = Convert.ToString(offer.date_end);
                tempOffers.Add(tempOfferModel);
            }

            return tempOffers;
        }
        public ICommand AddCommand { get; }
        public OffersViewModel()
        {
            Offers = LoadOffers();
            offersModel = new OffersModel();
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
