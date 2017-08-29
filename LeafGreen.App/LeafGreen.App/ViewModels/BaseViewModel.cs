using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace LeafGreen.App.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static event PropertyChangedEventHandler GlobalPropertyChanged;
        public readonly string DeviceId;
        public BaseViewModel()
        {
            DeviceId = Application.Current.Properties["deviceId"].ToString();
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                   new PropertyChangedEventArgs(propertyName));
        }

        public static void OnGlobalPropertyChanged(string propertyName)
        {
            GlobalPropertyChanged?.Invoke(typeof(BaseViewModel), 
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
