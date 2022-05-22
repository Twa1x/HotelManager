using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class LoginViewModel
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
            bool found = false;
            HotelEntities hotelEntities = new HotelEntities();
            List<User> listUsers = hotelEntities.Users.ToList();

            foreach (User user in listUsers)
            {
                if (user.username == _Login.Username)
                {
                    found = true;
                    if (user.password != _Login.Password)
                    {
                        MessageBox.Show("Password is wrong");
                    }
                    else
                    {
                      //  MessageBox.Show("Logged in Succesfully");
                        switch (user.type)
                        {
                            case "admin":
                                {
                                    AdminWindow adminWindow = new AdminWindow();
                                    adminWindow.Show();
                                    break;
                                }
                            case "employee":
                                {   EmployeeWindow employeeWindow = new EmployeeWindow();
                                    employeeWindow.Show();
                                    break;
                                }
                            case "user":
                                {   
                                    UserWindow userWindow = new UserWindow();
                                    userWindow.Show();
                                    break;
                                }
                            default:
                                break;
                        }
                        
                    }
                    break;
                }
            }

            if (found == false)
            {
                MessageBox.Show("Username doesn't exist in our system!");
            }

        }
    }
}
