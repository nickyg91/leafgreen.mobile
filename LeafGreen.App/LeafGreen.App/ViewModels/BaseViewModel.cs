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
        public readonly string DeviceId;

        public BaseViewModel()
        {
            DeviceId = Application.Current.Properties["deviceId"].ToString();
        }
    }
}
