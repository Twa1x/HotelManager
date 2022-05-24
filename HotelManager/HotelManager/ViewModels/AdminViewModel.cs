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
    public class AdminViewModel 
    {

        public ICommand EditRoomsCommand { get; }
        public ICommand AddRoomsCommand { get; }

        public ICommand EditOffersCommand { get; }
        public ICommand AddOffersCommand { get; }

        public ICommand EditServicesCommand { get; }
        public ICommand AddServicesCommand { get; }

        public ICommand EditFeaturesCommand { get; }
        public ICommand AddFeaturesCommand { get; }

      
     
        public AdminViewModel()
        {
            EditRoomsCommand = new RelayCommand(EditRooms);
            AddRoomsCommand = new RelayCommand(AddRooms);
          
            EditOffersCommand = new RelayCommand(EditOffers);
            AddOffersCommand = new RelayCommand(AddOffers);

            EditServicesCommand = new RelayCommand(EditServices);
            AddServicesCommand = new RelayCommand(AddServices);

            EditFeaturesCommand = new RelayCommand(EditFeatures);
            AddFeaturesCommand = new RelayCommand(AddFeatures);

        }

        private void AddFeatures()
        {
           AddFeaturesWindow addFeaturesWindow = new AddFeaturesWindow();
            addFeaturesWindow.Show();
        }

        private void EditFeatures()
        {
            EditFeaturesWindow editFeaturesWindow = new EditFeaturesWindow();
            editFeaturesWindow.Show();
        }

        private void AddServices()
        {
            AddServicesWindow addServicesWindow = new AddServicesWindow();
            addServicesWindow.Show();
        }

        private void EditServices()
        {
          EditServicesWindow editServicesWindow = new EditServicesWindow();
            editServicesWindow.Show();
        }

        private void AddOffers()
        {
            AddOffersWindow addOffersWindow = new AddOffersWindow();
            addOffersWindow.Show();
        }

        private void EditOffers()
        {
           EditOffersWindow editOffersWindow = new EditOffersWindow();
            editOffersWindow.Show();
        }

        private void AddRooms()
        {
           AddRoomWindow addRoomWindow = new AddRoomWindow();
            addRoomWindow.Show();
        }

        private void EditRooms()
        {
            EditRoomsWindow editRoomsWindow = new EditRoomsWindow();
            editRoomsWindow.Show();
        }
    }
}
