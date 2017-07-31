using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace LeafGreen.Mobile
{
	public partial class App : Application
	{
		public App()
		{
		    if (Device.RuntimePlatform != Device.Android) return;
		    if (Current.Resources == null)
		    {
		        Current.Resources = new ResourceDictionary();
		    }
		    var resources = Current.Resources;
		    if (!resources.ContainsKey("deviceId"))
		    {
		        resources.Add("deviceId", Guid.NewGuid().ToString("N"));
		    }
            InitializeComponent();

			MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
