using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LeafGreen.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LeafGreen.App.MainPage();
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

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
