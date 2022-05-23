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

        private OffersModel tempOffer;

        public OffersModel TempOffer
        {
            get { return tempOffer; }
            set { OnPropertyChanged(ref tempOffer, value); }
        }

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
                if (offer.deleted == 0 || offer.deleted == null)
                {
                    OffersModel tempOfferModel = new OffersModel();
                    tempOfferModel.Id = Convert.ToInt32(offer.id_offer);
                    tempOfferModel.Name = offer.name;
                    tempOfferModel.Description = offer.description;
                    tempOfferModel.Price = Convert.ToString(offer.price);
                    tempOfferModel.DateStart = Convert.ToString(offer.date_start);
                    tempOfferModel.DateEnd = Convert.ToString(offer.date_end);
                    tempOfferModel.RoomId = Convert.ToInt32(offer.room_id);
                    tempOffers.Add(tempOfferModel);
                }
            }

            return tempOffers;
        }
        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }
        public ICommand UpdateCommand { get; }

        public ICommand DeleteCommand { get; }
        public OffersViewModel()
        {
            Offers = LoadOffers();
            offersModel = new OffersModel();
            AddCommand = new RelayCommand(Add);
            UpdateCommand = new RelayCommand(Update);
            DeleteCommand = new RelayCommand(Delete);
            EditCommand = new RelayCommand(Edit);
        }

        private void Edit()
        {
            tempOffer = currentOffer;
            EditOffers editOffers = new EditOffers();
            editOffers.DataContext = this;
            editOffers.Show();
        }

        private void Delete()
        {
            tempOffer = currentOffer;
            HotelEntities hotelEntities = new HotelEntities();
            hotelEntities.sp_update_offer(tempOffer.RoomId, tempOffer.Id, tempOffer.Name, tempOffer.Description, Convert.ToDouble(tempOffer.Price),
                Convert.ToDateTime(tempOffer.DateStart), Convert.ToDateTime(tempOffer.DateEnd), 1);
            MessageBox.Show("Deleted Succesfully!");
        }

        private void Update()
        {
            HotelEntities hotelEntities = new HotelEntities();
            hotelEntities.sp_update_offer(tempOffer.RoomId, tempOffer.Id, tempOffer.Name, tempOffer.Description, Convert.ToDouble(tempOffer.Price),
                Convert.ToDateTime(tempOffer.DateStart), Convert.ToDateTime(tempOffer.DateEnd), 0);
            MessageBox.Show("Updated Succesfully!");
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
