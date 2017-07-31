using LeafGreen.Entities;
using LeafGreen.MobileApi;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace LeafGreen.Mobile.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly GardenApi _api;
        private readonly string _deviceId;
        public MainPageViewModel()
        {
            _api = new GardenApi();
            _deviceId = Application.Current.Resources["deviceId"].ToString();
        }

        public IEnumerable<Garden> Gardens { get; set; }

        public async Task<IEnumerable<Garden>> GetGardensByDeviceIdAsync()
        {
            return await _api.GetGardensByDeviceIdAsync(_deviceId);
        }
    }
}