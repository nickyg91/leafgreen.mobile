using System;
using LeafGreen.App.Pages;
using Xamarin.Forms;

namespace LeafGreen.App
{
    public partial class App : Application
    {
        public App()
        {
            var deviceId = Guid.NewGuid().ToString("N");
            if (!Current.Properties.ContainsKey("deviceId"))
            {
                Current.Properties.Add("deviceId", deviceId);
            }
            InitializeComponent();
            MainPage = new CarouselLandingPage();
        }

        protected override void OnStart()
        {
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
