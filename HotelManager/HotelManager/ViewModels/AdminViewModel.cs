using System;
using System.Collections.Generic;
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

        public AdminViewModel()
        {
            EditRoomsCommand = new RelayCommand(EditRooms);
            AddRoomsCommand = new RelayCommand(AddRooms);

            EditOffersCommand = new RelayCommand(EditOffers);
            AddOffersCommand = new RelayCommand(AddOffers);

            EditServicesCommand = new RelayCommand(EditServices);
            AddServicesCommand = new RelayCommand(AddServices);


        }

        private void AddServices()
        {
            AddServicesWindow addServicesWindow = new AddServicesWindow();
            addServicesWindow.Show();
        }

        private void EditServices()
        {
            throw new NotImplementedException();
        }

        private void AddOffers()
        {
            AddOffersWindow addOffersWindow = new AddOffersWindow();
            addOffersWindow.Show();
        }

        private void EditOffers()
        {
            throw new NotImplementedException();
        }

        private void AddRooms()
        {
           AddRoomWindow addRoomWindow = new AddRoomWindow();
            addRoomWindow.Show();
        }

        private void EditRooms()
        {
            throw new NotImplementedException();
        }
    }
}
