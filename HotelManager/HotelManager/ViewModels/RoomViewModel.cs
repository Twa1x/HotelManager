using HotelManager.Models;
using Microsoft.Win32;
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
    public class RoomViewModel : ObservableObject
    {
        public RoomModel roomModel { get; private set; }

        private RoomModel tempRoom = new RoomModel();


        private FeatureModel currentFeature;

        public FeatureModel CurrentFeature
        {
            get { return currentFeature; }
            set { OnPropertyChanged(ref currentFeature, value); }

        }
        public RoomModel TempRoom

        {
            get { return tempRoom; }
            set { OnPropertyChanged(ref tempRoom, value); }
        }

        private RoomModel currentRoom;
        public RoomModel CurrentRoom
        {
            get { return currentRoom; }
            set { OnPropertyChanged(ref currentRoom, value); }
        }


        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand UpdateCommand { get; }

        public ICommand SelectFeatureCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SelectImage1Command { get; }
        public ICommand SelectImage2Command { get; }
        public ICommand SelectImage3Command { get; }

        public RoomViewModel()
        {
            Rooms = LoadRooms();
            Features = LoadFeatures();
            TempFeatures = new ObservableCollection<FeatureModel>();
            roomModel = new RoomModel();
            roomModel.Avilabilty = true;
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            UpdateCommand = new RelayCommand(Update);
            DeleteCommand = new RelayCommand(Delete);
            SelectFeatureCommand = new RelayCommand(AddFeature);
            SelectImage1Command = new RelayCommand(SelectImage1);
            SelectImage2Command = new RelayCommand(SelectImage2);
            SelectImage3Command = new RelayCommand(SelectImage3);

        }

        private void Delete()
        {
            tempRoom = currentRoom;
            HotelEntities hotelEntities = new HotelEntities();
            hotelEntities.sp_update_room(tempRoom.Id, tempRoom.Type, Convert.ToInt32(tempRoom.Avilabilty), tempRoom.AditionalServices, Convert.ToDouble(tempRoom.Price), tempRoom.Image1, tempRoom.Image2, tempRoom.Image3, 1);
            MessageBox.Show("Deleted Succesfully!");

        }

        private void Update()
        {

            HotelEntities hotelEntities = new HotelEntities();
            hotelEntities.sp_update_room(tempRoom.Id, tempRoom.Type, Convert.ToInt32(tempRoom.Avilabilty), tempRoom.AditionalServices, Convert.ToDouble(tempRoom.Price), tempRoom.Image1, tempRoom.Image2, tempRoom.Image3, 0);
            MessageBox.Show("Updated Succesfully!");
        }

        private void Edit()
        {
            tempRoom = currentRoom;

            EditRooms editRooms = new EditRooms();
            editRooms.DataContext = this;
            editRooms.Show();
        }

        public ObservableCollection<RoomModel> Rooms { get; set; }
        private ObservableCollection<RoomModel> LoadRooms()
        {
            ObservableCollection<RoomModel> tempRooms = new ObservableCollection<RoomModel>();
            HotelEntities hotelEntities = new HotelEntities();
            List<Room> listRooms = hotelEntities.Rooms.ToList();
            foreach (var item in listRooms)
            {
                if (item.deleted == 0 || item.deleted == null)
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

        public ObservableCollection<FeatureModel> Features { get; set; }
        private ObservableCollection<FeatureModel> LoadFeatures()
        {
            var tempFeatures = new ObservableCollection<FeatureModel>();
            HotelEntities hotelEntities = new HotelEntities();
            List<Feature> listFeatures = hotelEntities.Features.ToList();
            foreach (Feature _feature in listFeatures)
            {
                if (_feature.deleted == 0 || _feature.deleted == null)
                {
                    FeatureModel tempFeatureModel = new FeatureModel();
                    tempFeatureModel.Name = _feature.name;
                    tempFeatureModel.Price = Convert.ToString(_feature.price);
                    tempFeatureModel.Id = Convert.ToInt32(_feature.id_feature);
                    tempFeatures.Add(tempFeatureModel);
                }
            }

            return tempFeatures;
        }

        public ObservableCollection<FeatureModel> TempFeatures { get; set; }

        private void AddFeature()
        {
            TempFeatures.Add(currentFeature);
        }
        private void Add()
        {

            int roomId = 0;
            List<int> featuresId = new List<int>();
            HotelEntities hotelEntities = new HotelEntities();

            if (roomModel.Image1 == null || roomModel.Image2 == null || roomModel.Image3 == null)
            {
                MessageBox.Show("You need to choose atleast 1 photo!!");
            }
            else
            {


                hotelEntities.sp_insert_room(roomModel.Type, Convert.ToInt32(roomModel.Avilabilty),
                    "-", Convert.ToDouble(roomModel.Price), roomModel.Image1, roomModel.Image2, roomModel.Image3, 0);
                MessageBox.Show("Room added succesfully!!");
            }

            List<Room> roomsList = hotelEntities.Rooms.ToList();
            foreach (var room in roomsList)
            {
                if (room.type == roomModel.Type && room.image1 == roomModel.Image1 && room.image2 == roomModel.Image2 && room.image3 == roomModel.Image3
                    && room.price == Convert.ToDouble(roomModel.Price))
                {
                    roomId = Convert.ToInt32(room.id_room);
                }

            }
            Console.WriteLine(roomId);

            List<Feature> featuresList = hotelEntities.Features.ToList();
            for (int i = 0; i < TempFeatures.Count; i++)
            {
                foreach (Feature feature in featuresList)
                {

                    if (feature.name == TempFeatures.ElementAt(i).Name)
                    {
                        
                        featuresId.Add(feature.id_feature);
                    }
                }
            }
         
            foreach (var item in featuresId)
            {
               
                hotelEntities.sp_insert_feature_room(roomId, item, 0);
            }

        }


        private void SelectImage3()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                roomModel.Image3 = openFileDialog.FileName;
                tempRoom.Image3 = openFileDialog.FileName;
            }
        }

        private void SelectImage2()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                roomModel.Image2 = openFileDialog.FileName;
                tempRoom.Image2 = openFileDialog.FileName;
            }
        }


        private void SelectImage1()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                roomModel.Image1 = openFileDialog.FileName;
                tempRoom.Image1 = openFileDialog.FileName;
            }
        }

    }
}
