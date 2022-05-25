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
    public class ReservationViewModel : ObservableObject
    {
        private ReservationModel currentReservation;

        private ReservationModel reservationModel;
        
        private HotelEntities hotelEntities = new HotelEntities();
        public ReservationModel CurrentReservation
        {
            get { return currentReservation; }
            set { OnPropertyChanged(ref currentReservation, value); }
        }

        public ReservationModel ReservationModel
        {
            get { return reservationModel; }
            set { OnPropertyChanged(ref reservationModel, value); }
        }
        public ObservableCollection<ReservationModel> Reservations { get; set; }

        public ICommand ActiveCommand { get; }
        public ICommand PaidCommand { get; }
        public ICommand CanceledCommand { get; }
        public ICommand BookCommand { get; }

        public ReservationViewModel()
        {
            Reservations = LoadReservations();
            ReservationModel = new ReservationModel();
            ActiveCommand = new RelayCommand(Active);
            PaidCommand = new RelayCommand(Paid);
            CanceledCommand = new RelayCommand(Cancel);
              BookCommand = new RelayCommand(Book);
        }

        private void Cancel()
        {
            
            hotelEntities.sp_update_reservations(currentReservation.Id, "canceled");
        }

        private void Paid()
        {
           
            hotelEntities.sp_update_reservations(currentReservation.Id, "paid");
        }

        private void Active()
        {
           
            hotelEntities.sp_update_reservations(currentReservation.Id, "active");
        }

        private void Book()
        {
            int count = 0;

            HotelEntities hotelEntities = new HotelEntities();
            List<Reservation> reservationList = hotelEntities.Reservations.ToList();
            List<Room> roomsList = hotelEntities.Rooms.ToList();

            List<int> roomsIds = new List<int>();
            foreach (var item in reservationList)
            {

                if (((Convert.ToDateTime(item.date_start) <= Convert.ToDateTime(ReservationModel.DateStart)) && Convert.ToDateTime(item.date_end) >= Convert.ToDateTime(ReservationModel.DateEnd))
                    || (Convert.ToDateTime(item.date_start) <= Convert.ToDateTime(ReservationModel.DateStart)) && Convert.ToDateTime(item.date_end) >= Convert.ToDateTime(ReservationModel.DateEnd)
                    || ((Convert.ToDateTime(item.date_start) >= Convert.ToDateTime(ReservationModel.DateStart)) && Convert.ToDateTime(item.date_end) >= Convert.ToDateTime(ReservationModel.DateEnd)) && Convert.ToDateTime(item.date_start) <= Convert.ToDateTime(reservationModel.DateEnd)
                    || ((Convert.ToDateTime(item.date_start) >= Convert.ToDateTime(ReservationModel.DateStart)) && Convert.ToDateTime(item.date_end) <= Convert.ToDateTime(ReservationModel.DateEnd)))
                {
                    Console.WriteLine("nu");
                    roomsIds.Add(Convert.ToInt32(item.id_room));

                }
                else
                {
                    count++;
                }
            }

            if (count != 0)
            {

                foreach (var item in roomsList)
                {
                    bool ok = false;

                    foreach (var tempRoom in roomsIds)
                    {
                        if (item.id_room == tempRoom)
                        {
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        if (item.deleted == 0 || item.deleted == null || item.availabilty == 1 && item.type == reservationModel.RoomType)
                        {

                            int numberOfDays = Convert.ToInt32(((Convert.ToDateTime(ReservationModel.DateEnd) - Convert.ToDateTime(ReservationModel.DateStart))).TotalDays);
                            double price = item.price * numberOfDays;

                            hotelEntities.sp_insert_reservation(Convert.ToDateTime(ReservationModel.DateStart), Convert.ToDateTime(ReservationModel.DateEnd), "active", item.id_room, 5, null, price, 0);
                            MessageBox.Show("Booked!");
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No rooms available!");
            }

        }

        private ObservableCollection<ReservationModel> LoadReservations()
        {
            var tempReservations = new ObservableCollection<ReservationModel>();
           
            List<Reservation> listReservations = hotelEntities.Reservations.ToList();
            List<Room> listRooms = hotelEntities.Rooms.ToList();

            foreach (Reservation reservation in listReservations)
            {
                if (reservation.deleted == 0 || reservation.deleted == null)
                {
                    ReservationModel reservationModel = new ReservationModel();
                    reservationModel.Id = reservation.id_reservation;
                    reservationModel.DateStart = Convert.ToString(reservation.date_start);
                    reservationModel.DateEnd = Convert.ToString(reservation.date_end);
                    reservationModel.Status = reservation.status;
                    reservationModel.Client_id = reservation.id_client;
                    reservationModel.Service_id = Convert.ToInt32(reservation.id_service);
                    reservationModel.Room_id = reservation.id_room;
                    reservationModel.Price = reservation.price;
                    foreach (var item in listRooms)
                    {
                        if (item.id_room == reservationModel.Room_id)
                        {
                            reservationModel.RoomType = item.type;
                            break;

                        }
                    }
                    tempReservations.Add(reservationModel);
                }
            }



            return tempReservations;
        }
    }
}
