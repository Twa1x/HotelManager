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
    public class FeatureViewModel : ObservableObject
    {
        public FeatureModel featureModel { get; private set; }

        private FeatureModel currentFeature;

        private FeatureModel tempFeature;

        public FeatureModel CurrentFeature
        {
            get { return currentFeature; }
            set { OnPropertyChanged(ref currentFeature, value); }

        }

        public FeatureModel TempFeature
        {
            get { return tempFeature; }
            private set { OnPropertyChanged(ref tempFeature, value); }
        }

        public ObservableCollection<FeatureModel> Features { get; set; }

        private ObservableCollection<FeatureModel> LoadFeatures()
        {
            var tempFeatures = new ObservableCollection<FeatureModel>();
            HotelEntities hotelEntities = new HotelEntities();
            List<Feature> listFeatures = hotelEntities.Features.ToList();
            foreach (Feature _feature in listFeatures)
            {
                if (_feature.deleted == 0 || _feature.deleted == null)
                {
                    FeatureModel tempFeatureModel = new FeatureModel();
                    tempFeatureModel.Name = _feature.name;
                    tempFeatureModel.Price = Convert.ToString(_feature.price);
                    tempFeatureModel.Id = Convert.ToInt32(_feature.id_feature);
                    tempFeatures.Add(tempFeatureModel);
                }
            }

            return tempFeatures;
        }

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ICommand UpdateCommand { get; }


        public FeatureViewModel()
        {
            Features = LoadFeatures(); 
            featureModel = new FeatureModel();
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            UpdateCommand = new RelayCommand(Update);

        }

        private void Delete()
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        private void Edit()
        {
            throw new NotImplementedException();
        }

        private void Add()
        {
            HotelEntities hotelEntities = new HotelEntities();
            hotelEntities.sp_insert_feature(featureModel.Name, Convert.ToDouble(featureModel.Price), 0);
            MessageBox.Show("Feature added sucesfully!");
        }
    }
}
