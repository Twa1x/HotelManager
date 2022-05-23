using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            bool found = false;

            HotelEntities hotelEntities = new HotelEntities();
            List<User> usersList = hotelEntities.Users.ToList();
            foreach (User user in usersList)
            {
                if (user.username == SignUpModel.Username)
                {
                    found = true;
                    break;
                }
            }
            if (SignUpModel.Username != "")
            {
                if (SignUpModel.Password != "")
                {


                    if (found == false)
                    {
                        if ((SignUpModel.IsAdmin == true && SignUpModel.IsUser == true) || (SignUpModel.IsUser == true && SignUpModel.IsEmployee == true) || (SignUpModel.IsAdmin == true && SignUpModel.IsEmployee == true) || (SignUpModel.IsAdmin == true && SignUpModel.IsEmployee == true && SignUpModel.IsUser == true))
                        {
                            MessageBox.Show("You need to choose only one type!");
                        }
                        else if (SignUpModel.IsAdmin == true)
                        {
                            hotelEntities.sp_insert_user(SignUpModel.Username, SignUpModel.Password, SignUpModel.Email, "admin");
                            MessageBox.Show("Your account has been created sucessfully!");

                        }
                        else if (SignUpModel.IsEmployee == true)
                        {
                            hotelEntities.sp_insert_user(SignUpModel.Username, SignUpModel.Password, SignUpModel.Email, "employee");
                            MessageBox.Show("Your account has been created sucessfully!");

                        }
                        else if (SignUpModel.IsUser == true)
                        {
                            long id = 0;
                            hotelEntities.sp_insert_user(SignUpModel.Username, SignUpModel.Password, SignUpModel.Email, "user");

                            List<User> users = hotelEntities.Users.ToList();

                            for (int i = users.Count-1; i > 0; i--)
                            {
                                   
                                if (users.ElementAt(i).type == "user")
                                {
                                    id = users.ElementAt(i).id_user;
                                    break;
                                }
                            }




                            hotelEntities.sp_insert_client(id);
                            MessageBox.Show("Your account has been created sucessfully!");

                        }

                        else if (SignUpModel.IsAdmin == false && SignUpModel.IsEmployee == false && SignUpModel.IsUser == false)
                        {
                            MessageBox.Show("You need to choose atleast one type!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You need to choose another username, this already exists in our system!!");
                    }
                }
                else
                {
                    MessageBox.Show("You need to enter a password!");
                }
            }
            else
            {
                MessageBox.Show("You need to enter an username!");
            }

        }

    }
}
