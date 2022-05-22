using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManager.ViewModels
{
    public class ServicesViewModel : ObservableObject
    {
        public ServicesModel servicesModel { get; private set; }

        private ServicesModel currentService;

        public ServicesModel CurrentService
        {
            get { return currentService; }
            set { OnPropertyChanged(ref currentService, value); }
        }

        public ObservableCollection<ServicesModel> Services { get; set; }

        private ObservableCollection<ServicesModel> LoadServices()
        {
            var tempServices = new ObservableCollection<ServicesModel>();
            HotelEntities hotelEntities = new HotelEntities();
            List<Service> listServices = hotelEntities.Services.ToList();
            foreach (Service service in listServices)
            {
                ServicesModel tempServiceModel = new ServicesModel();
                tempServiceModel.Name = service.name;
                tempServiceModel.Price = Convert.ToString(service.price);
                tempServices.Add(tempServiceModel);
            }
            return tempServices;
        }
        public ICommand AddCommand { get; }
        public ServicesViewModel()
        {
            Services = LoadServices();
            servicesModel = new ServicesModel();
            AddCommand = new RelayCommand(Add);
        }




        private void Add()
        {
            HotelEntities hotelEntities = new HotelEntities();
            hotelEntities.sp_insert_service(servicesModel.Name, Convert.ToDouble(servicesModel.Price), 0);
            MessageBox.Show("Service added succesfully!!");
        }
    }
}
