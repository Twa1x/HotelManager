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

        private ServicesModel tempService;
        public ServicesModel TempService
        {
            get { return tempService; }
            set {  OnPropertyChanged(ref tempService, value); }
        }

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
                if (service.deleted == 0 || service.deleted == null)
                {
                    ServicesModel tempServiceModel = new ServicesModel();
                    tempServiceModel.Name = service.name;
                    tempServiceModel.Price = Convert.ToString(service.price);
                    tempServiceModel.Id = Convert.ToInt32(service.id_service);
                    tempServices.Add(tempServiceModel);
                }
            }
            return tempServices;
        }
        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ICommand UpdateCommand { get; }
        public ServicesViewModel()
        {
            Services = LoadServices();
            servicesModel = new ServicesModel();
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            UpdateCommand = new RelayCommand(Update);
        }

        private void Update()
        {
            HotelEntities hotelEntites = new HotelEntities();
           hotelEntites.sp_update_service(tempService.Id,tempService.Name,Convert.ToDouble(tempService.Price),0 );
            MessageBox.Show("Updated Succesfully!");
        }

        private void Delete()
        {
            tempService = currentService;
            HotelEntities hotelEntites = new HotelEntities();
            hotelEntites.sp_update_service(tempService.Id, tempService.Name, Convert.ToDouble(tempService.Price), 1);
            MessageBox.Show("Deleted Succesfully!");
        }

        private void Edit()
        {
            tempService = currentService;
            EditServices editServices = new EditServices();
            editServices.DataContext = this;
            editServices.Show();

        }

        private void Add()
        {
            HotelEntities hotelEntities = new HotelEntities();
            hotelEntities.sp_insert_service(servicesModel.Name, Convert.ToDouble(servicesModel.Price), 0);
            MessageBox.Show("Service added succesfully!!");
        }
    }
}
