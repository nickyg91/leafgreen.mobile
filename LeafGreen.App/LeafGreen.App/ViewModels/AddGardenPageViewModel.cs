using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LeafGreen.App.Models;
using LeafGreen.App.Services;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace LeafGreen.App.ViewModels
{
    public class AddGardenPageViewModel : BaseViewModel
    {
        private double _latitude;
        private double _longitude;
        private readonly IGeolocator _locator;
        private readonly GardenApi _api;
        private string _gardenName;
        private int _plantId;
        private string _plantName;
        private Plant _plantToAdd;

        public AddGardenPageViewModel()
        {
            _api = new GardenApi();
            _locator = CrossGeolocator.Current;
            LoadLatLongAsync();
        }
        
        public double Latitude
        {
            set => _latitude = value;
            get => _latitude;
        }

        public double Longitude
        {
            set => _longitude = value;
            get => _longitude;
        }

        public string DisplayLat => _latitude.ToString();

        public string DisplayLong => _longitude.ToString();

        public string GardenName
        {
            get => _gardenName;
            set { _gardenName = value; OnPropertyChanged("GardenName"); }
        }

        public Plant Plant
        {
            set { _plantToAdd = value; OnPropertyChanged("GardenName"); }
            get => _plantToAdd;
        }

        public ObservableCollection<Plant> Plants { get; set; }

        private ICommand AddPlant
        {
            get
            {
                return new Command(obj => Task.Run(() =>
                {
                    Plants.Add(Plant);
                }));
            }
        }

        private void LoadLatLongAsync()
        {
            Task.Run(async () =>
            {
                if (_locator.IsGeolocationAvailable && _locator.IsGeolocationEnabled)
                {
                    try
                    {
                        var location = await _locator.GetPositionAsync(TimeSpan.FromSeconds(1));
                        _latitude = location.Latitude;
                        _longitude = location.Longitude;
                        OnPropertyChanged("DisplayLat");
                        OnPropertyChanged("DisplayLong");
                    }
                    catch (Exception ex)
                    {
                       MessagingCenter.Send(this, ex.Message); 
                    }
                }
            });
        }

        public ICommand AddGarden
        {
            get
            {
                return new Command(obj => Task.Run(async () =>
                {
                    var garden = new Garden
                    {
                        Longitude = _longitude,
                        Latitude = _latitude,
                        DateAdded = DateTime.Now,
                        DeviceId = DeviceId,
                        GardenName = _gardenName
                    };
                    try
                    {
                        var status = await _api.AddGardenAsync(garden);
                        if(status.GardenId > 0 && Plants.Count > 0)
                        {
                            var insertedPlants = Plants.Select(delegate(Plant plant, int i)
                            {
                                var insertedPlant = _api.InsertGardenPlant(plant, status.GardenId);
                                return insertedPlant;
                            });
                            if (insertedPlants.Count() < Plants.Count)
                            {
                                MessagingCenter.Send(this, "PlantsAdded", false);
                            }
                        }
                        MessagingCenter.Send(this, "AddedGarden", status);
                        return status;
                    }
                    catch (Exception ex)
                    {
                        MessagingCenter.Send(this, ex.Message);
                        return null;
                    }
                }));
            }
        }
    }
}
