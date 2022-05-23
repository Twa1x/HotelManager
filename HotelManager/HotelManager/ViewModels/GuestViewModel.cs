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
    public class GuestViewModel : ObservableObject
    {
        private int count;


        private RoomModel currentRoomGuest;
        public RoomModel CurrentRoomGuest
        {
            get { return currentRoomGuest; }
            set { OnPropertyChanged(ref currentRoomGuest, value); }
        }

        public ObservableCollection<RoomModel> RoomsGuest { get; set; }
        public ICommand CheckRoomsCommand { get; }
        public ICommand DetailRoomCommand { get; }
        public GuestViewModel()
        {
            RoomsGuest = LoadRooms();
            CheckRoomsCommand = new RelayCommand(CheckRooms);
            DetailRoomCommand = new RelayCommand(DetailRoom);
        }

        private void DetailRoom()
        { 

            DetailsRoomWindow detailsRoomWindow = new DetailsRoomWindow();
            detailsRoomWindow.DataContext = this;
            detailsRoomWindow.ShowDialog();
        }

        private void CheckRooms()
        {
            count = 0;
            HotelEntities hotelEntities = new HotelEntities();
            List<Room> rooms = hotelEntities.Rooms.ToList();
            foreach (Room room in rooms)
            {
                if (room.availabilty != 0 && (room.deleted == 0 || room.deleted == null) )
                    count++;
            }

            MessageBox.Show($"Numbers of room available: {count}");

        }

        private ObservableCollection<RoomModel> LoadRooms()
        {
            ObservableCollection<RoomModel> tempRooms = new ObservableCollection<RoomModel>();
            HotelEntities hotelEntities = new HotelEntities();
            List<Room> listRooms = hotelEntities.Rooms.ToList();
            foreach (var item in listRooms)
            {
                if (item.availabilty > 0 && (item.deleted == 0 || item.deleted == null))
                {
                    RoomModel tempRoomModel = new RoomModel();
                    tempRoomModel.Type = item.type;
                    tempRoomModel.Avilabilty = Convert.ToBoolean(item.availabilty);
                    tempRoomModel.AditionalServices = item.aditional_services;
                    tempRoomModel.Price = Convert.ToString(item.price);
                    tempRoomModel.Image1 = item.image1;
                    tempRoomModel.Image2 = item.image2;
                    tempRoomModel.Image3 = item.image3;
                    tempRoomModel.Id = Convert.ToInt32(item.id_room);
                    tempRooms.Add(tempRoomModel);
                }
            }
            return tempRooms;
        }
    }
}
