using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public  class LoginViewModel
    {
        public LoginModel _Login { get; private set; }

        public ICommand LoginCommand { get; }
        public LoginViewModel()
        {
            _Login = new LoginModel();
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            Console.WriteLine(_Login.Username);
            Console.WriteLine(_Login.Password);
        }
    }
}
