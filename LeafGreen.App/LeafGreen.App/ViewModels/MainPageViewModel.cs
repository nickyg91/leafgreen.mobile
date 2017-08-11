using System.Collections.Generic;
using LeafGreen.App.Models;
using LeafGreen.App.Services;
using Xamarin.Forms;

namespace LeafGreen.App.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        public MainPageViewModel()
        {
            var deviceId = Application.Current.Properties["deviceId"].ToString();
            var api = new GardenApi();
            Gardens = new NotifyTaskCompletion<List<Garden>>(api.GetGardensByDeviceIdAsync(deviceId));
        }

        public NotifyTaskCompletion<List<Garden>> Gardens { get; set; }
    }
}
