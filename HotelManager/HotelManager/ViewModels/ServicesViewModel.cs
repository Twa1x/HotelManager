using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class ServicesViewModel
    {
        public ServicesModel servicesModel { get;private set; }
        public ICommand AddCommand { get; }
        public ServicesViewModel()
        {
            servicesModel = new ServicesModel();
            AddCommand = new RelayCommand(Add);
        }

        private void Add()
        {
            Console.WriteLine(servicesModel.Name);
            Console.WriteLine(servicesModel.Price);
        }
    }
}
