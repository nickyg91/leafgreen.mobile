using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LeafGreen.App.Models;
using Xamarin.Forms;

namespace LeafGreen.App.ViewModels
{
    public class AddPlantModalPageViewModel : BaseViewModel
    {
        private string _plantName;
        private string _plantScientificName;
        public string PlantName
        {
            get => _plantName;
            set { _plantName = value; OnPropertyChanged("PlantName"); }
        }

        public string PlantScientificName
        {
            get => _plantScientificName;
            set
            {
                _plantScientificName = value;
                OnPropertyChanged("PlantScientificName");
            }
        }

        public ICommand RemoveModal
        {
            get
            {
                return new Command(obj => Task.Run(() =>
                {
                    MessagingCenter.Send(this, "RemoveModal");
                }));
            }
        }

        public ICommand AddPlant
        {
            get
            {
                return new Command(obj => Task.Run(() =>
                {
                    MessagingCenter.Send(this, "AddPlant", new Plant
                    {
                        PlantName = _plantName,
                        ScientificName = _plantScientificName
                    });
                }));
            }
        }
    }
}
