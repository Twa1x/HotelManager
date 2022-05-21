using HotelManager.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class RoomViewModel
    {
        public RoomModel roomModel { get; private set; }

        public ICommand AddCommand { get; }
        public ICommand SelectImage1Command { get; }
        public ICommand SelectImage2Command { get; }
        public ICommand SelectImage3Command { get; }

        public RoomViewModel()
        {
            roomModel = new RoomModel();
            roomModel.Avilabilty = true;
            AddCommand = new RelayCommand(Add);
            SelectImage1Command = new RelayCommand(SelectImage1);
            SelectImage2Command = new RelayCommand(SelectImage2);
            SelectImage3Command = new RelayCommand(SelectImage3);


        }

        private void Add()
        {
            if (roomModel.Image1 == null || roomModel.Image2 == null || roomModel.Image3 == null)
            {
                MessageBox.Show("You need to choose atleast 1 photo!!");
            }
            else
            {
                Console.WriteLine(roomModel.Type);
                Console.WriteLine(roomModel.Price);
                Console.WriteLine(roomModel.AditionalServices);
                Console.WriteLine(roomModel.Image1);
                Console.WriteLine(roomModel.Image2);
                Console.WriteLine(roomModel.Image3);
            }
        }


        private void SelectImage3()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                roomModel.Image3 = openFileDialog.FileName;
            }
        }

        private void SelectImage2()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                roomModel.Image2 = openFileDialog.FileName;
            }
        }


        private void SelectImage1()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                roomModel.Image1 = openFileDialog.FileName;
            }
        }

    }
}
