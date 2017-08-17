using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using LeafGreen.App.Models;
using LeafGreen.App.Services;
using Xamarin.Forms;

namespace LeafGreen.App.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Garden> _gardens;
        private readonly GardenApi _api;
        private bool _isLoading;
        private readonly string _deviceId;
        public MainPageViewModel()
        {
            _api = new GardenApi();
            _deviceId = Application.Current.Properties["deviceId"].ToString();
            LoadGardensAsync();
        }

        public bool IsLoading
        {
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
            get => _isLoading;
        }

        public ObservableCollection<Garden> Gardens
        {
            set
            {
                _gardens = value;
                IsLoading = false;
            }
            get => _gardens;
        }

        private Task LoadGardensAsync()
        {
            return Task.Run(async () =>
            {
                try
                {
                    var collection = new ObservableCollection<Garden>();
                    
                    var gardens = await _api.GetGardensByDeviceIdAsync(_deviceId);
                    foreach (var g in gardens)
                    {
                        collection.Add(g);
                    }
                    _gardens = collection;
                    OnPropertyChanged("Gardens");
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send(this, ex.Message);
                }
            });
        }
    }
}
