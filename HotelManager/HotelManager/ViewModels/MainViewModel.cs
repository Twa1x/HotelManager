﻿
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class MainViewModel
    {
       
        public ICommand SignUpCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand GuestCommand { get; }

        public MainViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            SignUpCommand = new RelayCommand(SignUp);
            GuestCommand = new RelayCommand(Guest); 

        }

        private void Login()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void SignUp()
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }

        private void Guest()
        {
           // HotelEntities hotelEntities = new HotelEntities();
           // hotelEntities.sp_insert_reservation(Convert.ToDateTime("15-01-2022"), Convert.ToDateTime("17-01-2022"), "active", 11, 5, 4, 330.5, 0);
           // hotelEntities.sp_insert_reservation(Convert.ToDateTime("15-03-2022"), Convert.ToDateTime("18-03-2022"), "achitat", 28, 5, 4, 200.5, 0);
            GuestWindow guestWindow = new GuestWindow();
            guestWindow.Show();

          
        }

    }
}
