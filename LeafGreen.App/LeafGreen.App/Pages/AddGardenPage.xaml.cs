using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeafGreen.App.Models;
using LeafGreen.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeafGreen.App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGardenPage : ContentPage
    {
        public AddGardenPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<AddGardenPage, Garden>(this, "AddedGarden", (sender, args) =>
            {
                if (args.GardenId <= 0) return;
                DisplayAlert("Success!", "Your garden was added successfully!", "Close");
                NameTextBox.Text = string.Empty;
            });
            MessagingCenter.Subscribe<AddGardenPageViewModel>(this, "ShowAddPlantModal", async (sender) =>
            {
                var modal = new AddPlantModalPage();
                await Navigation.PushModalAsync(modal);
            });
            MessagingCenter.Subscribe<AddPlantModalPageViewModel>(this, "RemoveModal", async (sender) =>
            {
                await Navigation.PopModalAsync(true);
            });
        }
    }
}