using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpModel SignUpModel { get; private set; }


        public ICommand SignUpCommand { get; }

        public SignUpViewModel()
        {
            SignUpModel = new SignUpModel();
            SignUpModel.IsUser = false;
            SignUpModel.IsAdmin = false;
            SignUpModel.IsEmployee = false; 
            SignUpCommand = new RelayCommand(SignUp);
          
        }

        private void SignUp()
        {
            Console.WriteLine(SignUpModel.Username);
            Console.WriteLine(SignUpModel.Password);
            Console.WriteLine(SignUpModel.Email);
            Console.WriteLine(SignUpModel.IsEmployee);
            Console.WriteLine(SignUpModel.IsAdmin);
            Console.WriteLine(SignUpModel.IsUser);
        }
      
    }
}
