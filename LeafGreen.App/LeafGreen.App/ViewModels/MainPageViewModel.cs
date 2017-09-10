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
        private bool _isLoading;
        private bool _hasGardens;

        public MainPageViewModel()
        {
            _api = new GardenApi();
            LoadGardensAsync();
            MessagingCenter.Subscribe<AddGardenPageViewModel, Garden>(this, "AddedGarden", (sender, arg) =>
            {
                Gardens.Add(arg);
            });
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

        public bool HasGardens
        {
            set { _hasGardens = value; OnPropertyChanged("HasGardens"); }
            get => _hasGardens;
        }

        public ObservableCollection<Garden> Gardens
        {
            set
            {
                _gardens = value;
                OnPropertyChanged("Gardens");
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
                    Gardens = collection;
                    HasGardens = Gardens.Count > 0;
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send(this, ex.Message);
                }
            });
        }
    }
}
