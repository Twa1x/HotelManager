using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class ClientViewModel : ObservableObject
    {
        private GuestViewModel guestViewModel;

        public GuestViewModel GuestViewModel
        {
            get { return guestViewModel; }
            set { OnPropertyChanged(ref guestViewModel, value); }
        }

        public ICommand ViewOffersCommand { get; }
        public ICommand MakeReservationCommand { get; }
        public ClientViewModel()
        {
            guestViewModel = new GuestViewModel();
            ViewOffersCommand = new RelayCommand(ViewOffers);
            MakeReservationCommand =  new RelayCommand(MakeReservation);
        }

        private void ViewOffers()
        {
            OffersWindow offersWindow = new OffersWindow();
            offersWindow.Show();
        }

        private void MakeReservation()
        {
            MakeReservationWindow makeReservationWindow = new MakeReservationWindow();
            makeReservationWindow.Show();

        }
    }
};
