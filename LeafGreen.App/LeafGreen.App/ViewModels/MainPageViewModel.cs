using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using LeafGreen.App.Models;
using LeafGreen.App.Services;
using Xamarin.Forms;

namespace LeafGreen.App.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private static ObservableCollection<Garden> _gardens;
        private readonly GardenApi _api;
        private static bool _isLoading;

        public MainPageViewModel()
        {
            _api = new GardenApi();
            IsLoading = true;
            LoadGardensAsync();
        }

        public static bool IsLoading
        {
            set
            {
                _isLoading = value;
                OnGlobalPropertyChanged("IsLoading");
            }
            get => _isLoading;
        }


        public static ObservableCollection<Garden> Gardens
        {
            set
            {
                _gardens = value;
                IsLoading = false;
            }
            get => _gardens;
        }

        private void LoadGardensAsync()
        {
            Task.Run(async () =>
            {
                try
                {
                    var collection = new ObservableCollection<Garden>();
                    
                    var gardens = await _api.GetGardensByDeviceIdAsync(DeviceId);
                    foreach (var g in gardens)
                    {
                        collection.Add(g);
                    }
                    _gardens = collection;
                    IsLoading = false;
                    OnGlobalPropertyChanged("Gardens");
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send(this, ex.Message);
                }
            });
        }
    }
}
