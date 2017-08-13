using System;
using Xamarin.Forms;

namespace LeafGreen.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LeafGreen.App.Pages.MainPage();
        }

        protected override void OnStart()
        {
            var deviceId = Guid.NewGuid().ToString("N");
            if (!Current.Properties.ContainsKey("deviceId"))
            {
                Current.Properties.Add("deviceId", deviceId);
            }
            // Handle when your app starts
        }

        protected override async void OnSleep()
        {
            await Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
        }

    }
}
