using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpModel signUpModel { get; private set; }

        SignUpViewModel()
        {
            signUpModel = new SignUpModel();
        }
    }
}
