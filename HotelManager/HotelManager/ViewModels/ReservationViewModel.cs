using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class ReservationViewModel : ObservableObject
    {
        private ReservationModel currentReservation;

        private HotelEntities hotelEntities = new HotelEntities();
        public ReservationModel CurrentReservation
        {
            get { return currentReservation; }
            set { OnPropertyChanged(ref currentReservation, value); }
        }

        public ObservableCollection<ReservationModel> Reservations { get; set; }

        public ICommand ActiveCommand { get; }
        public ICommand PaidCommand { get; }
        public ICommand CanceledCommand { get; }
        public ReservationViewModel()
        {
            Reservations = LoadReservations();

            ActiveCommand = new RelayCommand(Active);
            PaidCommand = new RelayCommand(Paid);
            CanceledCommand = new RelayCommand(Cancel);
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
