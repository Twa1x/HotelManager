using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class EmployeeViewModel : ObservableObject
    {
       private GuestViewModel guestViewModel;

        public GuestViewModel GuestViewModel
        {
            get { return guestViewModel; }
            set { OnPropertyChanged(ref guestViewModel, value); }
        }

        public ICommand ReservationsCommand { get; }
        public EmployeeViewModel()
        {
            guestViewModel = new GuestViewModel();
            ReservationsCommand = new RelayCommand(ReservationsOpen);
        }

        private void ReservationsOpen()
        {
           ReservationsWindow reservationsWindow = new ReservationsWindow();
            reservationsWindow.Show();
        }
    }
}
