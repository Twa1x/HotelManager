using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class LoginModel : ObservableObject
    {
        private string _username;
        private string _password;       

        public string Username
        {
            get { return _username; }
            set { OnPropertyChanged(ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set { OnPropertyChanged(ref _password, value); }
        }
    }
}
