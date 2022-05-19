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
        private bool isAdmin;
        private bool isEmployee;
        private bool isUser;

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

        public bool IsAdmin
        {
            get { return isAdmin; }
            set { OnPropertyChanged(ref isAdmin, value); }
        }

        public bool IsEmployee
        {
            get { return isEmployee; }
            set { OnPropertyChanged(ref isEmployee, value); }
        }

        public bool IsUser
        {
            get { return isUser; }
            set { OnPropertyChanged(ref isUser, value); }

        }
    }
}
